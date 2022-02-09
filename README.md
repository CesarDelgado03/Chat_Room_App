# Chat Room App

This is a real time chat room where logged users can chat between themselves

## Technologies

* [.Net core 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
* [Identity Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
* [SignalR](https://github.com/SignalR/SignalR) 
* [RabbitMQ](https://www.rabbitmq.com/)

## System Requirements

* [Microsoft SQL server LocalDb](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)
* .Net Core 5 SDK
* Visual Studio 2019
* RabbitMQ 

## Installation

Follow the next steps to get a working copy of the app

1. Clone the repository.
2. Configure RabbitMQ with the default settings following these [https://www.rabbitmq.com/download.html](https://www.rabbitmq.com/download.html) instructions. If you want to set your own settings, change the credentials in the appsettings.json 
3. Execute migrations using: 
```shell 
Update-Database -Context ApplicationDbContext
``` 
or 
```shell
dotnet ef database update --context ApplicationDbContext
```
4. Run the ChatRoomApp and the CommandBot
5. Ensure that RabbitMQ is running, register some users and start testing

## Notes

* If you have any dependency problem, try running the following command in the root folder:

  ```shell
  dotnet restore
  ```