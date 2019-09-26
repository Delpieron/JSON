using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON
{
    public class Repository
    {
        private readonly string file = ConfigurationManager.AppSettings["file"];
        private List<Person> getPersonList
        {
            get
            {
                var data = File.ReadAllText(file);
                return JsonConvert.DeserializeObject<List<Person>>(data);
            }
        }

        public object personList { get; private set; }

        private void serialize(List<Person> people)
        {
            string dataToSave = JsonConvert.SerializeObject(personList);
            File.WriteAllText(ConfigurationManager.AppSettings["file"],
                JToken.Parse(dataToSave).ToString());
        }
        internal void Add(Person person)
        {
            var personList = getPersonList;
            personList.Add(person);
            serialize(personList);
        }
    }
}
