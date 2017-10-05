using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK
{
    public class FuelSDKException : ApplicationException
    {
        public string[] Errors { get; set; }

        public FuelSDKException()
        { 
        
        }

        public FuelSDKException(string[] errors)
        {
            Errors = errors;
        }
    }
}
