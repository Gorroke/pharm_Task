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
        public string Name { get; set; } // 고객 이름
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
        /*public string EatCode { get; set; } // 복용 코드??
          public string EatHow { get; set; } // 복용법 ??*/

        public Medicine(string name, string drugcode, float eat, string onedayeat, string alleat, string drugunit/*, string eatcode, string eathow*/)
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
            /*EatCode = eatcode;
            EatHow = eathow;*/
        }
    }
    public class Customer //PCUSCUST 와 PPRESCR3 Join
    {
        public string CName { get; set; } //이름
        //public string Birth { get; set; } //나이
        public string CBirthDay { get; set; } // 생년월일
        public string Memo3 { get; set; } // 고객 메모3
        public string MeMo4 { get; set; } // 고객 메모4
        public string Hp { get; set; } // 휴대폰 번호
        public string DiseaseCode { get; set; } //질병코드
        public string HosName { get; set; } // 병원이름
        public string Partid { get; set; } //진료과
        public string HosCode { get; set; } // 병원 코드
        public string HosTel { get; set; } // 병원 전화번호
        public string DrName { get; set; } // 의사 이름
        public string DrCode { get; set; } // 의사 코드

        public Customer(string name, /*string age,*/ string birthDay, string memo3, string meMo4, string hp, string diseaseCode, string hosName, string partid, string hosCode, string hosTel, string drName, string drCode)
        {
            string[] name1 = name.Split(' ');
            CName = name1[0];
            //Birth = age;
            string strings = birthDay.Substring(0,6);
            CBirthDay = strings;
            Memo3 = memo3;
            MeMo4 = meMo4;
            Hp = hp;
            DiseaseCode = diseaseCode;
            HosName = hosName;
            Partid = partid;
            HosCode = hosCode;
            HosTel = hosTel;
            DrName = drName;
            DrCode = drCode;
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
        public LabelDrug(string drugName, string onecnt, string totalcnt)
        {
            DrugName = drugName;
            One_Cnt = onecnt;
            Total_Cnt = totalcnt;
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
}
