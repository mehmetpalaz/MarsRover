using System.Collections.Generic;
using System.Linq;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Helpers;

namespace MarsRover.ConsoleUI.Services
{
    public class RoverService : IRoverService
    {
        public RoverService()
        {
        }

        public List<Rover> GetRovers(List<string> inputs)
        {
            List<Rover> rovers = new List<Rover>();

            Plateau plateau = InputHelper.GetPlateau(inputs[0]);

            ///plato boyutu listeden kaldırılır.
            ///listede rover'lara ait başlangıç pozisyonları ve direktifler kalır.
            inputs.RemoveAt(0);

            ///plato boyutu diziden çıkartılınca, geri kalan dizi elemanlarının 2 ye bölümü
            ///kaç farklı rover olduğunu verir.
            int roverCount = inputs.Count() / 2;

            ///rover sayısı kadar döngüyer girilir, döngüde rover'ların başlangıç posizyonları ve
            ///nasa tarafından verilen komutlar belirlenip roverlar oluşturulur.
            for (int i = 0; i < roverCount; i++)
            {
                string roverPositionString = inputs[i * 2];
                string roverDirectionsString = inputs[(i * 2) + 1];

                var roverPosition = InputHelper.GetRoverPosition(roverPositionString);

                Rover rover = new Rover(roverPosition.Item1, roverPosition.Item2);
                rover.Plateau = plateau;
                rover.Commands = InputHelper.GetRoverCommands(rover, roverDirectionsString);

                rovers.Add(rover);
            }

            return rovers;

        }
    }
}
