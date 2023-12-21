FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/Service/Route/Trace.Service.Route.csproj"
WORKDIR "/src/src/Service/Route"
RUN dotnet build "Trace.Service.Route.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trace.Service.Route.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trace.Service.Route.dll"]
