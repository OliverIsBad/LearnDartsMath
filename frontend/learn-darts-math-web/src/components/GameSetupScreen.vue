<template>
    <div class="setup">
        <h1>Settings</h1>
        <label>
            Startscore:
            <input v-model.number="localStartScore" type="number"/>
        </label>

        <button @click="$emit('start', localStartScore)">Start</button>
    </div>


</template>

<script setup lang="ts">

import { ref } from 'vue'

defineProps<{
    startScore: number
}>()

defineEmits<{
    (e: 'start', value: number) : void 
}>()

const localStartScore = ref(501)
</script>

<style scoped>

</style>