# Job Application Tracker

## Overview
This is a **full-stack job application tracker** built using **ASP.NET Core Web API** for the backend and **React (Vite) with Material UI** for the frontend.

## Features
- **List all job applications**
- **Add a new job application**
- **Update job application status** (Interview/Offer/Rejected)

## Tech Stack
### Backend
- **ASP.NET Core Web API (.NET 8)**
- **Entity Framework Core (In-Memory Database)**
- **FluentValidation for validation**
- **Repository & Service Layer Architecture**
- **Swagger UI for API documentation**

### Frontend
- **React with Vite**
- **Material UI for UI Components**
- **Axios for API Calls**

## Prerequisites
- **.NET 8 SDK** (for the backend)
- **Node.js** (for the frontend)
- **Git** (for version control)

## Setup Instructions

### 1 Clone the Repository
```sh
git clone https://github.com/george-daniel314/job-application-tracker.git
cd job-application-tracker
```

### 2 Backend Setup (.NET 8 API)
#### Install dependencies:
```sh
cd JobApplicationTracker.Api
```
```sh
dotnet restore
```
#### Run the API:
```sh
dotnet run
```
The API will be available at **http://localhost:5000**.


### 3 Frontend Setup (React with Vite)
#### Install dependencies:
```sh
cd ../job-application-tracker-client
```
```sh
npm install
```
#### Run the frontend:
```sh
npm run dev
```
The frontend will be available at **http://localhost:3001**.

---

## Author
George Daniel
