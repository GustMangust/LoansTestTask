<template>
  <div class="filters" style="margin-bottom: 20px">
    <el-select
      v-model="filters.status"
      placeholder="Status"
      style="width: 180px; margin-right: 10px"
      @change="$emit('change')"
    >
      <el-option label="All" value="all" />
      <el-option label="Published" value="published" />
      <el-option label="Unpublished" value="unpublished" />
    </el-select>

    <el-input-number
      v-model="filters.minAmount"
      placeholder="Min amount"
      :min="0"
      style="margin-right: 5px"
      @change="$emit('change')"
    />
    <el-input-number
      v-model="filters.maxAmount"
      placeholder="Max amount"
      :min="0"
      style="margin-right: 10px"
      @change="$emit('change')"
    />
    <el-input-number
      v-model="filters.minTerm"
      placeholder="Min term"
      :min="0"
      style="margin-right: 5px"
      @change="$emit('change')"
    />
    <el-input-number
      v-model="filters.maxTerm"
      placeholder="Max term"
      :min="0"
      style="margin-right: 10px"
      @change="$emit('change')"
    />

    <el-button type="warning" @click="$emit('reset')">Reset</el-button>
  </div>
</template>

<script setup>
const props = defineProps({
  filters: Object,
});
</script>
