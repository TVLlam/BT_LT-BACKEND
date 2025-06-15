Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Nhập số: ");
int num = int.Parse(Console.ReadLine() ??"0");

Console.WriteLine(IsPrime(num) ? $"{num} là số nguyên tố." : $"{num} không phải là số nguyên tố.");
   
    static bool IsPrime(int num)
{
    if (num <= 1) return false;

    for (int i = 2; i * i <= num; i++)
        if (num % i == 0) return false;

    return true;
}