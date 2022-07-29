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

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                //Console.WriteLine(jsonResponse);


                var myData = JsonConvert.DeserializeObject<Data[]>(jsonResponse);

                //var result = myData.FirstOrDefault(x => x.stacja == input);

                foreach (var item in myData)
                {
                    Console.WriteLine($"{item.stacja} {item.temperatura}");
                }
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
