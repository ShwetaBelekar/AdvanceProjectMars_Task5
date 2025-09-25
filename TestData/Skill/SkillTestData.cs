using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.TestData.Skill
{
    public class SkillTestData
    {
        public class SkillData
        {
            
        }

        public static class TestDataReader
        {
            public static Dictionary<string, List<SkillData>> ReadTestData(string fileName)
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "Skill_TestCases", fileName);
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<SkillData>>>(jsonData);
                return testData;
            }
        }
    }
}
