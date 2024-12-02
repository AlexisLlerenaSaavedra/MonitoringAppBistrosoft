<template>
    <div class="platform-card">
      <h3>{{ platform.platformName }}</h3>
      <p>Status: <span :class="statusClass">{{ platform.status }}</span></p>
      <p>Version: {{ platform.version }}</p>
    </div>
  </template>
  
  <script>
  export default {
    name: 'PlatformCard',
    props: {
      platform: {
        type: Object,
        required: true,
      },
    },
    computed: {
      statusClass() {
        return this.platform.status === 'OK' ? 'status-ok' : 'status-error';
      },
    },
  };
  </script>
  
  <style scoped>
  .platform-card {
    border: 1px solid #ccc;
    padding: 10px;
    margin: 10px 0;
    border-radius: 5px;
    background-color: #f9f9f9;
  }
  
  .status-ok {
    color: green;
  }
  
  .status-error {
    color: red;
  }
  </style>
  