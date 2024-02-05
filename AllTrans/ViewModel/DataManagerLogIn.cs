using AllTrans.Model;
using AllTrans.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace AllTrans.ViewModel
{
    public class DataManagerLogIn
    {
        private Command _registerCommand;
        private Command _loginCommand;
        public Command RegisterCommand
        {
            get
            {
                return _registerCommand ?? new Command(obj =>
                {
                    try
                    {
                        RegisterPage Page = obj as RegisterPage;
                        if (Page != null)
                        {
                            if (!Regex.IsMatch(Page.LogIn.Text, "^(?=.*[a-zA-Z]).{6,}$"))
                            {
                                throw new Exception("Логин не соответствует требованиям:\n1) Содержит хотя бы одну букву от a до z (в верхнем или нижнем регистре);\n2) Имеют длину не менее 6 символов.");

                            }

                            if (!Regex.IsMatch(Page.emailIn.Text, "^([a-z0-9_-]+\\.)*[a-z0-9_-]+@[a-z0-9_-]+(\\.[a-z0-9_-]+)*\\.[a-z]{2,6}$"))
                            {
                                throw new Exception("Неверно указан email!");

                            }

                            if (!Regex.IsMatch(Page.PasswordIn.Text, "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,}$"))
                            {
                                throw new Exception("Пароль не соответствует требованиям:\nМинимум шесть символов, которые должны включать хотя бы одну цифру, одну строчную латинскую букву и одну заглавную латинскую букву.");

                            }

                            if (DataWorker.CheckUserLogin(Page.LogIn.Text))
                            {
                                throw new Exception("Пользователь с данным логином уже существует!");
                            }

                            if (DataWorker.CheckUserEmail(Page.emailIn.Text))
                            {
                                throw new Exception("Нельзя зарегистрировать несколько пользователей под одной почтой!");
                            }

                            DataWorker.CreateUser(Page.LogIn.Text, Page.emailIn.Text, Page.PasswordIn.Text);
                            MessageBox.Show("Регистрация прошла успешно.", "Register", MessageBoxButton.OK);
                            Page.NavigationService.Navigate(new LogInPage(Page.log));
                            var mail = RegisterPage.CreateMail("AllTrans", "alltransbatura@gmail.com", Page.emailIn.Text, "Регистрация", "Вы успешно зарегестрированы");
                            RegisterPage.SendMail("smtp.gmail.com", 587, "alltransbatura@gmail.com", "gpdfozzaxvohzqmi", mail);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Register", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                });
            }
        }

        public Command LoginCommand
        {
            get
            {
                return _loginCommand ?? new Command(obj =>
                {
                    try
                    {
                        LogInPage Page = obj as LogInPage;
                        if (Page != null)
                        {
                            if (DataWorker.CheckUserLogin(Page.LogIn.Text))
                            {
                                if (DataWorker.CheckUserPassword(Page.PasswordIn.Text))
                                {
                                    if (AppSettings.localUser.usertype == "user")
                                    {
                                        Data.UserLogin = true;
                                        Data.UserIsAdmin = false;
                                        MainWindow main = new MainWindow();
                                        main.Show();
                                        Page._LogIn.Close();
                                    }
                                    else
                                    {
                                        Data.UserLogin = true;
                                        Data.UserIsAdmin = true;
                                        MainWindow main = new MainWindow();
                                        main.Show();
                                        Page._LogIn.Close();
                                    }
                                }
                                else
                                {
                                    throw new Exception("Пароль неверный!");
                                }
                            }
                            else
                            {
                                throw new Exception("Пользователя с таким логином не существует!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Login in", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                });
            }
        }
    }
}
