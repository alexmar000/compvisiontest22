using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureComputerVisionTest22
{
    internal class ImageAnalysisService
    {
        private static readonly string ApiKey = ConfigurationManager.AppSettings.Get("CogSvcApiKey")!;
        private static readonly string Endpoint = ConfigurationManager.AppSettings["CogSvcEndpoint"]!;
        private string sampleDog = "https://cdn.britannica.com/60/8160-050-08CCEABC/German-shepherd.jpg";
        ComputerVisionClient client;
        public ImageAnalysisService()
        {
            client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(ApiKey))
            { Endpoint = Endpoint };
        }

        public async Task AnalyzeImage(string url)
        {
            var features = new List<VisualFeatureTypes?>()
            { VisualFeatureTypes.Description };
            Console.Clear();
            Console.WriteLine("Fetching results...");

            ImageAnalysis results = await client.AnalyzeImageAsync(url, visualFeatures: features);
            Console.Clear();

            foreach (var description in results.Description.Captions)
            {
                Console.WriteLine($"I think this is {description.Text} with confidence {description.Confidence}");
            }
        }
    }
}
