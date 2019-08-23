# sfox microservice

## Configuration - Development
The development environment uses [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows#secret-manager) to store the SFox Api key. To configure your development environment:

1. Run `dotnet user-secrets set "SFoxApi:ApiKey" "YOUR_API_KEY"` to set up your key.
2. Set the desired API endpoint in `appsettings.json`
3. Build the application
4. Run the application
5. Navigate to `https://localhost:5001/swagger` to view the documentation.

## Docker

1. Run `docker build -t sfox .` to build your container
2. Run `docker run -e SFoxApi__ApiKey=YOUR_API_KEY -p 80:80 sfox` to start the container.
3. Navigate to `http://localhost/swagger` to view documentation.
