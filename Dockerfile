FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

COPY ["Backend/SosUrbano.API/SosUrbano.API.csproj", "Backend/SosUrbano.API/"]
COPY ["Backend/SosUrbano.Application/SosUrbano.Application.csproj", "Backend/SosUrbano.Application/"]
COPY ["Backend/SosUrbano.Domain/SosUrbano.Domain.csproj", "Backend/SosUrbano.Domain/"]
COPY ["Backend/SosUrbano.Infrastructure/SosUrbano.Infrastructure.csproj", "Backend/SosUrbano.Infrastructure/"]

RUN dotnet restore "Backend/SosUrbano.API/SosUrbano.API.csproj"

COPY . .
WORKDIR "/src/Backend/SosUrbano.API"
RUN dotnet build "SosUrbano.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "SosUrbano.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SosUrbano.API.dll"]
