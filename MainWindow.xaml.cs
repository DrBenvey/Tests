using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Tests.test;

namespace Tests
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Stop_time=false;

        QuestionCounter question_counter_before;
        QuestionCounter question_counter_after;
        QuestionCounter question_counter;
        Test test;

        private DispatcherTimer _timer=new DispatcherTimer();
        private long _time;

        Resources _resources=new Resources();
        test_navigation _test_navigation = new test_navigation();

        public MainWindow()
        {
            InitializeComponent();
            Get_start_content();
            Get_choose_content();
        }

        /// <summary>
        /// подгрузка названий для кнопок, 
        /// вариантов выбора теста
        /// </summary>
        public void Get_start_content()
        {
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(Timer_Tick);

            ScrollViewer_main.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;

            TextBlock_question_info_one_correct.Text = _resources.Get_TextBlock_Question_Info_One_Correct_Value();
            TextBlock_test_choose.Text = _resources.Get_TextBlock_Test_Choose_Value();
            TextBlock_restart.Text = _resources.Get_TextBlock_Restart_Value();
            TextBlock_back.Text = _resources.Get_TextBlock_Back_Value();
            TextBlock_finish.Text = _resources.Get_TextBlock_Finish_Value();
            TextBlock_question_info_some_correct.Text = _resources.Get_TextBlock_Question_Info_Some_Correct_Value();
            TextBlock_question_info_input_word.Text = _resources.Get_TextBlock_Question_Info_Input_Word_Value();
            TextBlock_left.Text = _resources.Get_TextBlock_Left_Value();
            TextBlock_right.Text = _resources.Get_TextBlock_Right_Value();

            List<string> test_choose_options = _resources.ComboBox_Test_Choose_Options();
            foreach (string test_choose_option in test_choose_options)
                ComboBox_test_choose.Items.Add(test_choose_option);
        }
        /// <summary>
        /// видимость формы выбора теста для прохождения
        /// </summary>
        public void Get_choose_content()
        {
            ComboBox_test_choose.SelectedItem = null;
            Window.Title = _resources.Get_Window_Test_Choose_Value();
            Navigation("choose_content");
        }
        /// <summary>
        /// навигация между формами выбора теста и прохождения теста
        /// </summary>
        /// <param name="view"></param>
        public void Navigation(string view)
        {
            switch (view)
            {
                case "choose_content":
                    ScrollViewer_main.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                    StackPanel_test_choose.Visibility = Visibility.Visible;
                    StackPanel_main.Visibility = Visibility.Collapsed;
                    StackPanel_test_navidation.Visibility = Visibility.Collapsed;
                    break;
                case "main_content":
                    ScrollViewer_main.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;                    
                    StackPanel_test_choose.Visibility = Visibility.Collapsed; 
                    StackPanel_main.Visibility = Visibility.Visible;
                    StackPanel_test_navidation.Visibility = Visibility.Visible;
                    TextBlock_test_result.Visibility = Visibility.Collapsed;
                    TextBlock_test_result.Text = "";
                    Button_finish.IsEnabled = true;
                    break;
            }
        }
        /// <summary>
        /// выбор теста для прохождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_test_choose_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock_test_navidation.Text = _resources.Get_TextBlock_Test_Navidation_Value((string)comboBox.SelectedItem);
            Navigation("main_content");
            Window.Title = _resources.Get_Window_Test_Bigin_Value();
            Timer("start");
            UploadTest((string)comboBox.SelectedItem);
        }
        /// <summary>
        /// загрузка выбранного для прохождения теста
        /// </summary>
        /// <param name="Test_Option"></param>
        public void UploadTest(string Test_Option)
        {
            if (Test_Option == null)
                return;

            test = _resources.GetTestOrNullByName(Test_Option);
            if (test == null)
                return ;

            question_counter = _test_navigation.GetFirstOrNullQuestion(test);
            if (question_counter == null)
                return ;

            ShowQuestion();
        }
        /// <summary>
        /// Показывает схему нужной части 
        /// вопросов теста
        /// </summary>
        public void ShowPartTest()
        {
            Border_question_info_one_correct.Visibility = Visibility.Collapsed;
            Border_question_one_correct.Visibility = Visibility.Collapsed;
            Border_question_info_some_correct.Visibility = Visibility.Collapsed;
            Border_question_some_correct.Visibility = Visibility.Collapsed;
            Border_question_info_input_word.Visibility = Visibility.Collapsed;
            Border_question_input_word.Visibility = Visibility.Collapsed;
            //todo

            switch (question_counter.Part_id)
            {
                case 0:
                    Border_question_info_one_correct.Visibility = Visibility.Visible;
                    Border_question_one_correct.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Border_question_info_some_correct.Visibility = Visibility.Visible;
                    Border_question_some_correct.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Border_question_info_input_word.Visibility = Visibility.Visible;
                    Border_question_input_word.Visibility = Visibility.Visible;
                    break;
                case 3:
                    //todo
                    break;
            }
        }
        /// <summary>
        /// Очищает все ответы
        /// </summary>
        public void ClearAll()
        {
            RadioButton_question_one_correct_answer_1.IsChecked = false;
            RadioButton_question_one_correct_answer_2.IsChecked = false;
            RadioButton_question_one_correct_answer_3.IsChecked = false;
            RadioButton_question_one_correct_answer_4.IsChecked = false;
            RadioButton_question_one_correct_answer_5.IsChecked = false;
            RadioButton_question_one_correct_answer_6.IsChecked = false;

            CheckBox_question_some_correct_answer_1.IsChecked = false;
            CheckBox_question_some_correct_answer_2.IsChecked = false;
            CheckBox_question_some_correct_answer_3.IsChecked = false;
            CheckBox_question_some_correct_answer_4.IsChecked = false;
            CheckBox_question_some_correct_answer_5.IsChecked = false;
            CheckBox_question_some_correct_answer_6.IsChecked = false;

            TextBox_question_input_word_answer_1.Text = "";
            TextBox_question_input_word_answer_2.Text = "";
            TextBox_question_input_word_answer_3.Text = "";
            //todo
        }
        /// <summary>
        /// Сохраняет текущий вариант ответа
        /// </summary>
        public void SaveIt()
        {
            switch (question_counter.Part_id)
            {
                case 0:
                    if (RadioButton_question_one_correct_answer_1.IsChecked == false 
                        && RadioButton_question_one_correct_answer_2.IsChecked == false 
                        && RadioButton_question_one_correct_answer_3.IsChecked == false 
                        && RadioButton_question_one_correct_answer_4.IsChecked == false 
                        && RadioButton_question_one_correct_answer_5.IsChecked == false 
                        && RadioButton_question_one_correct_answer_6.IsChecked == false)
                        test.One_Correct_Questions[question_counter.Question_id].Person_Answer = null;
                    else
                    {
                        if (RadioButton_question_one_correct_answer_1.IsChecked == true)
                            test.One_Correct_Questions[question_counter.Question_id].Person_Answer = 0;
                        if (RadioButton_question_one_correct_answer_2.IsChecked == true)
                            test.One_Correct_Questions[question_counter.Question_id].Person_Answer = 1;
                        if (RadioButton_question_one_correct_answer_3.IsChecked == true)
                            test.One_Correct_Questions[question_counter.Question_id].Person_Answer = 2;
                        if (RadioButton_question_one_correct_answer_4.IsChecked == true)
                            test.One_Correct_Questions[question_counter.Question_id].Person_Answer = 3;
                        if (RadioButton_question_one_correct_answer_5.IsChecked == true)
                            test.One_Correct_Questions[question_counter.Question_id].Person_Answer = 4;
                        if (RadioButton_question_one_correct_answer_6.IsChecked == true)
                            test.One_Correct_Questions[question_counter.Question_id].Person_Answer = 5;
                    }
                    break;
                case 1:
                    if (CheckBox_question_some_correct_answer_1.IsChecked == false 
                        && CheckBox_question_some_correct_answer_2.IsChecked == false
                        && CheckBox_question_some_correct_answer_3.IsChecked == false
                        && CheckBox_question_some_correct_answer_4.IsChecked == false
                        && CheckBox_question_some_correct_answer_5.IsChecked == false
                        && CheckBox_question_some_correct_answer_6.IsChecked == false)
                        test.Some_Correct_Questions[question_counter.Question_id].Person_Answer = null;
                    else
                    {
                        test.Some_Correct_Questions[question_counter.Question_id].Person_Answer = new List<int>();
                        if (CheckBox_question_some_correct_answer_1.IsChecked == true)
                            test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.Add(0);
                        if (CheckBox_question_some_correct_answer_2.IsChecked == true)
                            test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.Add(1);
                        if (CheckBox_question_some_correct_answer_3.IsChecked == true)
                            test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.Add(2);
                        if (CheckBox_question_some_correct_answer_4.IsChecked == true)
                            test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.Add(3);
                        if (CheckBox_question_some_correct_answer_5.IsChecked == true)
                            test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.Add(4);
                        if (CheckBox_question_some_correct_answer_6.IsChecked == true)
                            test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.Add(5);
                    }
                    break;
                case 2:
                    if (TextBox_question_input_word_answer_1.Text == ""
                        && TextBox_question_input_word_answer_2.Text == ""
                        && TextBox_question_input_word_answer_3.Text == "")
                        test.Input_Word_Questions[question_counter.Question_id].Person_Answer = null;
                    else
                    {
                        test.Input_Word_Questions[question_counter.Question_id].Person_Answer = new List<string>();
                        if (String.IsNullOrEmpty(TextBox_question_input_word_answer_1.Text))
                            test.Input_Word_Questions[question_counter.Question_id].Person_Answer.Add("");
                        else
                            test.Input_Word_Questions[question_counter.Question_id].Person_Answer.Add(TextBox_question_input_word_answer_1.Text);
                        if (String.IsNullOrEmpty(TextBox_question_input_word_answer_2.Text))
                            test.Input_Word_Questions[question_counter.Question_id].Person_Answer.Add("");
                        else
                            test.Input_Word_Questions[question_counter.Question_id].Person_Answer.Add(TextBox_question_input_word_answer_2.Text);
                        if (String.IsNullOrEmpty(TextBox_question_input_word_answer_3.Text))
                            test.Input_Word_Questions[question_counter.Question_id].Person_Answer.Add("");
                        else
                            test.Input_Word_Questions[question_counter.Question_id].Person_Answer.Add(TextBox_question_input_word_answer_3.Text);
                    }
                    break;
                case 3:
                    //todo
                    break;
            }
        }

        public void ShowQuestion()
        {
            ClearAll();
            EnabledLeftRightButtons();
            ShowPartTest();

            switch (question_counter.Part_id)
            {
                case 0:
                    TextBlock_question_one_correct_question.Text = test.One_Correct_Questions[question_counter.Question_id].Question;
                    if (test.One_Correct_Questions[question_counter.Question_id].Picture=="-")
                        Image_question_one_correct_image.Visibility = Visibility.Collapsed;
                    else
                    {
                        Image_question_one_correct_image.Visibility = Visibility.Visible;
                        Image_question_one_correct_image.Source = new BitmapImage(new Uri(test.One_Correct_Questions[question_counter.Question_id].Picture, UriKind.Relative));
                    }

                    RadioButton_question_one_correct_answer_1.Visibility = Visibility.Visible;
                    RadioButton_question_one_correct_answer_2.Visibility = Visibility.Visible;
                    RadioButton_question_one_correct_answer_3.Visibility = Visibility.Visible;
                    RadioButton_question_one_correct_answer_4.Visibility = Visibility.Visible;
                    RadioButton_question_one_correct_answer_5.Visibility = Visibility.Visible;
                    RadioButton_question_one_correct_answer_6.Visibility = Visibility.Visible;

                    switch (test.One_Correct_Questions[question_counter.Question_id].Answer_Option.Count)
                    {
                        case 2:
                            RadioButton_question_one_correct_answer_1.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            RadioButton_question_one_correct_answer_2.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            RadioButton_question_one_correct_answer_3.Visibility = Visibility.Collapsed;
                            RadioButton_question_one_correct_answer_4.Visibility = Visibility.Collapsed;
                            RadioButton_question_one_correct_answer_5.Visibility = Visibility.Collapsed;
                            RadioButton_question_one_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 3:
                            RadioButton_question_one_correct_answer_1.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            RadioButton_question_one_correct_answer_2.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            RadioButton_question_one_correct_answer_3.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            RadioButton_question_one_correct_answer_4.Visibility = Visibility.Collapsed;
                            RadioButton_question_one_correct_answer_5.Visibility = Visibility.Collapsed;
                            RadioButton_question_one_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 4:
                            RadioButton_question_one_correct_answer_1.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            RadioButton_question_one_correct_answer_2.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            RadioButton_question_one_correct_answer_3.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            RadioButton_question_one_correct_answer_4.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[3].Answer;
                            RadioButton_question_one_correct_answer_5.Visibility = Visibility.Collapsed;
                            RadioButton_question_one_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 5:
                            RadioButton_question_one_correct_answer_1.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            RadioButton_question_one_correct_answer_2.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            RadioButton_question_one_correct_answer_3.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            RadioButton_question_one_correct_answer_4.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[3].Answer;
                            RadioButton_question_one_correct_answer_5.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[4].Answer;
                            RadioButton_question_one_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 6:
                            RadioButton_question_one_correct_answer_1.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            RadioButton_question_one_correct_answer_2.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            RadioButton_question_one_correct_answer_3.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            RadioButton_question_one_correct_answer_4.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[3].Answer;
                            RadioButton_question_one_correct_answer_5.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[4].Answer;
                            RadioButton_question_one_correct_answer_6.Content = test.One_Correct_Questions[question_counter.Question_id].Answer_Option[5].Answer;
                            break;
                    }
                    if (!test.One_Correct_Questions[question_counter.Question_id].Person_Answer.HasValue)
                        Border_question_one_correct.Background = new SolidColorBrush(Colors.LightGray);
                    else
                    {
                        Border_question_one_correct.Background = new SolidColorBrush(Colors.Fuchsia);
                        switch (test.One_Correct_Questions[question_counter.Question_id].Person_Answer.Value)
                        {
                            case 0:
                                RadioButton_question_one_correct_answer_1.IsChecked = true;
                                break;
                            case 1:
                                RadioButton_question_one_correct_answer_2.IsChecked = true;
                                break;
                            case 2:
                                RadioButton_question_one_correct_answer_3.IsChecked = true;
                                break;
                            case 3:
                                RadioButton_question_one_correct_answer_4.IsChecked = true;
                                break;
                            case 4:
                                RadioButton_question_one_correct_answer_5.IsChecked = true;
                                break;
                            case 5:
                                RadioButton_question_one_correct_answer_6.IsChecked = true;
                                break;
                        }
                    }
                    break;
                case 1:                    
                    TextBlock_question_some_correct_question.Text = test.Some_Correct_Questions[question_counter.Question_id].Question;
                    if (test.Some_Correct_Questions[question_counter.Question_id].Picture == "-")
                        Image_question_some_correct_image.Visibility = Visibility.Collapsed;
                    else
                    {
                        Image_question_some_correct_image.Visibility = Visibility.Visible;
                        Image_question_some_correct_image.Source = new BitmapImage(new Uri(test.Some_Correct_Questions[question_counter.Question_id].Picture, UriKind.Relative));
                    }

                    CheckBox_question_some_correct_answer_1.Visibility = Visibility.Visible;
                    CheckBox_question_some_correct_answer_2.Visibility = Visibility.Visible;
                    CheckBox_question_some_correct_answer_3.Visibility = Visibility.Visible;
                    CheckBox_question_some_correct_answer_4.Visibility = Visibility.Visible;
                    CheckBox_question_some_correct_answer_5.Visibility = Visibility.Visible;
                    CheckBox_question_some_correct_answer_6.Visibility = Visibility.Visible;

                    switch (test.Some_Correct_Questions[question_counter.Question_id].Answer_Option.Count)
                    {
                        case 2:
                            CheckBox_question_some_correct_answer_1.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            CheckBox_question_some_correct_answer_2.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            CheckBox_question_some_correct_answer_3.Visibility = Visibility.Collapsed;
                            CheckBox_question_some_correct_answer_4.Visibility = Visibility.Collapsed;
                            CheckBox_question_some_correct_answer_5.Visibility = Visibility.Collapsed;
                            CheckBox_question_some_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 3:
                            CheckBox_question_some_correct_answer_1.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            CheckBox_question_some_correct_answer_2.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            CheckBox_question_some_correct_answer_3.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            CheckBox_question_some_correct_answer_4.Visibility = Visibility.Collapsed;
                            CheckBox_question_some_correct_answer_5.Visibility = Visibility.Collapsed;
                            CheckBox_question_some_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 4:
                            CheckBox_question_some_correct_answer_1.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            CheckBox_question_some_correct_answer_2.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            CheckBox_question_some_correct_answer_3.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            CheckBox_question_some_correct_answer_4.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[3].Answer;
                            CheckBox_question_some_correct_answer_5.Visibility = Visibility.Collapsed;
                            CheckBox_question_some_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 5:
                            CheckBox_question_some_correct_answer_1.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            CheckBox_question_some_correct_answer_2.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            CheckBox_question_some_correct_answer_3.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            CheckBox_question_some_correct_answer_4.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[3].Answer;
                            CheckBox_question_some_correct_answer_5.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[4].Answer;
                            CheckBox_question_some_correct_answer_6.Visibility = Visibility.Collapsed;
                            break;
                        case 6:
                            CheckBox_question_some_correct_answer_1.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[0].Answer;
                            CheckBox_question_some_correct_answer_2.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[1].Answer;
                            CheckBox_question_some_correct_answer_3.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[2].Answer;
                            CheckBox_question_some_correct_answer_4.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[3].Answer;
                            CheckBox_question_some_correct_answer_5.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[4].Answer;
                            CheckBox_question_some_correct_answer_6.Content = test.Some_Correct_Questions[question_counter.Question_id].Answer_Option[5].Answer;
                            break;
                    }
                    if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer==null)
                        Border_question_some_correct.Background = new SolidColorBrush(Colors.LightGray);
                    else
                    {
                        Border_question_some_correct.Background = new SolidColorBrush(Colors.Fuchsia);
                        if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.IndexOf(0)>-1)
                            CheckBox_question_some_correct_answer_1.IsChecked = true;
                        if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.IndexOf(1) > -1)
                            CheckBox_question_some_correct_answer_2.IsChecked = true;
                        if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.IndexOf(2) > -1)
                            CheckBox_question_some_correct_answer_3.IsChecked = true;
                        if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.IndexOf(3) > -1)
                            CheckBox_question_some_correct_answer_4.IsChecked = true;
                        if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.IndexOf(4) > -1)
                            CheckBox_question_some_correct_answer_5.IsChecked = true;
                        if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer.IndexOf(5) > -1)
                            CheckBox_question_some_correct_answer_6.IsChecked = true;
                    }
                    break;
                case 2:                    
                    if (test.Input_Word_Questions[question_counter.Question_id].Picture == "-")
                        Image_question_input_word_image.Visibility = Visibility.Collapsed;
                    else
                    {
                        Image_question_input_word_image.Visibility = Visibility.Visible;
                        Image_question_input_word_image.Source = new BitmapImage(new Uri(test.Input_Word_Questions[question_counter.Question_id].Picture, UriKind.Relative));
                    }

                    TextBlock_question_input_word_question_1.Visibility = Visibility.Visible;
                    TextBox_question_input_word_answer_1.Visibility = Visibility.Visible;
                    TextBlock_question_input_word_question_2.Visibility = Visibility.Visible;
                    TextBox_question_input_word_answer_2.Visibility = Visibility.Visible;
                    TextBlock_question_input_word_question_3.Visibility = Visibility.Visible;
                    TextBox_question_input_word_answer_3.Visibility = Visibility.Visible;
                    TextBlock_question_input_word_question_4.Visibility = Visibility.Visible;

                    switch (test.Input_Word_Questions[question_counter.Question_id].Question.Count)
                    {
                        case 2:
                            TextBlock_question_input_word_question_1.Text = test.Input_Word_Questions[question_counter.Question_id].Question[0];
                            TextBlock_question_input_word_question_2.Text = test.Input_Word_Questions[question_counter.Question_id].Question[1];
                            TextBox_question_input_word_answer_2.Visibility = Visibility.Collapsed;
                            TextBox_question_input_word_answer_3.Visibility = Visibility.Collapsed;
                            TextBlock_question_input_word_question_3.Visibility = Visibility.Collapsed;
                            TextBlock_question_input_word_question_4.Visibility = Visibility.Collapsed;
                            break;
                        case 3:
                            TextBlock_question_input_word_question_1.Text = test.Input_Word_Questions[question_counter.Question_id].Question[0];
                            TextBlock_question_input_word_question_2.Text = test.Input_Word_Questions[question_counter.Question_id].Question[1];
                            TextBlock_question_input_word_question_3.Text = test.Input_Word_Questions[question_counter.Question_id].Question[2];
                            TextBlock_question_input_word_question_4.Visibility = Visibility.Collapsed;
                            TextBox_question_input_word_answer_3.Visibility = Visibility.Collapsed;
                            break;
                        case 4:
                            TextBlock_question_input_word_question_1.Text = test.Input_Word_Questions[question_counter.Question_id].Question[0];
                            TextBlock_question_input_word_question_2.Text = test.Input_Word_Questions[question_counter.Question_id].Question[1];
                            TextBlock_question_input_word_question_3.Text = test.Input_Word_Questions[question_counter.Question_id].Question[2];
                            TextBlock_question_input_word_question_4.Text = test.Input_Word_Questions[question_counter.Question_id].Question[3];
                            break;
                    }
                    if (test.Some_Correct_Questions[question_counter.Question_id].Person_Answer == null)
                        Border_question_input_word.Background = new SolidColorBrush(Colors.LightGray);
                    else
                    {
                        Border_question_input_word.Background = new SolidColorBrush(Colors.Fuchsia);
                        TextBox_question_input_word_answer_1.Text = test.Input_Word_Questions[question_counter.Question_id].Person_Answer[0];
                        TextBox_question_input_word_answer_2.Text = test.Input_Word_Questions[question_counter.Question_id].Person_Answer[1];
                        TextBox_question_input_word_answer_3.Text = test.Input_Word_Questions[question_counter.Question_id].Person_Answer[2];
                    }
                    break;
                case 3:
                    //todo
                    break;
            }
        }        

        public void Check()
        {
            Button_finish.IsEnabled = false;
            Timer("pause");
            
            test= _test_navigation.CheckTest(test);
            int correct_answers = _test_navigation.CountCorrectAnswers(test);

            TextBlock_test_result.Visibility = Visibility.Visible;
            TextBlock_test_result.Text = _resources.Get_TextBlock_Test_Result_Value(correct_answers);

            ShowQuestion();

            //if (RadioButton_question_one_correct_answer_1.IsChecked == true)
            //{
            //    correct_answers++;
            //    Border_question_one_correct.Background = new SolidColorBrush(Colors.LightGreen);
            //}
            //else
            //{
            //    Border_question_one_correct.Background = new SolidColorBrush(Colors.Coral);
            //}            
            //if (CheckBox_question_some_correct_answer_1.IsChecked == true && CheckBox_question_some_correct_answer_2.IsChecked == false && CheckBox_question_some_correct_answer_3.IsChecked == true && CheckBox_question_some_correct_answer_4.IsChecked == false && CheckBox_question_some_correct_answer_5.IsChecked == false)
            //{
            //    correct_answers++;
            //    Border_question_some_correct.Background = new SolidColorBrush(Colors.LightGreen);
            //}
            //else
            //{
            //    Border_question_some_correct.Background = new SolidColorBrush(Colors.Coral);
            //}           
            //if (TextBox_question_input_word_answer_1.Text == "тигр" && TextBox_question_input_word_answer_2.Text == "семейства кошачьих")
            //{
            //    correct_answers++;
            //    Border_question_input_word.Background = new SolidColorBrush(Colors.LightGreen);
            //}
            //else
            //{
            //    Border_question_input_word.Background = new SolidColorBrush(Colors.Coral);
            //}


        }

        #region Timer
        /// <summary>
        /// управления старт/стоп ht;bvfvb nfqvthf
        /// </summary>
        /// <param name="option"></param>
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
        /// <summary>
        /// отображение тиков таймера на форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            _time++;
            TextBlock_test_time.Text = _resources.TextBlock_Test_Time_Value(_time);           
        }
        #endregion

        #region Навигация по тесту
        /// <summary>
        /// Доступность нажатия следующего/предыдущего вопроса
        /// </summary>
        public void EnabledLeftRightButtons()
        {
            question_counter_before= _test_navigation.GetBeforeOrNullQuestion(test, question_counter);
            if (question_counter_before==null)
                Button_left.IsEnabled = false;
            else
                Button_left.IsEnabled = true;
            question_counter_after= _test_navigation.GetNextOrNullQuestion(test, question_counter);
            if (question_counter_after==null)
                Button_right.IsEnabled = false;
            else
                Button_right.IsEnabled= true;
        }
        /// <summary>
        /// Запомнить ответ и перейти к следующему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_right_Click(object sender, RoutedEventArgs e)
        {
            SaveIt();
            question_counter = question_counter_after;
            ShowQuestion();
        }
        /// <summary>
        /// Запомнить ответ и перейти к пердыдущему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_left_Click(object sender, RoutedEventArgs e)
        {
            SaveIt();
            question_counter = question_counter_before;
            ShowQuestion();
        }

        /// <summary>
        /// Начать тест заново
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_restart_Click(object sender, RoutedEventArgs e)
        {
            if (Stop_time)
                Timer("pause");
            if (MessageBox.Show(_resources.Get_MessageBox_Restart_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                if (Stop_time)
                    Timer("continue");
            }
            else
            {
                Timer("start");
                //todo
                //UploadData();
            }
        }

        /// <summary>
        /// Вернуться к выбору тестов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            if (Stop_time)
                Timer("pause");
            if (MessageBox.Show(_resources.Get_MessageBox_Back_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                if (Stop_time)
                    Timer("continue");
            }
            else
            {
                Get_choose_content();
            }
        }

        /// <summary>
        /// Закончить тест
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_finish_Click(object sender, RoutedEventArgs e)
        {
            SaveIt();
            if (Stop_time)
                Timer("pause");
            if (_test_navigation.IsTestCompleted(test))
            {
                if (MessageBox.Show(_resources.Get_MessageBox_Finish_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    if (Stop_time)
                        Timer("continue");
                }
                else
                {
                    Check();
                }
            }
            else
            {
                if (MessageBox.Show(_resources.Get_MessageBox_Finish_Not_Completed_Value(), _resources.Get_MessageBox_Title_Value(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    if (Stop_time)
                        Timer("continue");
                }
                else
                {
                    Check();
                }
            }
        }

        #endregion
    }
}
