using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Networking
{
    public class NetworkExecutor : ITema
    {
        private readonly ILoggerServise _logger;

        private string _mindaugasBlogUrl = "https://blog.mindaugas.cf";
        private string _DadJokeUrl = "https://icanhazdadjoke.com/";

        public NetworkExecutor(ILoggerServise logger)
        {
            _logger = logger;
        }

        public async Task Run()
        {
            //await GetWebHeader();
            //await GetDadJoke();
            await Test10Jokes();
        }

        private async Task GetWebHeader()
        {
            using var client = new HttpClient();

            try
            {
                var result = await client.GetAsync(_mindaugasBlogUrl);

                result.EnsureSuccessStatusCode();
                Console.WriteLine(result.Headers);
                Console.WriteLine(await result.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                await _logger.LogWarning($"Cannot reach {_mindaugasBlogUrl}");
                await _logger.LogWarning($"error: {ex.Message} \nTrace: {ex.StackTrace}");

            }
        }

        private async Task<DadJoke> GetDadJoke(string id = "")
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                var result = await client.GetAsync(string.IsNullOrEmpty(id) 
                    ? _DadJokeUrl 
                    : $"{_DadJokeUrl}j/{id}");

                result.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<DadJoke>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                await _logger.LogWarning($"Cannot reach {_DadJokeUrl}");
                await _logger.LogWarning($"error: {ex.Message} \nTrace: {ex.StackTrace}");

                return null;

            }
        }

        private async Task Test10Jokes()
        {
            var likedJokesIds = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                var joke = await GetDadJoke();

                var userAwnser = string.Empty;
                do
                {
                    Console.WriteLine($"Joke: {joke?.Joke ?? "Server error ;("}");
                    Console.WriteLine("\nDid you like this joke ? (y-yes/n-no)");
                    userAwnser = Console.ReadLine();
                }
                while (userAwnser != "n" && userAwnser != "y");

                if(userAwnser == "y")
                {
                    Console.WriteLine("\nGreat!");
                    likedJokesIds.Add(joke.Id);
                }
                else
                {
                    Console.WriteLine("\nSorry");
                }
            }

            foreach(var jokeId in likedJokesIds)
            {
                File.AppendAllText(@"./Juokingi.txt", $"{(await GetDadJoke(jokeId)).Joke}\n");
            }
        }
    }
}
