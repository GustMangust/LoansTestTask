import { createRouter, createWebHistory } from "vue-router";
import LoansList from "@/views/LoansList.vue";
import AddLoan from "@/views/AddLoan.vue";

const routes = [
  { path: "/", redirect: "/loans" },
  { path: "/loans", component: LoansList },
  { path: "/loans/add", component: AddLoan },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
