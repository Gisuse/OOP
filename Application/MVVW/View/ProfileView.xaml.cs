using Application.MVVW.ViewModel;
using MaterialDesignThemes.Wpf;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static Application.MVVW.View.TestView;

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        DataAccess db;
        public class Results
        {
            public string Theme { get; set; }
            public float Mark { get; set; }
        }

        public ProfileView()
        {

            InitializeComponent();
            db = new DataAccess();
            if (TemporaryUser.Email.Length > 7)
            {
                profile_email.Content = TemporaryUser.Email.Substring(0, 7) + "...";
                profile_email.ToolTip = TemporaryUser.Email;
            }
            else
            {
                profile_email.Content = TemporaryUser.Email;
            }

            if (TemporaryUser.Login.Length > 7)
            {
                profile_login.Content = TemporaryUser.Login.Substring(0, 7) + "...";
                profile_login.ToolTip= TemporaryUser.Login;
            }
            else
            {
                profile_login.Content = TemporaryUser.Login;
            }

            if (TemporaryUser.SName != "")
            {
                if (TemporaryUser.SName.Length > 7)
                {
                    profile_sname.Content = TemporaryUser.SName.Substring(0, 7) + "...";
                    profile_sname.ToolTip = TemporaryUser.SName;
                }
                else
                {
                    profile_sname.Content = TemporaryUser.SName;
                }
            }

            if (TemporaryUser.Name != "")
            {
                if (TemporaryUser.SName.Length > 7)
                {
                    profile_name.Content = TemporaryUser.Name.Substring(0, 7) + "...";
                    profile_name.ToolTip = TemporaryUser.Name;
                }
                else
                {
                    profile_name.Content = TemporaryUser.Name;
                }
            }
            
            showResults();

        }

        async void showResults()
        {
            //bool isHaveComletedTests = false;
            ////try
            ////{
            User user = new User();
            if (user.CompletedTests != null)
            {
                for (int i = 0; i < user.CompletedTests.Length; i++)
                {
                    if (user.CompletedTests[i] != null)
                    {
                        //isHaveComletedTests = true;
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
                        //var materials = await db.FindMaterials(user.CompletedTests[i].TestClass);
                        //materials.ToArray();
                        //for (int j = 0; j < materials.Count; j++)
                        //{
                        //    if (materials[j].NumberOfTheme == user.CompletedTests[i].TestTheme)
                        //    {
                        //        Results res = new Results();
                        //        if (materials[j].Title.Length > 20)
                        //        {
                        //            //tb.ToolTip = materials[i].Title;
                        //            res.Theme = materials[j].Title.Substring(0, 20) + "..."; 

                        //        }
                        //        else
                        //        {
                        //            res.Theme = materials[j].Title;
                        //        }
                        //        //res.Theme = materials[j].Title;
                        //        res.Mark = user.CompletedTests[i].TestMark;
                        //        LYears.Items.Add(res);
                        //        break;
                        //    }
                        //}
                    }

                }
            }
            else
            {
                Results res = new Results();
                res.Theme = "Ви не пройшли жодного теста";
                LYears.Items.Add(res);
            }
            //if (!isHaveComletedTests)
            //{
            //    
            //}
            ////}
            ////catch(Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message);
            ////}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fileName = Path.GetFullPath("UserData.json");

            File.Delete(fileName);

            // очистка TemporaryUser не нужна, так как мы присваиваем все данные в регистрации и логине
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            MainMenu mainMenu = Application.App.Current.Windows[0] as MainMenu;
            mainMenu.Close();
        }
    }
}
