# Migrations

For MindTheMangoDbContext

```bash
dotnet ef migrations add MIGRATION_NAME -s src/MindTheMango.Mind.Api.WebApi/MindTheMango.Mind.Api.WebApi.csproj -p src/MindTheMango.Mind.Persistence.Implementation/MindTheMango.Mind.Persistence.Implementation.csproj -c MindTheMangoDbContext
```