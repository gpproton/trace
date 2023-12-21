FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/Worker/Trace.Worker.csproj"
WORKDIR "/src/src/Worker"
RUN dotnet build "Trace.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trace.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trace.Worker.dll"]
