using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    }
}
