<template>
  <p v-if="loading">Loading...</p>
  <p v-if="error">{{ error }}</p>
  <Toolbar @add="goToAddLoan" />

  <LoanFilters :filters="filters" @change="loadLoans" @reset="resetFilters" />

  <LoansTable :loans="loans" @toggle="toggleStatus" />
</template>

<script setup>
import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";
import { loanService } from "../api/loanService";

import Toolbar from "../components/Toolbar.vue";
import LoanFilters from "../components/LoanFilters.vue";
import LoansTable from "../components/LoansTable.vue";

const router = useRouter();
const loans = ref([]);
const loading = ref(true);
const error = ref(null);

const goToAddLoan = () => router.push("/loans/add");

const filters = ref({
  status: "all",
  minAmount: null,
  maxAmount: null,
  minTerm: null,
  maxTerm: null,
});

const loadLoans = async () => {
  loading.value = true;
  error.value = null;
  try {
    loans.value = await loanService.getAll(filters.value);
  } catch (err) {
    error.value = "Error loading data";
  } finally {
    loading.value = false;
  }
};

onMounted(loadLoans);

const toggleStatus = async (loan) => {
  try {
    loan.updating = true;
    await loanService.toggleStatus(loan.number);
    loan.status = loan.status === "Published" ? "Unpublished" : "Published";
  } catch (err) {
    console.error("Status update error", err);
  } finally {
    loan.updating = false;
    loadLoans();
  }
};

const resetFilters = () => {
  filters.value = {
    status: "all",
    minAmount: null,
    maxAmount: null,
    minTerm: null,
    maxTerm: null,
  };
  loadLoans();
};
</script>
