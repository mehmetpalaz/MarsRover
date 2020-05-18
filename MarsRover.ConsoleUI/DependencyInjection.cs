using MarsRover.ConsoleUI.Services;
using Microsoft.Extensions.DependencyInjection;
namespace MarsRover.ConsoleUI
{
    public static class DependencyInjection
    {
        //bağımlılıkları tanımlıyoruz. 
        public static ServiceProvider Register()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
           .AddSingleton<IRoverService, RoverService>()
           .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
