using DataRecognitionHelper.Implementations;
using DataRecognitionHelper.Interfaces;
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

namespace DataRecognitionHelperUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRecognitionManager manager;
        List<OutputItem> outputs;

        public MainWindow()
        {
            InitializeComponent();
            manager = new DataRecognitionManager();
            outputs = manager.GetOutputs().Select(o => new OutputItem() { Name = o.Name, Value = string.Empty }).ToList();
            outputsItems.ItemsSource = outputs;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = (sender as TextBox)?.Text;
            var inputType = manager.GuessInputType(text);
            var bytes = inputType.GetBytes(text);
            outputsItems.ItemsSource = manager.GetOutputs().Select(o => new OutputItem() { Name = o.Name, Value = o.GetOutput(bytes) }).ToList();
        }
    }

    public class OutputItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
