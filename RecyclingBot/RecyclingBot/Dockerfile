#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:$PORT

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["RecyclingBot/RecyclingBot.csproj", "RecyclingBot/"]
RUN dotnet restore "RecyclingBot/RecyclingBot.csproj"
COPY . .
WORKDIR "/src/RecyclingBot"
RUN dotnet build "RecyclingBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecyclingBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "RecyclingBot.dll"]