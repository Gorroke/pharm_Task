using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

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
            Number = num;
            Name = name;
            Birthday = birthday;
            Pres_Time = time;
        }
    }
    public class Medicine // PDRUDRUG 와 PPRESCR14 Join
    {
        public string Name { get; set; } // 약품명 Drug_Name
        public string DrugCode { get; set; } // 약품코드 Drug_ID
        public float Eat { get; set; } // 1회 복용량 One_Qty
        public string Onedayeat { get; set; } // 1일 투여량 One_Cnt
        public string Alleat { get; set; } // 총투약일수 Total_Cnt
        public string DrugUnit { get; set; } // 약품 단위 Pres_Unit
        /*public string EatCode { get; set; } // 복용 코드??
          public string EatHow { get; set; } // 복용법 ??*/

        public Medicine(string name, string drugcode, float eat, string onedayeat, string alleat, string drugunit/*, string eatcode, string eathow*/)
        {
            Name = name;
            DrugCode = drugcode;
            Eat = eat;
            Onedayeat = onedayeat;
            Alleat = alleat;
            DrugUnit = drugunit;
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
            CName = name;
            //Birth = age;
            CBirthDay = birthDay;
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
}
