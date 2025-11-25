# roadcast
Main roadcast repository (MVP now, will be splitted into microservices if needed)

## Migrations
- dotnet ef migrations add Initial --context ApplicationDbContext --startup-project src/roadcast.Api/roadcast.Api.csproj --project src/roadcast.Persistence/roadcast.Persistence.csproj --output-dir Migrations/001