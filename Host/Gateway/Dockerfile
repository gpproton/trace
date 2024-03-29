FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /workspace
COPY . .
RUN dotnet restore "Host/Gateway/Trace.Gateway.csproj"
WORKDIR "/workspace/Host/Gateway"
RUN dotnet build "Trace.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trace.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trace.Gateway.dll"]
