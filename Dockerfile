FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Advent Of Code.csproj", "./"]
RUN dotnet restore "Advent Of Code.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Advent Of Code.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Advent Of Code.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Advent Of Code.dll"]
