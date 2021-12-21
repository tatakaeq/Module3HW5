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
            return await reader.ReadToEndAsync();
        }

        public static async Task<string> ReadWorldAsync()
        {
            using var reader = new StreamReader("World.txt");
            return await reader.ReadToEndAsync();
        }

        public static async Task<string> GetResultAsync()
        {
            var hello = Task.Run(async () => await ReadHelloAsync());
            var world = Task.Run(async () => await ReadWorldAsync());

            var result = await Task.WhenAll(new[] { hello, world });
            return string.Join(" ", result);
        }
    }
}