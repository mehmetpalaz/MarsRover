using System.Collections.Generic;
using MarsRover.ConsoleUI.Core.Infrastructure;
using MarsRover.ConsoleUI.Core.Models.Enums;

namespace MarsRover.ConsoleUI.Core.Models
{
    public class Rover
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }
        public Plateau Plateau { get; set; }

        public List<ICommand> Commands { get; set; }

        public Rover(Point position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public void SetPosition(Point point)
        {
            this.Position = point;
        }
    }
}
