using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace WeatherApp
{
	public class App
	{
		static async Task GetData()
        {
            string url = "https://danepubliczne.imgw.pl/api/data/synop";

            HttpClient httpClient = new HttpClient();

            Console.WriteLine("Podaj nazwę miasta: ");

            string input = Console.ReadLine();
            var firstLetter = input.Substring(0, 1);
            firstLetter = firstLetter.ToUpper();
            var otherLetters = input.Substring(1);
            otherLetters = otherLetters.ToLower();
            string matchingInput = firstLetter + otherLetters;

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                //Console.WriteLine(jsonResponse);


                var myData = JsonConvert.DeserializeObject<Data[]>(jsonResponse);

                var result = myData.FirstOrDefault(x => x.stacja == matchingInput);

                if (result != null)
                {
                    Console.WriteLine($"Stacja: {result.stacja}, " +
                        $"temperatura: {result.temperatura}, " +
                        $"ciśnienie: {result.cisnienie}, " +
                        $"wilgotność: {result.wilgotnosc_wzgledna}, " +
                        $"data pomiaru: {result.data_pomiaru}, " +
                        $"godzina pomiaru: {result.godzina_pomiaru}");
                }
                else
                {
                    Console.WriteLine("Ogółem... nie ma takiego miasta");
                }

                //foreach (var item in myData)
                //{
                //    Console.WriteLine($"{item.stacja} {item.temperatura}");
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        public async void RunApp()
        {
            await GetData();
        }
	}
}
