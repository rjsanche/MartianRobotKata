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

        private Dictionary<instructionTypes, ICommand> _commandsDictionary;

        private int x_max;
        private int y_max;

        #endregion

        public MartianRobotEngine()
        {
            _commandsDictionary = new Dictionary<instructionTypes, ICommand>();
            _commandsDictionary.Add(instructionTypes.F, new ForwardCommand());
            _commandsDictionary.Add(instructionTypes.L, new LeftCommand());
            _commandsDictionary.Add(instructionTypes.R, new RightCommand());
            x_max = 5;
            y_max = 3;

        }

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
                instructionTypes nextCommand = commands.Dequeue();
                if (_commandsDictionary.ContainsKey(nextCommand))
                {
                    _position = _commandsDictionary[nextCommand].Execute(_position, x_max, y_max);
                }
                if(_position.Lost)
                {
                    return;
                }
            }
        }

        public string GetOrientation()
        {
            return Enum.GetName(_position.orientation);
        }

        public string GetPosition()
        {
            return string.Format("{0} {1}",_position.x, _position.y);
        }

        public void SetGridBounds(string s)
        {
            x_max = 5;
            y_max = 3;
        }

        public string GetLostValue()
        {
            return "LOST";
        }

        #endregion

        #region Private



        #endregion
    }
}
