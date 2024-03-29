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
//using System.Text.Json;
using System.Reflection;
//using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                TemporaryMaterials.materials = materials.ToArray();

                for (int i = 0; i < materials.Count; i++)
                {
                    MyData tb = new MyData();
                    ListViewItem itm = new ListViewItem();
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
                    ListView1.Items.Add(tb);
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
                TemporaryMaterials.tests = tests.ToArray();

                for (int i = 0; i < tests.Count; i++)
                {
                    MyData tb = new MyData();

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
                    ListView1.Items.Add(tb);
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
            int n = 0;
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
        public T GetAncestorOfType<T>(FrameworkElement child) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(child);
            if (parent != null && !(parent is T))
                return (T)GetAncestorOfType<T>((FrameworkElement)parent);
            return (T)parent;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.CurrentTheme = int.Parse(JObject.Parse(ListView1.SelectedItem.ToJson())["Content"].ToString()[0].ToString());

            try
            {
                if (TemporaryMaterials.IsTest)
                {
                    string id = Array.Find(TemporaryMaterials.tests, element => element.ClassName == TemporaryMaterials.CurrentClass && element.numberOfTheme == TemporaryMaterials.CurrentTheme).Id;

                    db.DeleteTest(id);

                    ListView1.Items.Remove(ListView1.SelectedItem);
                }
                else
                {
                    string id = Array.Find(TemporaryMaterials.materials, element => element.ClassName == TemporaryMaterials.CurrentClass && element.NumberOfTheme == TemporaryMaterials.CurrentTheme).Id;

                    db.DeleteMaterial(id);

                    ListView1.Items.Remove(ListView1.SelectedItem);
                }
            }
            catch(Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.CurrentTheme = int.Parse(JObject.Parse(ListView1.SelectedItem.ToJson())["Content"].ToString()[0].ToString());
            TemporaryMaterials.isAddNewMaterial = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TemporaryMaterials.isAddNewMaterial = true;
        }
    }
}
