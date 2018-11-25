using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Global.Models
{
    public class ResultModel : PayloadModel
    {

        public ResultStatus Status;
        public String Message;

        public ResultModel(ResultStatus status, String message = "No Message.")
        {
            Message = message;
            Status = status;
        }

        public ResultModel()
        {
        }
    }


    public enum ResultStatus
    {
        [field: Description("Unkown Error")]
        Error,

        [field: Description("Success")]
        Fail,

        [field: Description("Success")]
        Success
    }
}
