using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Helper
{
    public static class EqualityComparer
    {
        public static bool isDefaultValue<T>(T value) 
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
