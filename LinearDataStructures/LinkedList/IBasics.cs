using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.LinkedList
{
    public interface IBasics<T>
    {
		public void Add(T data);
        public void AddFirst(T data);
        public void AddLast(T data);
        public void AddBefore(T find, T data);
        public void AddAfter(T find, T data);
        public void Delete(T data);
        public int Search(T data);
        public void Insert(int index, T data);
    }
}
