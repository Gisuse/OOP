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


                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                MainWindow mainWindow = Application.App.Current.MainWindow as MainWindow;
                mainWindow.Close();
            }
            catch (Exception er)
            { 
                MessageBox.Show("Такого користувача не існує", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
