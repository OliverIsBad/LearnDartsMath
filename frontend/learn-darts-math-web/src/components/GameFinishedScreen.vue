<template>
    <section class="finished-screen">
        <div class="finished-layout">
            <div class="intro">
                <p class="overline">result</p>
                <h1>leg completed</h1>
                <p class="description">
                    The game has been finished successfully with a valid double-out.
                </p>
            </div>

            <div class="main-stat">
                <span class="main-stat-label">thrown darts</span>
                <span class="main-stat-value">{{ thrownDarts }}</span>
            </div>

            <div class="details">
                <div class="detail">
                    <span class="detail-label">status</span>
                    <span class="detail-value accent">won</span>
                </div>

                <div class="detail">
                    <span class="detail-label">finish rule</span>
                    <span class="detail-value">double out</span>
                </div>

                <div class="detail">
                    <span class="detail-label">session</span>
                    <span class="detail-value">completed</span>
                </div>
            </div>

            <div class="actions">
                <button class="secondary-button" @click="emit('details')">View details</button>
                <button class="primary-button" @click="emit('reset')">Start new game</button>
            </div>
        </div>
    </section>
</template>

<script setup lang="ts">
defineProps<{
    thrownDarts: number
}>()

const emit = defineEmits<{
    (e: 'reset'): void
    (e: 'details'): void
}>()
</script>

<style scoped>
.finished-screen {
    width: 100%;
}

.finished-layout {
    width: 100%;
    max-width: 1400px;
    margin: 0 auto;
    display: grid;
    grid-template-columns: 1.2fr 0.8fr;
    grid-template-areas:
        "intro stat"
        "details details"
        "actions actions";
    gap: 2.5rem 3rem;
}

.intro {
    grid-area: intro;
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
    font-size: clamp(2rem, 4w, 3.5rem);
    line-height: 0.95;
    font-weight: 700;
    color: #f2f2f2;
    text-transform: lowercase;
}

.description {
    margin: 1.25rem 0 0 0;
    max-width: 700px;
    font-size: 1.05rem;
    line-height: 1.7;
    color: #8d8d8d;
}

.main-stat {
    grid-area: stat;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-end;
    text-align: right;
}

.main-stat-label {
    font-size: 0.95rem;
    color: #7f7f7f;
    text-transform: lowercase;
    margin-bottom: 0.5rem;
}

.main-stat-value {
    font-size: clamp(3rem, 6vw, 4.5rem);
    line-height: 0.9;
    font-weight: 700;
    color: var(--primary-color);
}

.details {
    grid-area: details;
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    gap: 1.25rem;
    padding-top: 1.5rem;
    border-top: 1px solid #2a2a2a;
}

.detail {
    padding: 1rem 0;
}

.detail-label {
    display: block;
    margin-bottom: 0.45rem;
    font-size: 0.9rem;
    color: #747474;
    text-transform: lowercase;
}

.detail-value {
    font-size: 1.35rem;
    font-weight: 600;
    color: #efefef;
    text-transform: lowercase;
}

.detail-value.accent {
    color: var(--primary-color);
}

.actions {
    grid-area: actions;
    display: flex;
    justify-content: flex-end;
    gap: 0.9rem;
    padding-top: 1rem;
    border-top: 1px solid #2a2a2a;
}

.primary-button,
.secondary-button {
    height: 50px;
    padding: 0 1.2rem;
    border-radius: 12px;
    font-size: 0.95rem;
    font-weight: 600;
    cursor: pointer;
    transition:
        background 0.15s ease,
        border-color 0.15s ease,
        color 0.15s ease,
        transform 0.15s ease;
}

.primary-button {
    border: none;
    background: var(--primary-color);
    color: #161616;
}

.primary-button:hover {
    filter: brightness(1.05);
}

.secondary-button {
    border: 1px solid #3a3a3a;
    background: transparent;
    color: #d6d6d6;
}

.secondary-button:hover {
    background: #222;
}

.primary-button:active,
.secondary-button:active {
    transform: translateY(1px);
}

@media (max-width: 900px) {
    .finished-layout {
        grid-template-columns: 1fr;
        grid-template-areas:
            "intro"
            "stat"
            "details"
            "actions";
        gap: 2rem;
    }

    .main-stat {
        align-items: flex-start;
        text-align: left;
    }

    .details {
        grid-template-columns: 1fr;
    }

    .actions {
        justify-content: flex-start;
        flex-wrap: wrap;
    }
}

@media (max-width: 600px) {
    .finished-screen {
        padding: 2rem 1rem;
    }

    .actions {
        flex-direction: column;
    }

    .primary-button,
    .secondary-button {
        width: 100%;
    }
}
</style>