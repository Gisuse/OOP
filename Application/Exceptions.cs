using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Newtonsoft.Json;
using MongoDB.Bson;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Windows.Navigation;
using System.Windows.Controls;
using static Application.MVVW.View.TestView;
using static Application.MVVW.View.ProfileView;

namespace Application
{
    public partial class Exceptions : Page
    {
        DataAccess db;
        Registration reg = new Registration();

        public Exceptions()
        {
            db = new DataAccess();
        }

        public async void Regestrarion(string email, string password, string login, string Name, string SName, bool rememberChecked)
        {
            User user = new User(email, password, login, Name, SName);

            try
            {
                await db.CreateUser(user);

                TemporaryUser.Email = user.Email;
                TemporaryUser.Password = user.Password;
                TemporaryUser.Login = user.Login;
                TemporaryUser.Role = user.Role;
                TemporaryUser.Name = user.Name;
                TemporaryUser.SName = user.SName;
                TemporaryUser.AboutMe = user.AboutMe;
                TemporaryUser.AboutMe = user.AboutMe;
                TemporaryUser.CompletedTests = user.CompletedTests;

                string pathDefaultAvatar = Path.GetFullPath("Images");
                var strIndex = pathDefaultAvatar.IndexOf("bin");
                pathDefaultAvatar = pathDefaultAvatar.Remove(strIndex, 10);
                string pathAvatar = pathDefaultAvatar + @"\avatar.png";
                pathDefaultAvatar = pathDefaultAvatar + @"\defaultAvatar.png";
                File.Delete(pathAvatar);
                File.Copy(pathDefaultAvatar, pathAvatar);
                TemporaryUser.ImagePath = pathAvatar;

                if (rememberChecked == true)
                {
                    var createdUser = await db.FindUser(email, password);

                    string fileName = Path.GetFullPath("UserData.json");

                    string jsonString = JsonConvert.SerializeObject(createdUser[0]);

                    File.WriteAllText(fileName, jsonString);
                }
                else
                {
                    string fileName = Path.GetFullPath("UserData.json");

                    string jsonString = "{}";

                    File.WriteAllText(fileName, jsonString);
                }

                reg.input_login.Text = "";
                reg.input_email.Text = "";
                reg.input_password.Password = "";
                reg.input_passConf.Password = "";

                MainMenu taskWindow = new MainMenu();
                taskWindow.Show();

                MainWindow main = Application.App.Current.MainWindow as MainWindow;

                main.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Такий email вже використовується", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public async void Login(string email, string password, bool rememberChecked) 
        {
            try
            {
                var user = await db.FindUser(email, password);


                if (user.Count < 1)
                {
                    throw new Exception();
                }

                TemporaryUser.Email = user[0].Email;
                TemporaryUser.Password = user[0].Password;
                TemporaryUser.Login = user[0].Login;
                TemporaryUser.Role = user[0].Role;
                TemporaryUser.Name = user[0].Name;
                TemporaryUser.SName = user[0].SName;
                TemporaryUser.AboutMe = user[0].AboutMe;
                TemporaryUser.CompletedTests = user[0].CompletedTests;
                //MessageBox.Show(user[0].CompletedTests[0].TestClass.ToString());
                if (rememberChecked == true)
                {
                    string fileName = Path.GetFullPath("UserData.json");

                    string jsonString = JsonConvert.SerializeObject(user[0]);

                    File.WriteAllText(fileName, jsonString);

                }
                

                else
                {
                    string fileName = Path.GetFullPath("UserData.json");

                    string jsonString = "{}";

                    File.WriteAllText(fileName, jsonString);
                }

                //Loading loading = new Loading();
                //NavigationService.Navigate(loading);
                //MessageBox.Show(user.Count.ToString());
                //NavigationService.StopLoading();

                if(TemporaryMaterials.IsAdmin == true)
                {
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                }
               

                MainWindow mainWindow = Application.App.Current.MainWindow as MainWindow;
                mainWindow.Close();
            }
            catch (Exception er)
            { 
                MessageBox.Show("Такого користувача не існує", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Update_Info_User (User user)
        {
            try
            {
                db.UpdateUser(user);

                TemporaryUser.SName = user.SName;
                TemporaryUser.Name = user.Name;
                TemporaryUser.AboutMe = user.AboutMe;

                string fileName = Path.GetFullPath("UserData.json");

                string jsonString = JsonConvert.SerializeObject(user);

                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        
        
        public void Save_test(int[] answersCheck, Label Mark_Message, ListView TestList)
        {
            try
            {
                User user = new User();

                if (user.CompletedTests == null)
                {
                    user.CompletedTests = new CompletedTestsModel[50];
                }

                int length = 0;

                for (int i = 0; ; i++)
                {
                    if (i == user.CompletedTests.Length)
                        break;

                    if (user.CompletedTests[i] != null)
                        length++;

                    if (user.CompletedTests[i]?.TestTheme == TemporaryMaterials.CurrentTheme && user.CompletedTests[i]?.TestClass == TemporaryMaterials.CurrentClass)
                    {
                        length = i;
                        break;
                    }
                }

                float mark = 0;

                var test = TemporaryMaterials.tests[TemporaryMaterials.CurrentTheme - 1];

                for (int i = 0; i < test.Question.Length; i++)
                {
                    if (test.Answers[i, answersCheck[i]].isCorrest == true)
                        mark++;
                }

                mark = (float)Math.Round(mark * 12 / test.Question.Length);

                user.CompletedTests[length] = new CompletedTestsModel(TemporaryMaterials.CurrentClass, TemporaryMaterials.CurrentTheme, mark, test.Title);
                db.UpdateUser(user);

                Mark_Message.Content = "Ваша оцінка: " + mark;
                TestList.Items.Clear();
                for (int i = 0; i < test.Question.Length; i++)
                {
                    TestAnswers data = new TestAnswers();
                    data.Answer1 = (i + 1) + ".1 " + test.Answers[i, 0].value;
                    data.Answer2 = (i + 1) + ".2 " + test.Answers[i, 1].value;
                    data.Answer3 = (i + 1) + ".3 " + test.Answers[i, 2].value;
                    data.Question = (i + 1) + ". " + test.Question[i];

                    TestList.Items.Add(data);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void Info_Completed_Tests(ListView LYears)
        {
            try
            {
                User user = new User();
                for (int i = 0; i < user.CompletedTests.Length; i++)
                {
                    if (user.CompletedTests[i] != null)
                    {
                        Results res = new Results();
                        if (user.CompletedTests[i].ThemeTitle.Length > 20)
                        {
                            //tb.ToolTip = materials[i].Title;
                            res.Theme = user.CompletedTests[i].ThemeTitle.Substring(0, 20) + "...";

                        }
                        else
                        {
                            res.Theme = user.CompletedTests[i].ThemeTitle;
                        }
                        res.Mark = user.CompletedTests[i].TestMark;
                        LYears.Items.Add(res);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
