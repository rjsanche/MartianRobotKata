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
            robot.TurnRight();
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
            robot.TurnLeft();
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
            robot.SetInitialPosition("1 1 N");
            robot.ProcessCommands("F");
            //act
            var result = robot.GetPosition();
            //assert
            Assert.AreEqual(expected, result);
        }

    }
}
