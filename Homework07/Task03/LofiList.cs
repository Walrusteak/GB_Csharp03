using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    /// <summary>
    /// В сути это выходит не список, а омерзительная (в отличие от штатного List) обертка над массивом, но ладно
    /// </summary>
    public class LofiList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {
        private T[] _array;

        public LofiList()
        {
            _array = Array.Empty<T>();
        }

        public LofiList(int capacity)
        {
            _array = new T[capacity];
        }

        public LofiList(IEnumerable<T> collection)
        {
            _array = collection.Cast<T>().ToArray();
        }

        public int Count => _array.Length;

        public bool IsReadOnly => false;

        public bool IsSynchronized => _array.IsSynchronized;

        public object SyncRoot => _array.SyncRoot;

        public bool IsFixedSize => false;

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        object IList.this[int index]
        {
            get => _array[index];
            set => _array[index] = (T)value;
        }

        public void Add(T item)
        {
            Array.Resize(ref _array, Count + 1);
            _array[Count - 1] = item;
        }

        public int Add(object value)
        {
            T item = (T)value;  //никакой проверки нет умышленно, чтобы в случае ошибки выбрасывалось стандартное исключение
            Add(item);
            return Count - 1;
        }

        public void Clear() => _array = Array.Empty<T>();

        public bool Contains(T item) => _array.Contains(item);

        public bool Contains(object value)
        {
            T item = (T)value;
            return Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) => _array.CopyTo(array, arrayIndex);

        public void CopyTo(Array array, int index) => _array.CopyTo(array, index);

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i] is null)
                {
                    if (item is null)
                        return i;
                }
                else
                {
                    if (_array[i].Equals(item))
                        return i;
                }
            }
            return -1;
        }

        public int IndexOf(object value)
        {
            T item = (T)value;
            return IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Array.Resize(ref _array, Count + 1);
            for (int i = index + 1; i < Count; i++)
                _array[i] = _array[i - 1];
            _array[index] = item;
        }

        public void Insert(int index, object value)
        {
            T item = (T)value;
            Insert(index, item);
        }

        public bool Remove(T item)
        {
            int ix = IndexOf(item);
            if (ix == -1)
                return false;
            RemoveAt(ix);
            return true;
        }

        public void Remove(object value)
        {
            T item = (T)value;
            Remove(item);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
                _array[i] = _array[i + 1];
            Array.Resize(ref _array, Count - 1);
        }

        IEnumerator IEnumerable.GetEnumerator() => _array.GetEnumerator();


        /// <summary>
        /// Ради этой штуки пришлось заглянуть в Reference Source
        /// </summary>
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private LofiList<T> _list;
            private int _index;
            private T _current;

            internal Enumerator(LofiList<T> list)
            {
                _list = list;
                _index = 0;
                _current = default;
            }

            public T Current => _current;

            object IEnumerator.Current => _current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (_index < _list._array.Length)
                {
                    _current = _list._array[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
                _current = default;
            }
        }
    }
}
