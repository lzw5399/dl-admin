FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Doublelives.Api/Doublelives.Api.csproj", "Doublelives.Api/"]
COPY ["Doublelives.Core/Doublelives.Core.csproj", "Doublelives.Core/"]
COPY ["Doublelives.Infrastructure/Doublelives.Infrastructure.csproj", "Doublelives.Infrastructure/"]
COPY ["Doublelives.Cos/Doublelives.Cos.csproj", "Doublelives.Cos/"]
COPY ["Doublelives.Domain/Doublelives.Domain.csproj", "Doublelives.Domain/"]
COPY ["Doublelives.Shared/Doublelives.Shared.csproj", "Doublelives.Shared/"]
COPY ["Doublelives.Service/Doublelives.Service.csproj", "Doublelives.Service/"]
COPY ["Doublelives.Data/Doublelives.Data.csproj", "Doublelives.Data/"]
COPY ["Doublelives.Migrations/Doublelives.Migrations.csproj", "Doublelives.Migrations/"]
RUN dotnet restore "Doublelives.Api/Doublelives.Api.csproj"
COPY . .
WORKDIR /src/Doublelives.Api
RUN dotnet build "Doublelives.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Doublelives.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Doublelives.Api.dll"]