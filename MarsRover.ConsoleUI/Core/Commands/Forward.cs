using MarsRover.ConsoleUI.Core.Infrastructure;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Core.Models.Enums;

namespace MarsRover.ConsoleUI.Core.Commands
{
    /// <summary>
    /// ilerle
    /// </summary>
    public class Forward : ICommand
    {
        private Rover _rover;

        public Forward(Rover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            Point newPosition = new Point(_rover.Position);

            switch (_rover.Direction)
            {
                case Direction.North:
                    newPosition.Y += 1;
                    break;
                case Direction.East:
                    newPosition.X += 1;
                    break;
                case Direction.South:
                    newPosition.Y -= 1;
                    break;
                case Direction.West:
                    newPosition.X -= 1;
                    break;
            }

            _rover.SetPosition(newPosition);

        }
    }
}
