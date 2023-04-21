FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CommonMormon.Admin.Api/CommonMormon.Admin.Api.csproj", "src/CommonMormon.Admin.Api/"]
COPY ["src/CommonMormon.Admin.EntityFramework.Shared/CommonMormon.Admin.EntityFramework.Shared.csproj", "src/CommonMormon.Admin.EntityFramework.Shared/"]
COPY ["src/CommonMormon.Admin.EntityFramework.SqlServer/CommonMormon.Admin.EntityFramework.SqlServer.csproj", "src/CommonMormon.Admin.EntityFramework.SqlServer/"]
COPY ["src/CommonMormon.Shared/CommonMormon.Shared.csproj", "src/CommonMormon.Shared/"]
COPY ["src/CommonMormon.Admin.EntityFramework.PostgreSQL/CommonMormon.Admin.EntityFramework.PostgreSQL.csproj", "src/CommonMormon.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/CommonMormon.Admin.EntityFramework.MySql/CommonMormon.Admin.EntityFramework.MySql.csproj", "src/CommonMormon.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/CommonMormon.Admin.Api/CommonMormon.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/CommonMormon.Admin.Api"
RUN dotnet build "CommonMormon.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommonMormon.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CommonMormon.Admin.Api.dll"]