using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class Ball
    {
        public Vector2 ballPosistion = new Vector2(250, 250);
        private Random r = new Random();
        public int colorNumber;

        public Ball()
        {
            ballPosistion.X = r.Next(10, 600);
            ballPosistion.Y = r.Next(10, 400);
            colorNumber = r.Next(0, 5);

        }

        public void intersectCheck(int charPositionX, int charPositionY, int n, int m)
        {
            Rectangle blockRectangle = new Rectangle((int)ballPosistion.X,
               (int)ballPosistion.Y, 32, 48);
            Rectangle charRectangle = new Rectangle((int)charPositionX,
                (int)charPositionY, n, m);
            if (charRectangle.Intersects(blockRectangle) == true)
            {
                ballPosistion.X = r.Next(20, 600);
                ballPosistion.Y = r.Next(20, 400);
            }
        }
    }
}
