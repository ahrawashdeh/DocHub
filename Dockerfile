FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY src/DocumentPlatform.Api/DocumentPlatform.Api.csproj src/DocumentPlatform.Api/
RUN dotnet restore src/DocumentPlatform.Api/DocumentPlatform.Api.csproj

COPY . .
RUN dotnet publish src/DocumentPlatform.Api/DocumentPlatform.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

USER $APP_UID
EXPOSE 8080
ENTRYPOINT ["dotnet", "DocumentPlatform.Api.dll"]
