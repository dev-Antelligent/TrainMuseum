using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMuseum
{
    class GlobalClass
    {
        public static string userid = "";

        private static string Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        public static string museumtitle = "";
        private static string museumTitle
        {
            get { return museumtitle; }
            set { museumtitle = value; }
        }

        public static string boardtitle = "";
        private static string boardTitle
        {
            get { return boardtitle; }
            set { boardtitle = value; }
        }
    }
}
