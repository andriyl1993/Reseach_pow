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
            int i = 0;
            foreach (var method in Methods.ModifiedMethodsDictionary)
            {
                //if (i == Methods.ModifiedMethodsDictionary.Count - 1)
                checkedListBoxModified.Items.Add(method.Key, true);
                //else
                //    checkedListBoxModified.Items.Add(method.Key, false);
                //i++;
            }

            foreach (var method in Methods.ClassicMethodsDictionary)
                checkedListBoxClassic.Items.Add(method.Key, true);
        }

        private object[,] AnalyzeMethods(string filename, bool isClassic = false)
        {
            List<int> lengthList = Generating.ParseIntervals(textBoxLength.Text, Generating.IsCorrectLength);
            List<int> nList = Generating.ParseIntervals(textBoxBits.Text);

            Dictionary<string, Methods.MethodsDelegate> methods;
            CheckedListBox listBox;

            if (isClassic)
            {
                methods = Methods.ClassicMethodsDictionary;
                listBox = checkedListBoxClassic;
            }
            else
            {
                methods = Methods.ModifiedMethodsDictionary;
                listBox = checkedListBoxModified;
            }

            object[,] sumTable = new object[lengthList.Count + 1, nList.Count + 1];

            int iLength = 1;

            for (int i = 0; i < nList.Count; i++)
                sumTable[0, i + 1] = nList[i];

            foreach (int length in lengthList)
            {
                sumTable[iLength, 0] = length;
                int jN = 1;

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

                    Dictionary<string, double[,]> resultDictionary = new Dictionary<string, double[,]>();
                    Dictionary<string, List<object>> commentsDictionary = new Dictionary<string, List<object>>();
                    Dictionary<string, double> sumDictionary = new Dictionary<string, double>();

                    for (int i = 0; i < listBox.Items.Count; i++)
                    {
                        if (listBox.GetItemChecked(i))
                        {
                            string key = listBox.Items[i].ToString();
                            List <object> comments = null;
                            double [,] result = methods[listBox.Items[i].ToString()](length, n, numbers, out comments, isRand);
                            
                            resultDictionary.Add(key, result);
                            commentsDictionary.Add(key, comments);
                            sumDictionary.Add(key, Methods.sum_of_column(result, 2));
                        }
                            
                    }

                    Output.WriteMethodsResult(filename, length, n, resultDictionary, commentsDictionary, sumDictionary);
                    sumTable[iLength, jN] = sumDictionary;

                    jN++;
                }
                iLength++;
            }

            return sumTable;
        }

        private delegate double CalcElementTable(double classic, double modified);

        private void WriteCompareTable(string filename, string sheetName, object[,] sumMethodsClassic, object[,] sumMethodsModified)
        {
            int classicItemsCount = checkedListBoxClassic.CheckedItems.Count;
            int modifiedItemsCount = checkedListBoxModified.CheckedItems.Count;

            int widthOfTable = sumMethodsModified.GetLength(1);
            int heightOfTable = sumMethodsModified.GetLength(0) + 2;
            int currentRow = 0;

            object[,] compareTable = new object[heightOfTable, widthOfTable];

            foreach (string classic in checkedListBoxClassic.CheckedItems)
                foreach (string modified in checkedListBoxModified.CheckedItems)
                {
                    compareTable[0, 0] = "Compare " + classic + " and " + modified;

                    for (int j = 1; j < widthOfTable; j++)
                        compareTable[1, j] = sumMethodsModified[0, j];

                    for (int i = 2; i <= sumMethodsModified.GetLength(0); i++)
                    {
                        compareTable[i, 0] = sumMethodsModified[i - 1, 0];

                        for (int j = 1; j < widthOfTable; j++)
                        {
                            Dictionary<string, double> modifiedDict = (Dictionary<string, double>)sumMethodsModified[i - 1, j];
                            Dictionary<string, double> classicDict = (Dictionary<string, double>)sumMethodsClassic[i - 1, j];
                            compareTable[i, j] = modifiedDict[modified] - classicDict[classic];
                        }
                    }

                    Output.WriteToExcel(filename, "Compare", compareTable, currentRow);

                    currentRow += heightOfTable;
                }
        }

        private void WriteMethodTable(string filename, string sheetName, object[,] sumMethods, CheckedListBox listBox)
        {
            int itemsCount = listBox.CheckedItems.Count;

            int widthOfTable = sumMethods.GetLength(1);
            int heightOfTable = sumMethods.GetLength(0) + 2;
            int currentRow = 0;

            object[,] compareTable = new object[heightOfTable, widthOfTable];
            
            foreach (string method in listBox.CheckedItems)
            {
                compareTable[0, 0] = "Method " + method;

                for (int j = 1; j < widthOfTable; j++)
                    compareTable[1, j] = sumMethods[0, j];

                for (int i = 2; i <= sumMethods.GetLength(0); i++)
                {
                    compareTable[i, 0] = sumMethods[i - 1, 0];

                    for (int j = 1; j < widthOfTable; j++)
                    {
                        Dictionary<string, double> dict = (Dictionary<string, double>)sumMethods[i - 1, j];
                        compareTable[i, j] = dict[method];
                    }
                }

                Output.WriteToExcel(filename, sheetName, compareTable, currentRow);

                currentRow += heightOfTable;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            string filename = "methods--" + start.ToString("yyyy-MM-dd,hh-mm-ss") + ".xls";

            object[,] sumMethods = AnalyzeMethods(filename);
            MessageBox.Show("success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            string filename = "compare--" + start.ToString("yyyy-MM-dd,hh-mm-ss") + ".xls";
            Output.WriteToExcel(filename, "Compare", null);
            Output.WriteToExcel(filename, "Classic Methods", null);
            Output.WriteToExcel(filename, "Modified Methods", null);

            if (checkedListBoxClassic.CheckedItems.Count == 0 && checkedListBoxModified.CheckedItems.Count == 0)
            {
                MessageBox.Show("1 of methods should be checked in every table");
                return;
            }

            object[,] sumMethodsClassic = AnalyzeMethods(filename, true);
            object[,] sumMethodsModified = AnalyzeMethods(filename, false);

            WriteCompareTable(filename, "Compare", sumMethodsClassic, sumMethodsModified);
            WriteMethodTable(filename, "Classic Methods", sumMethodsClassic, checkedListBoxClassic);
            WriteMethodTable(filename, "Modified Methods", sumMethodsModified, checkedListBoxModified);
            
            MessageBox.Show("success");
        }
    }
}
