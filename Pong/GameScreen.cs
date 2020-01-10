using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sasd
{
    class GameScreen : Screen
    {
        int [] dim;
        private IO io;

        Player1 p1 = new Player1();
        Player2 p2 = new Player2();

        Ball ball = new Ball();
        

        public GameScreen(IO io, Management inManagement)
        {
            SetManagement(inManagement);
            SetIO(io);
            ball.CurDirection = 4;
			ball.SetXPos(15);
			ball.SetYPos(15);
			p2.SetXPos(30);
			p2.SetYPos(1);
			setDim (31, 25);
        }
        

        public int[] getDim()
        {
            
            int[] rDim = dim;
            return rDim;
        }

        public void setDim(int inXDim,int inYDim)
        {
            dim[0] = inXDim;
            dim[1] = inYDim;
        }
        //TODO diese Methode wird im MainLoop aufgerufen und aktualisiert den Screen, siehe Management.cs:24
        public override void Redraw()
        {
            Console.Clear();
            Console.SetCursorPosition(p1.GetXPos(), p1.GetYPos());
            Console.Write(p1.GetSprite());

            Console.SetCursorPosition(p2.GetXPos(), p2.GetYPos());
            Console.Write(p2.GetSprite());

            Console.SetCursorPosition(ball.GetXPos(), ball.GetYPos());
            Console.Write(ball.GetSprite());
        }

        public override string Submit()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
			if (p1.GetYPos () > 1)
            	p1.moveU();
        }
        public override void Down()
        {
			if(p1.GetYPos()< getDim()[0])
            p1.moveD();
        }

        public override void Back()
        {//TODO sollte IO.CloseConnections() callen!!!!
			io.CloseConnection();
        }

		public override String Submit2()

		{
			throw new NotImplementedException();
		}

		public override void Down2()
		{
			if(p1.GetYPos()< getDim()[0])
			p2.moveD ();
		}

		public override void Up2()
		{
			if (p2.GetYPos () > 1)
			p2.moveU ();
		}
        public IO GetIO()
        {
            return io;
        }

        public void SetIO(IO io)
        {
            this.io = io;
        }

        public void ballroutine()
        {
            
            ball.move();
        }
        
    }
}
