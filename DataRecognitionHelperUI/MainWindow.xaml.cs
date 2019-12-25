using DataRecognitionHelper.Implementations;
using DataRecognitionHelper.Interfaces;
using DataRecognitionHelper.Utils;
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
        List<InputItem> inputItems;
        List<OutputItem> outputItems;
        List<IInput> inputs;
        List<IOutput> outputs;

        public MainWindow()
        {
            InitializeComponent();
            manager = new DataRecognitionManager();
            inputs = manager.GetInputs();
            inputItems = new List<InputItem>() { new InputItem { Name = "Auto", IsChecked = true} };
            inputItems.AddRange(inputs.Select(i => new InputItem() { Name = i.Name}));
            inputItemsControl.ItemsSource = inputItems;
            outputs = manager.GetOutputs();
            outputItems = outputs.Select(o => new OutputItem() { Name = o.Name, Value = "0" }).ToList();
            outputItemsControl.ItemsSource = outputItems;
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOutputs();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateOutputs();
        }

        private void UpdateOutputs()
        {
            var text = StringUtils.EscapeSpaces(intputText.Text);

            if (string.IsNullOrEmpty(text))
            {
                outputItemsControl.ItemsSource = outputs.Select(o => new OutputItem() { Name = o.Name, Value = "0" }).ToList();
                return;
            }

            IInput input = inputs.FirstOrDefault(i => i.Name == inputItems.FirstOrDefault(ii => ii.IsChecked).Name);

            if (input == null)
            {
                input = manager.GuessInputType(text);
            }

            if (input == null || !input.IsApplicable(text))
            {
                outputItemsControl.ItemsSource = outputs.Select(o => new OutputItem() { Name = o.Name, Value = "Not applicable" }).ToList();
                return;
            }

            var bytes = input.GetBytes(text);
            outputItemsControl.ItemsSource = outputs.Select(o => new OutputItem() { Name = o.Name, Value = o.GetOutput(bytes) }).ToList();
        }
    }

    public class OutputItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class InputItem
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
