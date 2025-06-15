using hoc_Generics;

static void printArray<T>(T[] a)
{
    for (int i = 0; i< a.Length; i++)
    {
        Console.WriteLine(a[i] + " ");
    }    
}

int[] a = { 1, 2, 3, 4, 5 };
double[] b = { 4.2, 5.9, 9.2 };
string[] c = { "a", "b", "c" };
printArray(a);
printArray(b);
printArray(c);

MyClasss<int> list1 = new MyClasss<int>(10);
list1.DisplayData();

MyClasss<string> list2 = new MyClasss<string>("Hien");
list2.DisplayData();

MyClasss<SanPham> list3 = new MyClasss<SanPham>(new SanPham());
list3.DisplayData();