using System;
using System.IO;
using CsvHelper;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelLibrary.SpreadSheet;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Accord.Statistics.Models.Regression.Linear;
using Accord.Statistics.Analysis;
using Accord.IO;
using Accord.Math;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using Accord.Controls;

namespace IST_teorver
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> wordsDictionaryClass1 = new Dictionary<string, int>();
        private Dictionary<string, int> wordsDictionaryClass2 = new Dictionary<string, int>();

        private Dictionary<string, int> ClassifierData = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();

            string filePathCSV = @"data/Table.csv";
            string filePathText2 = @"data/text2.txt";

            SettleCSVwords(filePathCSV);
            ReadText2(filePathText2);

            FrequencyTables();

            DrawGraphs();
        }

        public void FrequencyTables()
        {
            foreach (KeyValuePair<string, int> keyValue in wordsDictionaryClass1)
            {
                string item = string.Format("{0} - {1}", keyValue.Key, keyValue.Value);
                listBox1.Items.Add(item);
            }

            foreach (KeyValuePair<string, int> keyValue in wordsDictionaryClass2)
            {
                string item = string.Format("{0} - {1}", keyValue.Key, keyValue.Value);
                listBox2.Items.Add(item);
            }
        }

        public void ReadText2(string filePath)
        {
            string text = "";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            SettleText2Words(text);
        }

        public void SettleText2Words(string text)
        {
            string t = text;

            t = t.Replace(",", "")
                .Replace(".", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace("– ", "")
                .Replace("- ", "")
                .Replace("«", "")
                .Replace("»", "")
                .Replace("\"", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("?", "")
                .Replace("!", "")
                .Replace("#", "")
                .Replace("/", " ")
                .ToLower();

            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (wordsDictionaryClass2.ContainsKey(words[i]))
                {
                    wordsDictionaryClass2[words[i]]++;
                }
                else
                {
                    wordsDictionaryClass2.Add(words[i], 1);
                }

            }
        }

        public void SettleCSVwords(string filePath)
        {
            System.Data.DataTable table = new Accord.IO.CsvReader(filePath, true).ToTable();

            string[] texts = table.Columns[1].ToArray<string>();

            string concatText = "";

            for (int i = 0; i < texts.Length; i++)
            {
                concatText += texts[i];
                concatText += " ";
            }

            concatText = concatText
                .Replace(",", "")
                .Replace(".", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace("– ", "")
                .Replace("- ", "")
                .Replace("— ", "")
                .Replace("-", "")
                .Replace("«", "")
                .Replace("»", "")
                .Replace("\"", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("?", "")
                .Replace("!", "")
                .Replace("#", "")
                .Replace("/", " ")
                .ToLower();

            string[] words = concatText.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (wordsDictionaryClass1.ContainsKey(words[i]))
                {
                    wordsDictionaryClass1[words[i]]++;
                }
                else
                {
                    wordsDictionaryClass1.Add(words[i], 1);
                }

            }
           
        }

        public double CalculateProbabily(Dictionary<string, int> cl, double countUniqWords, string[] words)
        {
            double classWorsCount = 0;
            foreach (KeyValuePair<string, int> keyValue in cl)
            {
                classWorsCount += keyValue.Value;
            }

            double probability = 0;

            foreach(string w in words)
            {
                double freqW = 0;
                foreach(KeyValuePair<string, int> keyValue in cl)
                {
                    if (w == keyValue.Key)
                    {
                        freqW++;
                    }
                }
                probability += Math.Log((freqW + 1) / (countUniqWords + classWorsCount));
            }
            
            probability += Math.Log(0.5d);

            return probability;
        }

        public double ConvertToProcents(double prob, params double[] probs)
        {
            double percents = 0;

            double sum = 0;
            foreach(double d in probs)
            {
                sum += Math.Exp(d);
            }

            percents = Math.Exp(prob) / sum;

            return percents;
        }

        public void DrawGraphs()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;
            pane.XAxis.Scale.FontSpec.Angle = 90;
            pane.XAxis.Scale.FontSpec.Size = 10;
            pane.Title.Text = "Топ-30 слов в текст 1";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            int itemscount = 30;

            string[] names = new string[itemscount];
            // Высота столбиков
            double[] values = new double[itemscount];

            int a = 0;
            foreach(KeyValuePair<string, int> keyValue in wordsDictionaryClass1.OrderByDescending(pair => pair.Value))
            {
                names[a] = keyValue.Key;
                values[a] = keyValue.Value;
                a++;
                if (a >= 30)
                    break;
            }

            BarItem bar = pane.AddBar("Топ-30 слов в текст 1", null, values, Color.Blue);

            pane.XAxis.Type = AxisType.Text;
            pane.XAxis.Scale.TextLabels = names;

            zedGraph.AxisChange();
            zedGraph.Invalidate();

            GraphPane pane1 = zedGraph1.GraphPane;
            pane1.XAxis.Scale.FontSpec.Angle = 90;
            pane1.XAxis.Scale.FontSpec.Size = 10;
            pane1.Title.Text = "Топ-30 слов в текст 2";

            names = new string[itemscount];
            values = new double[itemscount];

            a = 0;
            foreach (KeyValuePair<string, int> keyValue in wordsDictionaryClass2.OrderByDescending(pair => pair.Value))
            {
                names[a] = keyValue.Key;
                values[a] = keyValue.Value;
                a++;
                if (a >= 30)
                    break;
            }

            BarItem bar1 = pane1.AddBar("Топ-30 слов в текст 2", null, values, Color.Blue);

            pane1.XAxis.Type = AxisType.Text;
            pane1.XAxis.Scale.TextLabels = names;

            zedGraph1.AxisChange();
            zedGraph1.Invalidate();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputTB.Text == "")
            {
                MessageBox.Show("Введите текст");
                return;
            }

            string inputText = InputTB.Text;
            inputText = inputText
                .Replace(",", "")
                .Replace(".", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace("—", "")
                .Replace("-", "")
                .Replace("«", "")
                .Replace("»", "")
                .Replace("\"", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("?", "")
                .Replace("!", "")
                .Replace("#", "")
                .Replace("/", " ")
                .ToLower();

            string[] inputWords = inputText.Split(' ');

            double uniqWordsCount = 0;
            foreach (KeyValuePair<string, int> keyValue in wordsDictionaryClass2)
            {
                uniqWordsCount++;
            }

            foreach (KeyValuePair<string, int> keyValue1 in wordsDictionaryClass1)
            {
                bool flag = true;
                foreach (KeyValuePair<string, int> keyValue2 in wordsDictionaryClass2)
                {
                    if (keyValue1.Key.Equals(keyValue2.Key))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    uniqWordsCount++;
                }
            }

            double probabilityClass1 = CalculateProbabily(wordsDictionaryClass1, uniqWordsCount, inputWords);
            double probabilityClass2 = CalculateProbabily(wordsDictionaryClass2, uniqWordsCount, inputWords);

            procentTB1.Text = ConvertToProcents(probabilityClass1, probabilityClass1, probabilityClass2).ToString();
            procentTB2.Text = ConvertToProcents(probabilityClass2, probabilityClass1, probabilityClass2).ToString();
        }
    }
}
