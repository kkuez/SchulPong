using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sasd
{   //TODO abstract
    class GameObject
    {
        private int xPos, yPos;
        private string Sprite;
        private string inId;
        private string id;

        public void SetXPos(int x)
        {
            xPos = x;
        }

        public int GetXPos()
        {
            return xPos;
        }

        public void SetYPos(int y)
        {
            yPos = y;
        }

        public int GetYPos()
        {
            return yPos;
        }

        public void SetSprite(string inSprite)
        {
            Sprite = inSprite;
        }

        public string GetSprite()
        {
            return Sprite;
        }
        public string serialize()
        {
            string SerialS;

            SerialS = "<" + id + ">" + xPos + "|" + yPos + "</" + id + ">";
            return SerialS;
        }

        public void deserialize(string SerialS)
        {
            string[] XY;
            XY = SerialS.Split(new Char[] { '|' });
            inId = XY[0];
            if (inId == id)
            {
                xPos = Convert.ToInt16(XY[1]);
                yPos = Convert.ToInt16(XY[2]);
            }
        }
         public void moveD()
        {
            yPos++;
 
        }
        public void moveU()
        {
            yPos--;
        }
        public void setId(string inId)
        {
            id = inId;
        }
    }
}
