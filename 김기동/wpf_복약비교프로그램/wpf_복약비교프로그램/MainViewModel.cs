using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;

namespace wpf_복약비교프로그램
{
    internal class MainViewModel
    {
        String connStr = "Data Source=BOOK-2NG7EV5MG4; Initial Catalog=Pharm; User ID=sa; Password=mammos3374;";

        
        public void Load_PRES(DateTime startDate, DateTime endDate, DataGrid DG_Pres)
        {
            string query = $"SELECT PPRESCR3.ChkNum, PPRESCR1.Ct_Name, PPRESCR1.Pres_Date, PPRESCR1.Pres_Time, PPRESCR1.Inhabitant_id " +
                           $"FROM PPRESCR1 " +
                           $"INNER JOIN PPRESCR3 ON PPRESCR1.Pres_Id = PPRESCR3.Pres_ID " +
                           $"WHERE PPRESCR1.Pres_Date BETWEEN '{startDate.ToString("yyyyMMdd")}' AND '{endDate.ToString("yyyyMMdd")}'";
            
            ObservableCollection<PrescriptionData> prescriptionDataList = new ObservableCollection<PrescriptionData>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@FirstDate", startDate);
                        command.Parameters.AddWithValue("@SecondDate", endDate);
                        connection.Open();

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                prescriptionDataList.Add(new PrescriptionData()
                                {                                   
                                    ChkNum = rdr["ChkNum"].ToString(),
                                    CtName = rdr["Ct_Name"].ToString(),
                                    PresDate = rdr["Pres_Date"].ToString(),
                                    PresTime = rdr["Pres_Time"].ToString(),
                                    InhabitantID = rdr["Inhabitant_ID"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"오류 발생: {ex.Message}");
                    }
                }
            }

            DG_Pres.ItemsSource = prescriptionDataList;
        }

        public class PrescriptionData
        {
            public string ChkNum { get; set; }
            public string CtName { get; set; }
            public string PresDate { get; set; }
            public string PresTime { get; set; }
            public string InhabitantID { get; set; }
        }


        public void Load_CusPres(SelectionChangedEventArgs e, DataGrid DG_Custom, DataGrid DG_Pres)
        {
            PrescriptionData selectedPrescription = (PrescriptionData)DG_Pres.SelectedItem;
            string selectedPresName = selectedPrescription.CtName;         

                string query = $@" SELECT PPRESCR3.ChkNum, PPRESCR1.Ct_Name, PPRESCR1.Pres_Date, PPRESCR1.Pres_Time, PPRESCR3.Dr_Name, PPRESCR3.Part_id,
                          PPRESCR3.Hs_Name, PPRESCR3.insurance_Gb
                          FROM PPRESCR1
                          INNER JOIN PPRESCR3 ON PPRESCR1.Pres_Id = PPRESCR3.Pres_ID
                          Where PPRESCR1.Ct_Name = '{selectedPresName}'
                          ";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Ct_Name", selectedPresName);
                        connection.Open();

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("순번", typeof(int));
                            dataTable.Columns.Add("성함", typeof(string));
                            dataTable.Columns.Add("날짜", typeof(string));
                            dataTable.Columns.Add("시간", typeof(string));
                            dataTable.Columns.Add("의사명", typeof(string));
                            dataTable.Columns.Add("진료과", typeof(string));
                            dataTable.Columns.Add("기관명", typeof(string));
                            dataTable.Columns.Add("보험", typeof(string));
                            while (rdr.Read())
                            {
                                DataRow row = dataTable.NewRow();
                                row["순번"] = rdr["ChkNum"].ToString();
                                row["성함"] = rdr["Ct_Name"].ToString();
                                row["날짜"] = rdr["Pres_Date"].ToString();
                                row["시간"] = rdr["Pres_Time"].ToString();
                                row["의사명"] = rdr["Dr_Name"].ToString();
                                row["진료과"] = rdr["Part_id"].ToString();
                                row["기관명"] = rdr["Hs_Name"].ToString();
                                row["보험"] = rdr["insurance_Gb"].ToString();

                                dataTable.Rows.Add(row);
                            }
                            DG_Custom.ItemsSource = dataTable.DefaultView;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"오류 발생: {ex.Message}");
                    }
                }
            }
        }
        }

    }


