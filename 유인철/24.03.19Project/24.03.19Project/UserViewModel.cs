using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _24._03._19Project
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public UserViewModel()
        {
            _PPRESCRList = new ObservableCollection<Prescription>();
            _PDRUDRUGList = new ObservableCollection<Medicine>();
            _PCUSCUSTList = new ObservableCollection<Customer>();
        }
        private DateTime _SelectDateTime;
        public DateTime SelectDateTime
        {
            get { return _SelectDateTime; }
            set
            {
                _SelectDateTime = value;
                OnPropertyChanged("SelectDateTime");
            }
        }

        ObservableCollection<Prescription> _PPRESCRList;
        public ObservableCollection<Prescription> PPRESCRList
        {
            get { return _PPRESCRList; }
            set
            {
                _PPRESCRList = value;
                OnPropertyChanged("PPRESCRList");
            }
        }

        ObservableCollection<Medicine> _PDRUDRUGList;
        public ObservableCollection<Medicine> PDRUDRUGList
        {
            get { return _PDRUDRUGList; }
            set
            {
                _PDRUDRUGList = value;
                OnPropertyChanged("PDRUDRUGList");
            }
        }

        ObservableCollection<Customer> _PCUSCUSTList;
        public ObservableCollection<Customer> PCUSCUSTList
        {
            get { return _PCUSCUSTList; }
            set
            {
                _PCUSCUSTList = value;
                OnPropertyChanged("PCUSCUSTList");
            }
        }
        Object _Selectlistview;
        public Object Selectlistview
        {
            get { return _Selectlistview; }
            set
            {
                _Selectlistview = value;
                OnPropertyChanged("Selectlistview");
            }
        }
        public void SelectedDates()
        {
            string date = SelectDateTime.ToString("yyyyMMDD");
            string qurey = $"Select Pres_Id, ct_name, Inhabitant_id, Pres_Time from PPRESCR1 Where Pres_Date = '{date}'";
            DB db = DB.GetInstance();
            PPRESCRList = db.PreSelectDB(qurey);
        }
        public void SelectedPDRUDRUG(string Pres_ID)
        {
            string qurey = $"Select PDRUDRUG.Drug_Name, PDRUDRUG.Drug_ID, PPRESCR4.One_Qty, PPRESCR4.One_Cnt, PPRESCR4.Total_Cnt, PDRUDRUG.Pres_Unit " +
                $"from PDRUDRUG Join PPRESCR4 " +
                $"On PDRUDRUG.Drug_ID = PPRESCR4.Drug_ID " +
                $"Where PDRUDRUG.Pres_ID = '{Pres_ID}'";
            DB db = DB.GetInstance();
            PDRUDRUGList = db.MedSelectDB(qurey);
        }
        public void SelectedPCUSCUST(string Pres_ID)
        {
            string qurey = $"Select PCUSCUST.Ct_Name, PCUSCUST.Inhabitant_ID, PCUSCUST.Ct_Special1, PCUSCUST.Ct_Special2, PCUSCUST.Ct_Hp, PPRESCR3.Sb_Cd1, PPRESCR3.Hs_Name, PPRESCR3.Part_id, " +
                $"PPRESCR3.Hs_Code, PPRESCR3.Hs_Tel, PPRESCR3.Dr_Name, PPRESCR3.Dr_Code from PCUSCUST Join PPRESCR3 " +
                $"On PPRESCR3.ChkUserid1 = PCUSCUST.Ds_Id " +
                $"Where PPRESCR3.Pres_ID = '{Pres_ID}'";
            DB db = DB.GetInstance();
            PCUSCUSTList = db.CusSelectDB(qurey);
        }
    }
}
