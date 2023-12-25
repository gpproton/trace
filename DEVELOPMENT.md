# Notes local development

Details for developing trace locally

## Build

```shell
## restore packages
dotnet tool restore

## build projects
dotnet build

## db migration
dotnet r opt:migrate
```

## Kubernetes testing

```shell
## deploy services
dotnet r k:apply

## delete services
dotnet r k:destroy

## expose frontend service
dotnet r k:frontend
```

## Docker compose testing

```shell
## build services container
docker-compose build

## run services
docker-compose up -d
```
