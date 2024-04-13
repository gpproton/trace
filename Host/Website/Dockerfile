FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:20-alpine AS node

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Import Node.js binaries
COPY --from=node /usr/lib /usr/lib
COPY --from=node /usr/local/share /usr/local/share
COPY --from=node /usr/local/lib /usr/local/lib
COPY --from=node /usr/local/include /usr/local/include
COPY --from=node /usr/local/bin /usr/local/bin
RUN npm i -g pnpm npm
WORKDIR /workspace
COPY . .
RUN dotnet publish "Host/Website/Trace.Host.Website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Trace.Host.Website.dll"]
