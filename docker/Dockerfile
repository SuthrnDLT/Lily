FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Copy the project files and restore dependencies
WORKDIR /app
COPY src .
RUN dotnet restore ./Lily/Lily.csproj

# Build the service and core projects
WORKDIR /app/Lily.Core
RUN dotnet build -c Release

WORKDIR /app/Lily
RUN dotnet build -c Release

# Publish the service project
WORKDIR /app/Lily
RUN dotnet publish -c Release -o out

# Run the service inside a separate runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/Lily/out ./

ENV DOTNET_USER_SECRETS_ID=0xlily

ENTRYPOINT ["dotnet", "Lily.dll"]
