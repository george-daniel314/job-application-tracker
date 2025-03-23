import axios from "axios";

const API_BASE_URL = "http://localhost:5000/api/jobapplications";

export const getJobApplications = async () => {
  try {
    const response = await axios.get(API_BASE_URL);
    return response.data;
  } catch (error) {
    throw error; // Allow error to be caught in the UI
  }
};

export const addJobApplication = async (job) => {
  try {
    const response = await axios.post(API_BASE_URL, job);
    return response.data;
  } catch (error) {
    throw error; // Ensure validation errors are thrown
  }
};

export const updateJobApplication = async (id, job) => {
  try {
    const response = await axios.put(`${API_BASE_URL}/${id}`, job);
    return response.data;
  } catch (error) {
    throw error;
  }
};
