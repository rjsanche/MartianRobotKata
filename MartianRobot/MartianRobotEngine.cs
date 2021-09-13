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

        public enum instructionTypes
        {
            R,
            L,
            F,            
            Unknown
        };

        private Position _position;

        #endregion

        #region Public methods

        public void SetInitialPosition(string s)
        {
            _position = InputsParser.ParsePosition(s);
        }

        public void ProcessCommands(string s)
        {
            Queue<instructionTypes> commands = InputsParser.ParseCommands(s);
            while (commands.Count > 0)
            {
                if (commands.Dequeue() == instructionTypes.F)
                {
                    _position.x = _position.x + 1;
                }
            }
        }

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
