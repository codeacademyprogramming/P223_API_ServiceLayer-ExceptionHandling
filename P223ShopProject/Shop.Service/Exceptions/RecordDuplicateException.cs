using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.Exceptions
{
    public class RecordDuplicateException:Exception
    {
        public RecordDuplicateException(string msg):base(msg)
        {

        }
    }
}
