# TodoMvc

This folder contains a minimal ASP.NET Core MVC application that implements a simple Todo List.

## Running

This project targets **.NET 8**. To run the application locally, use the following commands:

```bash
cd TodoMvc
# restore dependencies
dotnet restore
# run the application
dotnet run
```

The application will be available at `https://localhost:5001` by default. Users must log in before managing Todos. Three test accounts (`alice`, `bob`, `charlie`) are created automatically with the password `123456`; passwords are stored using ASP.NET Core's `PasswordHasher`. Data is stored in a local **SQLite** database located in `todos.db`.

The views use [Bootstrap 5](https://getbootstrap.com/) for a responsive layout styled similarly to the **Front Dashboard** theme.
