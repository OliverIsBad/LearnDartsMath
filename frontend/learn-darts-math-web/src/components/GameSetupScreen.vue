<template>
    <div class="setup">
        <h1>Settings</h1>
        <label>
            Startscore:
            <select v-model.number="localStartScore" class="selection">
                <option :value="501">501</option>
                <option :value="301">301</option>
            </select>

        </label>

        <button @click="$emit('start', localStartScore)">Start</button>
    </div>


</template>

<script setup lang="ts">

import { ref } from 'vue'


const localStartScore = ref(501)

defineProps<{
    startScore: number
}>()

defineEmits<{
    (e: 'start', value: number) : void 
}>()

</script>

<style scoped>

.setup {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 1rem;
    max-width: 400px;
}

.selection {
    padding: 0.75rem 1rem;
    font-size: 1rem;
    border: 1px solid #444;
    border-radius: 4px;
    background-color: #1e1e1e;
    color: white;
    outline: none;
    cursor: pointer;
    transition: border-color 0.2s ease, box-shadow 0.2s ease;
}

</style>