using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PictuerDrawing
{
    internal class DeleteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Action CloseAction { get; set; }

        private string _deletename;
        public string Deletename
        {
            get { return _deletename; }
            set { _deletename = value; }
        }
        public ICommand DeleteButton { get; set; }
        public DeleteViewModel()
        {
            DeleteButton = new RelayCommand(DeletePicturename);
        }
        private void DeletePicturename(object sender)
        {
            DeletePicture dn = DeletePicture.GetInstance();
            dn.PictureName = Deletename;
            DB db = DB.GetInstance();
            string qurey = $"Delete from Picturelist where PictureName = '{Deletename}'";
            db.SaveDB(qurey);
            qurey = $"Delete from PictureObject where PictureName = '{Deletename}'";
            db.SaveDB(qurey);
            qurey = $"Delete from PictureEllipse where PictureName = '{Deletename}'";
            db.SaveDB(qurey);
            qurey = $"Delete from PictureLine where PictureName = '{Deletename}'";
            db.SaveDB(qurey);
            qurey = $"Delete from PicturePolygon where PictureName = '{Deletename}'";
            db.SaveDB(qurey);
            qurey = $"Delete from PictureRectangle where PictureName = '{Deletename}'";
            db.SaveDB(qurey);
            MessageBox.Show("삭제 완료");
            CloseAction();
        }
    }
}
