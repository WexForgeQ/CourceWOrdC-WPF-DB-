using AllTrans.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для TimeChangeWin.xaml
    /// </summary>
    public partial class TimeChangeWin : Window
    {
        public TimeChangeWin()
        {
            InitializeComponent();
            this.Text.Text = Data.newtime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Text.Text!=null && this.Name.Text!=null && this.Stop.Text!=null)
            {
                Data.newtime = this.Text.Text;
                Data.newRoute = this.Name.Text;
                Data.newstop = this.Stop.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при вводе");
            }
        }
    }
}
