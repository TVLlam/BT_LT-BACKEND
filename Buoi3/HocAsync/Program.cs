class Program
{
    ////1.Lập trình đồng bộ
    //static string DownloadData()
    //{
    //    Thread.Sleep(5000); // giả lập thời gian tải dữ liệu
    //    return "Du lieu tu server";
    //}
    //static void Main(string[] args)
    //{
    //    Console.WriteLine("Bat dau tai du lieu...");
    //    string result = DownloadData(); // chặn tại đây, không cho làm việc khác
    //    //khi tải xong thì mới thực hiện các lệnh dưới đây
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Console.WriteLine($"Dang lam viec kha ...{i}");
    //        Thread.Sleep(1000);
    //    }
    //    Console.WriteLine($"Tai xong: {result}");
    //}

    //2. Lập trình bất đồng bộ
    static async Task<string> DowloadDataAsync()
    {
        await Task.Delay(5000);
        return "Du lieu tu server";
    }
    static async Task Main(string[] args)
    {
        Console.WriteLine("Bat dau tai du lieu ...");
        var task = DowloadDataAsync();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Dang lam viec khac ... {i}");
            await Task.Delay(1000);
        }
        var result = await task;
        Console.WriteLine($"Tai xong: {result}");
    }
}

