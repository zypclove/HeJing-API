#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Identity/IdentityServer.STS.Identity/IdentityServer.STS.Identity.csproj", "src/Services/Identity/IdentityServer.STS.Identity/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Configuration/IdentityServer.Admin.EntityFramework.Configuration.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Configuration/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Identity/IdentityServer.Admin.EntityFramework.Identity.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Identity/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework/IdentityServer.Admin.EntityFramework.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Extensions/IdentityServer.Admin.EntityFramework.Extensions.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Extensions/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Shared/IdentityServer.Admin.EntityFramework.Shared.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/Services/Identity/IdentityServer.Shared.Configuration/IdentityServer.Shared.Configuration.csproj", "src/Services/Identity/IdentityServer.Shared.Configuration/"]
COPY ["src/Services/Identity/IdentityServer.Shared/IdentityServer.Shared.csproj", "src/Services/Identity/IdentityServer.Shared/"]
COPY ["src/Services/Identity/IdentityServer.Admin.BusinessLogic.Identity/IdentityServer.Admin.BusinessLogic.Identity.csproj", "src/Services/Identity/IdentityServer.Admin.BusinessLogic.Identity/"]
COPY ["src/Services/Identity/IdentityServer.Admin.BusinessLogic.Shared/IdentityServer.Admin.BusinessLogic.Shared.csproj", "src/Services/Identity/IdentityServer.Admin.BusinessLogic.Shared/"]
RUN dotnet restore "src/Services/Identity/IdentityServer.STS.Identity/IdentityServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/IdentityServer.STS.Identity"
RUN dotnet build "IdentityServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.STS.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.STS.Identity.dll"]