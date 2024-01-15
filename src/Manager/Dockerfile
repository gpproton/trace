FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /workspace
COPY . .
RUN dotnet restore "src/Manager/Service/Trace.Manager.csproj"
WORKDIR "/workspace/src/Manager/Service"
RUN dotnet build "Trace.Manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trace.Manager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trace.Manager.dll"]
