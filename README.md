# 🎬 ASP.NET Core MVC Movie App with External API Integration

This project consists of two main applications that work together:

1. **Test** – A RESTful API that provides movie data.
2. **WebApp** – An ASP.NET Core MVC client that consumes the API to display and manage movies.

---

## 🔧 Technologies Used

- ASP.NET Core 9 (MVC & API)
- C#
- HTTP Client
- REST API
- JSON
- Visual Studio 2022

---

## ✨ Features

### Test (API)

- Built using ASP.NET Core Web API.
- Exposes endpoints to perform full **CRUD** operations on movie data.
- Uses an interface (`IRepository`) to decouple data access logic.
- Stores movie data in-memory (for simplicity).
- Well-structured layers: Controller, Data, Model.

### WebApp (MVC)

- Consumes the external API exposed by the Test project.
- Displays movie list with:
  - Title, Genre, and Release Date.
- Performs full CRUD operations:
  - **Create**, **Read**, **Update**, **Delete**.
- Clean and responsive UI using Razor views.
- API integration handled via `MovieApiService`.
- Separation of concerns using Controllers, Services, and Views.

---

## 🚀 How to Run the Project

1. **Clone the repository.**
2. **Open the solution in Visual Studio.**
3. **Set both projects (`Test` and `WebApp`) to run simultaneously.**
4. **Ensure the API project is running before the MVC app tries to consume it.**
5. **Start debugging (F5).**

---

## 📌 Endpoints (API)

- `GET /api/movies` – Get all movies
- `GET /api/movies/{id}` – Get a single movie by ID
- `POST /api/movies` – Create a new movie
- `PUT /api/movies/{id}` – Update an existing movie
- `DELETE /api/movies/{id}` – Delete a movie

---

## 👤 Author

Mahmoud Reda  
Back-End Developer | ASP.NET Core | C# | SQL Server

---

## 📫 Contact

- LinkedIn: [Mahmoud Reda](linkedin.com/in/mahmoudredaprofile)
