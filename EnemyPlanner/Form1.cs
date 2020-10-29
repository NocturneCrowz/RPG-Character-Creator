using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnemyPlanner
{
    public partial class EnemyPlanner : Form
    {
        private string select;
        public EnemyPlanner()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new object[] { "Item1", "Item2", "Item3" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Listbox update based on combobox selected value and create button
            listBox1.BeginUpdate();
            if (this.select != null)
                listBox1.Items.Add(this.select);
            label2.Text = this.select;
            listBox1.EndUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = listBox1.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.select = comboBox1.SelectedItem.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete button
            listBox1.BeginUpdate();
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
            listBox1.EndUpdate();
        }
    }
}
