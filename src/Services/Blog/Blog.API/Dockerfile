#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Todo/Todo.API/Todo.API.csproj", "src/Services/Todo/Todo.API/"]
COPY ["src/Services/Todo/Todo.Domain/Todo.Domain.csproj", "src/Services/Todo/Todo.Domain/"]
COPY ["src/Services/Infrastructure/CommonMormon.Infrastructure/CommonMormon.Infrastructure.csproj", "src/Services/Infrastructure/CommonMormon.Infrastructure/"]
COPY ["src/Services/Todo/Todo.Infrastructure/Todo.Infrastructure.csproj", "src/Services/Todo/Todo.Infrastructure/"]
COPY ["src/Services/Todo/Todo.Shared/Todo.Shared.csproj", "src/Services/Todo/Todo.Shared/"]
RUN dotnet restore "src/Services/Todo/Todo.API/Todo.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Todo/Todo.API"
RUN dotnet build "Todo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.API.dll"]