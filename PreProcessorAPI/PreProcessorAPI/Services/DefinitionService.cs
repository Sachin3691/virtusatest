using Newtonsoft.Json;
using PreProcessorAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PreProcessorAPI.Services
{
    public class DefinitionService : IDefinitionService
    {
        private string JSONFile = "Definition.json";

        public List<Definition> GetAll()
        {
            if (File.Exists(JSONFile))
            {
                string jsonString = File.ReadAllText(JSONFile);
                return JsonConvert.DeserializeObject<List<Definition>>(jsonString);
            }
            return null;
        }

        public void Add(Definition definition)
        {
            if (!File.Exists(JSONFile))
            {
                File.Create(JSONFile);
            }
            try
            {
                List<Definition> definitions = new List<Definition>();
                string jsonString = File.ReadAllText(JSONFile);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                definitions = JsonConvert.DeserializeObject<List<Definition>>(jsonString, settings);
                if(definitions ==  null)
                {
                    definitions = new List<Definition>();
                }

                definitions.Add(definition);

                var definitionString = JsonConvert.SerializeObject(definitions);

                File.WriteAllText(JSONFile, String.Empty);
                File.WriteAllText(JSONFile, definitionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public bool Delete(string id)
        {
            if (File.Exists(JSONFile))
            {
                List<Definition> definitions = new List<Definition>();
                string jsonString = File.ReadAllText(JSONFile);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                definitions = JsonConvert.DeserializeObject<List<Definition>>(jsonString, settings);
                if (definitions == null)
                {
                    definitions = new List<Definition>();
                }

                definitions.RemoveAll(d => d.Id == id);

                var definitionString = JsonConvert.SerializeObject(definitions);

                File.WriteAllText(JSONFile, String.Empty);
                File.WriteAllText(JSONFile, definitionString);
                return true;
            }
            return false;
        }
    }

    public interface IDefinitionService
    {
        List<Definition> GetAll();
        void Add(Definition definition);
        bool Delete(string id);
    }
}
