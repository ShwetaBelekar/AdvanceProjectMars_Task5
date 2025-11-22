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
            public string Skill { get; set; }
            public string Level { get; set; }
            public string EditSkill { get; set; }
            public string NewSkill { get; set; }
            public string NewLevel { get; set; }

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
