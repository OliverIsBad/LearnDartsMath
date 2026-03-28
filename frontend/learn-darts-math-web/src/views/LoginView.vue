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

const usernameOrEmail = ref('')
const password = ref('')
const error = ref('')

async function login() {
  error.value = ''

  try {
    const result = await apiFetch<AuthResponse>('/auth/login', {
      method: 'POST',
      body: JSON.stringify({
        usernameOrEmail: usernameOrEmail.value,
        password: password.value
      })
    })

    localStorage.setItem('token', result.token)
    router.push('/dashboard')
  } catch (err: unknown) {
    error.value = err instanceof Error ? err.message : 'Unknown error'
  }
}
</script>

<template>
  <section class="login-screen">
    <div class="login-layout">
      <div class="intro">
        <p class="overline">account access</p>
        <h1>sign in to continue your training</h1>
        <p class="description">
          Access your account to continue using the application, manage your
          profile, and work with future progress and training data.
        </p>

        <div class="info-list">
          <div class="info-item">
            <span class="info-label">access</span>
            <span class="info-value">existing account</span>
          </div>

          <div class="info-item">
            <span class="info-label">purpose</span>
            <span class="info-value">training and profile features</span>
          </div>

          <div class="info-item">
            <span class="info-label">next step</span>
            <span class="info-value accent">dashboard access</span>
          </div>
        </div>
      </div>

      <div class="form-panel">
        <div class="form-header">
          <p class="panel-kicker">login</p>
          <h2>welcome back</h2>
          <p class="panel-description">
            Enter your account details to sign in.
          </p>
        </div>

        <form class="form" @submit.prevent="login">
          <div class="field-group">
            <label for="usernameOrEmail" class="field-label">username or email</label>
            <input
              id="usernameOrEmail"
              v-model="usernameOrEmail"
              class="input"
              type="text"
              placeholder="Enter your username or email"
              autocomplete="username"
            />
          </div>

          <div class="field-group">
            <label for="password" class="field-label">password</label>
            <input
              id="password"
              v-model="password"
              class="input"
              type="password"
              placeholder="Enter your password"
              autocomplete="current-password"
            />
          </div>

          <p v-if="error" class="error-message">{{ error }}</p>

          <button class="primary-button" type="submit">Sign in</button>
        </form>

        <div class="footer-row">
          <span class="footer-text">No account yet?</span>
          <router-link to="/register" class="footer-link">Create one</router-link>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.login-screen {
  width: 100%;
  padding: 2rem 2rem 3rem;
}

.login-layout {
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
  .login-layout {
    grid-template-columns: 1fr;
  }
}

@media (max-width: 640px) {
  .login-screen {
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