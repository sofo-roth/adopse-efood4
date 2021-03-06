﻿using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Domain.Context
{
    internal abstract class SqlContextBase
    {
        protected readonly static string _connectionString =  ConfigurationManager.ConnectionStrings["EFood"].ConnectionString;
        
        #region data mapping methods


        protected static T CreateInstance<T>(MySqlDataReader reader) where T : IDataTable, new()
        {

            var properties = typeof(T).GetProperties();
            var dto = new T();

            foreach (var property in properties)
            {
                if (!reader.HasColumn(property.Name)) continue;

                var value = GetDtoValue(reader[property.Name]);
                var propertyType = property.PropertyType;

                property.SetValue(dto, propertyType.Cast(value));
            }

            return dto;

        }

        protected static async Task<List<T>> GetAllAsDatabaseModel<T>() where T : IDataTable, new()
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


        protected static Dictionary<Type, object> GetAsDatabaseModelsGeneric(params Type[] tabletypes)
        {
            var results = new Dictionary<Type, object>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    foreach (var tabletype in tabletypes)
                        using (var command = new MySqlCommand($"SELECT * FROM {tabletype.Name}", connection))
                        {

                            var dto = Activator.CreateInstance(tabletype);
                            if (!IsDatabaseModelEntity(dto)) continue;

                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {

                                foreach (PropertyInfo property in tabletype.GetProperties())
                                {
                                    var value = GetDtoValue(reader[property.Name]);
                                    property.SetValue(dto, property.GetType().Cast(value));
                                }
                            }

                            results.Add(tabletype, dto);
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

        protected static Dictionary<string, DataTable> GetAsDataTablesGeneric(params Type[] tables)
        {
            var names = tables.Select(x => x.Name).ToArray();

            return GetAsDataTablesGeneric(names);
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

        #endregion


        #region sql script generation methods

        protected static string GetInsertScript<T>(T entity)
        {
            var entityList = new List<T>
            {
                entity
            };
            return GetInsertScripts(entityList);
        }

        protected static string GetInsertScripts<T>(List<T> entity)
        {
            if (!IsDatabaseModelEntity(entity.FirstOrDefault())) return null;

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

            if (typeof(IEnumerable<object>).IsAssignableFrom(typeof(T))) return null;
            if (!IsDatabaseModelEntity(entity)) return null;

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

        #endregion

        protected virtual List<int> ExecDbScripts(IEnumerable<string> sqlScripts)
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

        protected virtual int ExecDbScripts(string sqlScript)
        {
#pragma warning disable IDE0028
            var scriptsCollection = new List<string>();

            scriptsCollection.Add(sqlScript);

            var idCollection = ExecDbScripts(scriptsCollection);
            return idCollection.FirstOrDefault();

#pragma warning restore IDE0028

        }

        private static string GetValueString(object propertyValue)
        {
            switch (propertyValue)
            {
                case null:
                    return "NULL";
                case string str:
                    return "'" + MySqlHelper.EscapeString(str) + "'";
                case DateTime date:
                    return "'" + GetUTCString(date) + "'";

                default:
                    return propertyValue.ToString();

            }

        }

        private static bool IsDatabaseModelEntity<T>(T entity)
        {
            return entity is IDataTable;
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
