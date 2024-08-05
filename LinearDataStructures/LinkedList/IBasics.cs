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
        //TODO -> Dynamic array works with objects while Doubly linked list works with T, the dream is to one day unite their functions Add, Delete, Search with the help of this interface (but not today)

        public void Add(T data);
        public void Delete(T data);
        public int Search(T data);
        public void Insert(int index, T data);
    }
}
