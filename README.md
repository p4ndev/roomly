# Overview

This open-source application enables you to manage physical space reservations in various environments such as offices, factories, schools, and more.

Users can view available physical spaces, apply filters, make reservations with time conflict validation, and track existing reservations via an interactive dashboard.

The system will be provided as a monolith, packaged in a simple Docker container, allowing for seamless deployment into your infrastructure and hassle-free operation.

# Project

In order to check the requirement and status please open the board below:

- [Configuration](https://github.com/users/p4ndev/projects/8/views/1?filterQuery=tag%3AConfiguration)
- [Setup](https://github.com/users/p4ndev/projects/8/views/1?filterQuery=tag%3ASetup)
- [Dashboard](https://github.com/users/p4ndev/projects/8/views/1?filterQuery=tag%3ADashboard)
- [Management](https://github.com/users/p4ndev/projects/8/views/1?filterQuery=tag%3AManagement)

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