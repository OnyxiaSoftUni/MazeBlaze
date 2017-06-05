using MazeBlaze.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBlaze.Services
{
    public static class GameService
    {
        private static List<Character> loadedCharacters = null;
        private static Character currentCharacter = null;
        private const string savesDirectory = "Saves";
        private const string saveFilePath = savesDirectory + "\\" + "saves.json";

        public static void LoadSave(string characterName)
        {
            currentCharacter = loadedCharacters.FirstOrDefault(c => c.Name == characterName);
        }

        public static void Save()
        {
            var character = loadedCharacters.FirstOrDefault(c => c.Name == currentCharacter.Name);

            var indexOfCharacter = loadedCharacters.IndexOf(character);

            loadedCharacters[indexOfCharacter] = currentCharacter;

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(loadedCharacters, options);

            StoreSaveFile(json);
        }

        public static void LoadSavedData()
        {
            if (Directory.Exists(savesDirectory))
            {
                if (File.Exists(saveFilePath))
                {
                    var jsonFile = File.ReadAllText(saveFilePath);

                    var characters = JsonConvert.DeserializeObject<List<Character>>(jsonFile);

                    if (characters != null && characters.Count > 0)
                    {
                        loadedCharacters = characters;
                    }
                    else
                    {
                        loadedCharacters = new List<Character>();
                    }
                }
            }
        }

        public static void CreateCharacter(string name)
        {
            var character = new Character(name);

            currentCharacter = character;
            loadedCharacters.Add(character);
        }

        public static void CreateDummySave()//For Testing
        {
            List<Character> dummyList = new List<Character>();
            Character gosho = new Character
            {
                Name = "Gosho",
                Exp = 140,
                Level = 3,
                MaxStage = 4
            };

            Character pesho = new Character
            {
                Name = "Pesho",
                Exp = 3200,
                Level = 5,
                MaxStage = 7
            };

            Character lisa = new Character
            {
                Name = "Lisa",
                Exp = 0,
                Level = 1,
                MaxStage = 1
            };

            dummyList.Add(gosho);
            dummyList.Add(pesho);
            dummyList.Add(lisa);

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(dummyList, options);

            StoreSaveFile(json);
        }

        private static void StoreSaveFile(string json)
        {
            try
            {
                if (!Directory.Exists(savesDirectory))
                {
                    Directory.CreateDirectory(savesDirectory);
                }

                File.WriteAllText(saveFilePath, json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}