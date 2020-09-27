FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MinerCode/Miner.csproj", "MinerCode/"]
RUN dotnet restore "MinerCode/Miner.csproj"
COPY . .
WORKDIR "/src/MinerCode"
RUN dotnet build "Miner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Miner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Miner.dll"]
