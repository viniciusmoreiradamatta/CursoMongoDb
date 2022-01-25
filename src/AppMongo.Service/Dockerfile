#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AppMongo.Service/AppMongo.Service.csproj", "src/AppMongo.Service/"]
COPY ["src/AppMongo.Infra/AppMongo.Application.csproj", "src/AppMongo.Infra/"]
COPY ["src/AppMongo.Domain/AppMongo.Domain.csproj", "src/AppMongo.Domain/"]
COPY ["src/AppMongo.Data/AppMongo.Data.csproj", "src/AppMongo.Data/"]
RUN dotnet restore "src/AppMongo.Service/AppMongo.Service.csproj"
COPY . .
WORKDIR "/src/src/AppMongo.Service"
RUN dotnet build "AppMongo.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppMongo.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppMongo.Service.dll"]