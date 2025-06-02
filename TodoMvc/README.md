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

The application will be available at `https://localhost:5001` by default. The index page displays a basic Todo List where you can add, toggle, and delete items. Data is persisted in a local **SQLite** database located in `todos.db`.

The views use [Bootstrap 5](https://getbootstrap.com/) for a responsive layout styled similarly to the **Front Dashboard** theme.
