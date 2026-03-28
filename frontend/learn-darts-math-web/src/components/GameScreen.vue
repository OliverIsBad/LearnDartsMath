<template>
    <div class="game">
        <h1>{{ currentScore }}</h1>

        <ScoreSelection 
            :selected-score="selectedScore"
            :selected-modifier="selectedModifier"
            @update:selected-score="onScoreSelected"
            @update:selected-modifier="selectedModifier = $event"
        />

        <button @click="emit('reset')">Back</button>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import ScoreSelection from './ScoreSelection.vue'

type Modifier = 'DOUBLE' | 'TRIPLE'

const selectedScore = ref(0)
const selectedModifier = ref<Modifier | undefined>(undefined)

const props = defineProps<{
    currentScore: number
    isGameFinished: boolean
}>()

const emit = defineEmits<{
    (e: 'reset'): void
    (e: 'update:currentScore', value: number): void
    (e: 'update:isGameFinished', value: boolean): void
}>()

function onScoreSelected(score: number) {
    selectedScore.value = score

    let multiplier = 1

    if (selectedModifier.value === 'DOUBLE') multiplier = 2
    if (selectedModifier.value === 'TRIPLE') multiplier = 3

    const thrownScore = score * multiplier
    const remainingScore = props.currentScore - thrownScore
    const isDouble = selectedModifier.value === 'DOUBLE'

    if (remainingScore === 0 && isDouble) {
        emit('update:currentScore', 0)
        emit('update:isGameFinished', true)
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
.game {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 1rem;
    max-width: 400px;
}
</style>