#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HeJing-API/src/Services/CommonServer/CommonServer.API/CommonServer.API.csproj", "HeJing-API/src/Services/CommonServer/CommonServer.API/"]
COPY ["HeJing-API/src/Infrastructure/CommonMormon.Infrastructure.API/CommonMormon.Infrastructure.API.csproj", "HeJing-API/src/Infrastructure/CommonMormon.Infrastructure.API/"]
COPY ["HeJing-API/src/Infrastructure/CommonMormon.Infrastructure/CommonMormon.Infrastructure.csproj", "HeJing-API/src/Infrastructure/CommonMormon.Infrastructure/"]
COPY ["HeJing-API/src/Infrastructure/CommonMormon.Infrastructure.Shared/CommonMormon.Infrastructure.Shared.csproj", "HeJing-API/src/Infrastructure/CommonMormon.Infrastructure.Shared/"]
COPY ["HeJing-API/src/Services/CommonServer/CommonServer.Domain/CommonServer.Domain.csproj", "HeJing-API/src/Services/CommonServer/CommonServer.Domain/"]
COPY ["HeJing-API/src/Services/CommonServer/CommonServer.Shared/CommonServer.Shared.csproj", "HeJing-API/src/Services/CommonServer/CommonServer.Shared/"]
COPY ["HeJing-API/src/Services/CommonServer/CommonServer.Infrastructure/CommonServer.Infrastructure.csproj", "HeJing-API/src/Services/CommonServer/CommonServer.Infrastructure/"]
RUN dotnet restore "./HeJing-API/src/Services/CommonServer/CommonServer.API/CommonServer.API.csproj"
COPY . .
WORKDIR "/src/HeJing-API/src/Services/CommonServer/CommonServer.API"
RUN dotnet build "./CommonServer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CommonServer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommonServer.API.dll"]