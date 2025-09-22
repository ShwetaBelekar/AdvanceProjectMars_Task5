using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvanceProjectMars_Task5.TestData.Language
{
    public class LanguageTestData
    {
        public class LanguageData
        {
            public string Language { get; set; }
            public string Level { get; set; }

        }

        public static class TestDataReader
        {
            public static Dictionary<string, List<LanguageData>> ReadTestData(string fileName)
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "Language_TestCases", fileName);
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<LanguageData>>>(jsonData);
                return testData;
            }
        }

    }
}
