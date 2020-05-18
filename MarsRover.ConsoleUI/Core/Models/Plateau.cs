namespace MarsRover.ConsoleUI.Core.Models
{
    public class Plateau
    {
      public  Point Size { get; set; }

        public Plateau(Point size)
        {
            this.Size = size;
        }
    }
}
