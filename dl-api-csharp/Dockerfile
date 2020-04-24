FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

COPY ./publish ./app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Doublelives.Api.dll"]