<script setup lang="ts">
import { ref } from 'vue'
import GameFinishedScreen from '@/components/GameFinishedScreen.vue'
import GameScreen from '@/components/GameScreen.vue'
import GameSetupScreen from '@/components/GameSetupScreen.vue'
import { saveTrainingSession } from '@/services/trainingSessionApi'
import type { LocalTurnEntry } from '@/types/trainingSession'

const gameStarted = ref(false)
const startScore = ref(501)
const currentScore = ref(501)
const isGameFinished = ref(false)
const dartsThrown = ref(0)

const startedAt = ref<string | null>(null)
const finishedAt = ref<string | null>(null)
const turnHistory = ref<LocalTurnEntry[]>([])

const error = ref('')
const success = ref('')
const savePending = ref(false)
const savedSessionId = ref<number | null>(null)

function startGame(selectedStartScore: number) {
  startScore.value = selectedStartScore
  currentScore.value = selectedStartScore
  gameStarted.value = true
  isGameFinished.value = false
  dartsThrown.value = 0
  startedAt.value = new Date().toISOString()
  finishedAt.value = null
  turnHistory.value = []
  error.value = ''
  success.value = ''
  savedSessionId.value = null
}

async function handleTurnFinished(payload: {
  newCurrentScore: number
  isGameFinished: boolean
  dartsThrown: number
  turnEntry: LocalTurnEntry
}) {
  currentScore.value = payload.newCurrentScore
  isGameFinished.value = payload.isGameFinished
  dartsThrown.value = payload.dartsThrown
  turnHistory.value.push(payload.turnEntry)

  if (payload.isGameFinished) {
    finishedAt.value = new Date().toISOString()

    try {
      savePending.value = true
      const result = await saveTrainingSession({
        mode: 'x01',
        startScore: startScore.value,
        finalScore: currentScore.value,
        isFinished: isGameFinished.value,
        startedAt: startedAt.value!,
        finishedAt: finishedAt.value,
        turns: turnHistory.value
      })

      savedSessionId.value = result.sessionId
      success.value = 'Training session saved successfully.'
    } catch (err: unknown) {
      error.value = err instanceof Error ? err.message : 'Could not save training session.'
    } finally {
      savePending.value = false
    }
  }
}

function resetGame() {
  gameStarted.value = false
  startScore.value = 501
  currentScore.value = 501
  isGameFinished.value = false
  dartsThrown.value = 0
  startedAt.value = null
  finishedAt.value = null
  turnHistory.value = []
  savedSessionId.value = null
  savePending.value = false
  error.value = ''
  success.value = ''
}
</script>

<template>
  <main class="page">
    <p v-if="error">{{ error }}</p>
    <p v-if="success">{{ success }}</p>

    <GameFinishedScreen
      v-if="isGameFinished"
      :thrown-darts="dartsThrown"
      :saved-session-id="savedSessionId"
      :save-pending="savePending"
      @reset="resetGame"
    />

    <GameSetupScreen
      v-else-if="!gameStarted"
      :start-score="startScore"
      @start="startGame"
    />

    <GameScreen
      v-else
      :current-score="currentScore"
      :is-game-finished="isGameFinished"
      :darts-thrown="dartsThrown"
      @turn-finished="handleTurnFinished"
      @reset="resetGame"
    />
  </main>
</template>

<style scoped>

.page {
    padding: 2rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin-top: 15vh;
    margin-left: 30vw;
    margin-right: 30vw;
}

.setup{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 1rem;
    max-width: 400px;
}

button {
  padding: 0.75rem 1rem;
  font-size: 1rem;
  background-color: #42b883;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  opacity: 0.5;
}

</style>


