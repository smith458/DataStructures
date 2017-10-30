using HashTable;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Shapes;
using System.Windows;

namespace HashWordCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HashTable<string, int> _wordCounts = new HashTable<string, int>();

        public ObservableCollection<WordCountData> WordCountCollection { get; private set; }

        public MainWindow()
        {
            WordCountCollection = new ObservableCollection<WordCountData>();

            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string file = GetFileName();

            try
            {
                LoadFileData(file);
                DisplayTopWords();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayTopWords()
        {
            WordCountCollection.Clear();
        }

        private void LoadFileData(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                using (FileStream contents = File.OpenRead(file))
                using (StreamReader reader = new StreamReader(contents))
                {
                    _wordCounts.Clear();

                    while (!reader.EndOfStream)
                    {
                        LoadLine(reader.ReadLine());
                    }
                }
            }
        }

        private void LoadLine(string line)
        {
            string[] words = line.Split(" \t,.:()\"\'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string wordLower = word.ToLower();

                int count;
                if (!_wordCounts.TryGetValue(wordLower, out count))
                {
                    count = 0;
                    _wordCounts.Add(wordLower, 0);
                }

                _wordCounts[wordLower] = count + 1;
            }
        }
    }
}
