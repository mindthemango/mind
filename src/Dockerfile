FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5100
EXPOSE 5100

FROM microsoft/dotnet:sdk as builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./

COPY MindTheMango.Mind.Api.WebApi/*.csproj MindTheMango.Mind.Api.WebApi/
COPY MindTheMango.Mind.Application.Contract/*.csproj MindTheMango.Mind.Application.Contract/
COPY MindTheMango.Mind.Application.Implementation/*.csproj MindTheMango.Mind.Application.Implementation/
COPY MindTheMango.Mind.Domain.Entity/*.csproj MindTheMango.Mind.Domain.Entity/
COPY MindTheMango.Mind.Domain/*.csproj MindTheMango.Mind.Domain/
COPY MindTheMango.Mind.Persistence.Contract/*.csproj MindTheMango.Mind.Persistence.Contract/
COPY MindTheMango.Mind.Persistence.Implementation/*.csproj MindTheMango.Mind.Persistence.Implementation/

RUN dotnet restore
COPY . .
WORKDIR /src/MindTheMango.Mind
RUN dotnet build -c $Configuration -o /app ../MindTheMango.Mind.sln 

FROM builder as publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app ../MindTheMango.Mind.sln 

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MindTheMango.Mind.Api.WebApi.dll"]