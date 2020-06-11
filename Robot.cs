using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMartianRobots
{
    class Robot
    {
        public Position Position { get; set; }
        public bool IsLost { get; set; }
        public Robot(int x, int y, Directions direction)
        {
            this.Position = new Position(x, y, direction);
        }
        public Robot()
        {
            IsLost = false;
        }
        private void RotateRight()
        {
            switch (this.Position.Direction)
            {
                case Directions.N:
                    this.Position.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Position.Direction = Directions.S;
                    break;
                case Directions.S:
                    this.Position.Direction = Directions.W;
                    break;
                case Directions.W:
                    this.Position.Direction = Directions.N;
                    break;
            }
        }
        private void RotateLeft()
        {
            switch (this.Position.Direction)
            {
                case Directions.N:
                    this.Position.Direction = Directions.W;
                    break;
                case Directions.W:
                    this.Position.Direction = Directions.S;
                    break;
                case Directions.S:
                    this.Position.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Position.Direction = Directions.N;
                    break;
            }
        }
        private void MoveForward()
        {
            switch (this.Position.Direction)
            {
                case Directions.N:
                    this.Position.Y += 1;
                    break;
                case Directions.S:
                    this.Position.Y -= 1;
                    break;
                case Directions.E:
                    this.Position.X += 1;
                    break;
                case Directions.W:
                    this.Position.X -= 1;
                    break;
                default:
                    break;
            }
        }


        public void Move(Commands command, List<Position> blackLIst)
        {
            switch (command)
            {
                case Commands.R:
                    this.RotateRight();
                    break;
                case Commands.L:
                    this.RotateLeft();
                    break;
                case Commands.F:
                    {
                        bool blackMarker = false;
                        foreach (var blackPosition in blackLIst)
                        {
                            if (this.Position.X == blackPosition.X && this.Position.Y == blackPosition.Y && this.Position.Direction == blackPosition.Direction)
                            {
                                blackMarker = true;
                                break;
                            }
                        }
                        if (!blackMarker)
                        {
                            this.MoveForward();
                        }
                        
                        break;
                    }
                    
                default:
                    throw new ArgumentException("Command is not valid");
                    
            }
        }

    }
}
