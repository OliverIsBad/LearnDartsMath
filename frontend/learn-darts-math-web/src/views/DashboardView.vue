<template>
  <div class="container">
    <h1>Dashboard</h1>
    <p>Start your darts math practice session.</p>

    <router-link class="button" to="/training">Start Training</router-link>
  </div>
</template>

<style scoped>
.container {
  padding: 40px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.button {
  display: inline-block;
  margin-top: 20px;
  padding: 12px 18px;
  background: var(--primary-color);
  color: white;
  border-radius: 8px;
  text-decoration: none;
}
</style>