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

namespace StackUndoButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<UndoAction> undoOps = new Stack<UndoAction>();
        Random _rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private Brush GetRandomBrush()
        {
            byte[] rgb = new byte[3];
            _rng.NextBytes(rgb);

            return new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoAction(button));
            button.Background = GetRandomBrush();
            UpdateList();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoAction(button1));
            button1.Background = GetRandomBrush();
            UpdateList();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Push(new UndoAction(button2));
            button2.Background = GetRandomBrush();
            UpdateList();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            undoOps.Pop().Excecute();
            UpdateList();
        }

        private void UpdateList()
        {
            listBox.Items.Clear();
            foreach (UndoAction action in undoOps)
            {
                listBox.Items.Add(action.ToString());
            }
        }

        
    }
}
