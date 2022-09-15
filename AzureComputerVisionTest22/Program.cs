namespace AzureComputerVisionTest22;

class Program
{
    static async Task Main()
    {
        var client = new ImageAnalysisService();

        do
        {
            Console.Clear();
            Console.WriteLine("Enter image url to analyze:");
            await client.AnalyzeImage(Console.ReadLine());
            Console.WriteLine("Type 'r' to try again");
        }
        while (Console.ReadLine() == "r");
    }
}