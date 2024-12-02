<template>
  <div id="app">
    <h1>Platform Status</h1>
    <div v-if="loading" class="loading">Loading...</div>
    <div v-else>
      <PlatformCard v-for="platform in platforms" :key="platform.platformName" :platform="platform" />
    </div>
    <div v-if="error" class="error">{{ error }}</div>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { fetchPlatformStatuses } from './services/platformService';
import PlatformCard from './components/PlatformCard.vue';

export default {
  name: 'App',
  components: {
    PlatformCard,
  },
  setup() {
    const platforms = ref([]);
    const loading = ref(true);
    const error = ref(null);

    const loadPlatforms = async () => {
      try {
        loading.value = true;
        error.value = null;
        platforms.value = await fetchPlatformStatuses();
      } catch (err) {
        error.value = 'Failed to fetch platform statuses.';
      } finally {
        loading.value = false;
      }
    };

    onMounted(() => {
      loadPlatforms(); 
      setInterval(loadPlatforms, 10000); // Actualización cada 10 segundos
    });

    return {
      platforms,
      loading,
      error,
    };
  },
};
</script>

<style>

body {
  font-family: Arial, sans-serif;
  margin: 0;
  padding: 20px;
  background-color: #f4f4f9;
}


.loading {
  color: blue;
}

.error {
  color: red;
  font-weight: bold;
}
</style>
