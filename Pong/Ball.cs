using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sasd
{
    class Ball:GameObject
    {
        public int CurDirection;
        public Ball()
        {
            SetSprite("o");
        }
		public void move(int dimY)
		{
			if (GetYPos () == 1 || GetYPos() == dimY)
				bounceWall ();
			else {
				switch (CurDirection) {
				case 0:                                         //NW
					SetXPos (GetXPos () - 1);                 
					SetYPos (GetYPos () - 1);                 
					break;                                   
				case 1:                                         //N
					SetYPos (GetYPos () - 1);
					break;
				case 2:                                         //NE
					SetXPos (GetXPos () + 1);                     
					SetYPos (GetYPos () - 1);
					break;
				case 3:                                         //E
					SetXPos (GetXPos () + 1);
					break;
				case 4:                                         //SE
					SetXPos (GetXPos () + 1);
					SetYPos (GetYPos () + 1);
					break;
				case 5:                                         //S
					SetYPos (GetYPos () + 1);
					break;
				case 6:                                         //SW
					SetXPos (GetXPos () - 1);
					SetYPos (GetYPos () + 1);
					break;
				case 7:                                         //W
					SetXPos (GetXPos () - 1);
					break;
				default: 
					break;
				}
			}
		}
       	public void bounceWall()
            {
                switch(CurDirection)
                {
                    case 0:
                        CurDirection = 2;
                        break;
                    case 1:
                        CurDirection = 5;
                        break;
                    case 2:
                        CurDirection = 0;
                        break;
                    case 3:
                        CurDirection = 3;
                        break;
                    case 4:
                        CurDirection = 6;
                        break;
                    case 5:
                        CurDirection = 1;
                        break;
                    case 6:
                        CurDirection = 4;
                        break;
                    case 7:
                        CurDirection = 7;
                        break;
                    default:
                        break;
             
                }
            }
     	public void bouncePadel()
            {
                switch (CurDirection)
                {
                    case 0:
                        CurDirection = 1;
                        break;
                    case 1:
                        CurDirection = 1;
                        break;
                    case 2:
                        CurDirection = 1;
                        break;
                    case 3:
                        CurDirection = 7;
                        break;
                    case 4:
                        CurDirection = 6;
                        break;
                    case 5:
                        CurDirection = 5;
                        break;
                    case 6:
                        CurDirection = 4;
                        break;
                    case 7:
                        CurDirection = 3;
                        break;
                    default:
                        break;
                }
            }
            
            public void checkPadelCol(int p1Y,int p2Y)
            {
                if (GetXPos() == 0)
                {
                if (GetYPos() >= p1Y && GetYPos() <= p1Y + 3)
                    {
                        bouncePadel();
                    }
				else
				{
					SetXPos(15);
					SetYPos (15);
                }
            }

    }
}
}