<template>
  <section class="game-screen">
    <div class="game-layout">
      <div class="top-row">
        <div class="score-block">
          <p class="overline">current score</p>
          <h1>{{ currentScore }}</h1>
          <p class="description">
            Select the scored segment and confirm the turn. The leg is handled locally and saved after completion.
          </p>
        </div>

        <div class="side-panel">
          <div class="info-item">
            <span class="info-label">mode</span>
            <span class="info-value">x01</span>
          </div>

          <div class="info-item">
            <span class="info-label">finish rule</span>
            <span class="info-value">double out</span>
          </div>

          <div class="info-item">
            <span class="info-label">darts thrown</span>
            <span class="info-value accent">{{ dartsThrownCounter }}</span>
          </div>

          <div class="info-item">
            <span class="info-label">selected</span>
            <span class="info-value">
              {{ selectedModifier ? selectedModifier + ' ' : '' }}{{ selectedScore || '-' }}
            </span>
          </div>
        </div>
      </div>

      <div class="selection-section">
        <ScoreSelection
          :selected-score="selectedScore"
          :selected-modifier="selectedModifier"
          @update:selected-score="selectedScore = $event"
          @update:selected-modifier="selectedModifier = $event"
        />
      </div>

      <div v-if="feedback" class="feedback" :class="{ invalid: lastTurnWasInvalid }">
        {{ feedback }}
      </div>

      <div class="actions">
        <button class="secondary-button" @click="emit('reset')">Back</button>
        <button class="primary-button" :disabled="selectedScore === 0" @click="submitTurn">
          Confirm turn
        </button>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import ScoreSelection from './ScoreSelection.vue'
import type { LocalTurnEntry } from '@/types/trainingSession'

type Modifier = 'DOUBLE' | 'TRIPLE'

const props = defineProps<{
  currentScore: number
  isGameFinished: boolean
  dartsThrown: number
}>()

const emit = defineEmits<{
  (e: 'reset'): void
  (e: 'turn-finished', payload: {
    newCurrentScore: number
    isGameFinished: boolean
    dartsThrown: number
    turnEntry: LocalTurnEntry
  }): void
}>()

const selectedScore = ref(0)
const selectedModifier = ref<Modifier | undefined>(undefined)
const dartsThrownCounter = ref(props.dartsThrown)
const feedback = ref('')
const lastTurnWasInvalid = ref(false)

watch(
  () => props.dartsThrown,
  (value) => {
    dartsThrownCounter.value = value
  }
)

function submitTurn() {
  if (selectedScore.value === 0) return

  const previousScore = props.currentScore
  const multiplier = getMultiplier()
  const enteredScoredPoints = selectedScore.value * multiplier
  const correctRemainingScore = previousScore - enteredScoredPoints
  const isDouble = selectedModifier.value === 'DOUBLE'
  const isScoreValid = isValidThrow(selectedScore.value, selectedModifier.value)
  const isBust = isBusted(correctRemainingScore, isDouble)
  const isCorrect = isScoreValid && !isBust
  const newCurrentScore = isCorrect ? correctRemainingScore : previousScore
  const finished = isCorrect && newCurrentScore === 0

  dartsThrownCounter.value++

  const turnEntry: LocalTurnEntry = {
    previousScore,
    enteredScoredPoints,
    enteredRemainingScore: newCurrentScore,
    correctRemainingScore,
    isScoreValid,
    isRemainingCorrect: true,
    isCorrect,
    createdAt: new Date().toISOString()
  }

  if (!isScoreValid) {
    feedback.value = 'That throw combination is not valid.'
    lastTurnWasInvalid.value = true
  } else if (isBust) {
    feedback.value = 'Bust. The score stays the same.'
    lastTurnWasInvalid.value = true
  } else if (finished) {
    feedback.value = 'Leg completed with a valid double-out.'
    lastTurnWasInvalid.value = false
  } else {
    feedback.value = `New score: ${newCurrentScore}`
    lastTurnWasInvalid.value = false
  }

  emit('turn-finished', {
    newCurrentScore,
    isGameFinished: finished,
    dartsThrown: dartsThrownCounter.value,
    turnEntry
  })

  resetSelection()
}

function getMultiplier() {
  if (selectedModifier.value === 'DOUBLE') return 2
  if (selectedModifier.value === 'TRIPLE') return 3
  return 1
}

function isValidThrow(score: number, modifier?: Modifier) {
  if (score < 1 || score > 20) {
    return score === 25 && modifier !== 'TRIPLE'
  }

  if (score === 25 && modifier === 'TRIPLE') {
    return false
  }

  return true
}

function isBusted(remainingScore: number, isDouble: boolean): boolean {
  if (remainingScore < 0) return true
  if (remainingScore === 1) return true
  if (remainingScore === 0 && !isDouble) return true
  return false
}

function resetSelection() {
  selectedScore.value = 0
  selectedModifier.value = undefined
}
</script>

<style scoped>
.game-screen {
  width: 100%;
  padding: 1.5rem 2rem 3rem;
}

.game-layout {
  width: 100%;
  max-width: 1400px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  gap: 2rem;
}

.top-row {
  display: grid;
  grid-template-columns: 1.15fr 0.85fr;
  gap: 1.5rem;
  align-items: stretch;
}

.score-block,
.side-panel,
.selection-section,
.feedback {
  background: #1b1b1b;
  border: 1px solid #2a2a2a;
  border-radius: 22px;
}

.score-block {
  padding: 2rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.overline {
  margin: 0 0 0.75rem 0;
  font-size: 0.95rem;
  color: var(--primary-color);
  text-transform: lowercase;
  letter-spacing: 0.04em;
}

.score-block h1 {
  margin: 0;
  font-size: clamp(3rem, 8vw, 6rem);
  line-height: 0.9;
  font-weight: 700;
  color: #f2f2f2;
}

.description {
  margin: 1rem 0 0 0;
  max-width: 640px;
  font-size: 1rem;
  line-height: 1.7;
  color: #8b8b8b;
}

.side-panel {
  padding: 1.5rem;
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1rem;
}

.info-item {
  display: flex;
  flex-direction: column;
  gap: 0.35rem;
  padding: 0.2rem 0;
}

.info-label {
  font-size: 0.88rem;
  color: #747474;
  text-transform: lowercase;
}

.info-value {
  font-size: 1.15rem;
  font-weight: 600;
  color: #ededed;
  text-transform: lowercase;
}

.info-value.accent {
  color: var(--primary-color);
}

.selection-section {
  padding: 1.5rem;
}

.feedback {
  padding: 1rem 1.25rem;
  color: #dcdcdc;
}

.feedback.invalid {
  color: #ffb8b8;
  border-color: rgba(220, 70, 70, 0.4);
}

.actions {
  display: flex;
  justify-content: flex-end;
  gap: 0.9rem;
}

.primary-button,
.secondary-button {
  height: 50px;
  padding: 0 1.2rem;
  border-radius: 12px;
  font-size: 0.95rem;
  font-weight: 600;
  cursor: pointer;
  transition:
    background 0.15s ease,
    border-color 0.15s ease,
    color 0.15s ease,
    transform 0.15s ease;
}

.primary-button {
  border: none;
  background: var(--primary-color);
  color: #161616;
}

.primary-button:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.secondary-button {
  border: 1px solid #3a3a3a;
  background: transparent;
  color: #d6d6d6;
}

.secondary-button:hover {
  background: #222;
}

.primary-button:active,
.secondary-button:active {
  transform: translateY(1px);
}

@media (max-width: 950px) {
  .top-row {
    grid-template-columns: 1fr;
  }
}
</style>