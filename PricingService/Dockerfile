# 1. CONSTRUCCIÓN
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# EL TRUCO: Copiamos TODO (.) lo que haya en el contexto a la carpeta actual (.)
COPY . .

# RESTAURAR: Al no poner nombre de archivo, dotnet buscará cualquier .csproj en la carpeta y lo usará.
RUN dotnet restore

# PUBLICAR
RUN dotnet publish -c Release -o /app/publish

# 2. EJECUCIÓN
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PricingService.dll"]