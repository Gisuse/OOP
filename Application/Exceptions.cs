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
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using static Application.MVVW.View.ProfileView;
using Application.MVVW.View;

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
            
            try
            {
                User user = new User(email, password, login, Name, SName);
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
                TemporaryUser.ContentImage = user.ContentImage;

                string pathDefaultAvatar = Path.GetFullPath("Images");
                var strIndex = pathDefaultAvatar.IndexOf("bin");
                pathDefaultAvatar = pathDefaultAvatar.Remove(strIndex, 10);
                pathDefaultAvatar = pathDefaultAvatar + @"\defaultAvatar.png";
                TemporaryUser.ImagePath = pathDefaultAvatar;

                if (rememberChecked == true)
                {
                    var createdUser = await db.FindUser(email, password);

                    createdUser[0].CompletedTests = null;

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
                TemporaryUser.ContentImage = user[0].ContentImage;
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

                if (TemporaryUser.ContentImage == null)
                {
                    string pathDefaultAvatar = Path.GetFullPath("Images");
                    var strIndex2 = pathDefaultAvatar.IndexOf("bin");
                    pathDefaultAvatar = pathDefaultAvatar.Remove(strIndex2, 10);
                    pathDefaultAvatar = pathDefaultAvatar + @"\defaultAvatar.png";
                    TemporaryUser.ImagePath = pathDefaultAvatar;
                }
                else
                {
                    BsonValue bs = TemporaryUser.ContentImage;
                    var photoimg = bs.AsByteArray;
                    string pathAvatar = Path.GetFullPath("Images");
                    var strIndex = pathAvatar.IndexOf("bin");
                    pathAvatar = pathAvatar.Remove(strIndex, 10);
                    pathAvatar = pathAvatar + @"\avatar.png";

                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(photoimg)))
                    {
                        image.Save(pathAvatar, ImageFormat.Png);
                    }
                    TemporaryUser.ImagePath = pathAvatar;
                }


                if (TemporaryMaterials.IsAdmin == true)
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

        public void Update_Info_User(User user)
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
                TemporaryUser.CompletedTests = user.CompletedTests;
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
                if (user.CompletedTests != null)
                {
                    for (int i = 0; i < user.CompletedTests.Length; i++)
                    {
                        if (user.CompletedTests[i] != null)
                        {
                            Results res = new Results();
                            if (user.CompletedTests[i].ThemeTitle.Length > 37)
                            {
                                res.Theme = user.CompletedTests[i].ThemeTitle.Substring(0, 37) + "...";

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
                else
                {
                    Results res = new Results();
                    res.Theme = "Ви не пройшли жодного теста";
                    LYears.Items.Add(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void AdminFieldsTestsView(Tests test)
        {
            try
            {
                Tests[] oldTemp = TemporaryMaterials.tests;
                TemporaryMaterials.tests = new Tests[oldTemp.Length + 1];
                for (int i = 0; i < oldTemp.Length; i++)
                {
                    TemporaryMaterials.tests[i] = oldTemp[i];
                }
                TemporaryMaterials.tests[oldTemp.Length] = test;
                await db.CreateTest(test);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
