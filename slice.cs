using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashconsole
{ 

    public struct Slice<T>
    {
        private readonly T[] _array;

        private readonly int _startIndex;

        public Slice(T[] array):this(array,0)
        {
        }

        public Slice(T[] array, int startIndex)
        {
            if (startIndex<0 || startIndex >= array.Length)
                throw new IndexOutOfRangeException(nameof(startIndex));

            _array = array;
            _startIndex = startIndex;
            Length = array.Length - startIndex;
        }

        public Slice(T[] array, int startIndex, int length)
        {
            if (length<0 || length > array.Length - startIndex)
                throw new ArgumentException(nameof(length));

            _array = array;
            _startIndex = startIndex;
            Length = length;
        }

        public int Length { get; }

        public T this[int index]
        {
            get
            {
                if(!AssertIndex(index))
                    throw new IndexOutOfRangeException(nameof(index));
                return _array[_startIndex + index];
            }
            set
            {
                if (!AssertIndex(index))
                    throw new IndexOutOfRangeException(nameof(index));
                _array[_startIndex + index] = value;
            }
        }

        public bool IsEmpty => Length == 0;

        public T[] ToArray()
        {
            var newArray = new T[Length];
            Array.Copy(_array,_startIndex,newArray,0,Length);
            return newArray;
        }

        private bool AssertIndex(int index)
        {
            return index>-1 && index < _startIndex + Length;
        }
    }
}
