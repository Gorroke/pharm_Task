using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml.Linq;

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
            SelectedDates();
            LabelButton = new RelayCommand(LabelButtonAction);
            PrintButton = new RelayCommand(LabelPrintAction);
            SelectButton = new RelayCommand(SelectButtonAction);
            BagButton = new RelayCommand(BagCase);
        }

        private DateTime _SelectDateTime1 = DateTime.Now;
        public DateTime SelectDateTime1
        {
            get { return _SelectDateTime1; }
            set
            {
                _SelectDateTime1 = value;
                OnPropertyChanged("SelectDateTime1");
            }
        }
        private DateTime _SelectDateTime2 = DateTime.Now;
        public DateTime SelectDateTime2
        {
            get { return _SelectDateTime2; }
            set
            {
                _SelectDateTime2 = value;
                OnPropertyChanged("SelectDateTime2");
            }
        }
        private ObservableCollection<Prescription> _PPRESCRList;
        public ObservableCollection<Prescription> PPRESCRList
        {
            get { return _PPRESCRList; }
            set
            {
                _PPRESCRList = value;
                OnPropertyChanged("PPRESCRList");
            }
        }

        private Medicine _BagMedicine;
        public Medicine BagMedicine
        {
            get { return _BagMedicine; }
            set
            {
                _BagMedicine = value;
                OnPropertyChanged("BagMedicine");
            }
        }
        private Medicine _SelectedMedicine;
        public Medicine SelectedMedicine
        {
            get { return _SelectedMedicine; }
            set
            {
                _SelectedMedicine = value;
                OnPropertyChanged("SelectedMedicine");
            }
        }

        private ObservableCollection<Medicine> _PDRUDRUGList;
        public ObservableCollection<Medicine> PDRUDRUGList
        {
            get { return _PDRUDRUGList; }
            set
            {
                _PDRUDRUGList = value;
                OnPropertyChanged("PDRUDRUGList");
            }
        }

        private string _DrugCount = "0건";
        public string DrugCount
        {
            get { return _DrugCount; }
            set
            {
                _DrugCount = value;
                OnPropertyChanged("DrugCount");
            }
        }
        List<string> _Pres_IDlist;
        public List<string> Pres_IDlist
        {
            get { return _Pres_IDlist; }
            set
            {
                _Pres_IDlist = value;
            }
        }
        private string _Pres_id;
        public string Pres_id
        {
            get { return _Pres_id; }
            set
            {
                _Pres_id = value;
                OnPropertyChanged("Pres_id");
            }
        }
        private string _Drname;
        public string Drname
        {
            get { return _Drname; }
            set
            {
                _Drname = value;
                OnPropertyChanged("Drname");
            }
        }
        private string _Dr_Code;
        public string Dr_Code
        {
            get { return _Dr_Code; }
            set
            {
                _Dr_Code = value;
                OnPropertyChanged("Dr_Code");
            }
        }
        private string _Hs_Name;
        public string Hs_Name
        {
            get { return _Hs_Name; }
            set
            {
                _Hs_Name = value;
                OnPropertyChanged("Hs_Name");
            }
        }
        private string _Hs_Code;
        public string Hs_Code
        {
            get { return _Hs_Code; }
            set
            {
                _Hs_Code = value;
                OnPropertyChanged("Hs_Code");
            }
        }
        private string _Hs_Tel;
        public string Hs_Tel
        {
            get { return _Hs_Tel; }
            set
            {
                _Hs_Tel = value;
                OnPropertyChanged("Hs_Tel");
            }
        }
        private string _Part_id;
        public string Part_id
        {
            get { return _Part_id; }
            set
            {
                _Part_id = value;
                OnPropertyChanged("Part_id");
            }
        }
        public void BagMedicineAllDrug()
        {
            BagMedicine.AllDrug = (int.Parse(BagMedicine.Onedayeat) * int.Parse(BagMedicine.Alleat) * int.Parse(BagMedicine.Eat)).ToString();
            OnPropertyChanged("BagMedicine");
        }
        public void SelectDatesPres_ID(string date1, string date2)
        {
            string qurey = $"Select Pres_ID from PPRESCR1 where Pres_Date Between '{date1}' And '{date2}'";
            DB db = DB.GetInstance();
            Pres_IDlist = db.SelectPres_ID(qurey);
        }
        public void SelectedDates()
        {
            string date1 = SelectDateTime1.ToString("yyyyMMdd");
            string date2 = SelectDateTime2.ToString("yyyyMMdd");
            string qurey = $"Select PPRESCR3.ChkNum, PPRESCR1.ct_name, PPRESCR1.Inhabitant_id, PPRESCR1.Pres_Time " +
                $"from PPRESCR1 Join PPRESCR3 " +
                $"On PPRESCR1.Pres_ID = PPRESCR3.Pres_ID " +
                $"Where PPRESCR1.Pres_Date Between '{date1}' And '{date2}'";
            DB db = DB.GetInstance();
            PPRESCRList = db.PreSelectDB(qurey);
            SelectDatesPres_ID(date1, date2);
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
            Pres_id = PPRESCRList[Pres_ID].Number;
            DrugCount = PDRUDRUGList.Count.ToString() + "건";
        }
        public void SelectedHS_INFO(int Pres_ID)
        {
            string qurey = $"Select Dr_Name, Dr_Code, Hs_Name, Hs_Code, Hs_Tel, Part_id from PPRESCR3 where Pres_ID = '{Pres_IDlist[Pres_ID]}'";
            DB db = DB.GetInstance();
            HS_INFO hsin = db.SelectedHsinfo(qurey);
            Drname = hsin.Dr_Name;
            Dr_Code = hsin.Dr_Code;
            Hs_Name = hsin.Hs_Name;
            Hs_Code = hsin.Hs_Code;
            Hs_Tel = hsin.Hs_Tel;
            Part_id = hsin.Part_id;
        }
        public ICommand LabelButton { get; set; }
        private void LabelButtonAction(object sender)
        {
            LabelWindow lw = new LabelWindow();
            lw.ShowDialog();
        }
        public ICommand PrintButton { get; set; }
        private void LabelPrintAction(object sender)
        {
            if(PDRUDRUGList.Count != 0)
            {
                SelectDB();
                Document = new FlowDocument();
                Drugs = new List<LabelDrug>();
                switch (sender)
                {
                    case "All":
                        LoadAllDB();
                        break;
                    case "Select":
                        LoadSelectDB();
                        break;
                    case "NotDrug":
                        if (SelectedMedicine != null)
                        {
                            LoadNotDrugDB();
                        }
                        else
                        {
                            MessageBox.Show("원하는 약품을 선택하세요.");
                        }
                        break;
                    case "AllDrug":
                        if (SelectedMedicine != null)
                        {
                            LoadAllDrugDB();
                        }
                        else
                        {
                            MessageBox.Show("원하는 약품을 선택하세요.");
                        }
                        break;
                    case "Selecteditem":
                        LoadSelecteditem();
                        break;
                }
                for(int i = 0; i < Drugs.Count; i++)
                {
                    CreateLabel(Drugs[i]);
                    PrintLabel();
                    Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("처방전을 선택하세요.");
            }
        }
        FlowDocument Document;
        List<LabelUser> Users { get; set; }
        List<LabelDrug> Drugs { get; set; }
        List<LabelShop> Shops { get; set; }
        private void SelectDB()
        {
            SelectItem si = SelectItem.Getinstance();
            string Presid = si.SelectPres_ID;
            DB db = DB.GetInstance();
            string qurey = $"Select PPRESCR1.Ct_Name, PPRESCR3.ChkNum, PPRESCR1.Pres_Date " +
                $"from PPRESCR1 join PPRESCR3 " +
                $"On PPRESCR1.Pres_ID = PPRESCR3.Pres_ID " +
                $"Where PPRESCR1.Pres_ID = '{Presid}'";
            Users = db.SelectDBUser(qurey);
            qurey = $"Select Hp_Name, Hp_Tel, Hp_Address1, Hp_Address2 From PCOMSHOP";
            Shops = db.SelectDBShop(qurey);
        }
        private void LoadAllDB()
        {
            SelectItem si = SelectItem.Getinstance();
            string Presid = si.SelectPres_ID;
            DB db = DB.GetInstance();
            string qurey = $"Select PPRESCR4.Drug_Name, PPRESCR4.One_Cnt, PPRESCR4.Total_Cnt, PPRESCR4.One_Qty, PDRUDRUG.Pres_Unit " +
                $"From PPRESCR4 Join PDRUDRUG " +
                $"On PPRESCR4.Drug_Name = PDRUDRUG.Drug_Name " +
                $"Where PPRESCR4.Pres_ID = '{Presid}'";
            Drugs = db.SelectDBDrug(qurey);
        }
        private void LoadSelecteditem()
        {
            LabelDrug ld = new LabelDrug(SelectedMedicine.Name, SelectedMedicine.Onedayeat, SelectedMedicine.Alleat,
                int.Parse(SelectedMedicine.Eat), SelectedMedicine.DrugUnit);
            Drugs.Add(ld);
        }
        private void LoadSelectDB()
        {
            LabelDrug ld;
            for (int i = 0; i < PDRUDRUGList.Count; i++)
            {
                if (PDRUDRUGList[i].IsChecked)
                {
                    ld = new LabelDrug(PDRUDRUGList[i].Name, PDRUDRUGList[i].Onedayeat, PDRUDRUGList[i].Alleat, int.Parse(PDRUDRUGList[i].Eat), PDRUDRUGList[i].DrugUnit);
                    Drugs.Add(ld);
                }
            }
        }
        private void LoadNotDrugDB()
        {
            LabelDrug ld = new LabelDrug(null, BagMedicine.Onedayeat, BagMedicine.Alleat, int.Parse(BagMedicine.Eat), BagMedicine.DrugUnit);
            Drugs.Add(ld);
        }
        private void LoadAllDrugDB()
        {
            LabelDrug ld = new LabelDrug(BagMedicine.Name, BagMedicine.Onedayeat, BagMedicine.Alleat, int.Parse(BagMedicine.Eat), BagMedicine.DrugUnit);
            Drugs.Add(ld);
        }
        private void PrintLabel()
        {
            PrintDialog pd = new PrintDialog();
            DocumentPaginator paginator = ((IDocumentPaginatorSource)Document).DocumentPaginator;
            string fileName = "Label";
            pd.PrintDocument(paginator, fileName);
            MessageBox.Show("저장 완료");
        }
        private void CreateLabel(LabelDrug md)
        {
            Paragraph para = new Paragraph
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                FontSize = 20
            };
            TextBlock Tb = new TextBlock(new Run(Users[0].ChkNum + ' ' + Users[0].UserName));
            para.Inlines.Add(Tb);
            Document.Blocks.Add(para);

            if (md.DrugName != null)
            {
                para = new Paragraph
                {
                    TextAlignment = System.Windows.TextAlignment.Center,
                    FontSize = 13
                };
                Tb = new TextBlock(new Run(md.DrugName));
                para.Inlines.Add(Tb);
                Document.Blocks.Add(para);
            }

            para = new Paragraph
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                FontSize = 17
            };
            Tb = new TextBlock(new Run("1일 "+ md.OneDayEat + " * "+ md.Pres_Unit+ ' ' + md.One_Cnt + "회 복용(" + md.Total_Cnt + "일분)"));
            para.Inlines.Add(Tb);
            Document.Blocks.Add(para);

            para = new Paragraph
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                FontSize = 16
            };
            int oc = int.Parse(md.One_Cnt);
            int tc = int.Parse(md.Total_Cnt);
            int ode = int.Parse(md.OneDayEat);
            Tb = new TextBlock(new Run((oc * tc * ode).ToString() + "알"));
            para.Inlines.Add(Tb);
            Document.Blocks.Add(para);

            para = new Paragraph
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                FontSize = 18
            };
            Tb = new TextBlock(new Run(Users[0].NowDate));
            para.Inlines.Add(Tb);
            Document.Blocks.Add(para);

            para = new Paragraph
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                FontSize = 15
            };
            Tb = new TextBlock(new Run(Shops[0].Hp_Name + " Tel: " + Shops[0].Hp_Tel));
            para.Inlines.Add(Tb);
            Document.Blocks.Add(para);

            para = new Paragraph
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                FontSize = 14
            };
            Tb = new TextBlock(new Run(Shops[0].Hp_Address));
            para.Inlines.Add(Tb);
            Document.Blocks.Add(para);
        }
        public ICommand SelectButton { get; set; }
        private void SelectButtonAction(object sender)
        {
            if ((string)sender == "All")
            {
                for (int i = 0; i < PDRUDRUGList.Count; i++)
                {
                    PDRUDRUGList[i].IsChecked = true;
                }
            }
            else if ((string)sender == "NotAll")
            {
                for (int i = 0; i < PDRUDRUGList.Count; i++)
                {
                    PDRUDRUGList[i].IsChecked = false;
                }
            }
            else if ((string)sender == "UsageDel")
            {
                SelectedMedicine.Usage1 = "";
                SelectedMedicine.Usage2 = "";
                OnPropertyChanged("SelectedMedicine");
            }
            else if((string)sender == "Clear")
            {
                SelectedMedicine = null;
                OnPropertyChanged("SelectedMedicine");
            }
            CollectionViewSource.GetDefaultView(PDRUDRUGList).Refresh();
        }
        private string _DrugName;
        public string DrugName
        {
            get { return _DrugName; }
            set
            {
                _DrugName = value;
                OnPropertyChanged("DrugName");
            }
        }
        private string _DrugBarCode;
        public string DrugBarCode
        {
            get { return _DrugBarCode; }
            set
            {
                _DrugBarCode = value;
                OnPropertyChanged("DrugBarCode");
            }
        }
        public void SelectedDrugInfoName(int index)
        {
            string qurey = $"Select Drug_Name, BarCode from PDRUDRUG Where Drug_ID = '{PDRUDRUGList[index].DrugCode}'";
            DB db = DB.GetInstance();
            DRUGInfoName difo = db.SelectDRUGInfoName(qurey);
            DrugName = difo.DrugName;
            DrugBarCode = difo.DrugBarcode;
            BagMedicine = CopyMedicine();
        }
        private Medicine CopyMedicine()
        {
            Medicine mdi = new Medicine(SelectedMedicine.Name, SelectedMedicine.DrugCode, SelectedMedicine.Eat, SelectedMedicine.Onedayeat,
                SelectedMedicine.Alleat, SelectedMedicine.DrugUnit, SelectedMedicine.AllDrug, 
                SelectedMedicine.IsChecked, SelectedMedicine.HTT, SelectedMedicine.Usage1, SelectedMedicine.Usage2);
            return mdi;
        }
        public void Usage1Changed(int index, string checkstring, string radiostring)
        {
            SelectedMedicine.Usage1 = checkstring + radiostring;
            PDRUDRUGList[index] = SelectedMedicine;
        }
        public void Usage2Changed(int index, string radiostring)
        {
            SelectedMedicine.Usage2 = radiostring;
            PDRUDRUGList[index] = SelectedMedicine;
        }
        public void CellChangeAction(int index)
        {
            SelectedMedicine.HTT = "1회 " + SelectedMedicine.Eat + "*" + SelectedMedicine.DrugUnit + "씩 하루 " + SelectedMedicine.Onedayeat + "번";
            SelectedMedicine.AllDrug = (int.Parse(SelectedMedicine.Onedayeat) * int.Parse(SelectedMedicine.Alleat) * int.Parse(SelectedMedicine.Eat)).ToString();
            PDRUDRUGList[index] = SelectedMedicine;
            OnPropertyChanged("PDRUDRUGList");
        }

        public ICommand BagButton { get; set; }
        private void BagCase(object sender)
        {
            switch (sender)
            {
                case "1":
                    BagMedicine.Usage1 = "아침 점심 저녁 식후 30분";
                    break;
                case "2":
                    BagMedicine.Usage1 = "아침 점심 저녁";
                    break;
                case "3":
                    BagMedicine.Usage1 = "아침 식후 30분 복용";
                    break;
                case "4":
                    BagMedicine.Usage1 = "점심 식후 30분 복용";
                    break;
                case "5":
                    BagMedicine.Usage1 = "저녁 식후 30분 복용";
                    break;
                case "6":
                    BagMedicine.Usage1 = "아침 저녁 식후 30분";
                    break;
                case "7":
                    BagMedicine.Usage1 = "매 식후 30분 복용";
                    break;
                case "8":
                    BagMedicine.Usage1 = "아침 식전 30분 복용";
                    break;
                case "9":
                    BagMedicine.Usage1 = "점심 식전 30분 복용";
                    break;
                case "10":
                    BagMedicine.Usage1 = "저녁 식전 30분 복용";
                    break;
                case "11":
                    BagMedicine.Usage1 = "아침 저녁 식전 30분";
                    break;
                case "12":
                    BagMedicine.Usage1 = "매 식전 30분 복용";
                    break;
                case "13":
                    BagMedicine.Usage1 = "필요 시 복용";
                    break;
                case "14":
                    BagMedicine.Usage1 = "자기 전 복용";
                    break;
                case "15":
                    BagMedicine.Usage1 = "일정 시간 복용";
                    break;
                case "16":
                    BagMedicine.Usage1 = "하루 한번 복용";
                    break;
                case "17":
                    BagMedicine.Usage1 = "한달에 한번 복용";
                    break;
                case "18":
                    BagMedicine.Usage1 = "왼쪽 눈에 넣으세요";
                    break;
                case "19":
                    BagMedicine.Usage1 = "오른쪽 눈에 넣으세요";
                    break;
                case "20":
                    BagMedicine.Usage1 = "8시간마다 복용";
                    break;
                case "21":
                    BagMedicine.Usage1 = "12시간마다 복용";
                    break;
                case "22":
                    BagMedicine.Usage1 = "오전 8시 복용";
                    break;
            }
            OnPropertyChanged("BagMedicine");
            CollectionViewSource.GetDefaultView(PDRUDRUGList).Refresh();
        }


    }
}
