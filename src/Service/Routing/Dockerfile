FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /workspace
COPY . .
RUN dotnet restore "src/Service/Routing/Trace.Service.Routing.csproj"
WORKDIR "/workspace/src/Service/Routing"
RUN dotnet build "Trace.Service.Routing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trace.Service.Routing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trace.Service.Routing.dll"]
