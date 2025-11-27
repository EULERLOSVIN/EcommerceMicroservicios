# 1. CONSTRUCCIÓN
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# COPIAR TODO: Copiamos la carpeta entera del repositorio (PricingService, Inventory, etc)
COPY . .

# CAMINAR: Nos metemos dentro de la carpeta del proyecto explícitamente
WORKDIR /src/PricingService

# RESTAURAR Y PUBLICAR: Como ya estamos dentro de la carpeta, esto funcionará sí o sí
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# 2. EJECUCIÓN
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PricingService.dll"]