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
    success.value = 'Registered successfully!'
    router.push('/dashboard')
  } catch (err: unknown) {
    error.value = err instanceof Error ? err.message : 'Unknown error'
  }
}
</script>

<template>
  <div class="container">
    <h2>Register</h2>

    <input v-model="username" placeholder="Username" />
    <input v-model="email" placeholder="Email" />
    <input v-model="displayName" placeholder="Display Name" />
    <input v-model="password" type="password" placeholder="Password" />

    <button @click="register">Register</button>

    <p v-if="error" class="error">{{ error }}</p>
    <p v-if="success" class="success">{{ success }}</p>
  </div>
</template>

<style scoped>
.container {
  padding: 40px;
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.error {
  color: red;
}

.success {
  color: green;
}
</style>