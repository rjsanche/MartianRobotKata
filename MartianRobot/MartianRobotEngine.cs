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
        private const string LOST_STR = "LOST";
        private const int MAX_BOUND = 50;
        private const int MAX_COMMANDS = 100;

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
            _position.x = CheckCoordinatesBound(_position.x);
            _position.y = CheckCoordinatesBound(_position.y);
        }

        public void ProcessCommands(string s)
        {
            Queue<instructionTypes> commands = InputsParser.ParseCommands(s);
            int num_commands = 0;
            while (commands.Count > 0 && num_commands < MAX_COMMANDS)
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
                num_commands++;
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
            Tuple<int, int> bounds = InputsParser.ParseBounds(s);
            x_max = CheckCoordinatesBound(bounds.Item1);
            y_max = CheckCoordinatesBound(bounds.Item2);
        }

        public string GetLostValue()
        {
            return _position.Lost?
                LOST_STR :
                string.Empty;
        }

        #endregion

        #region Private

        private int CheckCoordinatesBound(int coordinate)
        {
            return coordinate > MAX_BOUND ? MAX_BOUND : coordinate;
        }

        #endregion
    }
}
