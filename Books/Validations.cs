using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books
{
    public static class Validations
    {
        public static bool isSelected(this int index)
        {
            return index > 0 ? true : false;
        }

        public static bool isEntered(this string text)
        {
            
                return text !=  "" ? true : false;
            
            
            
        }

    }
}