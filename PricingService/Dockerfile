# 1. FASE DE CONSTRUCCIÓN
# Usamos la imagen de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el archivo de proyecto (Ruta simplificada)
COPY ["PricingService.csproj", "."]
RUN dotnet restore "./PricingService.csproj"

# Copiamos el resto del código y construimos
COPY . .
RUN dotnet publish "PricingService.csproj" -c Release -o /app/publish

# 2. FASE FINAL
# Usamos la imagen ligera para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PricingService.dll"]