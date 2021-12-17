namespace Module3HW5
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
            var hello = await reader.ReadToEndAsync();
            Thread.Sleep(5000);
            return hello;
        }

        public static async Task<string> ReadWorldAsync()
        {
            using var reader = new StreamReader("World.txt");
            var world = await reader.ReadToEndAsync();
            Thread.Sleep(2000);
            return world;
        }

        public static async Task<string> GetResultAsync()
        {
            Console.WriteLine("Get REsult begin");
            var hello = Task.Run(() => ReadHelloAsync());
            var world = Task.Run(() => ReadWorldAsync());
            await Task.WhenAll(new[] { hello, world });
            var result = hello.GetAwaiter().GetResult() + world.GetAwaiter().GetResult();
            return result;
        }
    }
}