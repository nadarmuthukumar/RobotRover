using System;
using NUnit.Framework;
using RobertRover;

namespace RobertRoverTest
{
    [TestFixture]
    public class When_Moving_Rover
    {
        [Test]
        public void Valid_Command_Sequence_Movement_Is_Successful()
        {
            string expectedResult = "[ 13 9 N ]";
            IRoverPosition roverPosition = new RoverPosition();
            string result = roverPosition.Move("R1R3L2L1");

            Assert.AreEqual(expectedResult, result.Trim());
        }

        public void Impermissible_Command_Sequence_Causes_Fall_Off_Plateau()
        {
            string expectedResult = "Impermissible Movement";
            IRoverPosition roverPosition = new RoverPosition();
            string result = roverPosition.Move("R1R9L2R9L2R9");

            Assert.AreEqual(expectedResult, result);
        }
    }
}
