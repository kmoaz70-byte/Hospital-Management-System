# 🏥 **Hospital Management System**

A comprehensive hospital management system built with ASP.NET Core MVC using N-Tier Architecture.
---
## ✨ Features

- 👨‍⚕️ **Doctor Management** - Add, edit, delete doctors with specializations
- 👥 **Patient Management** - Complete patient records with search
- 🏢 **Department Management** - Organize doctors by departments
- 📅 **Appointment System** - Book and manage appointments
- 📊 **Dashboard** - Real-time statistics
- 🔍 **Search & Filter** - Advanced search across all modules
- 🔔 **Notifications** - Toast notifications for user actions
---
## 🛠️ Technology Stack

**Backend:**
- ASP.NET Core MVC 8.0
- Entity Framework Core
- SQL Server
- C# 12

**Frontend:**
- Bootstrap 5
- Toastr.js
- Bootstrap Icons

**Architecture:**
- N-Tier Architecture
- Repository Pattern
- Unit of Work Pattern
- Generic Repository
- Dependency Injection
---


## 📸 Screenshots

### Dashboard
- [Dashboard](https://github.com/kmoaz70-byte/Hospital-Management-System/raw/master/screenshots/Dashboard.png)

### Appointments Management
- [Appointments Screenshot](https://github.com/kmoaz70-byte/Hospital-Management-System/raw/master/screenshots/Appointments.png)

### Doctors Management  
- [Doctors Screenshot](https://github.com/kmoaz70-byte/Hospital-Management-System/raw/master/screenshots/Doctors.png)

### Patients Management
- [Patients Screenshot](https://github.com/kmoaz70-byte/Hospital-Management-System/raw/master/screenshots/Patients.png)

### Departments
- [Departments Screenshot](https://github.com/kmoaz70-byte/Hospital-Management-System/raw/master/screenshots/Departments.png)


## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022

### Installation

1. Clone the repository
```bash
git clone https://github.com/kmoaz70-byte/hospital-management-system.git
```

2. Update connection string in `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

3. Apply database migrations
```bash
dotnet ef database update
```

4. Run the application
```bash
dotnet run
```
---

## 📁 Project Structure
```
HospitalManagementSystem/
├── Controllers/          # MVC Controllers
├── Views/               # Razor Views
├── Models/              # Domain Models & ViewModels
├── DataAccess/          # Repository & DbContext
└── wwwroot/            # Static files (CSS, JS, images)
```
---

## 🗄️ Database Schema

**Relationships:**
- Department (1) → (*) Doctor
- Doctor (1) → (*) Appointment
- Patient (1) → (*) Appointment

**Tables:**
- Departments
- Doctors
- Patients
- Appointments
---
## 👨‍💻 Author
``
**Your Name**
- GitHub: [@kmoaz70-byte](https://github.com/kmoaz70-byte)
- LinkedIn: [Syed Muaaz](https://linkedin.com/in/syedmuaaz)
- Email: kmoaz70@gmail.com
```


## 📄 License

This project is licensed under the MIT License.

---

⭐ If you found this helpful, please give it a star!
