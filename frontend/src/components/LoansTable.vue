<template>
  <el-table :data="loans" style="width: 100%">
    <el-table-column prop="number" label="Number" :min-width="100" />
    <el-table-column prop="amount" label="Amount" :min-width="80" />
    <el-table-column prop="termValue" label="Term Value" :min-width="90" />
    <el-table-column
      prop="interestValue"
      label="Interest Value"
      :min-width="90"
    />
    <el-table-column prop="status" label="Status" :min-width="80" />
    <el-table-column prop="createdAt" label="Created At" :min-width="80" />
    <el-table-column label="Actions" :min-width="110">
      <template #default="scope">
        <el-button
          type="primary"
          size="small"
          :loading="scope.row.updating"
          @click="$emit('toggle', scope.row)"
          class="status-button"
        >
          {{ scope.row.status === "Published" ? "Unpublish" : "Publish" }}
        </el-button>
      </template>
    </el-table-column>
  </el-table>
</template>

<script setup>
const props = defineProps({
  loans: Array,
});
</script>

<style scoped>
.status-button {
  min-width: 80px;
  text-align: center;
}
</style>
