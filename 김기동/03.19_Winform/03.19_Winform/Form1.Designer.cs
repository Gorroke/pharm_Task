namespace _03._19_Winform
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.LV_DRUG = new System.Windows.Forms.ListView();
            this.LV_CUSTOM = new System.Windows.Forms.ListView();
            this.LV_PRES = new System.Windows.Forms.ListView();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LV_DRUG
            // 
            this.LV_DRUG.HideSelection = false;
            this.LV_DRUG.Location = new System.Drawing.Point(478, 75);
            this.LV_DRUG.Name = "LV_DRUG";
            this.LV_DRUG.Size = new System.Drawing.Size(621, 228);
            this.LV_DRUG.TabIndex = 1;
            this.LV_DRUG.UseCompatibleStateImageBehavior = false;
            this.LV_DRUG.View = System.Windows.Forms.View.Details;
            
            // 
            // LV_CUSTOM
            // 
            this.LV_CUSTOM.HideSelection = false;
            this.LV_CUSTOM.Location = new System.Drawing.Point(478, 344);
            this.LV_CUSTOM.Name = "LV_CUSTOM";
            this.LV_CUSTOM.Size = new System.Drawing.Size(621, 233);
            this.LV_CUSTOM.TabIndex = 2;
            this.LV_CUSTOM.UseCompatibleStateImageBehavior = false;
            this.LV_CUSTOM.View = System.Windows.Forms.View.Details;
            // 
            // LV_PRES
            // 
            this.LV_PRES.HideSelection = false;
            this.LV_PRES.Location = new System.Drawing.Point(52, 108);
            this.LV_PRES.Name = "LV_PRES";
            this.LV_PRES.Size = new System.Drawing.Size(365, 469);
            this.LV_PRES.TabIndex = 0;
            this.LV_PRES.UseCompatibleStateImageBehavior = false;
            this.LV_PRES.View = System.Windows.Forms.View.Details;
            this.LV_PRES.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LV_PRES_ItemSelectionChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(52, 71);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(284, 21);
            this.dateTimePicker.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 679);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.LV_PRES);
            this.Controls.Add(this.LV_CUSTOM);
            this.Controls.Add(this.LV_DRUG);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView LV_DRUG;
        private System.Windows.Forms.ListView LV_CUSTOM;
        private System.Windows.Forms.ListView LV_PRES;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button button1;
    }
}

