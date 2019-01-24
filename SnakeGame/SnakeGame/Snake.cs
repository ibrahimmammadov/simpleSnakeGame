using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class Snake
    {
        snake_parts[] snake_Part;
        int snake_long = 2;
        Direction dir;
        public Snake()
        {
            snake_Part = new snake_parts[2];
            snake_Part[0] = new snake_parts(100, 130);
            snake_Part[1] = new snake_parts(110, 130);
            //snake_Part[2] = new snake_parts(120, 130);
            //snake_Part[3] = new snake_parts(130, 130);
            //snake_Part[4] = new snake_parts(140, 130);
            //snake_Part[5] = new snake_parts(150, 130);
        }
        public void move(Direction direction)
        {
            dir = direction;
            if (direction._x == 0 && direction._y == 0)
            {

            }
            else
            {
                for (int i = snake_Part.Length-1; i>0; i--)
                {
                    snake_Part[i] = new snake_parts(snake_Part[i-1].x_, snake_Part[i-1].y_);
                }
                snake_Part[0] = new snake_parts(snake_Part[0].x_ + (direction._x), snake_Part[0].y_ + (direction._y));
               
            }
        }

        public void grow()
        {
            Array.Resize(ref snake_Part, snake_Part.Length + 1);
            snake_Part[snake_Part.Length - 1] = new snake_parts(snake_Part[snake_Part.Length - 2].x_ - dir._x, snake_Part[snake_Part.Length - 2].y_ - dir._y);
            snake_long++;
        }

        public Point GetDir(int numb)
        {
            return new Point(snake_Part[numb].x_, snake_Part[numb].y_);
        }

        public int SnakeLong
        {
            get
            {
                return snake_long;
            }
        }
    }
    class snake_parts
    {
        public int x_;
        public int y_;
        public readonly int size_x;
        public readonly int size_y;
        public snake_parts(int x, int y)
        {
            x_ = x;
            y_ = y;
            size_x = 10;
            size_y = 10;
        }
    }

    class Direction
    {
        public readonly int _x;
        public readonly int _y;
        public Direction(int x, int y)
        {
            _x = x;
            _y = y;
        }

    }
}
