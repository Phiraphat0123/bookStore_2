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
            try
            {
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

                        entries.Add(new BookModel { 
                            ISBN = query.IsDBNull(query.GetOrdinal("ISBN"))? 0: query.GetInt32(query.GetOrdinal("ISBN")),
                            title = query.IsDBNull(query.GetOrdinal("Title")) ? string.Empty : query.GetString(query.GetOrdinal("Title")),
                            description = query.IsDBNull(query.GetOrdinal("Description")) ? string.Empty : query.GetString(query.GetOrdinal("Description")),
                            price = query.IsDBNull(query.GetOrdinal("Price")) ? 0.0 : query.GetDouble(query.GetOrdinal("Price"))
                        });
                    }
                    db.Close();
                }
                return entries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return entries;
            }
            
        }
        public  List<Object>  GetData(int id)
        {
           List<Object> entries = new List<Object>();
            try
            {
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
                        entries.Add(new BookModel
                        {
                            ISBN = query.IsDBNull(query.GetOrdinal("ISBN")) ? 0 : query.GetInt32(query.GetOrdinal("ISBN")),
                            title = query.IsDBNull(query.GetOrdinal("Title")) ? string.Empty : query.GetString(query.GetOrdinal("Title")),
                            description = query.IsDBNull(query.GetOrdinal("Description")) ? string.Empty : query.GetString(query.GetOrdinal("Description")),
                            price = query.IsDBNull(query.GetOrdinal("Price")) ? 0.0 : query.GetDouble(query.GetOrdinal("Price"))
                        });
                    }
                    db.Close();
                }
                return entries;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return entries;
            }
           
        }
        public override Boolean AddData()
        {
            MessageBox.Show("Please in put data");
            return false;
            //throw new NotImplementedException();
        }

        public Boolean AddData(int bookId, string bookName, string bookDesc, int bookPrice)
        {
            try
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
        public override Boolean DeleteData() {
            MessageBox.Show("Delete must has a book id");
            return false;
        }
        public  Boolean DeleteData(int bookId)
        {
            try
            {
                using (SqliteConnection db =
             new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "Delete From Books WHERE ISBN=@ISBN";
                    insertCommand.Parameters.AddWithValue("@ISBN", bookId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.ExecuteReader();
                    db.Close();
                }
                return true;
                //MessageBox.Show("this is delete book");
                //return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }
        public  override  Boolean UpdateData()
        {
            MessageBox.Show("Need data for update!");
            return false;
        }
        public  Boolean UpdateData(int bookId, string bookName, string bookDesc, int bookPrice)
        {
            try
            {
                using (SqliteConnection db =
                             new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "UPDATE Books SET Title=@Title, Description=@Desc, Price=@Price  WHERE ISBN=@ISBN";
                    insertCommand.Parameters.AddWithValue("@ISBN", bookId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@Title", bookName); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@Desc", bookDesc); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@Price", bookPrice); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.ExecuteReader();
                    db.Close();
                }
                return true;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }

    }
}
