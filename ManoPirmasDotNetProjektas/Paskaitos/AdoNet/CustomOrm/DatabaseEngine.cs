using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using ManoPirmasDotNetProjektas.Paskaitos.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.AdoNet.CustomOrm
{
    public class DatabaseEngine
    {
        private readonly string _connectionString;
        private readonly ILoggerServise _logger;

        public DatabaseEngine(AppSettings settings, ILoggerServise logger)
        {
            _connectionString = settings.BookStoreConnection;
            _logger = logger;
        }
        
        public async Task<IEnumerable<T>> SelectAll<T>() where T : new()
        {
            //susikurem generic list
            var items = new List<T>();

            //Susirenkam specifines klases pavadinima ir properciu, pavadinimus
            var type = typeof(T);
            var properties = type.GetProperties();

            //deklaruojam connectiona
            using var conn = new SqlConnection(_connectionString);

            //Sugeneruojam query Sql'ui/sql sakyni)
            var SQ = new StringBuilder("Select ");

            //klases parametrai
            for (int i = 0; i < properties.Length; i++)
            {
                SQ.Append($" {(i == 0 ? "" : ",")}[{GetColumnName(properties[i])}] ");
            }

            SQ.Append($" FROM [{GetTableName(type)}]");

            Console.WriteLine(SQ.ToString());

            //deklaruojam SQL komanda            
            var sqlCmd = new SqlCommand(SQ.ToString(), conn);

            //Atidarom connectiona
            await conn.OpenAsync();

            try
            {
                //issikvieciam readeri
                using var reader = await sqlCmd.ExecuteReaderAsync();

                //nuskaitom visus duomenis is lentos
                while (await reader.ReadAsync())
                {
                    try
                    {
                        var item = new T();

                        for (int i = 0; i < properties.Length; i++)
                        {
                            properties[i].SetValue(item, reader.GetValue(i));
                        }

                        items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        await _logger.LogError($"Error parsing from DataBase, Table: {type.Name}");
                        await _logger.LogError(ex.Message);
                        await _logger.LogError(ex.StackTrace);
                    }
                }
            }
            catch(Exception ex)
            {
                await _logger.LogError($"Error reading from DataBase, Table: {type.Name}");
                await _logger.LogError(ex.Message);
                await _logger.LogError(ex.StackTrace);
            }        

            return items;
        }

        public async Task<IEnumerable<T>> Select<T>(string whereCondition) where T : new()
        {

            //susikurem generic list
            var items = new List<T>();

            //Susirenkam specifines klases pavadinima ir properciu, pavadinimus
            var type = typeof(T);
            var properties = type.GetProperties();

            //deklaruojam connectiona
            using var conn = new SqlConnection(_connectionString);

            //Sugeneruojam query Sql'ui/sql sakyni)
            var SQ = new StringBuilder("Select ");

            //klases parametrai
            for (int i = 0; i < properties.Length; i++)
            {
                SQ.Append($" {(i == 0 ? "" : ",")}[{GetColumnName(properties[i])}] ");
            }

            SQ.Append($" FROM [{GetTableName(type)}]");

            SQ.Append($"WHERE {whereCondition}");

            Console.WriteLine(SQ.ToString());

            //deklaruojam SQL komanda            
            var sqlCmd = new SqlCommand(SQ.ToString(), conn);

            //Atidarom connectiona
            await conn.OpenAsync();

            try
            {
                //issikvieciam readeri
                using var reader = await sqlCmd.ExecuteReaderAsync();

                //nuskaitom visus duomenis is lentos
                while (await reader.ReadAsync())
                {
                    try
                    {
                        var item = new T();

                        for (int i = 0; i < properties.Length; i++)
                        {
                            properties[i].SetValue(item, reader.GetValue(i));
                        }

                        items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        await _logger.LogError($"Error parsing from DataBase, Table: {type.Name}");
                        await _logger.LogError(ex.Message);
                        await _logger.LogError(ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                await _logger.LogError($"Error reading from DataBase, Table: {type.Name}");
                await _logger.LogError(ex.Message);
                await _logger.LogError(ex.StackTrace);
            }

            return items;
        }

        public async Task Delete<T>(T row)
        {
            
        }

        public async Task Delete<T>(IEnumerable<T> rows)
        {

        }

        public async Task<int> Insert<T>(T row)
        {
            return 10; // jei yra ID autoIncriment grazini ji, jei ne -1
        }

        public async Task InsertBulk<T>(IEnumerable<T> rows)
        {

        }

        public async Task Update<T>(IEnumerable<T> rows)
        {

        }

        public async Task Update<T>(T row)
        {

        }


        private string GetColumnName(PropertyInfo property) =>
            property.GetCustomAttributes(false).Select(x => 
                ((ColumnAttribute)x).Name).FirstOrDefault() ?? property.Name;

        private string GetTableName(Type type) => 
            type.GetCustomAttributes(false).Select(x =>
                ((TableAttribute)x).Name).FirstOrDefault() ?? type.Name;
    }    
}
