using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoc_Generics
{
    internal class MyClasss<T> 
    {
        private T data;
        public MyClasss(T data)
        {
            this.data = data;
        }
        public T GetData()
        {
            return data;
        }
        public void DisplayData()
        {
            Console.WriteLine($"Gia tri: {data}");
        }

    }
}
