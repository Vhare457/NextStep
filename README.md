# NextStep – Job Application System

## Overview

NextStep is a full-stack web application designed to simplify the recruitment process by connecting job seekers and employers on a single platform. The system provides an easy-to-use interface where employers can advertise vacancies and manage applications, while job seekers can search for jobs, apply with a single click, track their applications, and communicate directly with employers.

The project was developed as part of the ITPV302 Software Development Project module.

---

## Features

### Job Seekers

* Create and manage a personal profile
* Upload a CV and profile picture
* Browse and search available jobs
* One-click job applications
* Track application status
* Send and receive messages from employers
* Reset forgotten passwords

### Employers

* Register and manage company profiles
* Create and manage job listings
* View and manage applications
* Communicate directly with applicants

### Security

* JWT (JSON Web Token) authentication
* Secure password hashing using BCrypt
* Role-based authorization
* Protected API endpoints

---

## Technologies Used

### Backend

* ASP.NET Core Web API
* Entity Framework Core
* Microsoft SQL Server
* AutoMapper
* JWT Authentication
* BCrypt Password Hashing

### Frontend

* React
* Vite
* Bootstrap 5
* JavaScript
* HTML5
* CSS3

### Development Tools

* Visual Studio 2022
* Visual Studio Code
* SQL Server Management Studio (SSMS)
* Git & GitHub

---

## Project Structure

```text
NextStep/
│
├── Backend/
│   ├── Controllers/
│   ├── Models/
│   ├── DTOs/
│   ├── Services/
│   ├── Data/
│   └── Program.cs
│
├── Frontend/
│   ├── src/
│   ├── components/
│   ├── pages/
│   ├── assets/
│   └── vite.config.js
│
└── README.md
```

---

## Installation

### Clone the repository

```bash
git clone https://github.com/yourusername/NextStep.git
cd NextStep
```

### Backend

1. Open the backend project in Visual Studio 2022.
2. Update the SQL Server connection string in `appsettings.json`.
3. Apply the Entity Framework migrations.

```bash
Update-Database
```

4. Run the API.

### Frontend

Navigate to the frontend folder.

```bash
npm install
```

Run the development server.

```bash
npm run dev
```

---

## Screenshots

You can add screenshots of:

* Login Page
* Registration
* Job Listings
* Profile Management
* Messaging
* Application Tracking
* Employer Dashboard

---

## Future Improvements

* AI-powered job recommendation system
* Job categorisation and filtering
* Advanced search functionality
* Email and push notifications
* Interview scheduling
* Mobile application
* Resume matching algorithm
* Company verification system

---

## Lessons Learned

This project strengthened our understanding of:

* Full-stack web development
* ASP.NET Core Web API
* React and Vite
* Entity Framework Core
* JWT Authentication
* SQL Server
* GitHub version control and collaborative development
* Agile teamwork and problem solving

---

## Team

* **Kuhle Gumede** – Lead Developer
* **Fikelo Ndengeza** – Project Manager
* **Vharevhawe Nemushungwa** – QA Tester
* **Phumlani Mazibuko** – UI/UX Designer

---

## Project Goal

NextStep aims to make job searching and recruitment simpler, faster, and more accessible by providing a centralized platform where employers and job seekers can interact efficiently. By reducing barriers in the recruitment process, the platform has the potential to contribute towards reducing unemployment and improving employment opportunities.

---

## License

This project was developed for educational purposes as part of the ITPV302 Software Development Project.
