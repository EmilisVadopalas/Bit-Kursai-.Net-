using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files
{
    public static class IOExecutor
    {
        private static readonly string filePath = $@"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\";
        private static readonly string fileName = "SekmingaiSusikuriaFailas2.txt";

        private static readonly string nameFileDirectory = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\name.txt";

        public async static Task Run()
        {
            //await ReadTextFile();
            //await CreateFile();
            //DeleteFile();
            //ListenToFolder();
            //await RemoveSurnames();
            await FindMostPopularNames();
        }

        public async static Task ReadTextFile()
        {
            var lines = await File.ReadAllLinesAsync(@"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\ManoTxtFailas.txt");

            var counter = 0;
            foreach (var line in lines)
            {
                counter++;
                Console.WriteLine($"{counter}-oji eilute: {line}");
            }
        }

        public async static Task FindMostPopularNames()
        {
            var names = await File.ReadAllLinesAsync(nameFileDirectory);
            var namesWithCount = new List<(string, int)>();

            foreach (var name in names)
            {
                if(namesWithCount.Any(x => x.Item1 == name))
                {
                    var nameCountPair = namesWithCount.Where(x => x.Item1 == name).FirstOrDefault();

                    namesWithCount.Remove(nameCountPair);
                    nameCountPair.Item2++;
                    namesWithCount.Add(nameCountPair);
                }
                else
                {
                    namesWithCount.Add((name, 1));
                }
            }

            var orderedByPopularytiNames = namesWithCount.OrderByDescending(x => x.Item2).ToList();

            Console.WriteLine("\nMost Pupular Name\n");
            Console.WriteLine(orderedByPopularytiNames[0].Item1);
            Console.WriteLine($"it's {(double)orderedByPopularytiNames[0].Item2/orderedByPopularytiNames[1].Item2}" +
                $" times more popular than second most popular name\n");

            var counter = 1;
            foreach (var nameCount in orderedByPopularytiNames)
            {
                Console.WriteLine($"{counter}-{(counter == 1 ? "ist" : counter == 2 ? "nd" : counter == 3 ? "rd" : "th")} place, name: \"{nameCount.Item1}\", {nameCount.Item2} times repeated");

                counter++;
            }

            var place = -1;
            var placetext = string.Empty;

            do
            {
                Console.Write("\npasirinkite kelinta pagal populiaruma varda norite matyti: ");
                placetext = Console.ReadLine();
            } 
            while (!int.TryParse(placetext, out place) || place < 0 || place >= orderedByPopularytiNames.Count());            

            Console.WriteLine($"jusu pasitinkta vieta ({place}) vardas yra: " +
                $"{orderedByPopularytiNames[place-1].Item1}, " +
                $"sis vardas pasikartojo {orderedByPopularytiNames[place-1].Item2} kartu");
        }

        public async static Task RemoveSurnames()
        {
            var dir = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\name.txt";
            
            var names = await File.ReadAllLinesAsync(dir);
            var listOfJustNames = new List<string>();

            foreach (var name in names)
            {
                if(name.Contains(" "))
                {
                    listOfJustNames.Add(name.Split(" ")[0]);
                }
            }

            await File.WriteAllLinesAsync(dir, listOfJustNames);

        }

        public async static Task CreateFile()
        {
            Directory.CreateDirectory(filePath);
            await File.WriteAllTextAsync($"{filePath}{fileName}", "1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n11\n...");
        }

        public static void DeleteFile()
        {
            File.Delete($"{filePath}{fileName}");
        }

        public static void ListenToFolder()
        {
            using var fileSystemWatcher = new FileSystemWatcher(filePath);

            //fileSystemWatcher.IncludeSubdirectories = true;
            fileSystemWatcher.EnableRaisingEvents = true;

            fileSystemWatcher.Changed += (object sender, FileSystemEventArgs e) => { Console.WriteLine("Event fired 'Changed'"); };
            fileSystemWatcher.Created += OnFileCreation;
            fileSystemWatcher.Deleted += (object sender, FileSystemEventArgs e) => { Console.WriteLine("Event fired 'Deleted'"); };
            fileSystemWatcher.Error += (object sender, ErrorEventArgs e) => { Console.WriteLine("Event fired 'Error'"); };
            fileSystemWatcher.Renamed += OnFileRename;

            Console.WriteLine("Directory will be watched until you press ENTER");
            Console.ReadLine();
        }

        public static void OnFileRename(object s, RenamedEventArgs e)
        {
            Console.WriteLine("Event fired 'Renamed'");
        }

        public static void OnFileCreation(object s, FileSystemEventArgs e)
        {
            Console.WriteLine("Event fired 'Created'");
        }
    }
}
