using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProjectMars_Task5.TestData.Shareskill.ShareskillTestData;

namespace AdvanceProjectMars_Task5.TestData.Searchskills
{


    public class SearchskillsTestData
    {
        public class SearchskillsData
        {
            public string Filter { get; set; }
            public string Category { get; set; }

            public string Subcategory { get; set; }

        }
        public static class TestDataReader
        {
            public static Dictionary<string, List<SearchskillsData>> ReadTestData(string fileName)
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "Searchskills_TestCases", fileName);
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<SearchskillsData>>>(jsonData);
                return testData;
            }
        }
    }
}
