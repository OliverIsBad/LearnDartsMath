<template>
  <div class="layout">
    <nav class="nav">
      <router-link to="/">Home</router-link>
      <router-link to="/login">Login</router-link>
      <router-link to="/register">Register</router-link>
      <router-link to="/dashboard">Dashboard</router-link>
      <router-link to="/training">Training</router-link>
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
  gap: 20px;
  padding: 20px;
  background: #1a1a1a;
}

.footer {
  background: #1a1a1a;
  display: flex;
  justify-content: space-between;
  align-items: center;
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