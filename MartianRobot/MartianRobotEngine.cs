using System;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobot
{
    public class MartianRobotEngine
    {
        #region Fields

        public enum orientationTypes
        {
            N,
            E,
            S,
            W,
            Unknown
        };

        private Position _position;

        #endregion

        #region Constructor
        public MartianRobotEngine(string input)
        {
            _position = InputsParser.ParsePosition(input);
        }

        #endregion

        #region Public methods
        public void TurnRight()
        {
            _position.orientation = GetNext(_position.orientation);
        }

        public void TurnLeft()
        {
            _position.orientation = GetPrevious(_position.orientation);
        }

        public string GetOrientation()
        {
            return Enum.GetName(_position.orientation);
        }

        public string GetPosition()
        {
            return string.Format("{0} {1}",_position.x, _position.y);
        }
        #endregion

        #region Private



        private orientationTypes GetNext(orientationTypes currentOrientation)
        {            
            orientationTypes nextOrientation = currentOrientation + 1;            
            if(nextOrientation == orientationTypes.Unknown)
            {
                nextOrientation = orientationTypes.N;
            }
            return nextOrientation;
        }

        private orientationTypes GetPrevious(orientationTypes currentOrientation)
        {
            orientationTypes nextOrientation = currentOrientation - 1;
            if (nextOrientation < orientationTypes.N)
            {
                nextOrientation = orientationTypes.W;
            }
            return nextOrientation;
        }

        #endregion
    }
}
