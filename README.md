# Loan Service
## Project Overview
**Loan Service** is a demo project that simulates a simple loan request management system.
It consists of a **.NET 8 Web API backend**, a **Vue 3 frontend**, and a **PostgreSQL database**, all orchestrated with **Docker Compose**.
The goal of this project is to demonstrate practical skills in backend and frontend development, REST API design, validation, and containerized deployment.

## Technology Stack:
### Backend
- .NET 8 Web API
- Entity Framework Core
- PostgreSQL
- AutoMapper
- Docker
- Axios
### Frontend
- Vue 3 (Composition API)
- Element Plus
- Vite
- Docker

## Architecture

The project follows a modular layered architecture:

**Backend** provides REST endpoints for managing loans.

**Frontend** single-page application for viewing and creating loan requests.

**Database** PostgreSQL container for data persistence.

Both backend and frontend are built and served using Docker Compose.

## Backend Features
### Get All Loan

Endpoint: `GET /api/loans`

Returns all loan stored in the database with the following fields:

- Number

- Loan amount

- Term

- Interest rate

- Status (`Published` / `Unpublished`)

- Creation and modification timestamps

Supports **filtering parameters**:

- `status` — filter by status

- `minAmount` / `maxAmount` — filter by amount range

- `minTerm` / `maxTerm` — filter by loan term range

### Add a New Loan

Endpoint: `POST /api/loans`

Creates a new loan.
Validation rules:

- `Amount > 0`

- `TermValue > 0`

- `InterestValue > 0`

On successful creation:

- Status is automatically set to `Published`

- `CreatedAt` and `ModifiedAt` fields are filled with current timestamps

## Publish / Unpublish

Endpoint: `PATCH /api/loans/{number}/`

Toggles loan status:

- If current status = `Published` → becomes `Unpublished`

- If current status = `Unpublished` → becomes `Published`

Updates the ModifiedAt field on every change.

## Frontend Features
### Loan List Page

Displays a table of all loans with:

- Number

- Amount

- Term

- Interest rate

- Status (Published / Unpublished)

- Creation date

- Action button to change status

Includes **filter controls**:

- Status filter (All / Published / Unpublished)

- Amount range

- Term range

The list updates dynamically after filters or status changes.

## Create Loan Page

A form for submitting a new loan.

Fields:

- Number

- Amount

- Term value

- Interest rate

Client-side validation ensures:

- All numeric fields > 0

- Number is not empty

If validation passes, the form sends a POST `/api/loans` request to the backend.

## Docker Compose Configuration

The project includes a ready-to-use Docker Compose setup with three services:

Service	Description	Ports
- `postgres`	PostgreSQL database	`5432`
- `backend`	.NET 8 Web API	`5000`
- `frontend`	Vue 3 app served via Nginx	`5173`

Run the full stack:
`docker compose up --build`

Then open:

Frontend: `http://localhost:5173/`

Backend: `http://localhost:5000/`

## Design Highlights

- Dependency Injection throughout the backend

- SOLID and DRY principles applied

- RESTful endpoint design

- Dockerized development environment

## Possible Improvements

- Add authentication (JWT) and user roles

- Add pagination and sorting

- Extend test coverage (unit + integration)

- Enhance UI/UX and error handling

- CI/CD setup via GitHub Actions
