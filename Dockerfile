# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY myapi/*.csproj ./myapi/
RUN dotnet restore

# copy everything else and build app
COPY myapi/. ./myapi/
WORKDIR /source/myapi
# RUN dotnet publish -c release -o /app --no-restore
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "myapi.dll"]
