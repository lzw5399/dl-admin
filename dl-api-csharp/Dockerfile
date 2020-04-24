#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Doublelives.Api/Doublelives.Api.csproj", "Doublelives.Api/"]
COPY ["Doublelives.Core/Doublelives.Core.csproj", "Doublelives.Core/"]
COPY ["Doublelives.Infrastructure/Doublelives.Infrastructure.csproj", "Doublelives.Infrastructure/"]
COPY ["Doublelives.Shared/Doublelives.Shared.csproj", "Doublelives.Shared/"]
COPY ["Doublelives.Query/Doublelives.Query.csproj", "Doublelives.Query/"]
COPY ["Doublelives.Domain/Doublelives.Domain.csproj", "Doublelives.Domain/"]
COPY ["Doublelives.Persistence/Doublelives.Persistence.csproj", "Doublelives.Persistence/"]
COPY ["Doublelives.Service/Doublelives.Service.csproj", "Doublelives.Service/"]
COPY ["Doublelives.Migrations/Doublelives.Migrations.csproj", "Doublelives.Migrations/"]
RUN dotnet restore "Doublelives.Api/Doublelives.Api.csproj"
COPY . .
WORKDIR "/src/Doublelives.Api"
RUN dotnet build "Doublelives.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Doublelives.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Doublelives.Api.dll"]