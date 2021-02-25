using System.Collections.Generic;
using System.Linq;

namespace Framework.Domain
{
    public static class ValueObjectExtensions
    {
        public static void UpdateFrom<T>(this List<T> source, List<T> newList) where T : ValueObject<T>
        {
            var addedItems = newList.Except(source).ToList();
            var removedItems = source.Except(newList).ToList();

            addedItems.ForEach(source.Add);
            removedItems.ForEach(item => source.Remove(item));
        }
    }
}