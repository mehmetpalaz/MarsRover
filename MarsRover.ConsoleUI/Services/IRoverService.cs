using System.Collections.Generic;
using MarsRover.ConsoleUI.Core.Models;

namespace MarsRover.ConsoleUI.Services
{
    public interface IRoverService
    {
        List<Rover> GetRovers(List<string> inputs);
    }
}
