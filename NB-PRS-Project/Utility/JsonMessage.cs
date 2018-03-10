using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NB_PRS_Project.Utility
{
    public class JsonMessage
    {
        public string Result { get; set; }
        public string Message { get; set; }

        public JsonMessage(string Result, string Message)
        {
            this.Result = Result;
            this.Message = Message;
        }
    }
}