using MarsRover.ConsoleUI.Core.Infrastructure;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Core.Models.Enums;

namespace MarsRover.ConsoleUI.Core.Commands
{
    /// <summary>
    /// sola dön
    /// </summary>
    public class Left : ICommand
    {
        private Rover _rover;

        public Left(Rover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            switch (_rover.Direction)
            {
                case Direction.North:
                    _rover.Direction = Direction.West;
                    break;
                case Direction.East:
                    _rover.Direction = Direction.North;
                    break;
                case Direction.South:
                    _rover.Direction = Direction.East;
                    break;
                case Direction.West:
                    _rover.Direction = Direction.South;
                    break;
            }
        }
    }
}
