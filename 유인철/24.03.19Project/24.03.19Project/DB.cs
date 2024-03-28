using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _24._03._19Project
{
    internal class DB
    {
        string constr = "Data Source=BOOK-V6GV8E0ABL; Initial Catalog=Pharm; User ID=sa; Password=mammos3374;";
        private static DB instance;
        public static DB GetInstance()
        {
            if (instance == null)
            {
                instance = new DB();
            }
            return instance;
        }
        public List<string> SelectPres_ID(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    List<string> lists = new List<string>();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lists.Add(reader.GetString(0));
                            }
                        }
                    }
                    return lists;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public ObservableCollection<Prescription> PreSelectDB(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    Prescription pre;
                    ObservableCollection<Prescription> plist = new ObservableCollection<Prescription>();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pre = new Prescription
                                (
                                    reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3)
                                );
                                plist.Add(pre);
                            }
                        }
                    }
                    return plist;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public ObservableCollection<Medicine> MedSelectDB(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    Medicine Med;
                    ObservableCollection<Medicine> mlist = new ObservableCollection<Medicine>();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Med = new Medicine
                                (
                                    reader.GetString(0), reader.GetString(1),
                                    reader.GetFloat(2), reader.GetString(3),
                                    reader.GetString(4), reader.GetString(5)
                                );
                                mlist.Add(Med);
                            }
                        }
                    }
                    return mlist;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        
        public void UpdateDB(string query)
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
        public List<LabelUser> SelectDBUser(string query)
        {
            using(SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    LabelUser lu;
                    List<LabelUser> labelUsers = new List<LabelUser>();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) 
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lu = new LabelUser(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                                labelUsers.Add(lu);
                            }
                        }
                    }
                    return labelUsers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public List<LabelDrug> SelectDBDrug(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    LabelDrug ld;
                    List<LabelDrug> labelDrugs = new List<LabelDrug>();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ld = new LabelDrug(reader.GetString(0), reader.GetString(1), 
                                    reader.GetString(2), reader.GetFloat(3), reader.GetString(4));
                                labelDrugs.Add(ld);
                            }
                        }
                    }
                    return labelDrugs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public List<LabelShop> SelectDBShop(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    LabelShop ls;
                    List<LabelShop> labelShops = new List<LabelShop>();
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ls = new LabelShop(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                                labelShops.Add(ls);
                            }
                        }
                    }
                    return labelShops;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public DRUGInfoName SelectDRUGInfoName(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    DRUGInfoName difn = null;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                difn = new DRUGInfoName(reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                    return difn;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public HS_INFO SelectedHsinfo(string query)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    HS_INFO hsin = null;
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hsin = new HS_INFO(
                                    reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4), reader.GetString(5)
                                    );
                            }
                        }
                    }
                    return hsin;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
