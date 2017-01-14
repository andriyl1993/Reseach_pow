using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Recearch_Pow
{
    delegate bool pred(int num);
    class Generating
    {
        public static bool CheckValues(int start, int end)
        {
            if (start > end)
            {
                return false;
            }
            if ((start <= 0) || (end <= 0))
            {
                return false;
            }

            return true;
        }

        private static bool stub(int n)
        {
            return true;
        }

        public static bool IsCorrectLength(int n)
        {
            if (n < 3)
                return false;

            string s = Convert.ToString(n, 2);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '1')
                    return false;
            }

            return true;
        }

        public static void GenerateValuesP(List<int> pValues, string filename)
        {
            #region prevVersion
            /*StreamWriter sw = new StreamWriter(filename);

            foreach (int pValue in pValues) {
                sw.Write(pValue);
                sw.Write(", ");
            }

            sw.Close();*/
            #endregion prevVersion

            StreamWriter sw = new StreamWriter(filename);

            foreach (int pValue in pValues)
            {
                sw.WriteLine(pValue);
            }

            sw.Close();
        }
        public static List<int> ParseList(string str)
        {
            List<int> numbers = new List<int>();

            int number;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) == true)
                {
                    int j;
                    for (j = i; j < str.Length; j++)
                    {
                        if (char.IsDigit(str[j]) == false)
                        {
                            break;
                        }
                    }
                    bool result = int.TryParse(str.Substring(i, j - i), out number);
                    if (result == false)
                    {
                        return null;
                    }
                    else
                    {
                        if (number > 0)
                        {
                            numbers.Add(number);
                        }
                    }
                    i = j - 1;
                }
            }

            if (numbers.Count == 0)
            {
                return null;
            }

            return numbers;
        }

        public static List<int> ParseIntervals(string s)
        {
            return ParseIntervals(s, stub);
        }
        public static List<int> ParseIntervals(string s, pred pr)
        {
            String[] strs = s.Split(',');
            List<int> lst = new List<int>();
            foreach (string str in strs)
            {
                if (str.Contains('-'))
                {
                    String[] nums = str.Split('-');
                    int start, step, end;
                    if (nums.GetLength(0) == 3 && Int32.TryParse(nums[0], out start) && Int32.TryParse(nums[1], out end) && Int32.TryParse(nums[2], out step))
                    {
                        for (int i = start; i <= end; i += step)
                            if (pr(i))
                                lst.Add(i);
                    }
                    else
                    {
                        MessageBox.Show("Error in intervals");
                        return null;
                    }
                }
                else
                {
                    int i = 0;
                    if (Int32.TryParse(str, out i) && (pr(i)))
                        lst.Add(i);
                    else
                    {
                        MessageBox.Show("Error in intervals");
                        return null;
                    }
                }
            }
            return lst;
        }
    }
}
