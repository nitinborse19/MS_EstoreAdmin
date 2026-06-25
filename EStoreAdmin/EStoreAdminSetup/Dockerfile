#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EStoreAdmin/EStoreAdminSetup/EStoreAdminSetup.csproj", "EStoreAdmin/EStoreAdminSetup/"]
COPY ["CatalogRepository/CatalogRepository.csproj", "CatalogRepository/"]
COPY ["EStoreAdmin/CatalogModel/CatalogModel.csproj", "EStoreAdmin/CatalogModel/"]
COPY ["CatalogService/CatalogService.csproj", "CatalogService/"]
RUN dotnet restore "./EStoreAdmin/EStoreAdminSetup/EStoreAdminSetup.csproj"
COPY . .
WORKDIR "/src/EStoreAdmin/EStoreAdminSetup"
RUN dotnet build "./EStoreAdminSetup.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EStoreAdminSetup.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EStoreAdminSetup.dll"]