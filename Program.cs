class Program
{
    static void Main(string[] args)
    {
        string websiteAddress = "http://google.com";
        if (args.Length > 0) websiteAddress = args.Single();
        new Timer((e) =>
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(websiteAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"{DateTime.Now}: {websiteAddress} is up and running. Recieved {response.Content.Headers.ContentLength} bytes");
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now}: {websiteAddress} is down.");
                }
            }
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        Console.ReadLine();
    }
}