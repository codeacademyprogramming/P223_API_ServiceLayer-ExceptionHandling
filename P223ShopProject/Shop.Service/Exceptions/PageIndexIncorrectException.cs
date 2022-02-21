using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.Exceptions
{
    public class PageIndexIncorrectException:Exception
    {
        public PageIndexIncorrectException(string msg):base(msg)
        {

        }
    }
}
