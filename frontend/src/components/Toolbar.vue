<template>
  <div class="toolbar">
    <el-button type="success" @click="$emit('add')">Add loan request</el-button>
  </div>
</template>

<script setup></script>

<style scoped>
.toolbar {
  display: flex;
  justify-content: flex-start;
  margin-bottom: 16px;
}
</style>
