#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Identity/IdentityServer.Admin/IdentityServer.Admin.csproj", "src/Services/Identity/IdentityServer.Admin/"]
COPY ["src/Services/Identity/IdentityServer.Admin.BusinessLogic/IdentityServer.Admin.BusinessLogic.csproj", "src/Services/Identity/IdentityServer.Admin.BusinessLogic/"]
COPY ["src/Services/Identity/IdentityServer.Admin.BusinessLogic.Shared/IdentityServer.Admin.BusinessLogic.Shared.csproj", "src/Services/Identity/IdentityServer.Admin.BusinessLogic.Shared/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework/IdentityServer.Admin.EntityFramework.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Extensions/IdentityServer.Admin.EntityFramework.Extensions.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Extensions/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.MySql/IdentityServer.Admin.EntityFramework.MySql.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.MySql/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Shared/IdentityServer.Admin.EntityFramework.Shared.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Configuration/IdentityServer.Admin.EntityFramework.Configuration.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Configuration/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.Identity/IdentityServer.Admin.EntityFramework.Identity.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.Identity/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.PostgreSQL/IdentityServer.Admin.EntityFramework.PostgreSQL.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Services/Identity/IdentityServer.Admin.EntityFramework.SqlServer/IdentityServer.Admin.EntityFramework.SqlServer.csproj", "src/Services/Identity/IdentityServer.Admin.EntityFramework.SqlServer/"]
COPY ["src/Services/Identity/IdentityServer.Admin.UI/IdentityServer.Admin.UI.csproj", "src/Services/Identity/IdentityServer.Admin.UI/"]
COPY ["src/Services/Identity/IdentityServer.Admin.BusinessLogic.Identity/IdentityServer.Admin.BusinessLogic.Identity.csproj", "src/Services/Identity/IdentityServer.Admin.BusinessLogic.Identity/"]
COPY ["src/Services/Identity/IdentityServer.Shared.Configuration/IdentityServer.Shared.Configuration.csproj", "src/Services/Identity/IdentityServer.Shared.Configuration/"]
COPY ["src/Services/Identity/IdentityServer.Shared/IdentityServer.Shared.csproj", "src/Services/Identity/IdentityServer.Shared/"]
RUN dotnet restore "src/Services/Identity/IdentityServer.Admin/IdentityServer.Admin.csproj"
COPY . .
WORKDIR "/src/src/Services/Identity/IdentityServer.Admin"
RUN dotnet build "IdentityServer.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Admin.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.Admin.dll"]