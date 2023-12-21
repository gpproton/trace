FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /workspace
COPY . .
RUN dotnet restore "src/Service/Core/Trace.Service.Core.csproj"
WORKDIR "/workspace/src/Service/Core"
RUN dotnet build "Trace.Service.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trace.Service.Core.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trace.Service.Core.dll"]
