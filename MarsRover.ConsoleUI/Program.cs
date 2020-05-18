using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.ConsoleUI.Core.Commands;
using MarsRover.ConsoleUI.Core.Models;
using MarsRover.ConsoleUI.Services;
using Microsoft.Extensions.DependencyInjection;
/// <summary>
/// ------ MarsRover ------
/// Rover : object =  position and location (x,y,z)
/// Plateau : object = x,y grid
/// Controls : L Spin left, R spin right and M move
/// Inputs : string input = x,y,z   
/// </summary>
namespace MarsRover.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ////servisler tanımlanıyor.
            ServiceProvider serviceProvider = DependencyInjection.Register();
            IRoverService roverService = serviceProvider.GetService<IRoverService>();

            CommandInvoker commandInvoker = new CommandInvoker();

            List<string> inputs = GetInputs();

            /// verilen bilgilere göre rover'lar oluşturuluyor.
            List<Rover> rovers = roverService.GetRovers(inputs);

            /// oluşan roverlar'ın komutları(sağa dön, sola dön, ilerle) set edilip hareket etmesi sağlanıyor.
            foreach (var rover in rovers)
            {
                foreach (var roverCommand in rover.Commands)
                {
                    commandInvoker.SetCommand(roverCommand);
                    commandInvoker.Invoke();
                }
            }

            WriteOutput(rovers);
            
        }

        private static List<string> GetInputs()
        {
            return new List<string>() {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };
        }

        private static void WriteOutput(List<Rover> rovers){
            var plateau = rovers.First().Plateau;
            Console.WriteLine($"plateau size : {plateau.Size.X}, {plateau.Size.Y}");
            Console.WriteLine();
            Console.WriteLine($"rovers");
            Console.WriteLine("------------");

            var i = 0;
            foreach (var rover in rovers)
            {
                i++;
                Console.WriteLine($"{i}.rover end position : {rover.Position.X}, {rover.Position.Y} - {rover.Direction}");
            }

            Console.ReadKey();
        }
    }
}
