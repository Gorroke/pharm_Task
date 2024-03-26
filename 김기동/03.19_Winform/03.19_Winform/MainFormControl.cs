using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03._19_Winform
{
    internal class MainFormControl
    {
        String connStr = "Data Source=BOOK-2NG7EV5MG4; Initial Catalog=Pharm; User ID=sa; Password=mammos3374;";

        /// <summary>
        /// 처방전 불러오기 기능
        /// </summary>
        /// <param name="selectedDate"></param>
        public void Load_PRES(DateTime selectedDate, ListView LV_PRES)
        {
            string query = $"SELECT PPRESCR3.Pres_ID, PPRESCR1.Ct_Name, PPRESCR1.Inhabitant_id, PPRESCR1.Pres_Time " +
                   $"FROM PPRESCR1 " +
                   $"INNER JOIN PPRESCR3 ON PPRESCR1.Pres_Id = PPRESCR3.Pres_ID "+
                   $"WHERE CONVERT(date, PPRESCR1.Pres_Date) = CONVERT(date, @SelectedDate)"; //PPRESCR1.Pres_Date와 선택된 날짜의 일자를 비교

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@SelectedDate", selectedDate);
                        connection.Open();

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            LV_PRES.Items.Clear();
                            LV_PRES.Columns.Clear();

                            LV_PRES.Columns.Add("순번");
                            LV_PRES.Columns.Add("이름");
                            LV_PRES.Columns.Add("생년월일");
                            LV_PRES.Columns.Add("접수시간");


                            while (rdr.Read())
                            {
                                ListViewItem item = new ListViewItem(rdr["Pres_ID"].ToString());
                                item.SubItems.Add(rdr["Ct_Name"].ToString());
                                item.SubItems.Add(rdr["Inhabitant_id"].ToString());
                                item.SubItems.Add(rdr["Pres_Time"].ToString());

                                LV_PRES.Items.Add(item);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"오류 발생: {ex.Message}");
                    }
                }
            }
        }
        public void Load_Drug(ListViewItemSelectionChangedEventArgs e, ListView LV_DRUG)
        {
            string selectedPresID = e.Item.SubItems[0].Text; //Pres_ID 가져옴

            string query = $@" SELECT PDRUDRUG.Drug_Name, PDRUDRUG.Drug_ID, PDRUDRUG.LMax_Eat, PDRUDRUG.Drug_Term, PDRUDRUG.Pres_Unit
                              FROM PDRUDRUG
                              INNER JOIN PPRESCR4 ON PDRUDRUG.Drug_ID = PPRESCR4.Drug_ID
                              Where PPRESCR4.Pres_ID = '{selectedPresID}'
                              ";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@PresID", selectedPresID);
                        connection.Open();

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            LV_DRUG.Items.Clear();
                            LV_DRUG.Columns.Clear();

                            LV_DRUG.Columns.Add("약품명");
                            LV_DRUG.Columns.Add("약품코드");
                            LV_DRUG.Columns.Add("1회복용량");
                            LV_DRUG.Columns.Add("하루N번");
                            LV_DRUG.Columns.Add("복용일수");
                            LV_DRUG.Columns.Add("약품단위");


                            while (rdr.Read())
                            {
                                ListViewItem item = new ListViewItem(rdr["Drug_Name"].ToString());
                                item.SubItems.Add(rdr["Drug_ID"].ToString());
                                item.SubItems.Add(rdr["LMax_Eat"].ToString());
                                item.SubItems.Add(rdr["Drug_Term"].ToString());


                                LV_DRUG.Items.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"오류 발생: {ex.Message}");
                    }
                }
            }
        }


        public void Load_Custom(ListViewItemSelectionChangedEventArgs e, ListView LV_COSTOM)
        {
            string selectedPresName = e.Item.SubItems[1].Text; // 이름을 가져옴

            string query = $@" SELECT PCUSCUST.Ct_Name, PCUSCUST.Ct_BirthDate, PCUSCUST.Ct_Special1, PCUSCUST.Ct_Hp,
                              PPRESCR3.Hs_Name, PPRESCR3.Part_id, PPRESCR3.Hs_Tel, PPRESCR3.Dr_Name, PPRESCR3.Dr_Code
                              FROM PCUSCUST                              
                              INNER JOIN PPRESCR3 ON PCUSCUST.Ds_Id = PPRESCR3.ChkUserid1
                              Where PCUSCUST.Ct_Name = '{selectedPresName}'
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
                                LV_COSTOM.Items.Clear();
                                LV_COSTOM.Columns.Clear();

                                LV_COSTOM.Columns.Add("성명");                                
                                //LV_COSTOM.Columns.Add("나이");                                
                                LV_COSTOM.Columns.Add("생년월일");
                                LV_COSTOM.Columns.Add("고객메모");
                                LV_COSTOM.Columns.Add("전화번호");                               
                                //LV_COSTOM.Columns.Add("질병코드");                                
                                LV_COSTOM.Columns.Add("병원명");
                                LV_COSTOM.Columns.Add("진료과");
                                //LV_COSTOM.Columns.Add("병원코드");
                                LV_COSTOM.Columns.Add("병원전화번호");
                                LV_COSTOM.Columns.Add("의사명");
                                LV_COSTOM.Columns.Add("의사코드");


                            while (rdr.Read())
                                {
                                    ListViewItem item = new ListViewItem(rdr["Ct_Name"].ToString());
                                    item.SubItems.Add(rdr["Ct_BirthDate"].ToString());
                                    item.SubItems.Add(rdr["Ct_Special1"].ToString());
                                    item.SubItems.Add(rdr["Ct_Hp"].ToString());  
                                    item.SubItems.Add(rdr["Hs_Name"].ToString());
                                    item.SubItems.Add(rdr["Part_id"].ToString());
                                    item.SubItems.Add(rdr["Hs_Tel"].ToString());
                                    item.SubItems.Add(rdr["Dr_Name"].ToString());
                                    item.SubItems.Add(rdr["Dr_Code"].ToString());

                                LV_COSTOM.Items.Add(item);
                                }

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
