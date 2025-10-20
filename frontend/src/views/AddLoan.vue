<template>
  <el-card style="max-width: 500px; margin: 30px auto">
    <h3>Add New Loan</h3>
    <el-form :model="form" :rules="rules" ref="loanForm" label-width="150px">
      <el-form-item label="Loan Number" prop="number">
        <el-input v-model="form.number" />
      </el-form-item>

      <el-form-item label="Amount" prop="amount">
        <el-input-number v-model="form.amount" :step="0.01" :precision="2" />
      </el-form-item>

      <el-form-item label="Term" prop="termValue">
        <el-input-number v-model="form.termValue" />
      </el-form-item>

      <el-form-item label="Interest Value" prop="interestValue">
        <el-input-number
          v-model="form.interestValue"
          :step="0.01"
          :precision="2"
        />
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="submitForm">Create</el-button>
      </el-form-item>
      <p v-if="errorMessage" class="text-red-500 mt-3">
        {{ errorMessage }}
      </p>
    </el-form>
  </el-card>
</template>

<script setup>
import { reactive, ref } from "vue";
import { useRouter } from "vue-router";
import { validateNumber, validatePositive } from "../utils/validators";
import { loanService } from "../api/loanService";

const router = useRouter();
const loanForm = ref(null);
const errorMessage = ref("");

const form = reactive({
  number: "",
  amount: null,
  termValue: null,
  interestValue: null,
});

const rules = {
  number: [
    {
      async validator(rule, value) {
        await validateNumber(value);
      },
      trigger: "blur",
    },
  ],
  amount: [
    {
      async validator(rule, value) {
        await validatePositive(value);
      },
      trigger: "blur",
    },
  ],
  termValue: [
    {
      async validator(rule, value) {
        await validatePositive(value);
      },
      trigger: "blur",
    },
  ],
  interestValue: [
    {
      async validator(rule, value) {
        await validatePositive(value);
      },
      trigger: "blur",
    },
  ],
};

const submitForm = () => {
  loanForm.value.validate(async (valid) => {
    if (!valid) return;
    errorMessage.value = "";

    const error = await loanService.createLoan(form);

    if (error) {
      errorMessage.value = error;
    } else {
      router.push("/loans");
    }
  });
};
</script>
