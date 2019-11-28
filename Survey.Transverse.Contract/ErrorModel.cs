using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract
{ 
    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string  Message { get; set; }

        public ErrorModel()
        {

        }

        public ErrorModel(string fieldName,string message)
        {
            Message = message;
            FieldName = fieldName;
        }
    }
}
