using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using ManoPirmasDotNetProjektas.Paskaitos.Settings;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<T>> Select<T>(string whereCondition = "") where T : new()
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

            if (!string.IsNullOrEmpty(whereCondition))
            {
                SQ.Append($" WHERE {whereCondition}");
            }

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
            var type = typeof(T);
            var properties = type.GetProperties();

            using var conn = new SqlConnection(_connectionString);

            var SQ = new StringBuilder("Delete ");
            SQ.Append($" FROM [{GetTableName(type)}]");
            SQ.Append(" WHERE ");

            //klases parametrai
            for (int i = 0; i < properties.Length; i++)
            {
                SQ.Append($" {(i == 0 ? "" : " AND ")} [{GetColumnName(properties[i])}] = '{properties[i].GetValue(row).ToString()}' ");
            }

            Console.WriteLine(SQ.ToString());

            var sqlCmd = new SqlCommand(SQ.ToString(), conn);

            await conn.OpenAsync();

            await sqlCmd.ExecuteNonQueryAsync();
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

        private string GetColumnName(PropertyInfo property) =>
            property.GetCustomAttributes(false).Select(x => 
                ((ColumnAttribute)x).Name).FirstOrDefault() ?? property.Name;

        private string GetTableName(Type type)
        {
            var xyy = type.GetCustomAttributes(false);

            if (xyy == null)
            {
                return type.Name;
            }
            else 
            {
                return xyy.Select(x => 
                {
                    try
                    {
                        return ((TableAttribute)x).Name;
                    }
                    catch
                    {
                        return string.Empty;
                    }                
                }).Where(x => string.IsNullOrEmpty(x)).FirstOrDefault() ?? type.Name;
            }   
        }
            
    }    
}
