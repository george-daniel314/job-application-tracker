import axios from "axios";

const API_BASE_URL = "http://localhost:5000/api/jobapplications";

export const getJobApplications = async () => {
  const response = await axios.get(API_BASE_URL);
  return response.data;
};

export const addJobApplication = async (job) => {
  const response = await axios.post(API_BASE_URL, job);
  return response.data;
};

export const updateJobApplication = async (id, job) => {
  const response = await axios.put(`${API_BASE_URL}/${id}`, job);
  return response.data;
};