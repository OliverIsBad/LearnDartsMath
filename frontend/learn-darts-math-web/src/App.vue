<template>
  <div>
    <nav class="nav">
      <router-link to="/">Home</router-link>
      <router-link to="/login">Login</router-link>
      <router-link to="/register">Register</router-link>
      <router-link to="/dashboard">Dashboard</router-link>
      <router-link to="/training">Training</router-link>
    </nav>

    <router-view />
  </div>
</template>

<style>
body {
  margin: 0;
  font-family: Arial, Helvetica, sans-serif;
  background: #0f0f0f;
  color: white;
}

.nav {
  display: flex;
  gap: 20px;
  padding: 20px;
  background: #1a1a1a;
}

a {
  color: white;
  text-decoration: none;
}

a.router-link-active {
  font-weight: bold;
}
</style>