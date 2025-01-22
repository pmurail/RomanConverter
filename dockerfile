# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["RomanConverter.sln", "./"]
COPY ["RomanConverter/RomanConverter.csproj", "RomanConverter/"]
COPY ["RomanConverterApi/RomanConverterApi.csproj", "RomanConverterApi/"]
COPY ["RomanConverterTest/RomanConverterTest.csproj", "RomanConverterTest/"]

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build -c Release -o /app/build

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/build .

# Expose the port for the API
EXPOSE 80

# Set the entry point for the API
ENTRYPOINT ["dotnet", "RomanConverterApi.dll"]