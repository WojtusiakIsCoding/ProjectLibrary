using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Collections;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ProjectLibrary.Model
{
    public static class Serializer
    {
        public static void Serialize(ObservableCollection <Item> list, string path)
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting= Formatting.Indented;
            File.WriteAllText(path, JsonConvert.SerializeObject(list, settings));
           
        }
        public static void Serialize(ObservableCollection<User> list, string path)
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            File.WriteAllText(path, JsonConvert.SerializeObject(list, settings));
        }
        public  static ObservableCollection<Item> DeserializeToItem(string path) {

            
                return JsonConvert.DeserializeObject<ObservableCollection<Item>>(File.ReadAllText(path));
           
           
        }
        public static ObservableCollection<User> DeserializeToUser(string path)
        {
            return JsonConvert.DeserializeObject<ObservableCollection<User>>(File.ReadAllText(path));



        }
    }
}
