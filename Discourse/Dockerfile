#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Discourse/Discourse.csproj", "Discourse/"]
RUN dotnet restore "Discourse/Discourse.csproj"
COPY . .
WORKDIR "/src/Discourse"
RUN dotnet build "Discourse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discourse.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discourse.dll"]