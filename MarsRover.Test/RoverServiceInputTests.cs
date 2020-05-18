using System;
using System.Collections.Generic;
using MarsRover.ConsoleUI.Services;
using Xunit;

namespace MarsRover.Test
{
    public class RoverServiceInputTests
    {
        [Theory]
        [MemberData(nameof(ValidInputs))]
        public void If_Given_Valid_Input_Return_RoverList(List<string> inputs)
        {
            var roverService = new RoverService();

            Assert.NotNull(roverService.GetRovers(inputs));
        }

        [Theory]
        [MemberData(nameof(InValidInputs))]
        public void If_Given_Invalid_Input_Return_InvalidCastException(List<string> inputs)
        {
            var roverService = new RoverService();

            Assert.Throws<InvalidCastException>(() => roverService.GetRovers(inputs));
        }

        #region static variables
        public static IEnumerable<object[]> ValidInputs
        {
            get
            {
                return new[]{
                new object[] {  new List<string>(){"5 5", "1 2 N", "LMLMLMLMM", "3 4 S", "RMRMRMRMM" } }
                };

            }
        }

        public static IEnumerable<object[]> InValidInputs
        {
            get
            {
                return new[]{
                new object[] {  new List<string>(){"5 5", "1 2 K", "BLABLA", "3 4 S", "BLABAL" } }
                };

            }
        }
        #endregion
    }
}
