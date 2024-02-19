using System.Collections.ObjectModel;

namespace DataAccess.Utilities
{
    public static class Convertor
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
