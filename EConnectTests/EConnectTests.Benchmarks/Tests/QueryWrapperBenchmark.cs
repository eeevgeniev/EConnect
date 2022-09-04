using BenchmarkDotNet.Attributes;
using EConnect;
using EConnectTests.Benchmarks.Models;
using EConnectTests.SettingParser;
using EConnectTests.Settings;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;

namespace EConnectTests.Benchmarks.Tests
{
    [MemoryDiagnoser(true)]
    public class QueryWrapperBenchmark
    {
        private const string SETTING_NAME = "settings.json";
        private const string SMALLLISTQUERY = "SELECT * FROM models ORDER BY id LIMIT 10 OFFSET 1011;";
        private const string LARGELISTQUERY = "SELECT * FROM models ORDER BY id LIMIT 98989 OFFSET 1011;";
        private const string SINGLEQUERY = "SELECT * FROM models ORDER BY id LIMIT 1 OFFSET 52333;";

        private readonly Parser _parser;
        private readonly Setting _setting;

        public QueryWrapperBenchmark()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), SETTING_NAME);

            this._parser = new Parser();
            this._setting = this._parser.ParserConfiguration(path);
        }

        [Benchmark]
        public List<Model> SmallQueryEConnect()
        {
            List<Model> models = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                models = connection.Query<Model>(SMALLLISTQUERY, null);
            }

            return models;
        }

        [Benchmark]
        public List<Model> LargeQueryEConnect()
        {
            List<Model> models = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                models = connection.Query<Model>(LARGELISTQUERY, null);
            }

            return models;
        }

        [Benchmark]
        public List<string> LargeStringQueryEConnect()
        {
            List<string> strings = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                strings = connection.Query<string>("SELECT Strp FROM models ORDER BY id LIMIT 98989 OFFSET 1011;", null);
            }

            return strings;
        }

        [Benchmark]
        public List<int> LargeIntQueryEConnect()
        {
            List<int> integers = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                integers = connection.Query<int>("SELECT Id FROM models ORDER BY id LIMIT 98989 OFFSET 1011;", null);
            }

            return integers;
        }

        [Benchmark]
        public List<DateTime> LargeDateTimesQueryEConnect()
        {
            List<DateTime> dateTimes = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                dateTimes = connection.Query<DateTime>("SELECT Date FROM models ORDER BY id LIMIT 98989 OFFSET 1011;", null);
            }

            return dateTimes;
        }

        [Benchmark]
        public List<decimal> LargeDecimalsQueryEConnect()
        {
            List<decimal> decimals = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                decimals = connection.Query<decimal>("SELECT Dcml FROM models ORDER BY id LIMIT 98989 OFFSET 1011;", null);
            }

            return decimals;
        }

        [Benchmark]
        public List<long> LargeLongsQueryEConnect()
        {
            List<long> longs = null;

            using (Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString))
            {
                longs = connection.Query<long>("SELECT Lng FROM models ORDER BY id LIMIT 98989 OFFSET 1011;", null);
            }

            return longs;
        }

        [Benchmark]
        public Model SmallQueryEConnectSingleModel()
        {
            using Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString);

            var (hasResults, model) = connection.Single<Model>(SINGLEQUERY, null);

            return model;
        }

        [Benchmark]
        public Dictionary<string, object> SmallQueryEConnectSingleDict()
        {
            using Connection<NpgsqlConnection> connection = new Connection<NpgsqlConnection>(this._setting.ConnectionString);

            var (hasResults, dict) = connection.Single<Dictionary<string, object>>(SINGLEQUERY, null);

            return dict;
        }
    }
}