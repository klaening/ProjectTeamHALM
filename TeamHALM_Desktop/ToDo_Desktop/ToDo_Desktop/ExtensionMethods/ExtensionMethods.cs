using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Desktop.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static ObservableCollection<T> MakeObservable<T>(this IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        //public static T Clone<T>(this T obj)
        //{
        //    T clone = obj;
        //    return clone;
        //}
    }
}
