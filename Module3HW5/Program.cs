﻿namespace Module3HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = GetResultAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        public static async Task<string> ReadHelloAsync()
        {
            using var reader = new StreamReader("Hello.txt");
            Thread.Sleep(5000);
            return await reader.ReadToEndAsync();
        }

        public static async Task<string> ReadWorldAsync()
        {
            using var reader = new StreamReader("World.txt");
            Thread.Sleep(2000);
            return await reader.ReadToEndAsync();
        }

        public static async Task<string> GetResultAsync()
        {
            Console.WriteLine("GetResult begin");
            var hello = Task.Run(async () => await ReadHelloAsync());
            var world = Task.Run(async () => await ReadWorldAsync());

            await Task.WhenAll(new[] { hello, world });
            return hello.GetAwaiter().GetResult() + world.GetAwaiter().GetResult();
        }
    }
}