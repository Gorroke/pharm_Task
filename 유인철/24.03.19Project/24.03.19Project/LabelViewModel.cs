using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace _24._03._19Project
{
    internal class LabelViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private FlowDocument Document { get; set; }
        public LabelViewModel(FlowDocument fd)
        {
            PrintButton = new RelayCommand(PrintLabel);
            Document = fd;
            LoadDB();
            CreateLabel();
        }

        private void CreateLabel()
        {
            for (int i = 0; i < Drugs.Count; i++)
            {
                Paragraph para = new Paragraph
                {
                    TextAlignment = System.Windows.TextAlignment.Center,
                    FontSize = 20
                };
                TextBlock Tb = new TextBlock(new Run(Users[0].ChkNum + ' ' + Users[0].UserName));
                para.Inlines.Add(Tb);
                Document.Blocks.Add(para);

                para = new Paragraph
                {
                    TextAlignment = System.Windows.TextAlignment.Center,
                    FontSize = 17
                };
                Tb = new TextBlock(new Run(Drugs[i].DrugName));
                para.Inlines.Add(Tb);
                Document.Blocks.Add(para);

                para = new Paragraph
                {
                    TextAlignment = System.Windows.TextAlignment.Center,
                    FontSize = 17
                };
                Tb = new TextBlock(new Run("1일 " + Drugs[i].One_Cnt + "회 복용(" + Drugs[i].Total_Cnt + "일분)"));
                para.Inlines.Add(Tb);
                Document.Blocks.Add(para);

                para = new Paragraph
                {
                    TextAlignment = System.Windows.TextAlignment.Center,
                    FontSize = 16
                };
                int oc = int.Parse(Drugs[i].One_Cnt);
                int tc = int.Parse(Drugs[i].Total_Cnt);
                Tb = new TextBlock(new Run((oc * tc).ToString() + "알"));
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
        }

        List<LabelUser> Users { get; set; }
        List<LabelDrug> Drugs { get; set; }
        List<LabelShop> Shops { get; set; }
        private void LoadDB()
        {
            SelectItem si = SelectItem.Getinstance();
            string Presid = si.SelectPres_ID;
            DB db = DB.GetInstance();
            string qurey = $"Select PPRESCR1.Ct_Name, PPRESCR3.ChkNum, PPRESCR1.Pres_Date " +
                $"from PPRESCR1 join PPRESCR3 " +
                $"On PPRESCR1.Pres_ID = PPRESCR3.Pres_ID " +
                $"Where PPRESCR1.Pres_ID = '{Presid}'";
            Users = db.SelectDBUser(qurey);
            qurey = $"Select Drug_Name, One_Cnt, Total_Cnt From PPRESCR4 Where Pres_ID = '{Presid}'";
            Drugs = db.SelectDBDrug(qurey);
            qurey = $"Select Hp_Name, Hp_Tel, Hp_Address1, Hp_Address2 From PCOMSHOP";
            Shops = db.SelectDBShop(qurey);
        }

        public ICommand PrintButton { get; set; }

        private void PrintLabel(object sender)
        {
            PrintDialog pd = new PrintDialog();
            DocumentPaginator paginator = ((IDocumentPaginatorSource)Document).DocumentPaginator;
            MessageBox.Show(paginator.PageSize.ToString());
            /*paginator.PageSize = new Size(794, 1123);*/
            string fileName = "Label";
            pd.PrintDocument(paginator, fileName);
            MessageBox.Show("저장 완료");
        }

        
    }
}
