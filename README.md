
# 🎓 Student Enrolment Tracker

This project is a **Student Enrolment Tracker** system that enables tracking of student enrolment in universities (varsities). It allows students to register and log in to view their profiles. The system is made up of two main components:

* A **.NET Core 8 Web API** (backend)
* A **ReactJS Web App** (frontend)

---

## ✨ Features

* 📝 Register students and track their enrolment details.
* 🔐 Secure student profile access via basic authentication.
* 🌐 ReactJS frontend communicates with .NET Core API.
* 👤 Public and protected API controllers for flexibility in development.

---

## 🛠 Technologies Used

* **Backend:** .NET 8 Web API (built with Visual Studio 2022)
* **Frontend:** React.js (default port: `3000`)
* **Node.js Version:** `22.x`
* **Authentication:** Basic Auth on selected endpoints

---

## 🚀 Getting Started

### 🔧 Prerequisites

Make sure you have the following installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
* [Node.js v22](https://nodejs.org/en)
* [npm](https://www.npmjs.com/) (comes with Node.js)

---

### 🖥️ Running the .NET Core API

1. Open the solution in **Visual Studio 2022**.
2. Set the API project as the **Startup Project**.
3. Press `F5` or click on **Run** to start the API.

By default, the API runs on:

```
https://localhost:44363
```

> Note: One controller is protected using **Basic Authentication**, while another remains public for development/testing purposes.

---

### 🌐 Running the ReactJS Web App

1. Navigate to the `client` folder (or wherever the React app is located):

   ```bash
   cd client
   ```
2. Install dependencies:

   ```bash
   npm install
   ```
3. Start the app:

   ```bash
   npm start
   ```

The React app will run by default on:

```
http://localhost:3000
```

It communicates with the .NET Core API hosted on:

```
https://localhost:44363
```

Make sure both frontend and backend are running for full functionality.

---

## 📂 Project Structure (High-Level)

```
/api                 -> .NET Core 8 Web API
/client              -> ReactJS frontend app
README.md            -> This file
```

---

## 🔐 Authentication Note

* **Protected Controller**: Requires Basic Auth headers (username & password).
* **Public Controller**: Open for development/testing access.

---

## 🧪 Development Notes

* CORS is configured to allow requests from `http://localhost:3000`.
* Ensure SSL is enabled for the API during local development.

---

