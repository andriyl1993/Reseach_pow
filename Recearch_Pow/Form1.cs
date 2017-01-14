using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Recearch_Pow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var method in Methods.ModifiedMethodsDictionary)
                checkedListBoxModified.Items.Add(method.Key, true);

            foreach (var method in Methods.ClassicMethodsDictionary)
                checkedListBoxClassic.Items.Add(method.Key, true);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //object[,] array =
            //{
            //    {1, 2, 3 },
            //    {4, 5, 6 }
            //};
            //Output.WriteToExcel("excel.xls", "sheet1", array, 6, 0);
            //Output.WriteToExcel("excel.xls", "sheet2", array, 1, 0);

            DateTime start = DateTime.Now;

            List<int> lengthList = Generating.ParseIntervals(textBoxLength.Text, Generating.IsCorrectLength);
            List<int> nList = Generating.ParseIntervals(textBoxBits.Text);

            foreach (int length in lengthList)
                foreach (int n in nList)
                {

                    BigInteger max_number = new BigInteger(Math.Pow(2, (double)n));

                    List<BigInteger> numbers = new List<BigInteger>();

                    bool isRand = radioButtonRand.Checked;

                    if (isRand)
                    {
                        int rand_count = Int32.Parse(textBoxRandomNumbers.Text);
                        Random r = new Random();

                        for (int i = 0; i < rand_count; i++)
                            numbers.Add(r.Next() % max_number);
                    }

                    Dictionary<string, double[,]> results = new Dictionary<string, double[,]>();

                    for (int i = 0; i < checkedListBoxModified.Items.Count; i++)
                    {
                        if (checkedListBoxModified.GetItemChecked(i))
                            results.Add(checkedListBoxModified.Items[i].ToString(), Methods.ModifiedMethodsDictionary[checkedListBoxModified.Items[i].ToString()](length, n, numbers, isRand));
                    }

                    string filename = "methods--" + start.ToString("yyyy-MM-dd,hh-mm-ss") + ".xls";
                    Output.WriteMethodsResult(filename, length, n, results);
                }

            MessageBox.Show("success");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
