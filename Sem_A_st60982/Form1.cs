using GraphSolution;
using GraphSolution.RailComponents;
using Microsoft.VisualBasic.Devices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Sem_A_st60982
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}
		// Load from File
		private void button2_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string fileName = ofd.FileName;
				string fileContents = File.ReadAllText(fileName);
				try
				{
					parser.ToParse = fileContents;
					parser.StartParsing();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				network.Network = parser.graph;
				StartTrain = parser.StartTrain;
				FinishPath = parser.FinishPath;

				RefreshLists();
			}
		}
		// Start Dijkstra
		private void button3_Click(object sender, EventArgs e)
		{
			if (StartTrain != null && FinishPath != null && network.Network != null)
			{
				try
				{
					network.Network.GetAllVertexes().ForEach(x => { x.Value = double.MaxValue; });
					Train Train = new Train(StartTrain);
					string result = network.Dijkstra(Train);

					if (string.IsNullOrEmpty(result))
						MessageBox.Show("Path does not exists or there is any issue.");
					else
					{
						result = "START -> " + result + " END";
						MessageBox.Show(result);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Cannot start the algorithm without start and finish.");
			}
		}
		// Reset
		private void button4_Click(object sender, EventArgs e)
		{
			network = new TrainNetwork();
			StartTrain = null;
			FinishPath = null;
			RailList.RailPathList.Clear();
			RailList.RailVertexList.Clear();
			RailList.RailObstacleList.Clear();
			Ids.ResetCounters();
			RefreshLists();
			parser = new Parser();
		}
		// set start
		private void button1_Click(object sender, EventArgs e)
		{
			StartDialog sd = new StartDialog();
			sd.ShowDialog();
			if (sd.train is not null)
			{
				StartTrain = sd.train;
				StartTrain.LastVisitedVertex = network.Network.GetOtherVertex(StartTrain.RailTheTrainIsOn, StartTrain.CurrentVertex);
			}
		}
		// set finish
		private void button5_Click(object sender, EventArgs e)
		{
			FinishDialog fd = new FinishDialog(network);
			fd.ShowDialog();
			if (fd.rp != null)
			{
				RailPath r = network.Network.GetEdge(finishPath);
				r.isFinish = false;
				RailObstacle toRemove = r.Obstacles.First(p => p.isFinish);
				r.Obstacles.Remove(toRemove);
				RailList.RailObstacleList.Remove(toRemove);
				RefreshEdgeList();
				RailList.RailObstacleList.Add(fd.finishObstacle);
				RefreshObstacleList();
			}
		}

		private void RefreshLists()
		{
			RefreshEdgeList();
			RefreshVertexList();
			RefreshObstacleList();
		}

		private void RefreshObstacleList()
		{
			ObstacleListBox.Items.Clear();
			foreach (RailObstacle ro in RailList.RailObstacleList)
			{

				ObstacleListBox.Items.Add(ro.ToString());
			}
		}

		private void RefreshVertexList()
		{
			VertexListBox.Items.Clear();
			foreach (RailVertex rv in RailList.RailVertexList)
			{

				VertexListBox.Items.Add(rv.ToString());
			}
		}

		private void RefreshEdgeList()
		{
			EdgeListBox.Items.Clear();
			foreach (RailPath rp in RailList.RailPathList)
			{

				EdgeListBox.Items.Add(rp.ToString());
			}
			AddObstaclePath.DataSource = RailList.RailPathList;
		}
		//Add Edge
		private void button6_Click(object sender, EventArgs e)
		{
			if (int.TryParse(AddEdgeV1.Text, out int v1) && int.TryParse(AddEdgeV2.Text, out int v2) &&
				int.TryParse(AddEdgeLength.Text, out int lenght))
			{
				RailPath rp = new RailPath() { ID = Ids.Path_ID, Length = lenght };
				RailVertex rv1 = new RailVertex() { ID = v1, Value = double.MaxValue };
				RailVertex rv2 = new RailVertex() { ID = v2, Value = double.MaxValue };
				network.Network.AddEdge(rp, rv1, rv2);
				RailList.RailPathList.Add(rp);
			}
			RefreshEdgeList();
		}
		//Remove Edge
		private void button7_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(EdgeListBox.SelectedItem as string))
			{
				string rp = EdgeListBox.SelectedItem as string;
				string pathID = rp.Split(",")[0].Trim().Split(":")[1];
				if (int.TryParse(pathID, out int id))
				{
					RailPath rpath = network.Network.RemoveEdge(new RailPath { ID = id });
					RailList.RailPathList.Remove(rpath);
				}
				RefreshEdgeList();
			}

		}
		// Add Obstacle
		private void button11_Click(object sender, EventArgs e)
		{
			ObstaclePositionPoint position = AddObstacleFrom.Checked ? ObstaclePositionPoint.FROM_ORIGIN : ObstaclePositionPoint.NOT_FROM_ORIGIN;
			if (double.TryParse(AddObstacleLength.Text, out double length) && double.TryParse(AddObstacleDistance.Text, out double distance))
			{
				RailObstacle ObstacleToAdd = new RailObstacle { ID = Ids.Obstacle_ID, RailObstaclePosition = position, DistanceFromPositionPoint = distance, Length = length };

				RailPath rp = AddObstaclePath.SelectedItem as RailPath;

				network.Network.GetEdge(rp).Obstacles.Add(ObstacleToAdd);
				RailList.RailObstacleList.Add(ObstacleToAdd);
			}
			RefreshObstacleList();
			RefreshEdgeList();
		}
		// Remove Obstacle
		private void button10_Click(object sender, EventArgs e)
		{
			if (ObstacleListBox.SelectedItems != null)
			{
				string obs = ObstacleListBox.SelectedItem as string;
				string pathID = obs.Split(",")[0].Trim().Split(":")[1];
				if (int.TryParse(pathID, out int id))
				{
					RailPath? thePathWithObstacle = null;
					RailObstacle obsToRemove = new RailObstacle { ID = id };
					
					foreach(RailPath rp in network.Network.GetAllEdges())
					{
						rp.Obstacles.RemoveAll(r => r.ID == id);
					}
					RailList.RailObstacleList.RemoveAll(r => r.ID == id);
				}
				RefreshEdgeList();
				RefreshObstacleList();
			}
		}
	}
}