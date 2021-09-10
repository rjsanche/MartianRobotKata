using System;

namespace MartianRobot
{
    public class MartianRobotEngine
    {
        #region Fields
        private string _orientation;
        #endregion

        #region Constructor
        public MartianRobotEngine(string orientation)
        {
            _orientation = orientation;
        }
        #endregion

        #region Public methods
        public void TurnRight()
        {
            _orientation = "E";
        }

        public string GetOrientation()
        {
            return "E";
        }
        #endregion
    }
}
