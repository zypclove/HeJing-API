FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdentityServer.STS.Identity/IdentityServer.STS.Identity.csproj", "src/IdentityServer.STS.Identity/"]
COPY ["src/IdentityServer.Shared.Configuration/IdentityServer.Shared.Configuration.csproj", "src/IdentityServer.Shared.Configuration/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Shared/IdentityServer.Admin.EntityFramework.Shared.csproj", "src/IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Identity/IdentityServer.Admin.EntityFramework.Identity.csproj", "src/IdentityServer.Admin.EntityFramework.Identity/"]
COPY ["src/IdentityServer.Admin.EntityFramework/IdentityServer.Admin.EntityFramework.csproj", "src/IdentityServer.Admin.EntityFramework/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Extensions/IdentityServer.Admin.EntityFramework.Extensions.csproj", "src/IdentityServer.Admin.EntityFramework.Extensions/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Configuration/IdentityServer.Admin.EntityFramework.Configuration.csproj", "src/IdentityServer.Admin.EntityFramework.Configuration/"]
COPY ["src/IdentityServer.Shared/IdentityServer.Shared.csproj", "src/IdentityServer.Shared/"]
COPY ["src/IdentityServer.Admin.BusinessLogic.Identity/IdentityServer.Admin.BusinessLogic.Identity.csproj", "src/IdentityServer.Admin.BusinessLogic.Identity/"]
COPY ["src/IdentityServer.Admin.BusinessLogic.Shared/IdentityServer.Admin.BusinessLogic.Shared.csproj", "src/IdentityServer.Admin.BusinessLogic.Shared/"]
RUN dotnet restore "src/IdentityServer.STS.Identity/IdentityServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer.STS.Identity"
RUN dotnet build "IdentityServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityServer.STS.Identity.dll"]