#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["src/Betting.API/Betting.API.csproj", "src/Betting.API/"]
COPY ["src/Betting.Infrastructure/Betting.Infrastructure.csproj", "src/Betting.Infrastructure/"]
COPY ["src/Betting.Application/Betting.Application.csproj", "src/Betting.Application/"]
COPY ["src/Betting.Domain/Betting.Domain.csproj", "src/Betting.Domain/"]

RUN dotnet restore "src/Betting.API/Betting.API.csproj"
COPY . .

WORKDIR "/src/src/Betting.API"
RUN dotnet build "Betting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Betting.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Betting.API.dll"]