FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./src/Api/. ./Api/
COPY ./src/Common/. ./Common/
COPY ./src/Core/. ./Core/
COPY ./src/Data/. ./Data/
COPY ./src/Domain/. ./Domain/

RUN dotnet publish ./Api/ -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT Docker
ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "Api.dll"]