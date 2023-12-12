#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookMe.API.Auth/BookMe.API.Auth.csproj", "BookMe.API.Auth/"]
RUN dotnet restore "BookMe.API.Auth/BookMe.API.Auth.csproj"
COPY . .
WORKDIR "/src/BookMe.API.Auth"
RUN dotnet build "BookMe.API.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookMe.API.Auth.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookMe.API.Auth.dll"]