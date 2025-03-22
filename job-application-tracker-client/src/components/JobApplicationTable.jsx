import { useEffect, useState } from "react";
import { getJobApplications } from "../api/jobApplicationService";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
} from "@mui/material";

const JobApplicationTable = ({ onEdit }) => {
  const [applications, setApplications] = useState([]);

  useEffect(() => {
    loadApplications();
  }, []);

  const loadApplications = async () => {
    const data = await getJobApplications();
    setApplications(data);
  };

  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Company Name</TableCell>
            <TableCell>Position</TableCell>
            <TableCell>Status</TableCell>
            <TableCell>Date Applied</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {applications.map((app) => (
            <TableRow key={app.id}>
              <TableCell>{app.companyName}</TableCell>
              <TableCell>{app.position}</TableCell>
              <TableCell>{app.status}</TableCell>
              <TableCell>{new Date(app.dateApplied).toLocaleDateString()}</TableCell>
              <TableCell>
                <Button variant="contained" onClick={() => onEdit(app)}>
                  Edit
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default JobApplicationTable;
