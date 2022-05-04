using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Tests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer=new DispatcherTimer();
        private long _time;

        Resources _resources=new Resources();
        public MainWindow()
        {
            InitializeComponent();
            Get_start_content();
            Get_choose_content();
        }
        public void Navigation(string view)
        {
            switch (view)
            {
                case "choose_content":
                    ScrollViewer_main.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                    ScrollViewer_main.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                    StackPanel_test_choose.Visibility = Visibility.Visible;
                    StackPanel_main.Visibility = Visibility.Hidden;
                    break;
                case "main_content":
                    ScrollViewer_main.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    ScrollViewer_main.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    StackPanel_test_choose.Visibility = Visibility.Hidden; 
                    StackPanel_main.Visibility = Visibility.Visible;                    
                    break;
            }
        }
        public void Get_start_content()
        {
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(Timer_Tick);
            TextBlock_test_choose.Text = _resources.Get_TextBlock_test_choose_Value();
            TextBlock_restart.Text = _resources.Get_TextBlock_Restart_Value();
            TextBlock_back.Text = _resources.Get_TextBlock_Back_Value();
            TextBlock_finish.Text = _resources.Get_TextBlock_Finish_Value();
            List<string> test_choose_options = _resources.ComboBox_test_choose_Options();
            foreach (string test_choose_option in test_choose_options)
                ComboBox_test_choose.Items.Add(test_choose_option);
        }
        public void Get_choose_content()
        {
            ComboBox_test_choose.SelectedItem = null;
            Window.Title = _resources.Get_Window_test_choose_Value();
            Navigation("choose_content");
        }

        #region Forms button actions
        private void ComboBox_test_choose_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock_test_navidation.Text = _resources.Get_TextBlock_test_navidation_Value((string)comboBox.SelectedItem);
            Navigation("main_content");
            Window.Title = _resources.Get_Window_test_bigin_Value();
            Timer("start");
        }

        private void Button_restart_Click(object sender, RoutedEventArgs e)
        {
            Timer("pause");
            if (MessageBox.Show(_resources.Get_MessageBox_Restart_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Timer("continue");
            }
            else
            {
                //do yes stuff
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            Timer("pause");
            if (MessageBox.Show(_resources.Get_MessageBox_Back_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Timer("continue");
            }
            else
            {
                Get_choose_content();
            }
        }

        private void Button_finish_Click(object sender, RoutedEventArgs e)
        {
            Timer("pause");
            if (MessageBox.Show(_resources.Get_MessageBox_Finish_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Timer("continue");
            }
            else
            {
                //do yes stuff
            }
        }

        #endregion

        #region Timer
        public void Timer(string option)
        {
            switch (option)
            {
                case "start":
                    _time = -1;                   
                    _timer.Start();
                    break;
                case "pause":
                    _timer.Stop();
                    break;
                case "continue":
                    _timer.Start();
                    break;
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _time++;
            TextBlock_test_time.Text = _resources.TextBlock_test_time_Value(_time);           
        }
        #endregion
    }
}
