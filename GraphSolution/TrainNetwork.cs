using GraphSolution.RailComponents;

namespace GraphSolution
{
	public class TrainNetwork
	{
		public GraphADT<RailVertex, RailPath>? Network { get; set; }

		public PriorityQueue<Train, double> PriorityQueue { get; set; } = new PriorityQueue<Train, double>();


		public string? Dijkstra(Train firstTrain)
		{
			PriorityQueue.Clear();
			Network.GetVertex(firstTrain.LastVisitedVertex).Value = 0;
			Network.GetVertex(firstTrain.CurrentVertex).Value = 0;
			if (Network is null)
			{
				throw new Exception("Cannot execute Dijkstra algorithm without rail network (graph)");
			}
			PriorityQueue.Enqueue(firstTrain, 0);
			while (PriorityQueue.Count > 0)
			{
				Train train = PriorityQueue.Dequeue();
				if (Network.VertexExistsInGraph(train.CurrentVertex))
				{

					List<RailPath> possiblePaths = Network.GetNextEdges(train.CurrentVertex, train.RailTheTrainIsOn);
					foreach (RailPath path in possiblePaths)
					{
						Train tToMove = new Train(train);
						Tuple<RailVertex, RailVertex> verticies = Network.GetVertexesOfEdge(path);
						var v1 = verticies.Item1;
						var v2 = verticies.Item2;
						if (!path.isFinish)
						{

							bool poss = v1.Equals(tToMove.CurrentVertex) ? tToMove.CheckValidity(v2, path) : tToMove.CheckValidity(v1, path);
							if (poss)
							{
								if (v1.Equals(tToMove.CurrentVertex))
									tToMove.moveTrain(v2, path);
								else
									tToMove.moveTrain(v1, path);
								if (Network.GetVertex(tToMove.CurrentVertex).Value >= Network.GetVertex(tToMove.LastVisitedVertex).Value + tToMove.RailTheTrainIsOn.Length)
								{
									Network.GetVertex(tToMove.CurrentVertex).Value = Network.GetVertex(tToMove.LastVisitedVertex).Value + tToMove.RailTheTrainIsOn.Length;
									Train t = new Train(tToMove);

									PriorityQueue.Enqueue(t, Network.GetVertex(t.CurrentVertex).Value);
								}

							}
							else
							{
								if (tToMove.CurrentVertex.SwitchVertex != null && path.CheckObstacles())
								{
									List<RailVertex> visited = new List<RailVertex> { tToMove.LastVisitedVertex };
									List<RailVertex> result = new List<RailVertex>();

									result = DepthFirstSearch(path, tToMove.CurrentVertex, visited, result, tToMove.TrainLenght);
									if (result != null)
									{
										result.ForEach(e => tToMove.PathTheTrainWentBy += $" (back){e.ID} ->");
										if (v1.Equals(tToMove.CurrentVertex))
											tToMove.moveTrain(v2, path);
										else
											tToMove.moveTrain(v1, path);
										if (Network.GetVertex(tToMove.CurrentVertex).Value >= Network.GetVertex(tToMove.LastVisitedVertex).Value + tToMove.RailTheTrainIsOn.Length + tToMove.TrainLenght)
										{
											Network.GetVertex(tToMove.CurrentVertex).Value = Network.GetVertex(tToMove.LastVisitedVertex).Value + tToMove.RailTheTrainIsOn.Length + tToMove.TrainLenght;
											Train t = new Train(tToMove);

											PriorityQueue.Enqueue(t, Network.GetVertex(t.CurrentVertex).Value);
										}
									}

								}
							}
						}
						else
						{
							var secVertex = v1.Equals(train.CurrentVertex) ? v2 : v1;
							if (path.CanFinish(train, secVertex))
								return train.PathTheTrainWentBy;
						}
					}
				}
			}
			return null;
		}

		private List<RailVertex>? DepthFirstSearch(RailPath bannedPath, RailVertex actual, List<RailVertex> visited, List<RailVertex> result, double restLength)
		{
			visited.Add(actual);

			if (restLength <= 0)
			{
				return result;
			}

			List<RailPath> possEdges = Network.GetPossibleEdges(actual);

			List<RailVertex> vertexes = new List<RailVertex>();

			possEdges.ForEach(p => vertexes.Add(Network.GetOtherVertex(p, actual)));

			foreach (RailVertex rv in vertexes)
			{
				RailPath edge = Network.GetEdge(rv, actual);
				if (edge.CheckObstacles())
				{
					if (!visited.Contains(rv) && edge != bannedPath)
					{
						result.Add(rv);
						return DepthFirstSearch(bannedPath, rv, visited, result, restLength - edge.Length);
					}
				}
				else
				{
					if (edge.GetRestLengthFromObsticles(actual) > restLength)
					{
						result.Add(rv);
						return result;
					}
					return null;
				}

			}
			return null;
		}
	}
}
