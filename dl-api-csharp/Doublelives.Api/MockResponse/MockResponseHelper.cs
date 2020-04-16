using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace Doublelives.Api.MockResponse
{
    public static class MockResponseHelper
    {
        public static T GetMockModel<T>(string fileName)
        {
            Stream stream = null;
            StreamReader sr = null;
            string json;
            var filePath = $"Doublelives.Api.MockResponse.{fileName}.json";
            try
            {
                stream = Assembly.GetEntryAssembly().GetManifestResourceStream(filePath);
                sr = new StreamReader(stream);
                json = sr.ReadToEndAsync().Result;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }

                if (sr != null)
                {
                    sr.Dispose();
                }
            }

            var model = JsonConvert.DeserializeObject<T>(json);

            return model;
        }
    }
}
