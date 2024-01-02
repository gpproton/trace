# Trace [Experimental]

Trace is an end to end logistics B2C platform, for handling all processes in the logistics process,
manages the entire logistics cycle from procurement and distribution to transport,
delivery to the customer and ending with return logistics.

## License

Trace is license under the [Business Source License 1.1](./LICENSE.md) [![Business Source License 1.1](https://img.shields.io/badge/license-BSL--1.1-blue.svg?style=flat-square)](./LICENSE.md)

- Agboola Solomon ([agboolas@outlook.com](mailto:agboolas@outlook.com))
- Godwin peter .O ([me@godwin.dev](mailto:me@godwin.dev))

|                       |                                                                                                                                                                                                           |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Licensor:             | drolx Solutions.                                                                                                                                                                                          |
| Licensed Work:        | The Licensed Work is (c) 2023 drolx Solutions.                                                                                                                                                            |
| Additional Use Grant: | You may make production use of the Licensed Work, provided such use does not include offering the Licensed Work to third parties on a hosted or embedded basis which is competitive with drolx's products |
| Change Date:          | Four years from the date a Licensed version is published                                                                                                                                                  |
| Change License:       | Reciprocal Public License (RPL-1.5)                                                                                                                                                                       |

## Core Project Goals
* Unify all logistics data source
* Single client UI for logistics processes
* Combine multiple map data to handle order routing
* Real-time GPS tracking
* Travel route analysis
* Operational task processing


## Project Status
This is an experimental platform; however the logic and ideas have been previously tested
in different forms of disjointed applications.


## Project Roadmap

There are a some modules supported. Most of them are configurable via the web
interface or mobile app. A few of them are:


### Stage 1

| Version | Feature             | Progress | Comments                                                       |
| ------- | ------------------- | -------- | -------------------------------------------------------------- |
| v0.0.1  | Protocol endpoint   | [x]      | MQTT, GRPC and HTTP based API ingest for location data         |
| v0.0.1  | Tenant profile      | [ ]      | basic setting and profile feature fron tenant accounts         |
| v0.0.1  | Tags                | [ ]      | For authorization ans sharing for features                     |
| v0.0.1  | Device              | [ ]      | IOT devices with compatible usaage e.g GPS, RFID, Sensors, etc |
| v0.0.1  | Asset - Vehicle     | [ ]      | Sub module for managing vehicle as asset                       |
| v0.0.1  | Asset - Trailer     | [ ]      | Sub module for managing trailer as asset                       |
| v0.0.1  | Asset - Others      | [ ]      | Sub module for managing other asset                            |
| v0.0.1  | Location management | [ ]      | Location management for POI's and geofences                    |
| v0.0.1  | Route management    | [ ]      | General management and permission assignment                   |
| v0.0.1  | Central event       | [ ]      | Architectire for processing all events                         |
| v0.0.1  | Dashboard           | [ ]      | Standard dashboard for initial features                        |
| v0.0.1  | Authentication      | [ ]      | Related API and UI for account authentication                  |
| v0.0.1  | Tenant On-boarding  | [ ]      | Related API and UI for creating new tenants                    |


### Stage 2

| Version | Feature                 | Progress | Comments                                                          |
| ------- | ----------------------- | -------- | ----------------------------------------------------------------- |
| v0.0.2  | Dispatchers             | [ ]      | Dispatchers management                                            |
| v0.0.2  | Dispatch team           | [ ]      | Dispatch team management                                          |
| v0.0.2  | Tenant branch           | [ ]      | Branch management for tenant profiles                             |
| v0.0.2  | Event (Extended)        | [ ]      | Extended event capabilty and integrate with (Novu)                |
| v0.0.2  | Contact module          | [ ]      | Module for managing organization, customer and users contact      |
| v0.0.2  | Engagement module       | [ ]      | A central module for viewing and managing all messages and events |
| v0.0.2  | Organization profile    | [ ]      | Define organization contact information                           |
| v0.0.2  | Customer module         | [ ]      | Manage customers and and related entities                         |
| v0.0.2  | Integrated DMS          | [ ]      | Upload and manage files                                           |
| v0.0.2  | Schedule module         | [ ]      | Manage and view schudules for all features                        |
| v0.0.2  | Dashboard customization | [ ]      | Allow dashboard customization                                     |


### Stage 3

| Version | Feature                                            | Progress | Comments                                              |
| ------- | -------------------------------------------------- | -------- | ----------------------------------------------------- |
| v0.0.3  | Task management & processing                       | [ ]      | Task management                                       |
| v0.0.3  | Trip Authority                                     | [ ]      | Assign & Authorize task to dispatcher                 |
| v0.0.3  | Shipment (Courier, Logistics)                      | [ ]      | Create and manage shipments                           |
| v0.0.3  | Catalogs (Courier, Logistics)            | [ ]      | Manage tenant or customer catalog                     |
| v0.0.3  | Passenger (Passenger, Logistics)        | [ ]      | Passengers onboarding and mangement                   |
| v0.0.4  | Finacial module (Courier, Passenger, Logistics)    | [ ]      | Handle Finacial options for users                     |
| v0.0.4  | Shortages (Courier, Logistics)           | [ ]      |                                                       |
| v0.0.4  | Invoice management                                 | [ ]      |                                                       |
| v0.0.4  | Order management                                   | [ ]      |                                                       |
| v0.0.4  | Expense management (Courier, Passenger, Logistics) | [ ]      | Users and dispatchers expense assignment and analysis |


### Stage 4

| Version | Feature                | Progress | Comments                                                          |
| ------- | ---------------------- | -------- | ----------------------------------------------------------------- |
| v0.0.5  | Notification           | [ ]      | Notification settings and mangement                               |
| v0.0.5  | Notification Templates | [ ]      | Email, Chat and SMS notification templates                        |
| v0.0.5  | Warehouse              | [ ]      | Manage warehouses                                                 |
| v0.0.5  | Waybill                | [ ]      | Manage and distribute waybills                                    |
| v0.0.5  | Equipment maintenance  | [ ]      | Schedule and manage maintenance for vehicles and other equipments |
| v0.0.5  | Employees              | [ ]      | Manage Employees                                                  |


### State 5

| Version | Feature        | Progress | Comments                                 |
| ------- | -------------- | -------- | ---------------------------------------- |
| v0.0.6  | Ticket support | [ ]      | Customers ticketing and support module   |
| v0.0.6  | Insurance      | [ ]      | Manage insurance plans and subscriptions |
| v0.0.6  | Contracts      | [ ]      | Manage customers contract                |
| v0.0.6  | Suppliers      | [ ]      | Manage Tenant suppliers                  |
| v0.0.6  | Stocks         | [ ]      | Manage tenants stocks                    |
| v0.0.6  | Custom form    | [ ]      | Create and manage custom forms           |


## Support

To get free support, use github issue tab.

## Prerequisites

In order to run Trace, you need the following configured, secured  and
working Basic Operating System (Linux).

The project uses Docker, dotnet, PostgreSQL, vueJs and leaflet.

## Contributing

Interested in contributing? check out the [contributing guide](./CONTRIBUTING.md).


