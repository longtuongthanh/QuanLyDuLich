using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuLich2.Helper
{
    // Returns elements that pass any predicate
    public class FilterHelper_Any<T>
    {
        HashSet<Predicate<T>> predicates;
        public void Clear()
        {
            predicates.Clear();
        }
        public void Insert(Predicate<T> predicate)
        {
            if (predicate == null)
                return;
            predicates.Add(predicate);
        }
        public void Remove(Predicate<T> predicate)
        {
            if (predicate == null)
                return;
            predicates.Remove(predicate);
        }
        public IEnumerable<T> Filter(IEnumerable<T> unfilteredList)
        {
            return unfilteredList.Where(item =>
            {
                foreach (var func in predicates)
                    if (func(item))
                        return true;
                return predicates.Count == 0;
            });
        }
    }
    // Returns elements that pass all predicates
    public class FilterHelper_All<T>
    {
        HashSet<Predicate<T>> predicates;
        public void Clear()
        {
            predicates.Clear();
        }
        public void Insert(Predicate<T> predicate)
        {
            if (predicate == null)
                return;
            predicates.Add(predicate);
        }
        public void Remove(Predicate<T> predicate)
        {
            if (predicate == null)
                return;
            predicates.Remove(predicate);
        }
        public IEnumerable<T> Filter(IEnumerable<T> unfilteredList)
        {
            return unfilteredList.Where(item =>
            {
                foreach (var func in predicates)
                    if (!func(item))
                        return false;
                return true;
            });
        }
    }
}
