using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace _24._03._19Project
{
    internal class ClassCollect
    {
        
    }
    public class Prescription // PPRESCR1
    {
        public string Number { get; set; } // 조제번호
        public string Name { get; set; } // 고객 이름 ct_Name
        public string Birthday { get; set; } // 주민등록번호
        public string Pres_Time { get; set; } // 조제 시간

        public Prescription(string num, string name, string birthday, string time)
        {
            string[] num1 = num.Split(' ');
            Number = num1[0];
            string[] name1 = name.Split(' ');
            Name = name1[0];
            string strings = birthday.Substring(0, 6);
            Birthday = strings;
            string time1 = time.Substring(0, 2);
            string time2 = time.Substring(2, 2);
            Pres_Time = time1 + "시 " + time2 + "분";
        }
    }
    public class Medicine // PDRUDRUG 와 PPRESCR4 Join
    {
        public string Name { get; set; } // 약품명 Drug_Name
        public string DrugCode { get; set; } // 약품코드 Drug_ID
        public string Eat { get; set; } // 1회 복용량 One_Qty
        public string Onedayeat { get; set; } // 1일 투여량 One_Cnt
        public string Alleat { get; set; } // 총투약일수 Total_Cnt
        public string DrugUnit { get; set; } // 약품 단위 Pres_Unit
        public string AllDrug { get; set; } // 총 투약량
        public bool IsChecked { get; set; } // 선택 checkbox
        public string HTT { get; set; } // 복용법
        public string Usage1 { get; set; } // 용법1
        public string Usage2 { get; set; } // 용법1

        public Medicine(string name, string drugcode, float eat, string onedayeat, string alleat, string drugunit)
        {
            Name = name;
            DrugCode = drugcode;
            Eat = eat.ToString();
            Onedayeat = onedayeat;
            string[] alleatlist = alleat.Split(' ');
            Alleat = alleatlist[0];
            string[] drugunitlist = drugunit.Split(' ');
            DrugUnit = drugunitlist[0];
            AllDrug = (int.Parse(onedayeat) * int.Parse(alleat) * eat).ToString();
            IsChecked = false;
            HTT = "1회 " + Eat + "*" + DrugUnit + "씩 하루 " + Onedayeat + "번";
        }
        public Medicine(string name, string drugCode, string eat, string onedayeat, string alleat, string drugUnit, string allDrug, bool isChecked, string hTT, string usage1, string usage2)
        {
            Name = name;
            DrugCode = drugCode;
            Eat = eat;
            Onedayeat = onedayeat;
            Alleat = alleat;
            DrugUnit = drugUnit;
            AllDrug = allDrug;
            IsChecked = isChecked;
            HTT = hTT;
            Usage1 = usage1;
            Usage2 = usage2;
        }
    }
    
    public class SelectItem
    {
        private static SelectItem instance;
        public static SelectItem Getinstance()
        {
            if (instance == null)
            {
                instance = new SelectItem();
    }
            return instance;
        }
        public string SelectPres_ID { get; set; }
    }
    public class LabelUser
    {
        public string UserName { get; set; }
        public string ChkNum { get; set; }
        public string NowDate { get; set; }
        public LabelUser(string userName, string chkNum, string nowDate)
        {
            string[] name1 = userName.Split(' ');
            UserName = name1[0];
            ChkNum = chkNum;
            string date1 = nowDate.Substring(0, 4);
            string date2 = nowDate.Substring(4, 2);
            string date3 = nowDate.Substring(6, 2);
            NowDate = date1 + "-" + date2 + "-" + date3;
        }
    }
    public class LabelDrug
    {
        public string DrugName { get; set; }
        public string One_Cnt { get; set; }
        public string Total_Cnt { get; set; }
        public string OneDayEat { get; set; }
        public string Pres_Unit { get; set; }
        public LabelDrug(string drugName, string onecnt, string totalcnt, float oneDayEat, string pres_Unit)
        {
            DrugName = drugName;
            One_Cnt = onecnt;
            Total_Cnt = totalcnt;
            OneDayEat = oneDayEat.ToString();
            string[] presunitlist = pres_Unit.Split(' ');
            Pres_Unit = presunitlist[0];
        }
    }
    public class LabelShop
    {
        public string Hp_Name { get; set; }
        public string Hp_Tel { get; set; }
        public string Hp_Address { get; set; }
        public LabelShop(string hp_Name, string hp_Tel, string hp_Address1, string hp_Address2)
        {
            Hp_Name = hp_Name;
            Hp_Tel = hp_Tel;
            Hp_Address = hp_Address1 + ' ' + hp_Address2;
        }
    }

    public class DRUGInfoName
    {
        public string DrugName { get; set; }
        public string DrugBarcode { get; set; }
        public DRUGInfoName(string drugName, string drugBarcode)
        {
            DrugName = drugName;
            string[] drugbarcodelist = drugBarcode.Split(' ');
            DrugBarcode = drugbarcodelist[0];
        }
    }

    public class HS_INFO
    {
        public string Dr_Name { get; set; }
        public string Dr_Code { get; set; }
        public string Hs_Name { get; set; }
        public string Hs_Code { get; set; }
        public string Hs_Tel { get; set; }
        public string Part_id { get; set; }
        public HS_INFO(string dr_Name, string dr_Code, string hs_Name, string hs_Code, string hs_Tel, string part_id)
        {
            string[] drnamelist = dr_Name.Split(' ');
            Dr_Name = drnamelist[0];
            string[] drcodelist = dr_Code.Split(' ');
            Dr_Code = drcodelist[0];
            Hs_Name = hs_Name;
            Hs_Code = hs_Code;
            string[] hstellist = hs_Tel.Split(' ');
            Hs_Tel = hstellist[0];
            Part_id = part_id;
        }
    }
}
