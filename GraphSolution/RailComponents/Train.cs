namespace GraphSolution.RailComponents
{
	public class Train
	{
		public double TrainLenght { get; set; }
		public RailVertex? LastVisitedVertex { get; set; }
		public RailVertex CurrentVertex { get; set; }
		public RailPath RailTheTrainIsOn { get; set; }

		public List<RailVertex> WentBy { get; set; } = new List<RailVertex>();

		public string PathTheTrainWentBy { get; set; } = string.Empty;
		public Train()
		{

		}
		public Train(Train origin)
		{
			TrainLenght = origin.TrainLenght;
			LastVisitedVertex = origin.LastVisitedVertex;
			CurrentVertex = origin.CurrentVertex;
			RailTheTrainIsOn = origin.RailTheTrainIsOn;
			WentBy = origin.WentBy.ToList();
			PathTheTrainWentBy = origin.PathTheTrainWentBy.ToString();
		}
		public void moveTrain(RailVertex vertexToGo, RailPath railPathToGo)
		{
				LastVisitedVertex = CurrentVertex;
				CurrentVertex = vertexToGo;
				RailTheTrainIsOn = railPathToGo;
				WentBy.Add(vertexToGo);
				PathTheTrainWentBy += $" {vertexToGo.ID} ->";
		} 
		public bool CheckValidity(RailVertex railVertexToGo, RailPath railPathToGo)
		{
			if (!railPathToGo.CheckObstacles()) return false;
			if(railVertexToGo.SwitchVertex != null)
				return railVertexToGo.SwitchVertex.IsValid(LastVisitedVertex, CurrentVertex, railVertexToGo);
			return true;
		}


	}
}
