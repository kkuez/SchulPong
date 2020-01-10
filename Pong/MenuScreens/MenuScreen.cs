using System;
using System.Collections.Generic;
/**
 This class provides the super class for all menu related consolescreens used.
     */
namespace sasd
{
    public abstract class MenuScreen : Screen
    {
        private List<MenuLine> lineList;

        private IO io;
        
        public abstract override void Back();

        public override void Down()
        {
            int indexOfCurrentlyMarkedLine = lineList.IndexOf(GetMarkedLine());
            if (indexOfCurrentlyMarkedLine != lineList.Count - 1)
            {
                lineList[indexOfCurrentlyMarkedLine].SetIsMarked(false);
                lineList[indexOfCurrentlyMarkedLine + 1].SetIsMarked(true);
            }
        }

        public abstract override String Submit();

        public override void Up()
        {
            int indexOfCurrentlyMarkedLine = lineList.IndexOf(GetMarkedLine());
            if(indexOfCurrentlyMarkedLine != 0) {
                lineList[indexOfCurrentlyMarkedLine].SetIsMarked(false);
                lineList[indexOfCurrentlyMarkedLine - 1].SetIsMarked(true);
            }
        }

        public override void Redraw() {
            Console.Clear();
            foreach (MenuLine menuLine in lineList) {
                if (menuLine.GetIsMarked()) {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(menuLine.GetContent());
        }
        }

        public MenuLine GetMarkedLine() {
            MenuLine markedLine = null;
        foreach(MenuLine menuLine in lineList)
            {
                if (menuLine.GetIsMarked()) {
                    markedLine = menuLine;
                }
            }
            return markedLine;
        }

        //GETTER SETTER

        public List<MenuLine> GetLineList() {
            return lineList; 
        }

        public void SetLineList(List<MenuLine> lineList) {
            this.lineList = lineList;
        }

        public IO GetIO()
        {
            return io;
        }

        public void SetIO(IO io) {
            this.io = io;
        }
		public override string Submit2 ()
		{
			throw new NotImplementedException ();
		}
		public override void Down2 ()
		{
			throw new NotImplementedException ();
		}
		public override void Up2 ()
		{
			throw new NotImplementedException ();
		}
    }

}
