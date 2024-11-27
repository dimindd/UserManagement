FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserManagementApp.API/UserManagementApp.API.csproj", "UserManagementApp.API/"]
RUN dotnet restore "UserManagementApp.API/UserManagementApp.API.csproj"
COPY . .
WORKDIR "/src/UserManagementApp.API"
RUN dotnet build "UserManagementApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagementApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagementApp.API.dll"]
