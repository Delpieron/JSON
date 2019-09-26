using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            repo.Add(new Person
            {
                LastName = "LN",
                Name = "Name",
                ListOfObjects = new List<string> { "1", "2" }
            });
            var list = repo.getPersonList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var data = File.ReadAllText(ConfigurationManager.AppSettings["file"]);
            //JObject jsonObject = JObject.Parse(data);
            //Console.WriteLine(jsonObject["name"]);
            var personList = JsonConvert.DeserializeObject<List<Person>>(data);
            personList.RemoveAt(0);

            string dataToSave = JsonConvert.SerializeObject(personList);
            File.WriteAllText(ConfigurationManager.AppSettings["file"], 
                JToken.Parse(dataToSave).ToString());

            Console.WriteLine(personList[0]);
            Console.WriteLine(personList[1]);
            Console.Read();
        }
    }
}
