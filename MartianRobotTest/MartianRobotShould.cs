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
            MartianRobotEngine robot = new MartianRobotEngine("N");
            var expected = "E";
            //act
            robot.TurnRight();
            var result = robot.GetOrientation();
            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
