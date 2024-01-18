# Trace [Experimental]

Trace is an end to end trasport and logistics CRM platform, for handling all processes in the trasportation process,
manages the entire trasportation cycle from procurement and distribution to transport,
delivery to the customer and ending with return logistics.

## License

Trace is license under the [Trace License 1.0](./LICENSE.md) and [Business Source License 1.1](./LICENSE\(BSL\).md) [![Business Source License 1.1](https://img.shields.io/badge/license-BSL--1.1-blue.svg?style=flat-square)](./LICENSE\(BSL\).md)

- Agboola Solomon ([abiodun@drolx.com](mailto:abiodun@drolx.com))
- Godwin peter .O ([me@godwin.dev](mailto:me@godwin.dev))

|                       |                               |
| --------------------- | ----------------------------- |
| Licensor:             | drolx Solutions.              |
| Licensed Work:        | The Licensed Work is (c) 2024 Trace |
| Additional Use Grant: | You may make production use of the Licensed Work, provided such use does not include offering the Licensed Work to third parties on a hosted or embedded basis which is competitive with drolx's products |
| Change Date:          | Four years from the date a Licensed version is |
| Change License:       | [Reciprocal Public License \(RPL-1.5\)](./LICENSE\(Change\).md) |

## Core Project Goals
* Unify all transportation and logistics data source
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

| Version | Feature              | Progress   | Comments                                                        |
| ------- | -------------------- | ---------- | --------------------------------------------------------------- |
| v0.0.1  | HTTP Position ingest | Ongoing    | GRPC and HTTP based API ingest for location data                |
| v0.0.1  | Trccar queue ingest  | Ongoing    | Queue based integration with traccar platform                   |
| v0.0.1  | Tenant profile       | Ongoing    | basic setting and profile feature fron tenant accounts          |
| v0.0.1  | Contact module       | Ongoing    | Module for managing organization, customer and users contact    |
| v0.0.1  | CRM module (Basic)   | Ongoing    | A central module for viewing and managing all messages, events  |
| v0.0.1  | Tags                 | Ongoing    | For authorization ans sharing for features                      |
| v0.0.1  | Device               | Ongoing    | IOT devices with compatible usaage e.g GPS, RFID, Sensors, etc  |
| v0.0.1  | Asset - Vehicle      | Ongoing    | Module for managing vehicle as asset                            |
| v0.0.1  | Asset - Trailer      | Ongoing    | Module for managing trailer as asset                            |
| v0.0.1  | Asset - Others       | Ongoing    | Module for managing other asset                                 |
| v0.0.1  | Location management  | Ongoing    | Location management for POI's and geofences                     |
| v0.0.1  | Route management     | Ongoing    | General management and permission assignment                    |
| v0.0.1  | Dashboard            | Planned    | Standard dashboard for initial features                         |
| v0.0.1  | Authentication       | Planned    | Related API and UI for account authentication                   |
| v0.0.1  | Position pipeline    | Ongoing    | Parallel position processing                                    |
| v0.0.1  | Position decoder     | Planned    | Data conversion of position data from compatible sources        |
| v0.0.1  | Position handlers    | Planned    | A step based filtering for recieved positions                   |
| v0.0.3  | Cache manager        | Planned    | A caching pattern for frequently accessed entities              |
| v0.0.4  | Event module         | Planned    | Architectire for processing all events                          |
| v0.0.4  | Event pipeline       | Planned    | Parallel pipeline for transforming event and related triggers   |
| v0.0.5  | Tenant On-boarding   | Planned    | Related API and UI for on-boarding new tenants                  |
| v0.0.6  | Manager UI bootstrap | Planned    | Management application to interact with tenants and platform    |
| v0.0.6  | Manager UI Auth      | Planned    | Management application authentication                           |
| v0.0.7  | Tracking module (*)  | Ongoing    | Bootstrap sub application focused on tracking vehicle location  |
| v0.0.8  | Live tracking        | Planned    | A usable live tracking functionality on the tracking view       |
| v0.0.9  | Tracking events      | Planned    | A websocket based stream for recieving and list recent events   |
| v0.0.9  | Tracking history     | Planned    | A combined view for position and event history trail            |
| v0.0.9  | Tracking reports     | Planned    | A basic report view for tracking module                         |


### Stage 2

| Version | Feature                   | Progress  | Comments                                                      |
| ------- | ------------------------- | --------- | ------------------------------------------------------------- |
| v0.1    | Scheduler module          | Planned   | Links cron based schedules to modules that require it         |
| v0.1    | Scheduler workers         | Planned   | Hosted process to process stored schedules                    |
| v0.1    | Routing pipeline          | Planned   | Steps for handling distance, ETA, traffic, delays, divertion  |
| v0.1    | Tenant branch             | Planned   | Branch management for tenant profiles                         |
| v0.1    | Customer profile          | Planned   | Manage customers and and related entities                     |
| v0.2    | Customer Portal bootstrap | Planned   | Manage customers and and related entities                     |
| v0.2    | Dispatchers               | Planned   | Dispatchers management                                        |
| v0.2    | Dispatch team             | Planned   | Dispatch team management                                      |
| v0.2    | Tag linking               | Planned   | UI and API query to link tags to entities that require it     |
| v0.2    | Authorization resolver    | Planned   | Authorization resolver by evaluating roles, tags, etc         |


### Stage 3

| Version | Feature                   | Progress  | Comments                                 |
| ------- | ------------------------- | --------- | ---------------------------------------- |
| v0.3    | MQTT Position ingest      | Planned   | MQTT based ingest for location data      |
| v0.3    | Event (Extended)          | Planned   | Extended event capabilty                 |
| v0.3    | Task management (basic)   | Planned   | Task management                          |
| v0.3    | Ticket support            | Planned   | Customers ticketing and support module   |
| v0.3    | Dashboard customization   | Planned   | Allow dashboard customization            |
| v0.3    | Employees                 | Planned   | Manage Employees                         |
| v0.3    | Passengers                | Planned   | Passengers onboarding and mangement      |
| v0.3    | Catalogs                  | Planned   | Manage tenant or customer catalog        |
| v0.3    | Warehouse                 | Planned   | Manage warehouses                        |


### Stage 4.0

| Version | Feature                            | Progress | Comments                                |
| ------- | ---------------------------------- | -------- | --------------------------------------- |
| v0.4    | Task management (Position/Routing) | Planned  | Task management                         |
| v0.4    | Task management (dispather)        | Planned  | Integrate dispathcer/drivers to task    |
| v0.4    | Shipment                           | Planned  | Create and manage shipments             |
| v0.4.1  | Trip/Task Authority                | Planned  | Assign & Authorize task to dispatchers  |


### Stage 4.1

| Version | Feature                              | Progress | Comments                              |
| ------- | ------------------------------------ | -------- | ------------------------------------- |
| v0.4.1  | Integrated DMS                       | Planned  | Upload and manage files               |
| v0.4.1  | Minio infrastruture integration      | Planned  | Implements integration to minio       |
| v0.4.1  | Task management (extended relation)  | Planned  | Link task to more modules             |


### Stage 4.2

| Version | Feature             | Progress | Comments                                              |
| ------- | ------------------- | -------- | ----------------------------------------------------- |
| v0.4.2  | Finacial module     | Planned  | Handle Finacial options for users                     |
| v0.4.2  | Shortages           | Planned  | Basic shprtage information management                 |
| v0.4.2  | Expense management  | Planned  | Users and dispatchers expense assignment and analysis |
| v0.5    | Notification        | Planned  | Notification settings and mangement                   |


### Stage 5

| Version | Feature                | Progress   | Comments                                              |
| ------- | ---------------------- | ---------- | ----------------------------------------------------- |
| v0.6    | Order management       | Planned    | Basic order management                                |
| v0.6    | Invoice management     | Planned    | Basic invoice management                              |
| v0.6    | Task (Financial link)  | Planned    | Link task to expense, shortage and others             |
| v0.6    | Task (Catalogue)       | Planned    | Link task to shipped catalogue items                  |
| v0.6    | Notification Templates | Planned    | Email, Chat and SMS notification templates            |
| v0.6    | Waybill                | Planned    | Manage and distribute waybills                        |
| v0.6    | Equipment maintenance  | Planned    | Schedule and manage maintenance for vehicles          |


### State 6

| Version | Feature        | Progress | Comments                                 |
|---------| -------------- | -------- | ---------------------------------------- |
| v0.7    | Ticket support (Extended) | Planned       | Customers ticketing and support module   |
| v0.8    | Insurance      | Planned       | Manage insurance plans and subscriptions |
| v0.8    | Contracts      | Planned       | Manage customers contract                |
| v0.8.1  | Suppliers      | Planned       | Manage Tenant suppliers                  |
| v0.8.2  | Stocks         | Planned       | Manage tenants stocks                    |
| v0.8.3  | Custom form    | Planned       | Create and manage custom forms           |


## Support

To get free support, use github issue tab.

## Prerequisites

In order to run Trace, you need the following configured, secured  and
working Basic Operating System (Linux).

The project uses Docker, dotnet, PostgreSQL, vueJs and leaflet.

## Contributing

Interested in contributing? check out the [contributing guide](./CONTRIBUTING.md).


