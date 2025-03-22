import { useState, useEffect } from "react";
import { TextField, Button, MenuItem, Box } from "@mui/material";
import { addJobApplication, updateJobApplication } from "../api/jobApplicationService";

const JobApplicationForm = ({ selectedJob, onFormSubmit }) => {
  const [formData, setFormData] = useState({
    companyName: "",
    position: "",
    status: "Interview",
    dateApplied: "",
  });

  useEffect(() => {
    if (selectedJob) {
      setFormData(selectedJob);
    }
  }, [selectedJob]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (selectedJob) {
      await updateJobApplication(selectedJob.id, formData);
    } else {
      await addJobApplication(formData);
    }
    onFormSubmit();
  };

  return (
    <Box component="form" onSubmit={handleSubmit} sx={{ display: "flex", flexDirection: "column", gap: 2, maxWidth: 400 }}>
      <TextField label="Company Name" name="companyName" value={formData.companyName} onChange={handleChange} required />
      <TextField label="Position" name="position" value={formData.position} onChange={handleChange} required />
      <TextField select label="Status" name="status" value={formData.status} onChange={handleChange} required>
        <MenuItem value="Interview">Interview</MenuItem>
        <MenuItem value="Offer">Offer</MenuItem>
        <MenuItem value="Rejected">Rejected</MenuItem>
      </TextField>
      <TextField type="date" name="dateApplied" value={formData.dateApplied} onChange={handleChange} required />
      <Button type="submit" variant="contained">
        {selectedJob ? "Update" : "Add"}
      </Button>
    </Box>
  );
};

export default JobApplicationForm;
