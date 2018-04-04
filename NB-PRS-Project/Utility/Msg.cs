using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NB_PRS_Project.Utility
{
    public class Msg
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = null;
    }
}