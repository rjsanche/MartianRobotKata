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
        private List<Tuple<string, orientationTypes>> _orientationParser = new List<Tuple<string, orientationTypes>>
        {
            new Tuple<string, orientationTypes>("N", orientationTypes.N),
            new Tuple<string, orientationTypes>("E", orientationTypes.E),
            new Tuple<string, orientationTypes>("S", orientationTypes.S),
            new Tuple<string, orientationTypes>("W", orientationTypes.W)
        };

        #endregion

        #region Constructor
        public MartianRobotEngine(string orientation)
        {
            _orientation = ParseOrientation(orientation);
        }
        #endregion

        #region Public methods
        public void TurnRight()
        {
            _orientation = GetNext(_orientation);
        }

        public string GetOrientation()
        {
            return Enum.GetName(_orientation);
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
        #endregion
    }
}
