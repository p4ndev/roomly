# Overview

This open-source application enables you to manage physical space reservations in various environments such as offices, factories, schools, and more.

Users can view available physical spaces, apply filters, make reservations with time conflict validation, and track existing reservations via an interactive dashboard.

The system will be provided as a monolith, packaged in a simple Docker container, allowing for seamless deployment into your infrastructure and hassle-free operation.

# Features

## Setup

- **Startup**
Review current installation (once it is available).

- **Installation**
Application settings like name and logotype.

	- Name: project title
	- Logotype: brand awareness

It is possible to have only one installation per container.

- **Access**
Passwords available for future usage.

	- Administrator password access
	- Coordinator password access
	- Viewer password access

It must not be shown twice, so please save it carefuly.

- **Authentication**
Initial section where users can connect based on previous password generated.

## Management

- **Reservation**
Page section designed to lock agenda for a specific room based on a date (not conflicted).

	- Logotype
	- Room: available on the system
	- Description: simplest and detailed objective
	- Date and Time: available on the system
	- Attendees: not conflicted with the capacity

- **Room Detail**
Float section to display on right side of the page with all room details and schedules.

- **Room List**
Page section dedicated to list all available room, and allow administrator to add, remove any previous data.

	- Logotype
	- Grid with all the rooms available
	- Icon to display the grid on float panel (room detail section)
	- Icon to remove the current room on entire system (hard delete / cascade)

- **New Room**
Float section to display on right side of the page with the form to add a new room.

	- Room name (friendly)
	- Capacity (max number)
	- Week availability (days)
	- Amenities (tags with possibilities to add new or reuse)
	
## Dashboard

- **Home**
List of all rooms no matter how its agenda is (locker or not).

	- Logotype
	- Search bar on right top
	- Hamburger menu
	- Grid with all rooms (3 or 2 per row)

- **Search**
Allow user to find rooms by name, capacity, amenities data.

	- Available for all roles

- **Menu**
Display menu items based on roles as a hamburger on right top side.

	- Viewer: home, sign out
	- Coordinator: home, reservation and sign out
	- Administrator: home, reservation, room, export and sign out

# Technical Specification

- **Frontend**: Angular
- **UIX**: Angular Material
- **Backend**: .Net Core
- **Database**: Offline
- **Quality**: Jasmine / Karma
- **Communication**: Rest
- **Codebase**: Git / Gitflow
- **Design / Component**:
  - Lazy Loading
  - Angular Router
  - Reactive Forms

# Command

## 1) Data

`dotnet ef migrations add <NAME> --output-dir Data/Migrations`

Migration name after build project with a Context configured

`dotnet ef database update`

Create a offline database file within the wwwroot/data folder

## 2) Backend

`dotnet run` or `dotnet watch`

Helper Dotnet cli run the api

## 3) Frontend

`ng g c <MODULE>/<COMPONENT> --module=<MODULE_NAME/MODULE_NAME.module.ts>`

Helper Angular cli to add component on specific module

`ng serve -o`

Development version with browser opened

`ng build`

It will create a browser folder within the wwwroot, please extract everything to wwwroot

## 4) Test

`ng test --watch=false --browsers=ChromeHeadless`

Run every test without browser opened

`ng test --include=<FOLDER/FILE.spec.ts>`

Run specific test with browser opened

`dotnet test`

Run every test on Platform.test project

# Roadmap

- Integration with Google, Exchange, Apple, Android
- Email notification with reservation details
- Internationalization support (i18n)
- Import / Export initial data