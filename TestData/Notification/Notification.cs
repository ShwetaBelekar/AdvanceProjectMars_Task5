using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.TestData.Notification
{
    public class NotificationTestData
    {
       
        
            public class NotificationData
            {

                public string searchSkill { get; set; }
                public string selectSeller { get; set; }
                public string selectSkill { get; set; }
                public string messageToSeller { get; set; }
                public string Emailaddress { get; set; }
                public string Password { get; set; }
                public string Sender { get; set; }
            public string Notification { get; set; }
            public string NewNotification { get; set; }

        }
            public static class TestDataReader
            {
                public static Dictionary<string, List<NotificationData>> ReadTestData(string fileName)
                {
                    string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                    string testDataPath = Path.Combine(projectRoot, "Configuration", "Notification_TestCases", fileName);
                    string jsonData = File.ReadAllText(testDataPath);
                    var testData = JsonConvert.DeserializeObject<Dictionary<string, List<NotificationData>>>(jsonData);
                    return testData;
                }
            }
        
    }
}
