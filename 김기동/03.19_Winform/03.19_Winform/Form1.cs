using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _03._19_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;
            MainFormControl mfc = new MainFormControl();           
            mfc.Load_PRES(selectedDate,LV_PRES);
        }

        private void LV_PRES_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(e.IsSelected)
            {
                MainFormControl mainFormControl = new MainFormControl();
                mainFormControl.Load_Drug(e,LV_DRUG);
                mainFormControl.Load_Custom(e,LV_CUSTOM);
            }
        }
    }
}