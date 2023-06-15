using GraphSolution;
using GraphSolution.RailComponents;

namespace Sem_A_st60982
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.VertexListBox = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AddEdgeLength = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.AddEdgeV2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.AddEdgeV1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.AddObstacleDistance = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.AddObstacleLength = new System.Windows.Forms.TextBox();
			this.AddObstaclePath = new System.Windows.Forms.ComboBox();
			this.AddObstaclesNotFrom = new System.Windows.Forms.RadioButton();
			this.AddObstacleFrom = new System.Windows.Forms.RadioButton();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.EdgeListBox = new System.Windows.Forms.ListBox();
			this.ObstacleListBox = new System.Windows.Forms.ListBox();
			this.groupOthers = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupOthers.SuspendLayout();
			this.SuspendLayout();
			// 
			// VertexListBox
			// 
			this.VertexListBox.FormattingEnabled = true;
			this.VertexListBox.ItemHeight = 20;
			this.VertexListBox.Location = new System.Drawing.Point(12, 29);
			this.VertexListBox.Name = "VertexListBox";
			this.VertexListBox.Size = new System.Drawing.Size(447, 204);
			this.VertexListBox.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AddEdgeLength);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.AddEdgeV2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.AddEdgeV1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Location = new System.Drawing.Point(477, 251);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(484, 204);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Edges";
			// 
			// AddEdgeLength
			// 
			this.AddEdgeLength.Location = new System.Drawing.Point(330, 60);
			this.AddEdgeLength.Name = "AddEdgeLength";
			this.AddEdgeLength.Size = new System.Drawing.Size(85, 27);
			this.AddEdgeLength.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(266, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Length";
			// 
			// AddEdgeV2
			// 
			this.AddEdgeV2.Location = new System.Drawing.Point(165, 81);
			this.AddEdgeV2.Name = "AddEdgeV2";
			this.AddEdgeV2.Size = new System.Drawing.Size(85, 27);
			this.AddEdgeV2.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(101, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Vertex2";
			// 
			// AddEdgeV1
			// 
			this.AddEdgeV1.Location = new System.Drawing.Point(165, 39);
			this.AddEdgeV1.Name = "AddEdgeV1";
			this.AddEdgeV1.Size = new System.Drawing.Size(85, 27);
			this.AddEdgeV1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(101, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Vertex1";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(283, 147);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(94, 29);
			this.button7.TabIndex = 1;
			this.button7.Text = "Remove";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(101, 147);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(94, 29);
			this.button6.TabIndex = 0;
			this.button6.Text = "Add";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.AddObstacleDistance);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.AddObstacleLength);
			this.groupBox3.Controls.Add(this.AddObstaclePath);
			this.groupBox3.Controls.Add(this.AddObstaclesNotFrom);
			this.groupBox3.Controls.Add(this.AddObstacleFrom);
			this.groupBox3.Controls.Add(this.button10);
			this.groupBox3.Controls.Add(this.button11);
			this.groupBox3.Location = new System.Drawing.Point(477, 468);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(484, 206);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Obstacles";
			// 
			// AddObstacleDistance
			// 
			this.AddObstacleDistance.Location = new System.Drawing.Point(266, 122);
			this.AddObstacleDistance.Name = "AddObstacleDistance";
			this.AddObstacleDistance.Size = new System.Drawing.Size(168, 27);
			this.AddObstacleDistance.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(194, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 20);
			this.label6.TabIndex = 11;
			this.label6.Text = "Distance";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(223, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 20);
			this.label5.TabIndex = 10;
			this.label5.Text = "Path";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(206, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 20);
			this.label4.TabIndex = 9;
			this.label4.Text = "Length";
			// 
			// AddObstacleLength
			// 
			this.AddObstacleLength.Location = new System.Drawing.Point(266, 25);
			this.AddObstacleLength.Name = "AddObstacleLength";
			this.AddObstacleLength.Size = new System.Drawing.Size(168, 27);
			this.AddObstacleLength.TabIndex = 8;
			// 
			// AddObstaclePath
			// 
			this.AddObstaclePath.FormattingEnabled = true;
			this.AddObstaclePath.Location = new System.Drawing.Point(266, 74);
			this.AddObstaclePath.Name = "AddObstaclePath";
			this.AddObstaclePath.Size = new System.Drawing.Size(168, 28);
			this.AddObstaclePath.TabIndex = 7;
			// 
			// AddObstaclesNotFrom
			// 
			this.AddObstaclesNotFrom.AutoSize = true;
			this.AddObstaclesNotFrom.Location = new System.Drawing.Point(23, 97);
			this.AddObstaclesNotFrom.Name = "AddObstaclesNotFrom";
			this.AddObstaclesNotFrom.Size = new System.Drawing.Size(138, 24);
			this.AddObstaclesNotFrom.TabIndex = 6;
			this.AddObstaclesNotFrom.TabStop = true;
			this.AddObstaclesNotFrom.Text = "Not From Origin";
			this.AddObstaclesNotFrom.UseVisualStyleBackColor = true;
			// 
			// AddObstacleFrom
			// 
			this.AddObstacleFrom.AutoSize = true;
			this.AddObstacleFrom.Checked = true;
			this.AddObstacleFrom.Location = new System.Drawing.Point(23, 48);
			this.AddObstacleFrom.Name = "AddObstacleFrom";
			this.AddObstacleFrom.Size = new System.Drawing.Size(109, 24);
			this.AddObstacleFrom.TabIndex = 5;
			this.AddObstacleFrom.TabStop = true;
			this.AddObstacleFrom.Text = "From Origin";
			this.AddObstacleFrom.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(283, 162);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(94, 29);
			this.button10.TabIndex = 4;
			this.button10.Text = "Remove";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(101, 162);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(94, 29);
			this.button11.TabIndex = 3;
			this.button11.Text = "Add";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// EdgeListBox
			// 
			this.EdgeListBox.FormattingEnabled = true;
			this.EdgeListBox.ItemHeight = 20;
			this.EdgeListBox.Location = new System.Drawing.Point(12, 251);
			this.EdgeListBox.Name = "EdgeListBox";
			this.EdgeListBox.Size = new System.Drawing.Size(447, 204);
			this.EdgeListBox.TabIndex = 4;
			// 
			// ObstacleListBox
			// 
			this.ObstacleListBox.FormattingEnabled = true;
			this.ObstacleListBox.ItemHeight = 20;
			this.ObstacleListBox.Location = new System.Drawing.Point(12, 470);
			this.ObstacleListBox.Name = "ObstacleListBox";
			this.ObstacleListBox.Size = new System.Drawing.Size(447, 204);
			this.ObstacleListBox.TabIndex = 5;
			// 
			// groupOthers
			// 
			this.groupOthers.Controls.Add(this.button5);
			this.groupOthers.Controls.Add(this.button1);
			this.groupOthers.Controls.Add(this.button4);
			this.groupOthers.Controls.Add(this.button3);
			this.groupOthers.Controls.Add(this.button2);
			this.groupOthers.Location = new System.Drawing.Point(477, 29);
			this.groupOthers.Name = "groupOthers";
			this.groupOthers.Size = new System.Drawing.Size(484, 204);
			this.groupOthers.TabIndex = 6;
			this.groupOthers.TabStop = false;
			this.groupOthers.Text = "Menu";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(266, 136);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(94, 29);
			this.button5.TabIndex = 5;
			this.button5.Text = "Set Finish";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(125, 136);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 29);
			this.button1.TabIndex = 4;
			this.button1.Text = "Set Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(312, 38);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(132, 60);
			this.button4.TabIndex = 3;
			this.button4.Text = "Reset";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(174, 38);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(132, 60);
			this.button3.TabIndex = 2;
			this.button3.Text = "Find best way";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(43, 38);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(125, 60);
			this.button2.TabIndex = 1;
			this.button2.Text = "Load from File";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(981, 694);
			this.Controls.Add(this.groupOthers);
			this.Controls.Add(this.ObstacleListBox);
			this.Controls.Add(this.EdgeListBox);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.VertexListBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupOthers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ListBox VertexListBox;
		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private ListBox EdgeListBox;
		private ListBox ObstacleListBox;
		private GroupBox groupOthers;
		private Button button7;
		private Button button6;
		private Button button5;
		private Button button1;
		private Button button4;
		private Button button3;
		private Button button2;
		private Button button10;
		private Button button11;


		private Parser parser = new Parser();
		private TrainNetwork network = new TrainNetwork { };
		private Train? startTrain;
		private RailPath? finishPath;
		private TextBox AddEdgeV2;
		private Label label2;
		private TextBox AddEdgeV1;
		private Label label1;
		private TextBox AddEdgeLength;
		private Label label3;
		private TextBox AddObstacleDistance;
		private Label label6;
		private Label label5;
		private Label label4;
		private TextBox AddObstacleLength;
		private ComboBox AddObstaclePath;
		private RadioButton AddObstaclesNotFrom;
		private RadioButton AddObstacleFrom;

		public RailPath FinishPath { get => finishPath; set => finishPath = value; }
		public Train StartTrain { get => startTrain; set => startTrain = value; }
	}
}