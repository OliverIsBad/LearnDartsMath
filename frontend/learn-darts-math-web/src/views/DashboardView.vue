<template>
  <section class="dashboard">
    <div class="hero">
      <div class="hero-copy">
        <p class="eyebrow">dashboard</p>
        <h1>train your darts maths with focus</h1>
        <p class="description">
          Practice remaining scores, checkout situations, and double-out decisions
          in a clean training environment built for repetition and consistency.
        </p>

        <div class="hero-actions">
          <router-link class="primary-button" to="/training">Start Training</router-link>
          <router-link class="secondary-button" to="/register">Create Account</router-link>
        </div>
      </div>

      <div class="hero-panel">
        <div class="panel-stat">
          <span class="panel-label">mode</span>
          <span class="panel-value">x01 training</span>
        </div>

        <div class="panel-stat">
          <span class="panel-label">focus</span>
          <span class="panel-value accent">checkout maths</span>
        </div>

        <div class="panel-stat">
          <span class="panel-label">rule</span>
          <span class="panel-value">double out</span>
        </div>
      </div>
    </div>

    <div class="section-header">
      <p class="section-kicker">overview</p>
      <h2>what this area is for</h2>
    </div>

    <div class="feature-grid">
      <article class="feature-card">
        <span class="feature-label">remaining score</span>
        <h3>build confidence in score calculation</h3>
        <p>
          Train common scoring situations and improve the speed and accuracy of
          your remaining-score calculations during a leg.
        </p>
      </article>

      <article class="feature-card">
        <span class="feature-label">checkout logic</span>
        <h3>understand valid finishes</h3>
        <p>
          Practice realistic finish situations and reinforce the logic behind
          proper double-out checkouts.
        </p>
      </article>

      <article class="feature-card">
        <span class="feature-label">training flow</span>
        <h3>repeat situations with clear structure</h3>
        <p>
          Stay focused on one task at a time with a simple interface designed for
          repeated practice and quick iteration.
        </p>
      </article>
    </div>

    <div class="bottom-strip">
      <div class="bottom-copy">
        <p class="section-kicker">next step</p>
        <h2>start a new session</h2>
        <p>
          Open the training view and begin a new round. The current setup is built
          to keep the interaction direct and distraction-free.
        </p>
      </div>

      <router-link class="primary-button" to="/training">Go to Training</router-link>
    </div>
  </section>
</template>

<style scoped>
.dashboard {
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
  grid-template-columns: 1.3fr 0.7fr;
  gap: 1.5rem;
  align-items: stretch;
}

.hero-copy,
.hero-panel,
.feature-card,
.bottom-strip {
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
  font-size: clamp(2.4rem, 5vw, 4.6rem);
  line-height: 0.95;
  font-weight: 700;
  color: #f2f2f2;
  text-transform: lowercase;
  max-width: 760px;
}

.description {
  margin: 1.25rem 0 0 0;
  max-width: 760px;
  font-size: 1.05rem;
  line-height: 1.75;
  color: #8d8d8d;
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

.panel-stat {
  display: flex;
  flex-direction: column;
  gap: 0.35rem;
  padding-bottom: 1rem;
  border-bottom: 1px solid #2b2b2b;
}

.panel-stat:last-child {
  border-bottom: none;
  padding-bottom: 0;
}

.panel-label {
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

.section-header h2 {
  margin: 0;
  font-size: clamp(1.8rem, 3vw, 2.6rem);
  line-height: 1.05;
  font-weight: 700;
  color: #f1f1f1;
  text-transform: lowercase;
}

.feature-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
}

.feature-card {
  padding: 1.5rem;
}

.feature-label {
  display: inline-block;
  margin-bottom: 1rem;
  font-size: 0.85rem;
  color: var(--primary-color);
  text-transform: lowercase;
}

.feature-card h3 {
  margin: 0 0 0.9rem 0;
  font-size: 1.35rem;
  line-height: 1.2;
  font-weight: 600;
  color: #f0f0f0;
  text-transform: lowercase;
}

.feature-card p {
  margin: 0;
  color: #8c8c8c;
  line-height: 1.7;
  font-size: 0.97rem;
}

.bottom-strip {
  padding: 1.5rem 1.75rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 1.5rem;
}

.bottom-copy {
  max-width: 760px;
}

.bottom-copy h2 {
  margin: 0;
  font-size: clamp(1.6rem, 3vw, 2.2rem);
  line-height: 1.05;
  font-weight: 700;
  color: #f1f1f1;
  text-transform: lowercase;
}

.bottom-copy p {
  margin: 0.9rem 0 0 0;
  color: #8b8b8b;
  line-height: 1.7;
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
  .hero {
    grid-template-columns: 1fr;
  }

  .feature-grid {
    grid-template-columns: 1fr;
  }

  .bottom-strip {
    flex-direction: column;
    align-items: flex-start;
  }
}

@media (max-width: 640px) {
  .dashboard {
    padding: 1.25rem 1rem 2rem;
  }

  .hero-copy,
  .hero-panel,
  .feature-card,
  .bottom-strip {
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