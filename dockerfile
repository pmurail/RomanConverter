FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["RomanConverter.sln", "./"]
COPY ["RomanConverter/RomanConverter.csproj", "RomanConverter/"]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "RomanConverter.dll"]