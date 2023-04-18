FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Copy the project files and restore dependencies
WORKDIR /app
COPY src/Lily ./
RUN dotnet restore

# Build the service project
WORKDIR /app
RUN dotnet publish -c Release -o out

# Run the service inside a separate runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Lily.dll"]
