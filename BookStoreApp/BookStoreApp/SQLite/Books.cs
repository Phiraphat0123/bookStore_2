using BookStoreApp.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStoreApp.SQLite
{
    internal class Books : DataAccess
    {
        private string databaseFile = "Books.db";
        public Books()
        {
            SqliteConnection db = new SqliteConnection($"Filename={databaseFile}");
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Books (" +
                    "ISBN INTEGER PRIMARY KEY, " + //book id
                    "Title varchar(50), " + //book name
                    "Description varchar(150)," + //book des
                    "Price DOUBLE" +
                    ") ";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

        public override List<Object> GetData()
        {
            List<Object> entries = new List<Object>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename={databaseFile}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                
                while (query.Read())
                {
                    //entries.Add(query.GetString(0));
                    //query.GetInt32(0); //Id
                    //query.GetString(1); //Title
                    //query.GetString(2); //Description
                    //query.GetDouble(3); //Price

                    entries.Add(new BookModel {ISBN= query.GetInt32(0), title=query.GetString(1), description=query.GetString(2), price=query.GetDouble(3) });
                }
                db.Close();
            }
            return entries;
        }
        public  List<Object>  GetData(int id)
        {
           List<Object> entries = new List<Object>();
           using (SqliteConnection db =
              new SqliteConnection($"Filename={databaseFile}"))
           {
               db.Open();
                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = $"SELECT * from Books Where ISBN=@Condition;";
                selectCommand.Parameters.AddWithValue("@Condition", id);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    //entries.Add(query.GetString(0));
                    entries.Add(new BookModel { ISBN = query.GetInt32(0), title = query.GetString(1), description = query.GetString(2), price = query.GetDouble(3) });
                }
                db.Close();
            }
            return entries;
        }
        public override Boolean AddData()
        {
            throw new Exception("Please in put data");
            //throw new NotImplementedException();
        }

        public Boolean AddData(string bookId, string bookName, string bookDesc, string bookPrice)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename={databaseFile}"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Books VALUES (@ISBN, @Title, @Description, @Price);";
                insertCommand.Parameters.AddWithValue("@ISBN", bookId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                insertCommand.Parameters.AddWithValue("@Title", bookName);
                insertCommand.Parameters.AddWithValue("@Description", bookDesc);
                insertCommand.Parameters.AddWithValue("@Price", bookPrice);
                insertCommand.ExecuteReader();
                db.Close();
            }
            return false;
        }

        public override Boolean DeleteData()
        {
            MessageBox.Show("this is delete book");
            return false;
        }
        public  override  Boolean UpdateData()
        {
            MessageBox.Show("this is update book");
            return false;
        }

    }
}
