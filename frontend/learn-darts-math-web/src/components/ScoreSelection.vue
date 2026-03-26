
<template>
    <div class="grid">
        <button @click="$emit('update:selectedScore', 1)" class="numberButton">1</button>
        <button @click="$emit('update:selectedScore', 2)" class="numberButton">2</button>
        <button @click="$emit('update:selectedScore', 3)" class="numberButton">3</button>
        <button @click="$emit('update:selectedScore', 4)" class="numberButton">4</button>
        <button @click="$emit('update:selectedScore', 5)" class="numberButton">5</button>
        <button @click="$emit('update:selectedScore', 6)" class="numberButton">6</button>
        <button @click="$emit('update:selectedScore', 7)" class="numberButton">7</button>
        <button @click="$emit('update:selectedScore', 8)" class="numberButton">8</button>
        <button @click="$emit('update:selectedScore', 9)" class="numberButton">9</button>
        <button @click="$emit('update:selectedScore', 10)" class="numberButton">10</button>
        <button @click="$emit('update:selectedScore', 11)" class="numberButton">11</button>
        <button @click="$emit('update:selectedScore', 12)" class="numberButton">12</button>
        <button @click="$emit('update:selectedScore', 13)" class="numberButton">13</button>
        <button @click="$emit('update:selectedScore', 14)" class="numberButton">14</button>
        <button @click="$emit('update:selectedScore', 15)" class="numberButton">15</button>
        <button @click="$emit('update:selectedScore', 16)" class="numberButton">16</button>
        <button @click="$emit('update:selectedScore', 17)" class="numberButton">17</button>
        <button @click="$emit('update:selectedScore', 18)" class="numberButton">18</button>
        <button @click="$emit('update:selectedScore', 19)" class="numberButton">19</button>
        <button @click="$emit('update:selectedScore', 20)" class="numberButton">20</button>


        <button @click="$emit('update:selectedScore', 25)" class="numberButton">25</button>

        <button @click="$emit('update:selectedModifier', 'DOUBLE')" class="modifierButton">D</button>
        <button @click="$emit('update:selectedModifier', 'TRIPLE')" class="modifierButton">T</button>
    </div>
</template>

<script setup lang="ts">

type Modifier = 'DOUBLE' | 'TRIPLE'

defineProps<{
    selectedScore : number
    selectedModifier? : Modifier
}>()

defineEmits<{
    (e: 'update:selectedScore', value: number) : void
    (e: 'update:selectedModifier', value: Modifier) : void
}>()
</script>

<style scoped>
    .modifierButton
    {
        background-color: rgb(228, 71, 71);
    }
    .grid {
        display: grid;
        grid-template-columns: repeat( 6, 1fr);
        gap: 16px;
    }
</style>