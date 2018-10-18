using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using Dapper;

namespace studentExercises 
{

    public class DatabaseInterface
    {

        public static SqliteConnection Connection
        {
            get
            {
                string _connectionString = $"Data Source=./StudentExercises.db";
                return new SqliteConnection(_connectionString);
            }
        }

        // public static void AddExercise(string name, string lang)
        // {
        //     SqliteConnection db = DatabaseInterface.Connection;

        //     db.Execute($"insert into Exercise (ExerciseName, ExerciseLanguage) values ({name}, {lang})");
        // }

        // public static void checkExerciseTable() 
        // {
        //   SqliteConnection db = DatabaseInterface.Connection;


        // }

    }


}