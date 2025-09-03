using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.TestData.Signin
{
    public class SigninTestData
    {
        public class SigninData
        {
            public string Emailaddress { get; set; }
            public string Password { get; set; }
        }

        public static class TestDataReader
        {
            public static Dictionary<string, List<SigninData>> ReadTestData()
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "Signin_TestCases", "signin_validcredentials.json");
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<SigninData>>>(jsonData);
                return testData;
            }
        }
    }
}
