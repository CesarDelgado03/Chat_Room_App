using ChatRoomApp.Infrastructure.Hubs;
using ChatRoomApp.Models;
using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.Tests
{
    [TestFixture]
    public class SignalRHubTests
    {
        [Test]
        public async Task SignalR_OnConnect_ShouldReturn1Message()
        {
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);


            ChatRoomHub chatHub = new ChatRoomHub()
            {
                Clients = mockClients.Object
            };

            // act
            await chatHub.Clients.All.SendAsync("receiveMessage", new ChatMessage { Message = "Test Message" });


            // assert
            mockClients.Verify(clients => clients.All, Times.Once);

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "receiveMessage",
                    It.Is<object[]>(o => o != null && o.Length == 1),
                    default),
                Times.Once);
        }

        [Test]
        public async Task SignalR_OnConnect_ShouldReturnRightMessage()
        {
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();
            var expectedMessage = "Test Message";
            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);


            ChatRoomHub chatHub = new ChatRoomHub()
            {
                Clients = mockClients.Object
            };

            // act
            await chatHub.Clients.All.SendAsync("receiveMessage", new ChatMessage { Message = "Test Message" });


            // assert
            mockClients.Verify(clients => clients.All, Times.Once);

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "receiveMessage",
                    It.Is<object[]>(o => o != null && o.Length == 1 && ((ChatMessage)o[0]).Message == expectedMessage),
                    default),
                Times.Once);
        }
    }
}
