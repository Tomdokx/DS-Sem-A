using GraphSolution;
using GraphSolution.RailComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem_A_st60982
{
	public partial class FinishDialog : Form
	{
		public FinishDialog(TrainNetwork network)
		{
			InitializeComponent();
			trainNetwork = network;
			comboBox1.DataSource = RailList.RailPathList;
		}


		private void button1_Click(object sender, EventArgs e)
		{
			rp = trainNetwork.Network.GetEdge(comboBox1.SelectedItem as RailPath);
			ObstaclePositionPoint point = radioButton1.Checked ? ObstaclePositionPoint.FROM_ORIGIN : ObstaclePositionPoint.NOT_FROM_ORIGIN;
			if (double.TryParse(textBox1.Text,out double length)&&double.TryParse(textBox2.Text,out double distance)) {
				RailObstacle finish = new RailObstacle() 
				{ 
				Length = length,
				RailObstaclePosition= point,
				DistanceFromPositionPoint= distance,
				isFinish=true
				};
				rp.Obstacles.Add(finish);
				rp.isFinish = true;

				finishObstacle = finish;
				
			}

			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
