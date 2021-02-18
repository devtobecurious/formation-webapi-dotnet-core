#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["SelfieAWookie.API.UI/SelfieAWookie.API.UI.csproj", "SelfieAWookie.API.UI/"]
RUN dotnet restore "SelfieAWookie.API.UI/SelfieAWookie.API.UI.csproj"
COPY . .
WORKDIR "/src/SelfieAWookie.API.UI"
RUN dotnet build "SelfieAWookie.API.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SelfieAWookie.API.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SelfieAWookie.API.UI.dll"]