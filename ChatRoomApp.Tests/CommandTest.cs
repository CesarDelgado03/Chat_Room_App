﻿using ChatRoomApp.Helpers;
using ChatRoomApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.Tests
{
    [TestFixture]
    class CommandTest
    {
        [Test]
        public void Should_Correctly_DetectRightful_Command()
        {
            // arrange
            ChatMessage msg = new ChatMessage() { Message = "/stock=AAPL.US" };
            bool isCommand = true;

            // act
            bool testIfCommand = msg.IsCommand();

            // assert
            Assert.AreEqual(testIfCommand, isCommand);
        }

        [Test]
        public void Should_Correctly_DetectNonCommand_Command()
        {
            // arrange
            ChatMessage msg = new ChatMessage() { Message = "This is not a valid expected command." };
            bool isCommand = false;

            // act
            bool testIfCommand = msg.IsCommand();

            // assert
            Assert.AreEqual(testIfCommand, isCommand);
        }

        [Test]
        public void Should_Correctly_Get_Command()
        {
            // arrange
            ChatMessage msg = new ChatMessage() { Message = "/stock=AAPL.US" };
            string resultCommand = "/stock=AAPL.US";

            // act
            string testCommand = msg.GetCommand();

            // assert
            Assert.AreEqual(testCommand, resultCommand);
        }

        [Test]
        public void Should_Return_Null_On_Invalid_Command()
        {
            // arrange
            ChatMessage msg = new ChatMessage() { Message = "This is not a valid expected command." };
            string resultCommand = null;

            // act
            string testCommand = msg.GetCommand();

            // assert
            Assert.AreEqual(testCommand, resultCommand);
        }
    }
}
