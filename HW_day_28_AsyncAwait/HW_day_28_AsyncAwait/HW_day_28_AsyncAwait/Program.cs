using System.Text;

namespace HW_day_28_AsyncAwait

{
    internal class Program
    {
        static async Task Main()
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();
            var token = cancellation.Token;
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int task = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    writeToFile(task, token);
                }, token);
                
            }
            
            static async Task writeToFile(int task, CancellationToken token)
            {
                try
                {
                    string fileName = $"C:\\Users\\Kiu-Student\\Desktop\\{task}.txt";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    using (FileStream fs = File.Create(fileName))
                    {
                        string content = $"{task}.txt ";
                        Byte[] text = new UTF8Encoding(true).GetBytes(content);
                        while (!token.IsCancellationRequested)
                        {
                          
                            await fs.WriteAsync(text, 0, text.Length);
                            await Task.Delay(100 * task);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Console.WriteLine("Enter 'x' to cancel");
            Console.ReadKey();
            cancellation.Cancel();
            await Task.Delay(2000);
            Task.WaitAll(tasks);
        }
    }
}