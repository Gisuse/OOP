﻿using MongoDB.Bson;
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
using System.Windows.Shapes;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace Application.MVVW.View
{
    /// <summary>
    /// Логика взаимодействия для EducationView.xaml
    /// </summary>
    public partial class EducationView : UserControl
    {
        DataAccess db;
        int NumberOfTheme;
        public class MyData
        {
            public Button btn { get; set; }
            public string Content { get; set; }
            public string ToolTip { get; set; }
            public Visibility adminVisible { get; set; }
        }
        public EducationView()
        {
            // Обработка ошибок при поиске тестов и материалов, если возвращает пустую коллекцию
            InitializeComponent();      
            if(TemporaryMaterials.IsAdmin == true)
            {
                AddButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddButton.Visibility = Visibility.Hidden;
            }

            db = new DataAccess();
            if(TemporaryMaterials.IsTest == true)
            {
                profile_login.Content = "Тестові завдання";
            }
            else if(TemporaryMaterials.IsTest == false)
            {
                profile_login.Content = "Навчальні матеріали";
            }

            if (!TemporaryMaterials.IsTest)
            {
                findMat(TemporaryMaterials.CurrentClass);
            }
            else
            {
                findTests(TemporaryMaterials.CurrentClass);
            }
            //findMat(TemporaryMaterials.CurrentClass);

            //txb1.Text = materials.ToJson();
        }

        public void ForwardToInfo(object sender, RoutedEventArgs e)
        {
            int currentTheme = int.Parse(sender.ToString().Split(' ')[1].Remove(1));
            TemporaryMaterials.CurrentTheme = currentTheme;
        }



        public async void findMat(int ClassValue)
        {
            try
            {
                var materials = await db.FindMaterials(ClassValue);
                TemporaryMaterials.materials = materials.ToArray();
                var temp = materials[0];

                for (int i = 0; i < materials.Count - 1; i++)
                {
                    for (int j = i + 1; j < materials.Count; j++)
                    {
                        if (materials[i].NumberOfTheme > materials[j].NumberOfTheme)
                        {
                            temp = materials[i];
                            materials[i] = materials[j];
                            materials[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < materials.Count; i++)
                {
                    //TextBlock tb = new TextBlock();

                    //tb.Text = materials[i].NumberOfTheme + ". " + (materials[i].Title.Length > 24 ? materials[i].Title.Substring(0, 24) + "..." : materials[i].Title);

                    //ListView.Items.Add(tb);
                    //Button tb = new Button();

                    MyData tb = new MyData();
                    ListViewItem itm = new ListViewItem();

                    //TemporaryMaterials.CurrentInfo = materials[i].MaterialContent;
                    if(materials[i].Title.Length > 24)
                    {
                        tb.btn = new Button();
                        tb.Content = materials[i].NumberOfTheme + ". " + materials[i].Title.Substring(0, 24) + "...";
                        tb.ToolTip = materials[i].Title;
                        if(TemporaryMaterials.IsAdmin == true)
                        {
                            tb.adminVisible = Visibility.Visible;
                        }
                        else
                        {
                            tb.adminVisible = Visibility.Hidden;
                        }                        
                    }
                    else
                    {
                        tb.btn = new Button();
                        tb.Content = materials[i].NumberOfTheme + ". " + materials[i].Title;
                        if (TemporaryMaterials.IsAdmin == true)
                        {
                            tb.adminVisible = Visibility.Visible;
                        }
                        else
                        {
                            tb.adminVisible = Visibility.Hidden;
                        }
                    }
                    //materials[i].NumberOfTheme + ". " + ( ?  + "..." : materials[i].Title);
                    //tb.Click += new RoutedEventHandler(ForwardToInfo);

                    ListView.Items.Add(tb);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void findTests(int ClassValue)
        {
            try 
            {
                var tests = await db.FindTests(ClassValue);
                //string tests = JsonConvert.DeserializeObject(await db.FindTests(7).ToString());
                TemporaryMaterials.tests = tests.ToArray();
                var temp = tests[0];

                for (int i = 0; i < tests.Count - 1; i++)
                {
                    for (int j = i + 1; j < tests.Count; j++)
                    {
                        if (tests[i].numberOfTheme > tests[j].numberOfTheme)
                        {
                            temp = tests[i];
                            tests[i] = tests[j];
                            tests[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < tests.Count; i++)
                {
                    //TextBlock tb = new TextBlock();

                    //tb.Text = tests[i].NumberOfTheme + ". " + (tests[i].Question.Length > 24 ? tests[i].Question.Substring(0, 24) + "..." : tests[i].Question);

                    //ListView.Items.Add(tb);
                    //Button tb = new Button();
                    MyData tb = new MyData();

                    //TemporaryMaterials.CurrentInfo = tests[i].MaterialContent;
                    if (tests[i].Title.Length > 24)
                    {
                        tb.btn = new Button();
                        tb.Content = tests[i].numberOfTheme + ". " + tests[i].Title.Substring(0, 24) + "...";
                        tb.ToolTip = tests[i].Title;
                        if (TemporaryMaterials.IsAdmin == true)
                        {
                            tb.adminVisible = Visibility.Visible;
                        }
                        else
                        {
                            tb.adminVisible = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        tb.btn = new Button();
                        tb.Content = tests[i].numberOfTheme + ". " + tests[i].Title;
                        if (TemporaryMaterials.IsAdmin == true)
                        {
                            tb.adminVisible = Visibility.Visible;
                        }
                        else
                        {
                            tb.adminVisible = Visibility.Hidden;
                        }
                    }
                    //tests[i].NumberOfTheme + ". " + ( ?  + "..." : tests[i].Question);
                    //tb.Click += new RoutedEventHandler(ForwardToInfo); 
                    ListView.Items.Add(tb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainWindow = new MainMenu();
            mainWindow.Show();
            MainMenu mainMenu = Application.App.Current.Windows[0] as MainMenu;
            mainMenu.Close();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TemporaryMaterials.IsTest == false)
            {
                
            }
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            if (e.Delta > 0)
            {
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta + 75);
            }
            else if (e.Delta < 0)
            {
                scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta - 75);
            }

            e.Handled = true;
        }
    }
}
