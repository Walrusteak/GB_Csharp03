using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03
{
    /// <summary>
    /// Сделал чисто из интереса
    /// </summary>
    public class LofiLinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {
        private Node<T> _first;
        private Node<T> _last;
        private int _count;
        private object _syncRoot;

        public LofiLinkedList()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        public LofiLinkedList(IEnumerable<T> collection)
        {
            foreach (T item in collection)
                Add(item);
        }

        public T this[int index]
        {
            get => GetByIndex(index)._value;
            set => GetByIndex(index)._value = value;
        }

        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = (T)value;
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public bool IsSynchronized => false;

        public object SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                    _syncRoot = new object();
                return _syncRoot;
            }
        }

        public bool IsFixedSize => false;

        public void Add(T item)
        {
            Node<T> node = new(item);
            if (_first == null)
                _first = node;
            else
                _last._next = node;
            _last = node;
            _count++;
        }

        public int Add(object value)
        {
            T item = (T)value;
            Add(item);
            return _count - 1;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> node = _first;
            while (node != null)
            {
                if (node.IsValue(item))
                    return true;
                node = node._next;
            }
            return false;
        }

        public bool Contains(object value)
        {
            T item = (T)value;
            return Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) => CopyTo((Array)array, arrayIndex);

        public void CopyTo(Array array, int index)
        {
            if (array != null && array.Rank != 1)
                throw new ArgumentException();
            T[] items = new T[_count];
            Node<T> node = _first;
            for (int i = 0; node != null; i++, node = node._next)
                items[i] = node._value;
            Array.Copy(items, 0, array, index, _count);
        }

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        public int IndexOf(T item)
        {
            int ix = 0;
            Node<T> node = _first;
            while (node != null && !node.IsValue(item))
                ix++;
            return node == null ? -1 : ix;
        }

        public int IndexOf(object value)
        {
            T item = (T)value;
            return IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (index > _count)
                throw new IndexOutOfRangeException();
            if (index == _count)
            {
                Add(item);
                return;
            }
            _count++;
            if (index == 0)
            {
                _first = new(item, _first);
                return;
            }
            Node<T> node = _first;
            for (int i = 0; i < index; i++)
                node = node._next;
            Node<T> newNode = new(item, node._next);
            node._next = newNode;
        }

        public void Insert(int index, object value)
        {
            T item = (T)value;
            Insert(index, item);
        }

        public bool Remove(T item)
        {
            if (_first == null)
                return false;
            if (_count == 1)
            {
                if (_first.IsValue(item))
                {
                    Clear();
                    return true;
                }
                return false;
            }

            Node<T> node = _first;
            while (node._next != null && !node._next.IsValue(item))
                node = node._next;
            if (node._next == null)
                return false;
            node._next = node._next._next;
            if (node._next == null)
                _last = node;
            _count--;
            return true;
        }

        public void Remove(object value)
        {
            T item = (T)value;
            Remove(item);
        }

        public void RemoveAt(int index)
        {
            if (index >= _count)
                throw new IndexOutOfRangeException();
            _count--;
            if (index == 0)
            {
                _first = _first._next;
                if (_first == null)
                    _last = null;
                return;
            }

            Node<T> node = _first;
            for (int i = 0; i < index; i++)
                node = node._next;
            node._next = node._next._next;
            if (node._next == null)
                _last = node;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private Node<T> GetByIndex(int index)
        {
            if (index >= _count)
                throw new IndexOutOfRangeException();
            Node<T> node = _first;
            for (int i = 0; i < index; i++)
                node = node._next;
            return node;
        }


        private class Node<TValue>
        {
            internal TValue _value;
            internal Node<TValue> _next;

            internal Node(TValue value) : this(value, null) { }

            internal Node(TValue value, Node<TValue> next)
            {
                _value = value;
                _next = next;
            }

            internal bool IsValue(TValue value) => _value is null ? value is null : _value.Equals(value);
        }


        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private LofiLinkedList<T> _list;
            private int _index;
            private T _current;

            internal Enumerator(LofiLinkedList<T> list)
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
                if (_index < _list._count)
                {
                    _current = _list[_index++];
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
