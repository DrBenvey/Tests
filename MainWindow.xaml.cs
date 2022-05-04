using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Tests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Resources _resources=new Resources();
        public MainWindow()
        {
            InitializeComponent();
            Get_choose_content();
        }
        public void Navigation(string view, string Test_Option=null)
        {
            switch (view)
            {
                case "choose_content":
                    StackPanel_test_choose.Visibility = Visibility.Visible;
                    StackPanel_main.Visibility = Visibility.Hidden;
                    break;
                case "main_content":
                    StackPanel_test_choose.Visibility = Visibility.Hidden; 
                    StackPanel_main.Visibility = Visibility.Visible;
                    TextBlock_test_navidation.Text = _resources.Get_TextBlock_test_navidation_Value(Test_Option);
                    break;
            }
        }
        public void Get_choose_content()
        {
            //Window
            Window.Title = _resources.Get_TWindow_test_choose_Value();
            //Visibility
            Navigation("choose_content");
            //add label
            TextBlock_test_choose.Text = _resources.Get_TextBlock_test_choose_Value();
            //add variants for test
            List<string> test_choose_options = _resources.ComboBox_test_choose_Options();
            foreach (string test_choose_option in test_choose_options)
                ComboBox_test_choose.Items.Add(test_choose_option);
        }
        private void ComboBox_test_choose_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Navigation("main_content", (string)comboBox.SelectedItem);           
        }
    }
}
