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

namespace SJ2_Save_Editor
{
    public partial class Editor : Form
    {
        string filePath;
        public Editor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Hover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }
        private void button1_Unhover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        // zapisywanie save'a
        private void button3_Click(object sender, EventArgs e)
        {
            Utils.Patch($"POINTS {points1.Text}", 1, filePath);
            Utils.Patch($"AUTO_C {autoc1.Text}", 2, filePath);
            Utils.Patch($"AUTO_T {autot1.Text}", 3, filePath);
            Utils.Patch($"QCA {QCA1.Text} {QCA2.Text} {QCA3.Text}", 7, filePath);
            Utils.Patch($"VOL_MAIN {VOL_MAIN.Text}", 15, filePath);
            Utils.Patch($"VOL_MUSIC {VOL_MUSIC.Text}", 16, filePath);
            Utils.Patch($"VOL_SFX {VOL_SFX.Text}", 17, filePath);
            Utils.Patch($"VOL_SPEECH {VOL_SPEECH.Text}", 18, filePath);
            Utils.Patch($"VOL_OTHER {VOL_OTHER.Text}", 19, filePath);
        }

        // wczytywanie
        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("POINTS"))
                        {
                            points1.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("AUTO_C"))
                        {
                            autoc1.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("AUTO_T"))
                        {
                            autot1.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("QCA"))
                        {
                            QCA1.Text = line.Split(' ')[1];
                            // fix dla problemu gdzie swiezy save nie zawiera tych 2 ostatnich liczb co triggerowalo errora u edytora
                            if(!line.Split(' ')[1].Contains("0"))
                            {
                                QCA2.Text = line.Split(' ')[2];
                                QCA3.Text = line.Split(' ')[3];
                            } else
                            {
                                QCA2.Text = "0";
                                QCA3.Text = "0";
                            }
                            
                        }
                        if (line.Contains("VOL_MAIN"))
                        {
                            VOL_MAIN.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("VOL_MUSIC"))
                        {
                            VOL_MUSIC.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("VOL_SFX"))
                        {
                            VOL_SFX.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("VOL_SPEECH"))
                        {
                            VOL_SPEECH.Text = line.Split(' ')[1];
                        }
                        if (line.Contains("VOL_OTHER"))
                        {
                            VOL_OTHER.Text = line.Split(' ')[1];
                        }
                    }
                }
            }
            
        }
    }
}
