# Chat Room App

This web Application can be used for areal time chat room, where logged users chat. This is focused in back-end code. 

## Technologies

* [.Net core 5](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-five)
* [Identity Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
* [SignalR](https://github.com/SignalR/SignalR) 
* [RabbitMQ](https://www.rabbitmq.com/)

## System Requirements

* Windows 7, 8.1, 10, 11
* Microsoft SQL server LocalDb
* .Net Core 5 SDK
* Visual Studio 2019
* RabbitMQ 

## Installation

Fallow the next steps to get a working copy of the app

1. Fallow the next steps to get a working copy of the app
2. Download the zip package or clone the repository using any git client.
3. Configure RabbitMQ Server client. The App uses the default values of RabbitMQ, so don’t change them. To install it with the default values just follow [these](https://www.rabbitmq.com/download.html) instructions. 
4. Start visual studio 2019 and open the copied solution.
5. Run entity framework migrations to restore the database to the correct version. SQL Server localdb is current database used in the project.
6. Ensure that RabbitMQ is already running, run the ChatRoomApp.Core application to test it. You must create a user to logging and start chatting with another created user in the required browser instances.


## Notes

* If you have any dependency problem, try running the following command in the root folder:

  ```shell
  dotnet restore
  ```