using AllTrans.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllTrans.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public LogIn log;
        public RegisterPage(LogIn logIn)
        {
            InitializeComponent();
            log = logIn;
            this.DataContext = new DataManagerLogIn();
        }
        private void LogIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LogIn.Text.Length > 0)
            {
                LogInPlug.Visibility = Visibility.Hidden;
            }
            else
            {
                LogInPlug.Visibility = Visibility.Visible;
            }
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordIn.Text.Length > 0)
            {
                PasswordPlug.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswordPlug.Visibility = Visibility.Visible;
            }
        }
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (emailIn.Text.Length > 0)
            {
                emailPlug.Visibility = Visibility.Hidden;
            }
            else
            {
                emailPlug.Visibility = Visibility.Visible;
            }
        }

        private void LogInEvent(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new LogInPage(log));
        }

        public static MailMessage CreateMail(string name, string emailFrom, string emailTo, string subject, string body)
        {
            var from = new MailAddress(emailFrom, name);
            var to = new MailAddress(emailTo);
            var mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            return mail;
        }
        public static void SendMail(string host, int smptPort, string emailFrom, string pass, MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(host, smptPort);
            smtp.Credentials = new NetworkCredential(emailFrom, pass);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

    }
}
