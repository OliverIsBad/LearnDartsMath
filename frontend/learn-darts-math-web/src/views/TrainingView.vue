<template>
    <main class="page">

        <GameFinishedScreen
            v-if="isGameFinished"
            :thrown-darts="dartsThrown"
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
            @update:current-score="currentScore = $event"
            @update:is-game-finished="isGameFinished = $event"
            @update:darts-thrown="dartsThrown= $event"
            @reset="resetGame" 
        />

    </main>
</template>

<script setup lang="ts">
import GameFinishedScreen from '@/components/GameFinishedScreen.vue'
import GameScreen from '@/components/GameScreen.vue'
import GameSetupScreen from '@/components/GameSetupScreen.vue'
import { ref } from 'vue'

const gameStarted = ref(false)
const startScore = ref(501)
const currentScore = ref(501)
const isGameFinished = ref(false)

const dartsThrown = ref(0)

function startGame(): void {
    currentScore.value = startScore.value
    gameStarted.value = true
    isGameFinished.value = false
}

function resetGame(): void {
    gameStarted.value = false
    startScore.value = 501
    currentScore.value = 501
    isGameFinished.value = false
}
</script>

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


