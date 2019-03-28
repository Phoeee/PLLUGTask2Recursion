﻿using System;
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

namespace PLLUGTask2Recursion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearOutput();
            Fibonacci fiboNumber = new Fibonacci();
            if (RadioButtonByAmount.IsChecked == true)
            {
                try
                {
                    for (ulong i = 1; i <= ulong.Parse(textboxInput.Text); i++)
                    {
                        RichTextBoxOutput.Document.Blocks.Add
                            (new Paragraph(new Run(fiboNumber.GetFibonacciSequencebyAmount(i).ToString())));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    foreach (var element in fiboNumber.GetFibonacciSequenceByNumber(ulong.Parse(textboxInput.Text)))
                    {
                        RichTextBoxOutput.Document.Blocks.Add(new Paragraph(new Run(element.ToString())));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RadioButtonByAmount_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButtonByNumber != null)
            {
                RadioButtonByNumber.IsChecked = false;
            }
        }

        private void RadioButtonByNumber_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButtonByAmount != null)
            {
                RadioButtonByAmount.IsChecked = false;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // check if not number => not accept
            if (e.Text != "," && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ",")
            {
                // check if dot in the beginning of number => not accept
                if (((TextBox)sender).Text.Length == 0)
                {
                    e.Handled = true;
                }
                // check if dot occurs ore than once in number => not accept
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private bool IsNumber(string inputText)
        {
            return int.TryParse(inputText, out var output);
        }

        public void ClearOutput()
        {
            RichTextBoxOutput.SelectAll();
            RichTextBoxOutput.Selection.Text = "";
        }
    }
}
