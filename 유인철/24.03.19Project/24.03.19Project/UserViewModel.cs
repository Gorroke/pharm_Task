using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
            PPRESCRList = new ObservableCollection<Prescription>();
            PDRUDRUGList = new ObservableCollection<Medicine>();
            PCUSCUSTList = new ObservableCollection<Customer>();
            SelectedDates();
            LabelButton = new RelayCommand(LabelButtonAction);
        }

        private DateTime _SelectDateTime = DateTime.Now;
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
/*        Object _Selectlistview;
        public Object Selectlistview
        {
            get { return _Selectlistview; }
            set
            {
                _Selectlistview = value;
                OnPropertyChanged("Selectlistview");
            }
        }*/
        List<string> _Pres_IDlist;
        public List<string> Pres_IDlist
        {
            get { return _Pres_IDlist;}
            set
            {
                _Pres_IDlist = value;
            }
        }
        public void SelectDatesPres_ID(string date)
        {
            string qurey = $"Select Pres_ID from PPRESCR1 where Pres_Date = '{date}'";
            DB db = DB.GetInstance();
            Pres_IDlist = db.SelectPres_ID(qurey);
        }
        public void SelectedDates()
        {
            string date = SelectDateTime.ToString("yyyyMMdd");
            string qurey = $"Select PPRESCR3.ChkNum, PPRESCR1.ct_name, PPRESCR1.Inhabitant_id, PPRESCR1.Pres_Time " +
                $"from PPRESCR1 Join PPRESCR3 " +
                $"On PPRESCR1.Pres_ID = PPRESCR3.Pres_ID " +
                $"Where PPRESCR1.Pres_Date = '{date}'";
            DB db = DB.GetInstance();
            PPRESCRList = db.PreSelectDB(qurey);
            SelectDatesPres_ID(date);
        }
        public void SelectedPDRUDRUG(int Pres_ID)
        {
            string qurey = $"Select PDRUDRUG.Drug_Name, PDRUDRUG.Drug_ID, PPRESCR4.One_Qty, PPRESCR4.One_Cnt, PPRESCR4.Total_Cnt, PDRUDRUG.Pres_Unit " +
                $"from PDRUDRUG Join PPRESCR4 " +
                $"On PDRUDRUG.Drug_ID = PPRESCR4.Drug_ID " +
                $"Where PPRESCR4.Pres_ID = '{Pres_IDlist[Pres_ID]}'";
            DB db = DB.GetInstance();
            PDRUDRUGList = db.MedSelectDB(qurey);

            SelectItem si = SelectItem.Getinstance();
            si.SelectPres_ID = Pres_IDlist[Pres_ID];
        }
        public void SelectedPCUSCUST(int Pres_ID)
        {
            string qurey = $"Select PCUSCUST.Ct_Name, PCUSCUST.Inhabitant_ID, PCUSCUST.Ct_Special1, PCUSCUST.Ct_Special2, PCUSCUST.Ct_Hp, PPRESCR3.Sb_Cd1, PPRESCR3.Hs_Name, PPRESCR3.Part_id, " +
                $"PPRESCR3.Hs_Code, PPRESCR3.Hs_Tel, PPRESCR3.Dr_Name, PPRESCR3.Dr_Code from PCUSCUST Join PPRESCR3 " +
                $"On PPRESCR3.ChkUserid1 = PCUSCUST.Ds_Id " +
                $"Where PPRESCR3.Pres_ID = '{Pres_IDlist[Pres_ID]}'";
            DB db = DB.GetInstance();
            PCUSCUSTList = db.CusSelectDB(qurey);
        }

        public ICommand LabelButton { get; set; }
        private void LabelButtonAction(object sender)
        {
            LabelWindow lw = new LabelWindow();
            lw.ShowDialog();
        }


    }
}
