using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MarsRover.ConsoleUI.Core.Commands;
using MarsRover.ConsoleUI.Core.Infrastructure;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Core.Models.Enums;

namespace MarsRover.ConsoleUI.Helpers
{
    public static class InputHelper
    {
        ///plato boyutu kontrol edilir. geçerli ise plato oluşturulup gerti döner.
        public static Plateau GetPlateau(string input)
        {

            if (Regex.IsMatch(input, @"^\d+ \d+$"))
            {
                int[] sizes = input.Split(' ').Select(int.Parse).ToArray();
                Point plateauSize = new Point(sizes[0], sizes[1]);
                Plateau plateau = new Plateau(plateauSize);

                return plateau;
            }
            else
            {
                throw new InvalidCastException("error message: invalid plateau size!");
            }
        }

        ///rover'ın posizyon bilgisi kontrol edilir, sorun yok ise pozisyonu geri döner.
        public static Tuple<Point, Direction> GetRoverPosition(string input)
        {
            if (Regex.IsMatch(input, @"^\d+ \d+ [NSEW]$"))
            {
                string[] position = input.Split(' ');

                int x = int.Parse(position[0]);
                int y = int.Parse(position[1]);
                Point point = new Point(x, y);
                Direction direction = (Direction)Enum.ToObject(typeof(Direction), char.Parse(position[2]));

                return new Tuple<Point, Direction>(point, direction);
            }
            else
            {
                throw new InvalidCastException("error message: invalid rover position!");
            }
        }

        ///rover'a verilen yönlendirme komutları kontrol edilir, komutlarda sorun yok ise listesini döner.
        public static List<ICommand> GetRoverCommands(Rover rover, string input)
        {
            List<ICommand> commands = new List<ICommand>();

            if (Regex.IsMatch(input, @"^[LRM]+$"))
            {

                for (int z = 0; z < input.Length; z++)
                {
                    switch (input[z])
                    {
                        case 'M':
                            commands.Add(new Forward(rover));
                            break;
                        case 'L':
                            commands.Add(new Left(rover));
                            break;
                        case 'R':
                            commands.Add(new Right(rover));
                            break;
                        default:
                            throw new Exception("Not a valid instructions");

                    }
                }

            }
            else
            {
                throw new InvalidCastException("error message: invalid directives!");
            }

            return commands;

        }
    }
}
