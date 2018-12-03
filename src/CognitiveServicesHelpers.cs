// <copyright file="CognitiveServicesHelpers.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace WindowsTestHelpers
{
    public static class CognitiveServicesHelpers
    {
        /// <summary>
        /// Extract images from the specified image file.
        /// For more see https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/vision-api-how-to-topics/howtosubscribe .
        /// </summary>
        /// <param name="imageFilePath">Path to image file.</param>
        /// <param name="apiKey">Azure Cognitive Services computer vision API key.</param>
        /// <param name="azureRegion">Computer vision API keys are tied to specific regions. Include the appropriate part of the subdomain. Trial keys are for the West Central US region.</param>
        /// <returns>Text extracted from image.</returns>
        public static async Task<(List<string> lines, List<string> words)> GetTextFromImageAsync(string imageFilePath, string apiKey, string azureRegion = "westcentralus")
        {
            if (string.IsNullOrWhiteSpace(imageFilePath))
            {
                throw new ArgumentException(nameof(imageFilePath));
            }

            if (!File.Exists(imageFilePath))
            {
                throw new ArgumentException("File does not exist.", nameof(imageFilePath));
            }

            var credentials = new ApiKeyServiceClientCredentials(apiKey);
            var handlers = new System.Net.Http.DelegatingHandler[] { };
            var endpoint = $"https://{azureRegion}.api.cognitive.microsoft.com";

            var computerVision = new ComputerVisionClient(credentials, handlers)
            {
                Endpoint = endpoint,
            };

            using (Stream imageStream = File.OpenRead(imageFilePath))
            {
                // Start the async process to recognize the text
                var textHeaders = await computerVision.RecognizeTextInStreamAsync(imageStream, TextRecognitionMode.Printed);

                int numberOfCharsInOperationId = 36;

                // stored from the Operation-Location header
                string operationId = textHeaders.OperationLocation.Substring(textHeaders.OperationLocation.Length - numberOfCharsInOperationId);

                var textOpResult = await computerVision.GetTextOperationResultAsync(operationId);

                // Wait for the operation to complete
                int i = 0;
                int maxRetries = 10;
                while ((textOpResult.Status == TextOperationStatusCodes.Running ||
                        textOpResult.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries)
                {
                    Debug.WriteLine("Server status: {0}, waiting {1} seconds...", textOpResult.Status, i);
                    await Task.Delay(1000);

                    textOpResult = await computerVision.GetTextOperationResultAsync(operationId);
                }

                var lines = textOpResult.RecognitionResult.Lines;

                var words = new List<string>();
                foreach (var line in lines)
                {
                    words.AddRange(line.Words.Select(w => w.Text));
                }

                return (lines.Select(l => l.Text).ToList(), words);
            }
        }
    }
}
