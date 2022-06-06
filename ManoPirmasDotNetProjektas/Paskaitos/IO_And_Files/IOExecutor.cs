using CsvHelper;
using CsvHelper.Configuration;
using log4net;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace ManoPirmasDotNetProjektas.Paskaitos.IO_And_Files
{
    public class IOExecutor : ITema
    {
        private readonly string _filePath = $@"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\";
        private readonly string _fileName = "SekmingaiSusikuriaFailas2.txt";
        private readonly string _nameFileDirectory = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\name.txt";
        private readonly string _nameFileDirectoryD = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\nameD.txt";
        private readonly string _csvFileDirectory = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder\characterlist.csv";
        private readonly string _csvFileFolder = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\NewFolder";

        private readonly ILoggerServise _logger;

        public IOExecutor(ILoggerServise logger)
        {
            _logger = logger;
        }

        public async Task Run()
        {
            
            //await ReadTextFile();
            //await CreateFile();
            //DeleteFile();
            //ListenToFolder();
            //await RemoveSurnames();
            //await FindMostPopularNames();
            //await FileStramingExamples();
            //CsvHelperExamples();
            //await ReadFileToClassCustom();
            await CsvToJSON(";");
        }

        public async Task CsvToJSON(string separator)
        {            
            await _logger.LogInfo("Starting CSV to JSON method");
            
            var csvFilesPath = FindCsvFiles(_csvFileFolder);

            foreach(var csvFilePath in csvFilesPath)
            {
                var className = GetNameOfParsibleClass(ReadFileHeaders(csvFilePath), separator);

                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
                csvConfiguration.Delimiter = separator;

                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, csvConfiguration))
                {
                    if (className == typeof(Character).Name)
                    {
                        try
                        {
                            var records = csv.GetRecords<Character>();
                            string jsonCharactersString = JsonConvert.SerializeObject(records);

                            await File.WriteAllTextAsync(csvFilePath.Replace(".csv", ".json"), jsonCharactersString);
                        }
                        catch (Exception ex)
                        {
                            await _logger.LogError("failed to Parse CSV Character (maybe bad format)");
                            await _logger.LogError(ex.ToString());
                        }
                    }
                    if (className == typeof(CsvEmployee).Name)
                    {
                        try
                        {
                            var records = csv.GetRecords<CsvEmployee>();
                            var modifiedRecords = new List<JsonEmployee>();

                            foreach (var record in records)
                            {
                                modifiedRecords.Add(new JsonEmployee(record));
                            }

                            string jsonEmployeesString = JsonConvert.SerializeObject(modifiedRecords);
                            await File.WriteAllTextAsync(csvFilePath.Replace(".csv", ".json"), jsonEmployeesString);
                        }
                        catch (Exception ex)
                        {
                            await _logger.LogError("failed to Parse CSV Employee (maybe bad format)");
                            await _logger.LogError(ex.ToString());
                        }
                    }
                }  
            }
        }

        public string GetNameOfParsibleClass(string headersString, string seperator)
        {
            var headers = headersString.Split(seperator);

            var isCharacter = true;
            var isEmployee = true;

            for (int i = 0; i < headers.Length; i++)
            {
                if(typeof(Character).GetProperties().Count() <= i || headers[i] != typeof(Character).GetProperties()[i].Name)
                {
                     isCharacter = false;
                }

                if(typeof(CsvEmployee).GetProperties().Count() <= i || headers[i] != typeof(CsvEmployee).GetProperties()[i].Name)
                {
                    isEmployee = false;
                }
            }

            if (isCharacter)
            {
                return typeof(Character).Name;
            }

            if (isEmployee)
            {
                return typeof(CsvEmployee).Name;
            }

            return null;
        }

        public string ReadFileHeaders(string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var fileReader = new StreamReader(fileStream);
            
            return fileReader.ReadLine();
        } 

        public string[] FindCsvFiles(string directory)
        {
            var csvFilesInfo = new DirectoryInfo(_csvFileFolder).GetFiles("*.csv");

            var csvFilesPath = new string[csvFilesInfo.Length];
            
            for (int i = 0; i < csvFilesInfo.Length; i++)
            {
                csvFilesPath[i] = csvFilesInfo[i].FullName;
            }

            return csvFilesPath;
        }

        public async Task ReadFileToClassCustom()
        {
            var lines = await File.ReadAllLinesAsync(_csvFileDirectory);
            var characters = new List<Character>();

            var columnNames = true;

            foreach (var line in lines)
            {
                if (columnNames) 
                {
                    columnNames = false;
                    continue;
                }

                var columns = line.Split(";");

                characters.Add(new Character(int.Parse(columns[0]), columns[1], columns[2], DateTime.Parse(columns[3])));
            }
            Console.WriteLine("\nCUSTOM PARSE\n");

            foreach (var record in characters)
            {
                Console.WriteLine(record.ID);
                Console.WriteLine(record.Name);
                Console.WriteLine(record.Surname);
                Console.WriteLine(record.BirthDate);
            }
        } 
        public void CsvHelperExamples()
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.Delimiter = ";";

            using (var reader = new StreamReader(_csvFileDirectory))  
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                var records = csv.GetRecords<Character>();

                Console.WriteLine("\nCSVHELPER PARSE\n");

                foreach (var record in records)
                {
                    Console.WriteLine(record.ID);
                    Console.WriteLine(record.Name);
                    Console.WriteLine(record.Surname);
                    Console.WriteLine(record.BirthDate);
                }
            }
        }

        public async Task FileStramingExamples()
        {
            //Susikuriam nauja file stream objekta
            using var fileStream = 
                new FileStream(_nameFileDirectory, FileMode.Open, FileAccess.Read);
            
            using var fileStramForWriting = 
                new FileStream(_nameFileDirectoryD, FileMode.OpenOrCreate, FileAccess.Write);

            //susikuriam nauja to streamo readeri
            using var fileReader = 
                new StreamReader(fileStream);

            //susikuriam nauja stream writeri
            using var fileWriter = new StreamWriter(fileStramForWriting);

            var counter = 1;

            while (!fileReader.EndOfStream) // kol streamas nedaeis iki failo galo
            {
                //nuskaitom viena eilute (kita kart iskvietus metoda, streamreaderis skaitys jau sekancia eilute)
                var line = await fileReader.ReadLineAsync();

                if (fileReader.EndOfStream)// true when last line already read.
                {
                    Console.WriteLine($"last line: {line}");
                }
                else
                {  
                    //isprintima i console ta eilute
                    Console.WriteLine($"line ({counter}): {line}");
                }               

                await fileWriter.WriteLineAsync(line);

                counter++;
            }

        }

        public async Task ReadTextFile()
        {
            var lines = await File.ReadAllLinesAsync(@"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\FileFolder\ManoTxtFailas.txt");

            var counter = 0;
            foreach (var line in lines)
            {
                counter++;
                Console.WriteLine($"{counter}-oji eilute: {line}");
            }
        }

        public async Task FindMostPopularNames()
        {
            var names = await File.ReadAllLinesAsync(_nameFileDirectory);
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

        public async Task RemoveSurnames()
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

        public async Task CreateFile()
        {
            Directory.CreateDirectory(_filePath);
            await File.WriteAllTextAsync($"{_filePath}{_fileName}", "1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n11\n...");
        }

        public void DeleteFile()
        {
            File.Delete($"{_filePath}{_fileName}");
        }

        public void ListenToFolder()
        {
            using var fileSystemWatcher = new FileSystemWatcher(_filePath);

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

        public void OnFileRename(object s, RenamedEventArgs e)
        {
            Console.WriteLine("Event fired 'Renamed'");
        }

        public void OnFileCreation(object s, FileSystemEventArgs e)
        {
            Console.WriteLine("Event fired 'Created'");
        }
    }
}

