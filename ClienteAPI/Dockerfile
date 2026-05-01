# 1. Imagen base para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# 2. Imagen para compilar (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos solo el .csproj primero (esto acelera futuras compilaciones)
COPY ["ClienteAPI.csproj", "./"]
RUN dotnet restore "ClienteAPI.csproj"

# Copiamos todo lo demás y compilamos
COPY . .
RUN dotnet build "ClienteAPI.csproj" -c Release -o /app/build

# 3. Publicación
FROM build AS publish
RUN dotnet publish "ClienteAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Imagen final (ligera)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClienteAPI.dll"]
