import axios from "axios";

const BASE_URL = "http://localhost:5000/api/loans";

export const loanService = {
  async getAll(filters = {}) {
    const params = {};

    if (filters.status && filters.status !== "all")
      params.status = filters.status;
    if (filters.minAmount != null) params.minAmount = filters.minAmount;
    if (filters.maxAmount != null) params.maxAmount = filters.maxAmount;
    if (filters.minTerm != null) params.minTerm = filters.minTerm;
    if (filters.maxTerm != null) params.maxTerm = filters.maxTerm;

    const res = await axios.get(BASE_URL, { params });
    return res.data.map((loan) => ({
      ...loan,
      updating: false,
      createdAt: new Date(loan.createdAt).toISOString().split("T")[0],
    }));
  },

  async toggleStatus(number) {
    await axios.patch(`${BASE_URL}/${number}`);
  },

  async createLoan(form) {
    try {
      await axios.post(BASE_URL, form);
      return null;
    } catch (err) {
      if (err.response?.data?.message) return err.response.data.message;
      if (err.response?.data?.errors) {
        return Object.values(err.response.data.errors).flat().join(", ");
      }
      return "Server error. Please try again later.";
    }
  },
};
