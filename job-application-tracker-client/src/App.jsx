import { useState } from "react";
import JobApplicationTable from "./components/JobApplicationTable";
import JobApplicationForm from "./components/JobApplicationForm";
import { Container, Typography } from "@mui/material";

const App = () => {
  const [selectedJob, setSelectedJob] = useState(null);
  const [refresh, setRefresh] = useState(false);

  const handleEdit = (job) => {
    setSelectedJob(job);
  };

  const handleFormSubmit = () => {
    setSelectedJob(null);
    setRefresh((prev) => !prev);
  };

  return (
    <Container>
      <Typography variant="h4" sx={{ my: 2 }}>Job Application Tracker</Typography>
      <JobApplicationForm selectedJob={selectedJob} onFormSubmit={handleFormSubmit} />
      <JobApplicationTable onEdit={handleEdit} key={refresh} />
    </Container>
  );
};

export default App;
