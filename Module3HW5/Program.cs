namespace Module3HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = GetResultAsync().GetAwaiter().GetResult();
            Console.WriteLine(result);
        }

        public static async Task<string> ReadHelloAsync()
        {
            using (var reader = new StreamReader("Hello.txt"))
            {
                var hello = await reader.ReadToEndAsync();
                return hello;
            }
        }

        public static async Task<string> ReadWorldAsync()
        {
            using var reader = new StreamReader("World.txt");
            var world = await reader.ReadToEndAsync();
            return world;
        }

        public static async Task<string> GetResultAsync()
        {
            Console.WriteLine("Get REsult begin");
            var hello = await Task.Run(() => ReadHelloAsync());
            var world = await Task.Run(() => ReadWorldAsync());
            return hello + world;
        }
    }
}