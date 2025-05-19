using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class HashEntry<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; set; }

        public HashEntry<TKey, TValue>? Next { get; set; }

        public HashEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;

        }

    }
}