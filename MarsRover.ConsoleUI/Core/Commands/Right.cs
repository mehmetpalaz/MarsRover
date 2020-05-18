using MarsRover.ConsoleUI.Core.Infrastructure;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Core.Models.Enums;

namespace MarsRover.ConsoleUI.Core.Commands
{
    /// <summary>
    /// sağa dön
    /// </summary>
    public class Right : ICommand
    {
        private Rover _rover;

        public Right(Rover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            switch (_rover.Direction)
            {
                case Direction.North:
                    _rover.Direction = Direction.East;
                    break;
                case Direction.East:
                    _rover.Direction = Direction.South;
                    break;
                case Direction.South:
                    _rover.Direction = Direction.West;
                    break;
                case Direction.West:
                    _rover.Direction = Direction.North;
                    break;
            }
        }
    }
}
