using System;
/**
 This class provides the super class for all Lines used in menuscreen classes.
     */
namespace sasd
{
    public class MenuLine
    {
        private String content;
        private String callBack;
        private Boolean isMarked;

        public MenuLine(String content, String callBack)
        {
            this.content = content;
            this.callBack = callBack;
            isMarked = false;
        }

      public String GetContent() {
            return content;
        }

        public String GetCallBack() {
            return callBack;
        }
        public Boolean GetIsMarked() {
            return isMarked;
       
        }
        public void SetIsMarked(Boolean value) {
            isMarked = value;
        }
    }
}
