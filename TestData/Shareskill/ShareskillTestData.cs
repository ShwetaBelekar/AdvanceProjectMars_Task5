using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.TestData.Shareskill
{
    public class ShareskillTestData
    {
        public class ShareskillData
        {
            public string Title { get; set; }
     
            public string Description { get; set; }
            public string Category  { get; set; }
            public string SelectSubcategory { get; set; }
            public string Tags { get; set; }
            public string ServiceType { get; set; }
            public string LocationType { get; set; }
            public string SkillTrade { get; set; }
            public string Credit { get; set; }
            public string SkillExchange { get; set; }
            public string Active { get; set; }
            
        }

        public static class TestDataReader
        {
            public static Dictionary<string, List<ShareskillData>> ReadTestData(string fileName)
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "ShareSkill_TestCases", fileName);
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<ShareskillData>>>(jsonData);
                return testData;
            }
        }
    }
}
