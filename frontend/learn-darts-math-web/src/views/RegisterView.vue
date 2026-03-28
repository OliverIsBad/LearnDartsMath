<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { apiFetch } from '@/services/api'

type AuthResponse = {
  token: string
  username: string
  email: string
  displayName: string
}

const router = useRouter()

const username = ref('')
const email = ref('')
const password = ref('')
const displayName = ref('')
const error = ref('')
const success = ref('')

async function register() {
  error.value = ''
  success.value = ''

  try {
    const result = await apiFetch<AuthResponse>('/auth/register', {
      method: 'POST',
      body: JSON.stringify({
        username: username.value,
        email: email.value,
        password: password.value,
        displayName: displayName.value
      })
    })

    localStorage.setItem('token', result.token)
    success.value = 'Registered successfully.'
    router.push('/dashboard')
  } catch (err: unknown) {
    error.value = err instanceof Error ? err.message : 'Unknown error'
  }
}
</script>

<template>
  <section class="register-screen">
    <div class="register-layout">
      <div class="intro">
        <p class="overline">account creation</p>
        <h1>create your profile for future training features</h1>
        <p class="description">
          Register a new account to access profile-based features, saved training
          progress, and future statistics across different practice modes.
        </p>

        <div class="info-list">
          <div class="info-item">
            <span class="info-label">account</span>
            <span class="info-value">new user registration</span>
          </div>

          <div class="info-item">
            <span class="info-label">purpose</span>
            <span class="info-value">training, profile, and progress features</span>
          </div>

          <div class="info-item">
            <span class="info-label">outlook</span>
            <span class="info-value accent">multiple training modes</span>
          </div>
        </div>
      </div>

      <div class="form-panel">
        <div class="form-header">
          <p class="panel-kicker">register</p>
          <h2>set up your account</h2>
          <p class="panel-description">
            Fill in the fields below to create a new account.
          </p>
        </div>

        <form class="form" @submit.prevent="register">
          <div class="field-group">
            <label for="username" class="field-label">username</label>
            <input
              id="username"
              v-model="username"
              class="input"
              type="text"
              placeholder="Enter your username"
              autocomplete="username"
            />
          </div>

          <div class="field-group">
            <label for="email" class="field-label">email</label>
            <input
              id="email"
              v-model="email"
              class="input"
              type="email"
              placeholder="Enter your email"
              autocomplete="email"
            />
          </div>

          <div class="field-group">
            <label for="displayName" class="field-label">display name</label>
            <input
              id="displayName"
              v-model="displayName"
              class="input"
              type="text"
              placeholder="Choose a display name"
              autocomplete="nickname"
            />
          </div>

          <div class="field-group">
            <label for="password" class="field-label">password</label>
            <input
              id="password"
              v-model="password"
              class="input"
              type="password"
              placeholder="Create a password"
              autocomplete="new-password"
            />
          </div>

          <p v-if="error" class="error-message">{{ error }}</p>
          <p v-if="success" class="success-message">{{ success }}</p>

          <button class="primary-button" type="submit">Create account</button>
        </form>

        <div class="footer-row">
          <span class="footer-text">Already registered?</span>
          <router-link to="/login" class="footer-link">Sign in</router-link>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.register-screen {
  width: 100%;
  padding: 2rem 2rem 3rem;
}

.register-layout {
  width: 100%;
  max-width: 1400px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1.05fr 0.95fr;
  gap: 2rem;
  align-items: start;
}

.intro {
  padding-top: 0.5rem;
}

.overline,
.panel-kicker {
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

.info-list {
  display: grid;
  grid-template-columns: 1fr;
  gap: 1rem;
  margin-top: 2rem;
  max-width: 640px;
}

.info-item {
  padding: 1rem 0;
  border-top: 1px solid #2a2a2a;
  display: flex;
  flex-direction: column;
  gap: 0.35rem;
}

.info-item:last-child {
  border-bottom: 1px solid #2a2a2a;
}

.info-label {
  font-size: 0.88rem;
  color: #747474;
  text-transform: lowercase;
}

.info-value {
  font-size: 1.15rem;
  font-weight: 600;
  color: #ededed;
  text-transform: lowercase;
}

.info-value.accent {
  color: var(--primary-color);
}

.form-panel {
  background: #1b1b1b;
  border: 1px solid #2a2a2a;
  border-radius: 22px;
  padding: 1.5rem;
}

.form-header h2 {
  margin: 0;
  font-size: 2rem;
  line-height: 1;
  font-weight: 700;
  color: #f2f2f2;
  text-transform: lowercase;
}

.panel-description {
  margin: 0.9rem 0 0 0;
  color: #8a8a8a;
  line-height: 1.7;
}

.form {
  display: flex;
  flex-direction: column;
  gap: 1.15rem;
  margin-top: 1.75rem;
}

.field-group {
  display: flex;
  flex-direction: column;
  gap: 0.6rem;
}

.field-label {
  font-size: 0.92rem;
  color: #8a8a8a;
  text-transform: lowercase;
}

.input {
  width: 100%;
  height: 54px;
  padding: 0 1rem;
  border: 1px solid #3a3a3a;
  border-radius: 12px;
  background: #222;
  color: #f1f1f1;
  font-size: 1rem;
  outline: none;
  transition:
    border-color 0.15s ease,
    background 0.15s ease,
    box-shadow 0.15s ease;
  box-sizing: border-box;
}

.input::placeholder {
  color: #777;
}

.input:hover {
  background: #262626;
}

.input:focus {
  border-color: var(--primary-color);
  box-shadow: 0 0 0 3px color-mix(in srgb, var(--primary-color) 20%, transparent);
}

.error-message {
  margin: 0;
  padding: 0.9rem 1rem;
  border-radius: 12px;
  background: rgba(255, 90, 90, 0.08);
  border: 1px solid rgba(255, 90, 90, 0.18);
  color: #ff8d8d;
  font-size: 0.95rem;
  line-height: 1.5;
}

.success-message {
  margin: 0;
  padding: 0.9rem 1rem;
  border-radius: 12px;
  background: rgba(120, 180, 120, 0.08);
  border: 1px solid rgba(120, 180, 120, 0.18);
  color: #9ad19a;
  font-size: 0.95rem;
  line-height: 1.5;
}

.primary-button {
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

.primary-button:hover {
  filter: brightness(1.05);
}

.primary-button:active {
  transform: translateY(1px);
}

.footer-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 1rem;
  margin-top: 1.5rem;
  padding-top: 1.25rem;
  border-top: 1px solid #2a2a2a;
  flex-wrap: wrap;
}

.footer-text {
  color: #8a8a8a;
}

.footer-link {
  color: var(--primary-color);
  text-decoration: none;
  font-weight: 600;
}

.footer-link:hover {
  text-decoration: underline;
}

@media (max-width: 950px) {
  .register-layout {
    grid-template-columns: 1fr;
  }
}

@media (max-width: 640px) {
  .register-screen {
    padding: 1.25rem 1rem 2rem;
  }

  .form-panel {
    padding: 1.25rem;
  }

  .footer-row {
    align-items: flex-start;
    flex-direction: column;
  }
}
</style>