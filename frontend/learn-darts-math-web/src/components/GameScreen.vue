<template>
    <section class="game-screen">
        <div class="game-layout">
            <div class="top-row">
                <div class="score-block">
                    <p class="overline">current score</p>
                    <h1>{{ currentScore }}</h1>
                    <p class="description">
                        Select a segment and an optional modifier to continue the leg.
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
                        <span class="info-value accent">{{ dartsTrownCounter }}</span>
                    </div>

                    <div class="info-item">
                        <span class="info-label">selected</span>
                        <span class="info-value">
                            {{ selectedModifier ? selectedModifier + " " : "" }}{{ selectedScore || "-" }}
                        </span>
                    </div>
                </div>
            </div>

            <div class="selection-section">
                <ScoreSelection 
                    :selected-score="selectedScore"
                    :selected-modifier="selectedModifier"
                    @update:selected-score="onScoreSelected"
                    @update:selected-modifier="selectedModifier = $event"
                />
            </div>

            <div class="actions">
                <button class="secondary-button" @click="emit('reset')">Back</button>
            </div>
        </div>
    </section>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import ScoreSelection from './ScoreSelection.vue'

type Modifier = 'DOUBLE' | 'TRIPLE'

const selectedScore = ref(0)
const selectedModifier = ref<Modifier | undefined>(undefined)
const dartsTrownCounter = ref(0)

const props = defineProps<{
    currentScore: number
    isGameFinished: boolean
    dartsThrown: number
}>()

const emit = defineEmits<{
    (e: 'reset'): void
    (e: 'update:currentScore', value: number): void
    (e: 'update:isGameFinished', value: boolean): void
    (e: 'update:dartsThrown', value: number): void
}>()

function onScoreSelected(score: number) {
    selectedScore.value = score

    let multiplier = 1

    if (selectedModifier.value === 'DOUBLE') multiplier = 2
    if (selectedModifier.value === 'TRIPLE') multiplier = 3

    const thrownScore = score * multiplier
    const remainingScore = props.currentScore - thrownScore
    const isDouble = selectedModifier.value === 'DOUBLE'

    dartsTrownCounter.value++

    if (remainingScore === 0 && isDouble) {
        emit('update:currentScore', 0)
        emit('update:isGameFinished', true)
        emit('update:dartsThrown', dartsTrownCounter.value)
        resetSelection()
        return
    }

    if (isBusted(remainingScore, isDouble)) {
        resetSelection()
        return
    }

    emit('update:currentScore', remainingScore)
    resetSelection()
}

function isBusted(remainingScore: number, isDouble: boolean): boolean {
    if (remainingScore < 0) {
        return true
    }

    if (remainingScore === 1) {
        return true
    }

    if (remainingScore === 0 && !isDouble) {
        return true
    }

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
.selection-section {
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

.actions {
    display: flex;
    justify-content: flex-end;
}

.secondary-button {
    height: 50px;
    padding: 0 1.2rem;
    border-radius: 12px;
    font-size: 0.95rem;
    font-weight: 600;
    cursor: pointer;
    border: 1px solid #3a3a3a;
    background: transparent;
    color: #d6d6d6;
    transition:
        background 0.15s ease,
        border-color 0.15s ease,
        color 0.15s ease,
        transform 0.15s ease;
}

.secondary-button:hover {
    background: #222;
}

.secondary-button:active {
    transform: translateY(1px);
}

@media (max-width: 950px) {
    .top-row {
        grid-template-columns: 1fr;
    }

    .side-panel {
        grid-template-columns: 1fr 1fr;
    }
}

@media (max-width: 640px) {
    .game-screen {
        padding: 1rem 1rem 2rem;
    }

    .score-block,
    .side-panel,
    .selection-section {
        padding: 1.25rem;
    }

    .side-panel {
        grid-template-columns: 1fr;
    }

    .actions {
        justify-content: stretch;
    }

    .secondary-button {
        width: 100%;
    }
}
</style>