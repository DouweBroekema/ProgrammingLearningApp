using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class Character
    {
        public Vector2Int Position;
        public Rotation Rotation;

        public Character(Vector2Int _startPosition = default, Rotation _startRotation = Rotation.East)
        {
            Position = _startPosition;
            Rotation = _startRotation;
        }
    }

    public enum Rotation
    {
        South,
        East,
        North,
        West
    }
    public struct Vector2Int
    {
        public int x, y;
        public Vector2Int(int x, int y)
        {
            this.x = x; this.y = y; 
        }


    }
}
