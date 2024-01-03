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

namespace Math_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private int n1;
        private int n2;
        private int correct;
        private double Rightcnt = 0;
        private double Wrongcnt = 0;
        private double finalgrade;
        public MainWindow()
        {
            InitializeComponent();
        }

     
        private string GetMathSymbol(int grade)
        {
            switch(grade)
            {
                case 1:
                    return "+";
                case 2: 
                    return "-";
                 case 3: 
                    return "*";
                 case 4: return "*";
                default:
                    return "";
            }
        }
        private void grade1btn(object sender, RoutedEventArgs e)
        {
            n1 = random.Next(1,20);
            n2 = random.Next(1,20);
            num1.Text = n1.ToString();
            num2.Text = n2.ToString();
            correct = n1 + n2;

        }

        private void grade2btn(object sender, RoutedEventArgs e)
        {
            n1 = random.Next(2, 20);
            n2 = random.Next(2, 20);
            num1.Text = n1.ToString();
            num2.Text = n2.ToString();
            correct = n1 - n2;
        }

        private void grade3btn(object sender, RoutedEventArgs e)
        {
            n1 = random.Next(1, 10);
            n2 = random.Next(1, 10);
            num1.Text = n1.ToString();
            num2.Text = n2.ToString();
            correct = n1 * n2;
        }

        private void grade4btn(object sender, RoutedEventArgs e)
        {
            n1 = random.Next(1, 100);
            n2= random.Next(1, 10);
            num1.Text = n1.ToString();
            num2.Text = n2.ToString();
            correct = n1 * n2;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void readybtn(object sender, RoutedEventArgs e)
        {
            choosegrade.Visibility = Visibility.Collapsed;
            grade.Visibility = Visibility.Collapsed;
            welcome.Visibility = Visibility.Collapsed;
            ready.Visibility = Visibility.Collapsed;

            num1.Text=n1.ToString();
            num2.Text=n2.ToString();
            string mathsymbole2 = GetMathSymbol(grade.SelectedIndex + 1);
            mathsymbol.Text = mathsymbole2;
            num1.Visibility= Visibility.Visible;
            num2.Visibility= Visibility.Visible;
            mathsymbol.Visibility= Visibility.Visible;
            answer.Visibility= Visibility.Visible;
            YourAnswerLabel.Visibility= Visibility.Visible;
            submitbtn.Visibility= Visibility.Visible;
            V.Visibility = Visibility.Visible;
            X.Visibility = Visibility.Visible;
            RightAnswers.Visibility = Visibility.Visible;
            WrongAnswers.Visibility = Visibility.Visible;
            finished.Visibility= Visibility.Visible;
            backtohomebtn.Visibility= Visibility.Visible;
            backtohomeimage.Visibility= Visibility.Visible;
        }


        private void grade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void subclick(object sender, RoutedEventArgs e)
        {
            if(answer.Text == correct.ToString())
            {
                MessageBox.Show("GOALLLLLL!!!!!!");
                wgif.Visibility= Visibility.Visible;
                Lgif.Visibility = Visibility.Collapsed;
                GenerateRandomNumbers();
                UpdateDisplay();
                Rightcnt++;
                RightAnswers.Text = Rightcnt.ToString();
            }
            else
            {
                wgif.Visibility = Visibility.Collapsed;
                Lgif.Visibility = Visibility.Visible;
                MessageBox.Show("missed...");
                Wrongcnt++;
                WrongAnswers.Text = Wrongcnt.ToString();
                UpdateDisplay();
            }
        }
        private void GenerateRandomNumbers()
        {
            // Generate new random numbers based on the selected grade
            int maxRange = GetMaxRangeForGrade(grade.SelectedIndex + 1); // Assuming grades are 1-indexed
            n1 = random.Next(0, maxRange);
            n2 = random.Next(0, maxRange);
            correct = CalculateCorrectAnswer(grade.SelectedIndex + 1);
        }

        private void UpdateDisplay()
        {
            // Update the display with new numbers
            num1.Text = n1.ToString();
            num2.Text = n2.ToString();
            answer.Text = ""; // Clear the answer textbox for the new question
        }

        private int GetMaxRangeForGrade(int grade)
        {
            switch (grade)
            {
                case 1:
                    return 10;
                case 2:
                    return 20;
                case 3:
                    return 50;
                case 4:
                    return 100;
                default:
                    return 10;
            }
        }

        private int CalculateCorrectAnswer(int grade)
        {
            switch (grade)
            {
                case 1:
                    return n1 + n2;
                case 2:
                    return n1 - n2;
                case 3:
                    return n1 * n2;
                case 4:
                    return n1 * n2;
                default:
                    return 0;
            }
        }

        private void answerfocous(object sender, RoutedEventArgs e)
        {
            
        }

        private void finishbtn(object sender, RoutedEventArgs e)
        {
            finalgrade = Rightcnt / (Rightcnt + Wrongcnt)*100;
            if (finalgrade==100)
            {
                MessageBox.Show("Your final grade is 100! You are perfect!");
            }
            if (finalgrade < 100 && finalgrade > 84)
            {
                MessageBox.Show("Your final grade is " + finalgrade.ToString() + "! Keep working to get to perfection.");
            }
            if (finalgrade < 85 && finalgrade > 69)
            {
                MessageBox.Show("Your final grade is " + finalgrade.ToString() + ". good job, keep working to get better!");
            }
            if (finalgrade < 70 && finalgrade > 54)
            {
                MessageBox.Show("Your final grade is " + finalgrade.ToString() + ". Keep working to get better results next time!");
            }
            if (finalgrade < 55)
            {
                MessageBox.Show("You failed, But don't worry.. keep working and you will get better and better!");
            }
            num1.Visibility = Visibility.Collapsed;
            num2.Visibility = Visibility.Collapsed;
            mathsymbol.Visibility = Visibility.Collapsed;
            answer.Visibility = Visibility.Collapsed;
            YourAnswerLabel.Visibility = Visibility.Collapsed;
            submitbtn.Visibility = Visibility.Collapsed;
            V.Visibility = Visibility.Collapsed;
            X.Visibility = Visibility.Collapsed;
            RightAnswers.Visibility = Visibility.Collapsed;
            WrongAnswers.Visibility = Visibility.Collapsed;
            finished.Visibility = Visibility.Collapsed;
            wgif.Visibility = Visibility.Collapsed;
            Lgif.Visibility = Visibility.Collapsed;
            backtohomeimage.Visibility = Visibility.Collapsed;
            backtohomebtn.Visibility = Visibility.Collapsed;

            choosegrade.Visibility = Visibility.Visible;
            grade.Visibility = Visibility.Visible;
            welcome.Visibility = Visibility.Visible;
            ready.Visibility = Visibility.Visible;

            RightAnswers.Text = "0";
            WrongAnswers.Text = "0";
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            num1.Visibility = Visibility.Collapsed;
            num2.Visibility = Visibility.Collapsed;
            mathsymbol.Visibility = Visibility.Collapsed;
            answer.Visibility = Visibility.Collapsed;
            YourAnswerLabel.Visibility = Visibility.Collapsed;
            submitbtn.Visibility = Visibility.Collapsed;
            V.Visibility = Visibility.Collapsed;
            X.Visibility = Visibility.Collapsed;
            RightAnswers.Visibility = Visibility.Collapsed;
            WrongAnswers.Visibility = Visibility.Collapsed;
            finished.Visibility = Visibility.Collapsed;
            wgif.Visibility = Visibility.Collapsed;
            Lgif.Visibility = Visibility.Collapsed;
            backtohomeimage.Visibility = Visibility.Collapsed;
            backtohomebtn.Visibility = Visibility.Collapsed;

            choosegrade.Visibility = Visibility.Visible;
            grade.Visibility = Visibility.Visible;
            welcome.Visibility = Visibility.Visible;
            ready.Visibility = Visibility.Visible;

            RightAnswers.Text = "0";
            WrongAnswers.Text = "0";
        }
    }
}
