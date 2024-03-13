using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace PictuerDrawing
{
    public class DB
    {
        string constr = "Data Source=BOOK-V6GV8E0ABL; Initial Catalog=PictureTest; User ID=sa; Password=mammos3374;";
        private static DB instance = new DB();
        public static DB GetInstance()
        {
            if(instance == null)
            {
                instance = new DB();
            }
            return instance;
        }
        public List<DBObject> SelectObjectDB(string query)
        {
            List<DBObject> ObjectDB = new List<DBObject>();
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DBObject dbo = new DBObject(reader.GetString(0), reader.GetInt32(1));
                                ObjectDB.Add(dbo);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return ObjectDB;
        }
        
        public DBLine SelectLineDB(string query)
        {
            DBLine LineDB = null;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LineDB = new DBLine
                                   (reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4), reader.GetString(5));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return LineDB;
        }
        public DBRectangle SelectRectDB(string query)
        {
            DBRectangle RectangleDB = null;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RectangleDB = new DBRectangle
                                   (reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4), reader.GetString(5));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return RectangleDB;
        }
        public DBEllipse SelectEliiDB(string query)
        {
            DBEllipse EliipseDB = null;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EliipseDB = new DBEllipse
                                   (reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4), reader.GetString(5));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return EliipseDB;
        }
        public DBPolygon SelectPolyDB(string query)
        {
            DBPolygon PolygonDB = null;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PolygonDB = new DBPolygon
                                   (reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return PolygonDB;
        }

        public void SaveDB(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
