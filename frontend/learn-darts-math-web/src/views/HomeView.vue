<template>
  <section class="home">
    <div class="hero">
      <div class="hero-copy">
        <p class="eyebrow">learn darts math</p>
        <h1>train the mathematical side of darts</h1>
        <p class="description">
          Improve your score calculation, checkout decisions, and confidence in
          typical x01 situations. The application is built as a focused training
          environment for practicing the mental side of the game.
        </p>

        <div class="hero-actions">
          <router-link class="primary-button" to="/training">Start Training</router-link>
          <router-link class="secondary-button" to="/dashboard">Open Dashboard</router-link>
        </div>
      </div>

      <div class="hero-panel">
        <div class="panel-item">
          <span class="panel-label">current focus</span>
          <span class="panel-value">x01 training</span>
        </div>

        <div class="panel-item">
          <span class="panel-label">goal</span>
          <span class="panel-value accent">math under pressure</span>
        </div>

        <div class="panel-item">
          <span class="panel-label">future modes</span>
          <span class="panel-value">finish and calculation drills</span>
        </div>
      </div>
    </div>

    <div class="section-header">
      <p class="section-kicker">training areas</p>
      <h2>built to grow beyond one mode</h2>
      <p class="section-description">
        The project starts with a training flow for score handling and game logic,
        but the structure is intended to support additional modes over time.
      </p>
    </div>

    <div class="mode-grid">
      <article class="mode-card active">
        <span class="mode-state">available</span>
        <h3>x01 training</h3>
        <p>
          Practice remaining scores, throw input, modifiers, and valid finishes
          with double-out rules.
        </p>
      </article>

      <article class="mode-card">
        <span class="mode-state muted">planned</span>
        <h3>finish practice</h3>
        <p>
          Train common checkout situations and learn to recognize practical finish
          paths more quickly.
        </p>
      </article>

      <article class="mode-card">
        <span class="mode-state muted">planned</span>
        <h3>calculation drills</h3>
        <p>
          Solve score scenarios directly and improve speed and accuracy in mental
          arithmetic during a leg.
        </p>
      </article>
    </div>

    <div class="info-strip">
      <div class="info-copy">
        <p class="section-kicker">project direction</p>
        <h2>a training platform, not just a score counter</h2>
        <p>
          The long-term goal is to create a structured darts training application
          with multiple modes, user accounts, and progress tracking. The current
          version focuses on establishing the core interaction and game logic.
        </p>
      </div>
    </div>

    <div class="feature-grid">
      <article class="feature-card">
        <span class="feature-label">focus</span>
        <h3>clear interaction</h3>
        <p>
          The interface is designed to keep attention on the actual exercise
          instead of distracting the user with unnecessary complexity.
        </p>
      </article>

      <article class="feature-card">
        <span class="feature-label">logic</span>
        <h3>rule-based validation</h3>
        <p>
          Training situations follow actual darts logic, including modifiers,
          bust handling, and legal double-out finishes.
        </p>
      </article>

      <article class="feature-card">
        <span class="feature-label">outlook</span>
        <h3>extensible structure</h3>
        <p>
          The project is intended to expand with more training scenarios,
          statistics, profiles, and personalized progress features.
        </p>
      </article>
    </div>
  </section>
</template>

<style scoped>
.home {
  width: 100%;
  max-width: 1400px;
  margin: 0 auto;
  padding: 2rem 2rem 3rem;
  display: flex;
  flex-direction: column;
  gap: 2.5rem;
}

.hero {
  display: grid;
  grid-template-columns: 1.2fr 0.8fr;
  gap: 1.5rem;
}

.hero-copy,
.hero-panel,
.mode-card,
.info-strip,
.feature-card {
  background: #1b1b1b;
  border: 1px solid #2a2a2a;
  border-radius: 22px;
}

.hero-copy {
  padding: 2rem;
}

.eyebrow,
.section-kicker {
  margin: 0 0 0.75rem 0;
  font-size: 0.9rem;
  color: var(--primary-color);
  text-transform: lowercase;
  letter-spacing: 0.04em;
}

.hero-copy h1 {
  margin: 0;
  font-size: clamp(2.6rem, 5vw, 4.8rem);
  line-height: 0.95;
  font-weight: 700;
  color: #f2f2f2;
  text-transform: lowercase;
  max-width: 780px;
}

.description,
.section-description,
.info-copy p,
.mode-card p,
.feature-card p {
  color: #8d8d8d;
  line-height: 1.75;
  font-size: 1rem;
}

.description {
  margin: 1.25rem 0 0 0;
  max-width: 760px;
}

.hero-actions {
  display: flex;
  gap: 0.9rem;
  flex-wrap: wrap;
  margin-top: 2rem;
}

.hero-panel {
  padding: 1.5rem;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  gap: 1rem;
}

.panel-item {
  display: flex;
  flex-direction: column;
  gap: 0.35rem;
  padding-bottom: 1rem;
  border-bottom: 1px solid #2b2b2b;
}

.panel-item:last-child {
  padding-bottom: 0;
  border-bottom: none;
}

.panel-label,
.feature-label {
  font-size: 0.88rem;
  color: #767676;
  text-transform: lowercase;
}

.panel-value {
  font-size: 1.2rem;
  font-weight: 600;
  color: #ededed;
  text-transform: lowercase;
}

.panel-value.accent {
  color: var(--primary-color);
}

.section-header h2,
.info-copy h2 {
  margin: 0;
  font-size: clamp(1.8rem, 3vw, 2.6rem);
  line-height: 1.05;
  font-weight: 700;
  color: #f1f1f1;
  text-transform: lowercase;
}

.section-description {
  margin: 0.9rem 0 0 0;
  max-width: 820px;
}

.mode-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
}

.mode-card {
  padding: 1.5rem;
}

.mode-state {
  display: inline-flex;
  margin-bottom: 1rem;
  padding: 0.35rem 0.65rem;
  border-radius: 999px;
  background: color-mix(in srgb, var(--primary-color) 16%, transparent);
  color: var(--primary-color);
  font-size: 0.82rem;
  font-weight: 600;
  text-transform: lowercase;
}

.mode-state.muted {
  background: #252525;
  color: #9a9a9a;
}

.mode-card h3,
.feature-card h3 {
  margin: 0 0 0.9rem 0;
  font-size: 1.35rem;
  line-height: 1.15;
  font-weight: 600;
  color: #f0f0f0;
  text-transform: lowercase;
}

.mode-card.active {
  border-color: color-mix(in srgb, var(--primary-color) 30%, #2a2a2a);
}

.info-strip {
  padding: 1.75rem;
}

.info-copy p {
  margin: 0.9rem 0 0 0;
  max-width: 900px;
}

.feature-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
}

.feature-card {
  padding: 1.5rem;
}

.primary-button,
.secondary-button {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  height: 50px;
  padding: 0 1.2rem;
  border-radius: 12px;
  font-size: 0.95rem;
  font-weight: 600;
  text-decoration: none;
  transition:
    background 0.15s ease,
    border-color 0.15s ease,
    color 0.15s ease,
    transform 0.15s ease;
}

.primary-button {
  background: var(--primary-color);
  color: #161616;
  border: none;
}

.primary-button:hover {
  filter: brightness(1.05);
}

.secondary-button {
  background: transparent;
  color: #d6d6d6;
  border: 1px solid #3a3a3a;
}

.secondary-button:hover {
  background: #222;
}

.primary-button:active,
.secondary-button:active {
  transform: translateY(1px);
}

@media (max-width: 1000px) {
  .hero,
  .mode-grid,
  .feature-grid {
    grid-template-columns: 1fr;
  }
}

@media (max-width: 640px) {
  .home {
    padding: 1.25rem 1rem 2rem;
  }

  .hero-copy,
  .hero-panel,
  .mode-card,
  .info-strip,
  .feature-card {
    padding: 1.25rem;
  }

  .hero-actions {
    flex-direction: column;
    align-items: stretch;
  }

  .primary-button,
  .secondary-button {
    width: 100%;
  }
}
</style>