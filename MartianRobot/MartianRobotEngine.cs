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

        private orientationTypes _orientation;
        private string _position = string.Empty;


        #endregion

        #region Constructor
        public MartianRobotEngine(string orientation)
        {            
            string[] inputs = orientation.Split(" ");
            foreach(string s in inputs)
            {
                if(Char.IsLetter(s[0]))
                {
                    _orientation = ParseOrientation(orientation);
                }
            }
            _position = "1 1";


        }
        #endregion

        #region Public methods
        public void TurnRight()
        {
            _orientation = GetNext(_orientation);
        }

        public void TurnLeft()
        {
            _orientation = GetPrevious(_orientation);
        }

        public string GetOrientation()
        {
            return Enum.GetName(_orientation);
        }

        public string GetPosition()
        {
            return _position;
        }
        #endregion

        #region Private

        private orientationTypes ParseOrientation(string orientation)
        {
            orientationTypes result = orientationTypes.Unknown;
            Enum.TryParse<orientationTypes>(orientation, true, out result);
            return result;
        }

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
