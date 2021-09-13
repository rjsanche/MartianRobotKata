using MartianRobot;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianRobotTest
{
    [TestClass]
    public class MartianRobotShould
    {
        [TestMethod]
        public void TurnRightWhenReceiveRightInstruction()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expected = "E";
            robot.SetInitialPosition("N");
            //act
            robot.ProcessCommands("R");
            var result = robot.GetOrientation();
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TurnLeftWhenReceiveLeftInstruction()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expected = "W";
            robot.SetInitialPosition("N");
            //act
            robot.ProcessCommands("L");
            var result = robot.GetOrientation();
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenSettingInitialPositionThenReturnSamePosition()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expected = "1 1";
            robot.SetInitialPosition("1 1");
            //act
            var result = robot.GetPosition();
            //assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void WhenSettingInitialOrientationThenReturnSameOrientation()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expected = "N";
            robot.SetInitialPosition("N");
            //act
            var result = robot.GetOrientation();
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GoHeadWhenReceiveFInstruction()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expected = "2 1";
            robot.SetInitialPosition("1 1 E");
            robot.ProcessCommands("F");
            //act
            var result = robot.GetPosition();
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenReceiveFInstructionAndOrientationNorthGoUp()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expectedPosition = "1 2";
            var expectedOrientation = "N";
            robot.SetInitialPosition("1 1 N");
            robot.ProcessCommands("F");
            //act
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();
            //assert
            Assert.AreEqual(expectedPosition, position);
            Assert.AreEqual(expectedOrientation, orientation);

        }

        [TestMethod]
        public void WhenReceiveRInstructionsAndOrientationEastThenGoEast()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expectedPosition = "1 1";
            var expectedOrientation = "S";
            robot.SetInitialPosition("1 1 E");
            robot.ProcessCommands("R");
            //act
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();
            //assert
            Assert.AreEqual(expectedPosition, position);
            Assert.AreEqual(expectedOrientation, orientation);

        }

        [TestMethod]
        public void WhenReceiveR_F_InstructionsAndOrientationEastThenGoEastOneSquare()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expectedPosition = "1 0";
            var expectedOrientation = "S";
            robot.SetInitialPosition("1 1 E");
            robot.ProcessCommands("RF");
            //act
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();
            //assert
            Assert.AreEqual(expectedPosition, position);
            Assert.AreEqual(expectedOrientation, orientation);

        }

        [TestMethod]
        public void WhenReceiveR_F_R_F_InstructionsAndOrientationEastThenGoTo_0_0_Position()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expectedPosition = "0 0";
            var expectedOrientation = "W";
            robot.SetInitialPosition("1 1 E");
            robot.ProcessCommands("RFRF");
            //act
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();
            //assert
            Assert.AreEqual(expectedPosition, position);
            Assert.AreEqual(expectedOrientation, orientation);

        }

        [TestMethod]
        public void WhenReceiveSeveralInstructionsAndOrientationEastThenGoToInitialPosition()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expectedPosition = "1 1";
            var expectedOrientation = "E";
            robot.SetInitialPosition("1 1 E");
            robot.ProcessCommands("RFRFRFRF");
            //act
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();
            //assert
            Assert.AreEqual(expectedPosition, position);
            Assert.AreEqual(expectedOrientation, orientation);

        }

        [TestMethod]
        public void WhenReceiveSeveralInstructionsGetLost()
        {
            //arrange
            MartianRobotEngine robot = new MartianRobotEngine();
            var expectedPosition = "3 3";
            var expectedOrientation = "N";
            var expectedLostValue = "LOST";
            robot.SetGridBounds("5 3");
            robot.SetInitialPosition("3 2 N");
            robot.ProcessCommands("FRRFLLFFRRFLL");
            //act
            var position = robot.GetPosition();
            var orientation = robot.GetOrientation();
            var lostValue = robot.GetLostValue();
            //assert
            Assert.AreEqual(expectedPosition, position);
            Assert.AreEqual(expectedOrientation, orientation);
            Assert.AreEqual(expectedLostValue, lostValue);

        }


    }

}
