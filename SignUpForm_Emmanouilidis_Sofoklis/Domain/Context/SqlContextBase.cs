﻿using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Domain.Context
{
    internal class SqlContextBase
    {
        protected readonly static string _connectionString =
            "datasource=localhost;port=3306;username=root;password=;database=efoodusers";


        protected static string GetInsertScripts<T>(T entity)
        {

            var entityList = new List<T>();
            entityList.Add(entity);
            return GetInsertScripts(entityList);

        }

        protected static T CreateInstance<T>(MySqlDataReader reader) where T : new()
        {

            var properties = typeof(T).GetProperties();
            var dto = new T();

            foreach(var property in properties)
            {
                var value = GetDtoValue(reader[property.Name]);
                var propertyType = property.GetType();

                property.SetValue(dto, propertyType.Cast(value));
            }

            return dto;

        }

        protected static async Task<List<T>> GetAsDatabaseModel<T>() where T : new()
        {
            var list = new List<T>();

            var properties = typeof(T).GetProperties();

            var columnNames = properties.Select(p => p.Name);
            var columns = string.Join(", ", columnNames);

            var sql = $"SELECT {columns} FROM {typeof(T).Name}";

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(sql, connection))
            {
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var model = new T();

                        foreach (var property in properties)
                        {
                            var value = GetDtoValue(reader[property.Name]);
                            property.SetValue(model, value);
                        }

                        list.Add(model);
                    }
                }
            }

            return list;
        }


        protected static Dictionary<string, object> GetAsDatabaseModelsGeneric(params Type[] tabletypes)
        {
            var results = new Dictionary<string, object>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    foreach (var tabletype in tabletypes)
                        using (var command = new MySqlCommand($"SELECT * FROM {tabletype.Name}", connection))
                        {
                            connection.Open();
                            var dto = Activator.CreateInstance(tabletype);
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {

                                foreach (PropertyInfo property in tabletype.GetProperties())
                                {
                                    var value = GetDtoValue(reader[property.Name]);
                                    property.SetValue(dto, property.GetType().Cast(value));
                                }
                            }

                            results.Add(tabletype.Name, dto);
                        }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();

                }

            }
            return results;
        }

        protected static Dictionary<string, DataTable> GetAsDataTablesGeneric(params string[] tables)
        {
            var results = new Dictionary<string, DataTable>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    foreach (var table in tables)
                        using (var command = new MySqlCommand($"SELECT * FROM {table}", connection))
                        {
                            connection.Open();

                            command.ExecuteNonQuery();

                            var adapter = new MySqlDataAdapter(command);
                            var dataEntries = new DataTable(table);
                            adapter.Fill(dataEntries);

                            results.Add(table, dataEntries);

                        }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();

                }

            }
            return results;
        }

        protected static string GetInsertScripts<T>(List<T> entity)
        {
                  
            var names = typeof(T).Name;
            var values = "VALUES ";

            var assignablePropertyCollection = typeof(T).GetProperties()
                .Where(x => x.CanWrite && !Attribute.IsDefined(x, typeof(PrimaryKey)));

            names += "(";
            names = assignablePropertyCollection
                .Aggregate(names, (current, property) => current + (property.Name + ","));
            names = names.TrimEnd(',');
            names += ")";

            foreach (var item in entity)
            {
                values += "(";
                values = assignablePropertyCollection
                    .Aggregate(values, (current, property) => current + (GetValueString(property.GetValue(item)) + ","));

                values = values.TrimEnd(',');
                values += "),";
            }
            values = values.TrimEnd(',');

            var query = "INSERT INTO " + names + " " + values + ";";

            return query;
        }

        protected static string GetUpdateScript<T>(T entity)
        {
            if (typeof(IEnumerable<object>).IsAssignableFrom(typeof(T))) return string.Empty;

            var assignablePropertyCollection = typeof(T).GetProperties()
                .Where(x => x.CanWrite && !Attribute.IsDefined(x, typeof(PrimaryKey)));

            var identityProperties = typeof(T).GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(PrimaryKey)));


            var values = new List<string>();

            foreach (PropertyInfo property in assignablePropertyCollection)
                values.Add(string.Format("{0}={1}", property.Name, GetValueString(property.GetValue(entity))));


            var where = new List<string>();

            foreach (PropertyInfo property in identityProperties)
                where.Add(string.Format("{0}={1}", property.Name, GetValueString(property.GetValue(entity))));


            var query = "UPDATE " + typeof(T).Name + " SET " + string.Join(", ", values) + " WHERE " + string.Join(" AND ", where) + ';';

            return query;
        }

        protected List<int> ExecDbScripts(IEnumerable<string> sqlScripts)
        {
            var idCollection = new List<int>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {

                    try
                    {
                        foreach (var item in sqlScripts)
                            using (var command = new MySqlCommand(item, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                                idCollection.Add((int)command.LastInsertedId);
                            }


                        transaction.Commit();


                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        throw;
                    }
                    finally
                    {
                        connection.Close();

                    }

                }
            }

            return idCollection;
        }

        protected int ExecDbScripts(string sqlScript)
        {
            var scriptsCollection = new List<string>();
            scriptsCollection.Add(sqlScript);
            
            var idCollection = ExecDbScripts(scriptsCollection);
            return idCollection.Count == 1 ? idCollection[0] : -1;

        }

        private static string GetValueString<T>(T propertyValue)
        {
            if (propertyValue == null) return "NULL";

            var propertyType = propertyValue.GetType();
            if (propertyType == typeof(string)) return "'" + MySqlHelper.EscapeString(propertyValue as string) + "'";
            if (propertyType == typeof(DateTime))
            {
                var date = DateTime.Parse(propertyValue.ToString());
                return "'" + GetUTCString(date) + "'";
            }

            return propertyValue.ToString();
        }

        private static string GetUTCString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd H:mm:ss");
        }

        private static object GetDtoValue(object DBvalue)
        {
            return DBvalue == DBNull.Value ? null : DBvalue;
        }

    }
}
