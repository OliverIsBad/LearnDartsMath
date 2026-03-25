<template>
    <main class="page">
        <div v-if="gameStarted === false" class="setup">
            <h1> Settings </h1>

            <label> 
                Startscore:
                <input v-model.number="startScore" type="number" />
            </label>

            <button @click="startGame">Start Game</button>
        </div>

        <div v-else class="game">
            <h1>Game is running</h1>
            <p>Startscore: {{ currentScore }}</p>

            <button @click="resetGame">Back</button>
        </div>
    </main>
</template>

<script setup lang = "ts">

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
}

.setup,
.game {
    display: flex;
    flex-direction: column;
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


