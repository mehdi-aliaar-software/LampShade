using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace _0.Framework.Application
{
    public class OperationResult
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSucceeded=false;
        }
        public OperationResult Succeeded(string message="the operation succeeded....!")
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message = "failed operation ... there is something wrong with the operation ! ")
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}
