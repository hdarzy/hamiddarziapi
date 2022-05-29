using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class Assert
    {
        public static void NotNull<T>(T? obj, string name, string message = null) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} : {typeof(T)}" , message);
            }
        }
        public static void NotNull<T>(T? obj , string name ,string message = null ) where T : struct
        {
            if (!obj.HasValue)
            {
                throw new ArgumentNullException($"{name} : {typeof(T)}", message); 
            }
        }

        public static void NotEmpty<T>(T obj ,string name , string message = null , T defaultvalue = null) where T : class
        {
            if (obj == defaultvalue || (obj is string str && string.IsNullOrWhiteSpace(str)) || (obj is IEnumerable list && !list.Cast <object>().Any()))
            {
                throw new ArgumentException("argument is empty : " + message, $"{name}:{typeof(T)}");
            }
        }
    }
}
