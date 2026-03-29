<template>
  <section class="setup-screen">
    <div class="setup-layout">
      <div class="intro">
        <p class="overline">training setup</p>
        <h1>configure your next session</h1>
        <p class="description">
          Choose the starting score for the training leg and begin a new session.
          The current setup supports standard x01 practice with a focused scoring flow.
        </p>
      </div>

      <div class="setup-panel">
        <div class="field-group">
          <label for="start-score" class="field-label">start score</label>
          <select id="start-score" v-model.number="localStartScore" class="selection">
            <option :value="501">501</option>
            <option :value="301">301</option>
          </select>
        </div>

        <div class="info-row">
          <div class="info-item">
            <span class="info-label">mode</span>
            <span class="info-value">x01</span>
          </div>

          <div class="info-item">
            <span class="info-label">finish rule</span>
            <span class="info-value">double out</span>
          </div>
        </div>

        <button class="start-button" @click="emit('start', localStartScore)">
          Start training
        </button>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'

const props = defineProps<{
  startScore: number
}>()

const emit = defineEmits<{
  (e: 'start', value: number): void
}>()

const localStartScore = ref(props.startScore)

watch(
  () => props.startScore,
  (value) => {
    localStartScore.value = value
  }
)
</script>
<style scoped>
.setup-screen {
    width: 100%;
    padding: 2rem 2rem 3rem;
}

.setup-layout {
    width: 100%;
    max-width: 1400px;
    margin: 0 auto;
    display: grid;
    grid-template-columns: 1.1fr 0.9fr;
    gap: 2rem;
    align-items: start;
}

.intro {
    padding-top: 0.5rem;
}

.overline {
    margin: 0 0 0.75rem 0;
    font-size: 0.95rem;
    color: var(--primary-color);
    text-transform: lowercase;
    letter-spacing: 0.04em;
}

.intro h1 {
    margin: 0;
    font-size: clamp(2.4rem, 5vw, 4.4rem);
    line-height: 0.95;
    font-weight: 700;
    color: #f2f2f2;
    text-transform: lowercase;
    max-width: 760px;
}

.description {
    margin: 1.25rem 0 0 0;
    max-width: 700px;
    font-size: 1.05rem;
    line-height: 1.75;
    color: #8d8d8d;
}

.setup-panel {
    background: #1b1b1b;
    border: 1px solid #2a2a2a;
    border-radius: 22px;
    padding: 1.5rem;
    display: flex;
    flex-direction: column;
    gap: 1.5rem;
}

.field-group {
    display: flex;
    flex-direction: column;
    gap: 0.65rem;
}

.field-label {
    font-size: 0.92rem;
    color: #8a8a8a;
    text-transform: lowercase;
}

.selection {
    width: 100%;
    height: 54px;
    padding: 0 1rem;
    font-size: 1rem;
    border: 1px solid #3a3a3a;
    border-radius: 12px;
    background: #222;
    color: #f1f1f1;
    outline: none;
    cursor: pointer;
    transition:
        border-color 0.15s ease,
        background 0.15s ease,
        box-shadow 0.15s ease;
}

.selection:hover {
    background: #262626;
}

.selection:focus {
    border-color: var(--primary-color);
    box-shadow: 0 0 0 3px color-mix(in srgb, var(--primary-color) 20%, transparent);
}

.info-row {
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    gap: 1rem;
    padding-top: 0.5rem;
    border-top: 1px solid #2a2a2a;
}

.info-item {
    display: flex;
    flex-direction: column;
    gap: 0.35rem;
}

.info-label {
    font-size: 0.88rem;
    color: #727272;
    text-transform: lowercase;
}

.info-value {
    font-size: 1.15rem;
    font-weight: 600;
    color: #ededed;
    text-transform: lowercase;
}

.start-button {
    height: 52px;
    padding: 0 1.2rem;
    border: none;
    border-radius: 12px;
    background: var(--primary-color);
    color: #161616;
    font-size: 0.96rem;
    font-weight: 600;
    cursor: pointer;
    transition:
        filter 0.15s ease,
        transform 0.15s ease;
}

.start-button:hover {
    filter: brightness(1.05);
}

.start-button:active {
    transform: translateY(1px);
}

@media (max-width: 950px) {
    .setup-layout {
        grid-template-columns: 1fr;
    }
}

@media (max-width: 640px) {
    .setup-screen {
        padding: 1.25rem 1rem 2rem;
    }

    .setup-panel {
        padding: 1.25rem;
    }

    .info-row {
        grid-template-columns: 1fr;
    }
}
</style>