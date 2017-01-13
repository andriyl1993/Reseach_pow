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
            checkedListBoxModified.SetItemChecked(0, true);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            BigInteger length, n;
            BigInteger.TryParse(textBoxLength.Text, out length);
            BigInteger.TryParse(textBoxBits.Text, out n);

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

            for (int i = 0; i < checkedListBoxModified.Items.Count; i++)
            {
                if (checkedListBoxModified.GetItemChecked(i))
                    Methods.MethodsList[i](length, n, numbers, isRand);
            }
        }
    }
}
