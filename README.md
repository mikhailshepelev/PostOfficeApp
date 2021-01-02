# Post office application

## About
This application is an example of post office web-site. It is developed for managing shipments, bags, parcels and letters in a post office. Main entity of this application is shipment, which can include bags. Bags can contain parcels or letters. Application represents basic GET and POST requests for fetching and creating units from database.

## Installation and usage
Before running an application, make sure that you downloaded and installed:
1. [.Net 5.0.1](https://dotnet.microsoft.com/download)
2. [SQL server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3. [Visual Studio Code](https://code.visualstudio.com)
4. [Node.Js](https://nodejs.org/en/)

Open this repository in Visual Studio Code by clicking on "clone repository" button in "welcome" pane.

### To setup and run back-end
1. Open Visual studio code, open "Extensions" pane and install "C#" and "SQL Server (mssql)" extentions.
2. Open terminal/command line at "API" folder.
3. Run following command to allow use terminal for entity framework:
```bash
dotnet tool install --global dotnet-ef --version 5.0.1
```
4. Establish connection to your database. You can find guide how to setup connection in VS code [here](https://docs.microsoft.com/en-us/sql/tools/visual-studio-code/sql-server-develop-use-vscode?view=sql-server-ver15). Note that you may also need to change connection string depending on your database setup. You can change it in "API\appsettings.Development.json" file, in property named "Default Connection".
5. Run following command to create migrations file with code first database setup:
```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```
6. Run project by executing following command:
```bash
dotnet run
```

### To setup and run front-end
1. Install angular by executing following command in terminal/command line:
```bash
npm install -g @angular/cli
```
2. Open terminal/command line at "Client" folder.
3. Run following command to install all required libraries:
```bash
npm install
```
4. Run the application:
```bash
ng serve --open
```
5. Your browser will be opened at http://localhost:4200. You can navigate through app by using this address.

## Author
[Mikhail Shepelev](https://github.com/mikhailshepelev)
