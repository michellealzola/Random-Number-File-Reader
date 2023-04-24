using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Number_File_Reader
{
    public partial class frmRandNumFileReader : Form
    {
        public frmRandNumFileReader()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            int num;
            int total = 0;
            int count = 0;

            try
            {
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    StreamReader inputFile;
                    inputFile = File.OpenText(openFile.FileName);
                    
                    while(!inputFile.EndOfStream)
                    {
                        if(int.TryParse(inputFile.ReadLine(), out num))
                        {
                            lboxRandomNumbersRead.Items.Add(num.ToString());
                            total += num;
                            count++;
                        }
                    }

                    lblTotal.Text = total.ToString();
                    lblRandCount.Text = count.ToString();

                    inputFile.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lboxRandomNumbersRead.Items.Clear();
            lblTotal.Text = "";
            lblRandCount.Text = "";

            btnOpenFile.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
