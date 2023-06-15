namespace GraphSolution.RailComponents
{
	public enum ObstaclePositionPoint
	{
		NOT_FROM_ORIGIN,
		FROM_ORIGIN
		
	}
	public class RailObstacle
	{
		public int ID { get; set; }
		public double Length { get; set; }
		public ObstaclePositionPoint RailObstaclePosition { get; set; }
		public double DistanceFromPositionPoint { get; set; }
		public bool isFinish { get; init; }

		public override bool Equals(object? obj)
		{
			if(obj == null) return false;
			RailObstacle ro = obj as RailObstacle;
			if(ro == null) return false;

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string? ToString()
		{
			string s = $"ID: {ID}, Length: {Length}";
			if (isFinish)
			{
				s += " - Finish";
			}
			return s;
		}
	}
}
