using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> store;
        private int count;

        public ListyIterator( List<T> input)
        {
            this.store = input;
            this.count = 0;
        }

        public bool Move()
        {
            if (count < store.Count)
            {
                count++;
                return true;
            }

            return false;

        }
        public void Print()
        {
            Console.WriteLine(this.store[count]);
        }
        public bool HasNext()
        {
            if (count <store.Count-1)
            {
                return true;
            }

            return false;
        }



        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.store)
            {
                yield return item;
            }
            
            
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
