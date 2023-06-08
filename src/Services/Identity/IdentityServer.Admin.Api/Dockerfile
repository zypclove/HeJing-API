FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdentityServer.Admin.Api/IdentityServer.Admin.Api.csproj", "src/IdentityServer.Admin.Api/"]
COPY ["src/IdentityServer.Admin.EntityFramework.PostgreSQL/IdentityServer.Admin.EntityFramework.PostgreSQL.csproj", "src/IdentityServer.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Shared/IdentityServer.Admin.EntityFramework.Shared.csproj", "src/IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Identity/IdentityServer.Admin.EntityFramework.Identity.csproj", "src/IdentityServer.Admin.EntityFramework.Identity/"]
COPY ["src/IdentityServer.Admin.EntityFramework/IdentityServer.Admin.EntityFramework.csproj", "src/IdentityServer.Admin.EntityFramework/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Extensions/IdentityServer.Admin.EntityFramework.Extensions.csproj", "src/IdentityServer.Admin.EntityFramework.Extensions/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Configuration/IdentityServer.Admin.EntityFramework.Configuration.csproj", "src/IdentityServer.Admin.EntityFramework.Configuration/"]
COPY ["src/IdentityServer.Shared.Configuration/IdentityServer.Shared.Configuration.csproj", "src/IdentityServer.Shared.Configuration/"]
COPY ["src/IdentityServer.Admin.BusinessLogic.Identity/IdentityServer.Admin.BusinessLogic.Identity.csproj", "src/IdentityServer.Admin.BusinessLogic.Identity/"]
COPY ["src/IdentityServer.Admin.BusinessLogic.Shared/IdentityServer.Admin.BusinessLogic.Shared.csproj", "src/IdentityServer.Admin.BusinessLogic.Shared/"]
COPY ["src/IdentityServer.Admin.EntityFramework.MySql/IdentityServer.Admin.EntityFramework.MySql.csproj", "src/IdentityServer.Admin.EntityFramework.MySql/"]
COPY ["src/IdentityServer.Admin.EntityFramework.SqlServer/IdentityServer.Admin.EntityFramework.SqlServer.csproj", "src/IdentityServer.Admin.EntityFramework.SqlServer/"]
COPY ["src/IdentityServer.Shared/IdentityServer.Shared.csproj", "src/IdentityServer.Shared/"]
COPY ["src/IdentityServer.Admin.BusinessLogic/IdentityServer.Admin.BusinessLogic.csproj", "src/IdentityServer.Admin.BusinessLogic/"]
RUN dotnet restore "src/IdentityServer.Admin.Api/IdentityServer.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer.Admin.Api"
RUN dotnet build "IdentityServer.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityServer.Admin.Api.dll"]