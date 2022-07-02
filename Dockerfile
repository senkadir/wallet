FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY ./Directory.Packages.props ./Directory.Packages.props

COPY ./src/UI/. ./UI/
COPY ./src/Common/. ./Common/
COPY ./src/Core/. ./Core/
COPY ./src/Data/. ./Data/
COPY ./src/Domain/. ./Domain/

RUN dotnet publish ./UI/ -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT Docker
ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "UI.dll"]