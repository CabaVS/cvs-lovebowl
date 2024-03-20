FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG WEBAPI_PROJECT_PATH="CabaVS.LoveBowl.WebApi/CabaVS.LoveBowl.WebApi.csproj"
WORKDIR /src
COPY src/ .
RUN dotnet restore $WEBAPI_PROJECT_PATH
RUN dotnet build $WEBAPI_PROJECT_PATH -c $BUILD_CONFIGURATION -o /app/build --no-restore
RUN dotnet publish $WEBAPI_PROJECT_PATH -c $BUILD_CONFIGURATION -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTPS_PORTS=443
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CabaVS.LoveBowl.WebApi.dll"]