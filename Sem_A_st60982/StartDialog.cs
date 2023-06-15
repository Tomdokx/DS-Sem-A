using GraphSolution.RailComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem_A_st60982
{
	public partial class StartDialog : Form
	{
		public StartDialog()
		{
			InitializeComponent();
			comboBox1.DataSource = RailList.RailVertexList;
			comboBox2.DataSource = RailList.RailPathList;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RailVertex rv = comboBox1.SelectedItem as RailVertex;
			RailPath rp = comboBox2.SelectedItem as RailPath;
			if(double.TryParse(textBox1.Text,out double length))
				train = new Train() { CurrentVertex = rv, RailTheTrainIsOn = rp, TrainLenght= length };
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
