# Chat Room App

This web Application can be used for areal time chat room, where logged users chat. This is focused in back-end code. 

## Technologies

* [.Net core 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
* [Identity Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
* [SignalR](https://github.com/SignalR/SignalR) 
* [RabbitMQ](https://www.rabbitmq.com/)

## System Requirements

* Microsoft SQL server LocalDb
* .Net Core 5 SDK
* Visual Studio 2019
* RabbitMQ 

## Installation

Follow the next steps to get a working copy of the app

1. Download the zip package or clone the repository using any git client.
2. Configure RabbitMQ Server client. The App uses the default values of RabbitMQ, so don’t change them. To install it with the default values just follow [these](https://www.rabbitmq.com/download.html) instructions. 
3. Start visual studio 2019 and open the downloaded solution.
4. Run entity framework migrations to restore the database to the correct version. SQL Server localdb is current database used in the project.
5. Ensure that RabbitMQ is already running, run the ChatRoomApp.Core application to test it. You must create a user to logging and start chatting with another created user in the required browser instances.


## Notes

* If you have any dependency problem, try running the following command in the root folder:

  ```shell
  dotnet restore
  ```