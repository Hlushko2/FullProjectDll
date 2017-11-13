using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC_DataModel.Exeotions
{
    class InvalidTypeOfMatrixException : Exception
    {
        public InvalidTypeOfMatrixException()
        {
        }
        public InvalidTypeOfMatrixException(string message) : base(message)
        {
        }
        public InvalidTypeOfMatrixException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
