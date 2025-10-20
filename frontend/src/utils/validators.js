export const validatePositive = async (value) => {
  if (value === null || value === undefined || value === "") {
    throw new Error("This field is required");
  }
  if (value <= 0) {
    throw new Error("Value must be greater than 0");
  }
};

export const validateNumber = async (value) => {
  if (!value || value.trim() === "") {
    throw new Error("Loan number is required");
  }
  if (!/^[A-Za-z0-9-]+$/.test(value)) {
    throw new Error(
      "Loan number can only contain letters, numbers, and hyphens"
    );
  }
};
