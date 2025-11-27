# 1. IMAGEN DE CONSTRUCCIÓN
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# COPIAR: Le decimos explícitamente "Copia el archivo que está dentro de la carpeta PricingService"
# y "Ponlo dentro de una carpeta PricingService aquí en el contenedor"
COPY ["PricingService/PricingService.csproj", "PricingService/"]

# RESTAURAR: Ahora sí encontrará la ruta exacta
RUN dotnet restore "PricingService/PricingService.csproj"

# COPIAR TODO: Copiamos todo el repositorio
COPY . .

# CONSTRUIR: Entramos a la carpeta y publicamos
WORKDIR "/src/PricingService"
RUN dotnet publish "PricingService.csproj" -c Release -o /app/publish

# 2. IMAGEN FINAL
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PricingService.dll"]