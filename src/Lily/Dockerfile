FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Copy the project files and restore dependencies
WORKDIR /app
COPY . ./
RUN dotnet restore

# Create a directory for secrets
RUN mkdir /run/secrets

# Build the service project
WORKDIR /app
RUN dotnet publish -c Release -o out

# Run the service inside a separate runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=build /app/out ./

ENV DOTNET_USER_SECRETS_ID=0xlily

ENTRYPOINT ["dotnet", "Lily.dll"]
