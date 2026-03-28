<template>
  <div class="layout">
    <nav class="nav">
      <div class="nav-left">
        <router-link to="/">Home</router-link>
        <router-link to="/dashboard">Dashboard</router-link>
        <router-link to="/training">Training</router-link>
      </div>

      <div class="nav-right">
        <div class="profile-menu-wrapper">
          <button class="profile-button" @click="toggleMenu">
            <div class="avatar">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                class="profile-icon"
                fill="currentColor"
              >
                <path d="M12 12a5 5 0 1 0-5-5 5 5 0 0 0 5 5Zm0 2c-4.42 0-8 2.24-8 5v1h16v-1c0-2.76-3.58-5-8-5Z" />
              </svg>
            </div>
          </button>

          <div v-if="menuOpen" class="dropdown">
            <router-link to="/login" class="dropdown-item" @click="closeMenu">
              Login
            </router-link>

            <router-link to="/register" class="dropdown-item" @click="closeMenu">
              Register
            </router-link>

            <router-link to="/profile" class="dropdown-item" @click="closeMenu">
              Profile
            </router-link>
          </div>
        </div>
      </div>
    </nav>

    <main class="content">
      <router-view />
    </main>

    <footer class="footer">
      <p>© 2026 Learn Darts Math</p>

      <a
        href="https://github.com/omann-dev/LearnDartsMath"
        target="_blank"
        rel="noopener noreferrer"
        class="github-link"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 24 24"
          class="github-icon"
          fill="currentColor"
        >
          <path
            d="M12 .5C5.65.5.5 5.65.5 12a11.5 11.5 0 008 10.95c.58.1.79-.25.79-.56v-2.02c-3.25.71-3.94-1.39-3.94-1.39-.53-1.35-1.3-1.7-1.3-1.7-1.06-.73.08-.72.08-.72 1.17.08 1.79 1.21 1.79 1.21 1.04 1.78 2.73 1.27 3.39.97.1-.76.41-1.27.74-1.56-2.6-.3-5.34-1.3-5.34-5.78 0-1.28.46-2.33 1.2-3.15-.12-.3-.52-1.5.11-3.12 0 0 .98-.31 3.2 1.2a11.1 11.1 0 015.82 0c2.22-1.51 3.2-1.2 3.2-1.2.63 1.62.23 2.82.11 3.12.75.82 1.2 1.87 1.2 3.15 0 4.49-2.75 5.47-5.37 5.76.42.37.79 1.1.79 2.22v3.29c0 .31.21.67.8.56A11.5 11.5 0 0023.5 12C23.5 5.65 18.35.5 12 .5z"
          />
        </svg>
        GitHub
      </a>
    </footer>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const menuOpen = ref(false)

function toggleMenu(): void {
  menuOpen.value = !menuOpen.value
}

function closeMenu(): void {
  menuOpen.value = false
}
</script>

<style>
body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
  background: #0f0f0f;
  color: white;
}

.layout {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.content {
  flex: 1;
}

.nav {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 20px;
  background: #1a1a1a;
}

.nav-left {
  display: flex;
  gap: 20px;
}

.nav-right {
  display: flex;
  align-items: center;
}

.profile-menu-wrapper {
  position: relative;
}

.profile-button {
  background: transparent;
  border: none;
  cursor: pointer;
  padding: 0;
}

.profile-icon {
  width: 22px;
  height: 22px;
  color: white;
}

.avatar {
  width: 42px;
  height: 42px;
  border-radius: 50%;
  background: var(--primary-color);
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: bold;
  user-select: none;
}

.dropdown {
  position: absolute;
  top: 52px;
  right: 0;
  min-width: 160px;
  background: #262626;
  border: 1px solid #333;
  border-radius: 12px;
  padding: 8px 0;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.35);
  z-index: 100;
}

.dropdown-item {
  display: block;
  padding: 10px 16px;
  color: white;
  text-decoration: none;
}

.dropdown-item:hover {
  background: #333;
}

.footer {
  background: #1a1a1a;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 16px 20px;
}

a {
  color: white;
  text-decoration: none;
}

a.router-link-active {
  font-weight: bold;
}

.github-link {
  display: flex;
  align-items: center;
  gap: 8px;
}

.github-icon {
  width: 22px;
  height: 22px;
}
</style>