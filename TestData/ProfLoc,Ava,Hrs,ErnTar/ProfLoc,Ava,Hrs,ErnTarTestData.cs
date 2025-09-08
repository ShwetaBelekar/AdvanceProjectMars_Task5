using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.TestData.ProfLoc_Ava_Hrs_ErnTar
{
    public class ProfLoc_Ava_Hrs_ErnTarTestData
    {
        public class ProfLoc_Ava_Hrs_ErnTar_Data
        {
            public string AvailabilityType { get; set; }
            
        }
        
        public static class TestDataReader
        {
            public static Dictionary<string, List<ProfLoc_Ava_Hrs_ErnTar_Data>> ReadTestData(string fileName)
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "ProfLoc,Ava,Hrs,ErnTa_TestCases", fileName);
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<ProfLoc_Ava_Hrs_ErnTar_Data>>>(jsonData);
                return testData;
            }
        }
    }
}
