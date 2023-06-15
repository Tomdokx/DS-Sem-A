namespace GraphSolution.RailComponents
{
	public class RailPath
	{
		public int ID { get; set; }
		public RailVertex OriginVertex { get; set; }
		public double Length { get; set; }
		public List<RailObstacle> Obstacles { get; set; } = new List<RailObstacle>();
		public bool isFinish { get; set; } = false;
		public double? DistanceOfFinishFromOrigin { get; }
		public RailPath? CrossedBy { get; set; }
		public double? DistanceOfCrossingFromOrigin { get; set; }

		public bool CheckObstacles()
		{
			//true -> everything is fine
			//false -> bad.
			if (Obstacles.Count > 0)
			{
				return false;
			}
			if (CrossedBy != null)
			{
				if (CrossedBy.Obstacles.Count > 0)
				{
					var x = CrossedBy.DistanceOfCrossingFromOrigin;
					foreach (var obstacle in CrossedBy.Obstacles)
					{
						if (obstacle.RailObstaclePosition == ObstaclePositionPoint.FROM_ORIGIN)
						{
							if (obstacle.DistanceFromPositionPoint < x && obstacle.DistanceFromPositionPoint + obstacle.Length > x) return false;
						}

						if (obstacle.RailObstaclePosition == ObstaclePositionPoint.NOT_FROM_ORIGIN)
						{
							if (CrossedBy.Length - (obstacle.DistanceFromPositionPoint + obstacle.Length) < x && obstacle.Length > x) return false;
						}
					}
				}
			}
			return true;
		}

		public double GetRestLengthFromObsticles(RailVertex backUpVertex)
		{
			double restLength = double.MaxValue;
			foreach (RailObstacle obstacle in Obstacles)
			{
				if (obstacle.RailObstaclePosition == ObstaclePositionPoint.FROM_ORIGIN && backUpVertex.Equals(OriginVertex) ||
					obstacle.RailObstaclePosition == ObstaclePositionPoint.NOT_FROM_ORIGIN && !backUpVertex.Equals(OriginVertex))
				{
					if (restLength > obstacle.DistanceFromPositionPoint)
						restLength = obstacle.DistanceFromPositionPoint;
				}

				if (obstacle.RailObstaclePosition == ObstaclePositionPoint.FROM_ORIGIN && !backUpVertex.Equals(OriginVertex) ||
					obstacle.RailObstaclePosition == ObstaclePositionPoint.NOT_FROM_ORIGIN && backUpVertex.Equals(OriginVertex))
				{
					if (restLength > Length - (obstacle.DistanceFromPositionPoint + obstacle.Length))
					{
						restLength = Length - (obstacle.DistanceFromPositionPoint + obstacle.Length);
					}
				}
			}
			return restLength;
		}

		public override bool Equals(object? obj)
		{
			
			RailPath? r = obj as RailPath;
			if (r != null)
			{
				return r.ID == ID;
			}
			return false;
		}

		public override string? ToString()
		{
			String sb = $"ID: {ID}, Length:{Length} ";
			if(Obstacles.Count > 0)
			{
				foreach (var obstacle in Obstacles)
				{
					sb += ", obs: " + obstacle.ID;

				}
			}
			if (isFinish)
			{
				sb += ", FINISH";
			}
			return sb;
		}

		public bool CanFinish(Train train, RailVertex otherVertex)
		{
			if (CheckObstacles())
			{
				return true;
			}
			if (Obstacles[0].isFinish)
				return true;
			if (train.CurrentVertex == OriginVertex && GetRestLengthFromObsticles(otherVertex) < train.TrainLenght)
				return true;

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(ID, OriginVertex, Length, Obstacles, isFinish, DistanceOfFinishFromOrigin, CrossedBy, DistanceOfCrossingFromOrigin);
		}
	}
}
