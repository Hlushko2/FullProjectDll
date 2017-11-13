using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC_DataModel.Exeotions
{
    class InvalidTypeOfPositionException : Exception
    {
        public InvalidTypeOfPositionException()
        {
        }
        public InvalidTypeOfPositionException(string message) : base(message)
        {
        }
        public InvalidTypeOfPositionException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
