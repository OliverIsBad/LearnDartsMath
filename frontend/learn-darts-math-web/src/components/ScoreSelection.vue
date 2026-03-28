<template>
    <div class="score-selection">
        <div class="score-grid">
            <button
                v-for="score in scores"
                :key="score"
                @click="$emit('update:selectedScore', score)"
                class="score-button"
                :class="{ active: selectedScore === score }"
            >
                {{ score }}
            </button>

            <button
                @click="$emit('update:selectedScore', 25)"
                class="score-button bull"
                :class="{ active: selectedScore === 25 }"
            >
                25
            </button>
        </div>

        <div class="modifier-row">
            <button
                @click="$emit('update:selectedModifier', 'DOUBLE')"
                class="modifier-button"
                :class="{ active: selectedModifier === 'DOUBLE' }"
            >
                Double
            </button>

            <button
                @click="$emit('update:selectedModifier', 'TRIPLE')"
                class="modifier-button"
                :class="{ active: selectedModifier === 'TRIPLE' }"
            >
                Triple
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
type Modifier = 'DOUBLE' | 'TRIPLE'

defineProps<{
    selectedScore: number
    selectedModifier?: Modifier
}>()

defineEmits<{
    (e: 'update:selectedScore', value: number): void
    (e: 'update:selectedModifier', value: Modifier): void
}>()

const scores = Array.from({ length: 20 }, (_, i) => i + 1)
</script>

<style scoped>
.score-selection {
    width: 100%;
    max-width: 760px;
    display: flex;
    flex-direction: column;
    gap: 1rem;
}

.score-grid {
    display: grid;
    grid-template-columns: repeat(7, 1fr);
    gap: 0.75rem;
}

.score-button {
    height: 62px;
    border: 1px solid #2f2f2f;
    border-radius: 16px;
    background: #181818;
    color: #f3f3f3;
    font-size: 1rem;
    font-weight: 500;
    cursor: pointer;
    transition: background 0.15s ease, border-color 0.15s ease, transform 0.15s ease;
}

.score-button:hover {
    background: #202020;
    border-color: #4a4a4a;
}

.score-button:active {
    transform: scale(0.98);
}

.score-button.active {
    background: #f3f3f3;
    color: #111;
    border-color: #f3f3f3;
}

.score-button.bull {
    font-weight: 700;
}

.modifier-row {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 0.75rem;
}

.modifier-button {
    height: 56px;
    border: 1px solid #3a3a3a;
    border-radius: 16px;
    background: transparent;
    color: #d8d8d8;
    font-size: 0.95rem;
    font-weight: 600;
    letter-spacing: 0.02em;
    cursor: pointer;
    transition: background 0.15s ease, color 0.15s ease, border-color 0.15s ease, transform 0.15s ease;
}

.modifier-button:hover {
    background: #1d1d1d;
    border-color: #5a5a5a;
}

.modifier-button:active {
    transform: scale(0.98);
}

.modifier-button.active {
    background: #ff9a1f;
    border-color: #ff6f00;
    color: white;
}

@media (max-width: 700px) {
    .score-grid {
        grid-template-columns: repeat(4, 1fr);
    }
}

@media (max-width: 520px) {
    .score-grid {
        grid-template-columns: repeat(3, 1fr);
    }

    .score-button {
        height: 56px;
    }

    .modifier-button {
        height: 52px;
    }
}
</style>