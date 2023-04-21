FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CommonMormon.STS.Identity/CommonMormon.STS.Identity.csproj", "src/CommonMormon.STS.Identity/"]
COPY ["src/CommonMormon.Admin.EntityFramework.Shared/CommonMormon.Admin.EntityFramework.Shared.csproj", "src/CommonMormon.Admin.EntityFramework.Shared/"]
COPY ["src/CommonMormon.Shared/CommonMormon.Shared.csproj", "src/CommonMormon.Shared/"]
RUN dotnet restore "src/CommonMormon.STS.Identity/CommonMormon.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/CommonMormon.STS.Identity"
RUN dotnet build "CommonMormon.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommonMormon.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "CommonMormon.STS.Identity.dll"]