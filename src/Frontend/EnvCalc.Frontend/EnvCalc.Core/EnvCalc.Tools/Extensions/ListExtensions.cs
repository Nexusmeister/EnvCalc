using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EnvCalc.Tools.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Konvertiert IEnumerable in eine ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="liste"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> liste)
        {
            return new(liste);
        }
    }
}