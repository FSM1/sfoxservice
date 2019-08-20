# sfox microservice

## Configuration
The development environment uses [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows#secret-manager) to store the SFox Api key. To configure your development environment:

1. Run `dotnet user-secrets set "SFoxApi:ApiKey" "YOUR_API_KEY"` to set up your key.
2. Set the desired API endpoint in `appsettings.json`


