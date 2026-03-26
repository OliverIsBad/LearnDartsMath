<template>
    <main class="page">
        <game-setup-screen 
            v-if="gameStarted === false" 
            :start-score="startScore"
            @start="startGame"/>

        <game-screen
            v-else="gameStarted === true"
            :current-score="currentScore"
            @reset="resetGame" 
        />

    </main>
</template>

<script setup lang = "ts">

import GameScreen from '@/components/GameScreen.vue'
import GameSetupScreen from '@/components/GameSetupScreen.vue'

import { ref } from 'vue'

const gameStarted = ref<boolean>(false)
const startScore = ref<number>(501)
const currentScore = ref<number>(501)

function startGame() : void {
    currentScore.value = startScore.value
    gameStarted.value = true
}

function resetGame(): void {
  gameStarted.value = false
  startScore.value = 501
  currentScore.value = 501
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
    border: 1px solid white;
    border-radius: 32px;
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
  border-radius: 8px;
  cursor: pointer;
}

button:hover {
  opacity: 0.9;
}

</style>


