using DictionaryTree.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace DictionaryTree.DataAccess
{
    public class LoadJson
    {
        public static async Task<CLib[]> GetJson(string url, string id, string limit, string offset)
        {

            var client = new HttpClient();

            var data = await client.GetFromJsonAsync<CLib[]>(url);


            return data;


            //  MessageBox.Show(jsonString);

            //return jsonString;

        }


        public static async Task<CLib> FileJson(string url)
        {
            CLib item = await ReadAsync<CLib>(url);
            return item;
        }



        public static async Task<T> ReadAsync<T>(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);

            return await JsonSerializer.DeserializeAsync<T>(stream);
        }


        public static async Task<T> ReadAsyncStr<T>(string JsonString)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonString));

            return await JsonSerializer.DeserializeAsync<T>(stream);
        }







        public static CLib[] GetCLib(string url, string id, string limit, string offset)
        {
            var singIn = Task.Run(() => GetJson(url, id, limit, offset)).Result;


            if (singIn != null)
            {
                foreach (var node in singIn)
                {
                    MessageBox.Show(node.Id + node.Caption);
                }
            }
            return singIn;
        }


    }
}
