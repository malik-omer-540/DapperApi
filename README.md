# DapperApi (.NET 8 Web API + Dapper Optimization)

A real-world Web API that demonstrates how to use **Dapper** efficiently with SQL indexing and caching.

## 🔍 Key Concepts

- ✅ Query optimization using **indexed columns**
- ✅ Parameterized queries to prevent SQL injection
- ✅ **Caching** with in-memory cache for repeated access
- ✅ Dapper for fast, lightweight data access

---

## ⚡ SQL Optimization Tip

If you're running the following query:

```sql
SELECT * FROM Users WHERE Email = @Email
```

Add this index in your database:

```sql
CREATE INDEX IX_Users_Email ON Users (Email);
```

---

## 🔧 API Endpoints

| Endpoint                      | Description                                      |
|-------------------------------|--------------------------------------------------|
| `GET /api/user/by-email`     | ✅ Fast lookup using indexed + parameterized SQL |
| `GET /api/user/cached`       | ✅ Cached list of all users                      |

---

## 🛠️ How to Run

1. Add your DB connection in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=YourDb;Trusted_Connection=True;"
}
```

2. Run the project:

```bash
dotnet restore
dotnet build
dotnet run
```

3. Access Swagger:
`https://localhost:5001/swagger`

---

## 📁 Folder Structure

```plaintext
DapperApi/
│
├── DapperApi.sln
├── README.md
│
├── DapperApi/
│   ├── Controllers/
│   │   └── UserController.cs
│   ├── Models/
│   │   └── User.cs
│   ├── Repositories/
│   │   ├── IDbConnectionFactory.cs
│   │   ├── DbConnectionFactory.cs
│   │   ├── IUserRepository.cs
│   │   └── UserRepository.cs
│   ├── Program.cs
│   └── DapperApi.csproj
```

---

## ✅ Pro Tips

- Don't over-index: Index what you filter or sort by most.
- Use caching for non-volatile data.
- Use `QueryFirstOrDefaultAsync<T>()` to avoid surprises.
- Validate user input even if you use parameterized queries.

---

> A fast database starts with smart SQL. Dapper gives you control—use it wisely 🚀
