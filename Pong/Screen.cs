using System;
using System.Collections.Generic;
/**
 This class provides the super class for all consolescreens used.
     */

namespace sasd
{
    public abstract class Screen
    {
        private List<String> screenList;

        private Management management;

        public String Ask(String question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public abstract String Submit();

        public abstract void Down();

        public abstract void Up();

		public abstract String Submit2();

		public abstract void Down2();

		public abstract void Up2();

        public abstract void Back();

        public abstract void Redraw();

        public Management GetManagement() {
            return management;
        }

        public void SetManagement(Management management) {
        this.management = management;
        }
    }
}
