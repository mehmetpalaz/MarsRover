using Xunit;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Core.Models.Enums;
using MarsRover.ConsoleUI.Core.Commands;
using MarsRover.ConsoleUI.Services;
using System.Collections.Generic;
using System;

namespace MarsRover.Test
{
    public class RoverCommandTests
    {
        [Fact]
        public void TurnLeft()
        {
            CommandInvoker commandInvoker = new CommandInvoker();

            Rover rover = new Rover(new Point(1,3), Direction.North);

            commandInvoker.SetCommand(new Left(rover));
            commandInvoker.Invoke();

            ///rover başarılı bir şekilde sola döndü.
            Assert.Equal(Direction.West, rover.Direction);
        }

        [Fact]
        public void TurnRight()
        {
            CommandInvoker commandInvoker = new CommandInvoker();

            Rover rover = new Rover(new Point(1, 3), Direction.North);

            commandInvoker.SetCommand(new Right(rover));
            commandInvoker.Invoke();

            ///rover başarılı bir şekilde sağa döndü.
            Assert.Equal(Direction.East, rover.Direction);
        }

        [Fact]
        public void MoveForward()
        {
            CommandInvoker commandInvoker = new CommandInvoker();

            Rover rover = new Rover(new Point(1, 3), Direction.South);

            commandInvoker.SetCommand(new Forward(rover));
            commandInvoker.Invoke();

            ///rover başarılı bir şekilde ilerledi.
            Assert.Equal(2, rover.Position.Y);
        }

      
    }
}
