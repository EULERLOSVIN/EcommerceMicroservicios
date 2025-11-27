# 1. IMAGEN DE CONSTRUCCIÓN
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# OJO: Como el robot ya estará DENTRO de la carpeta, solo copiamos el archivo por su nombre
COPY PricingService.csproj .
RUN dotnet restore

# Copiamos todo lo demás que hay en la carpeta
COPY . .
RUN dotnet publish -c Release -o /app/publish

# 2. IMAGEN FINAL
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PricingService.dll"]