using GraphSolution;
using GraphSolution.RailComponents;
using GraphSolution.RailComponents.RailSwitches;
using System.IO;

namespace Sem_A_st60982
{
	internal class Parser
	{
		public GraphADT<RailVertex, RailPath> graph { get; set; } = new GraphADT<RailVertex, RailPath> { };
		public string ToParse { get; set; } = string.Empty;
		public RailPath? FinishPath { get; set; }
		public Train StartTrain { get; set; }

		public void StartParsing()
		{
			graph = new GraphADT<RailVertex, RailPath>();
			ClearLists();
			string edges = ToParse.Split("---")[0];
			HandleEdges(edges);
			string obstacles = ToParse.Split("---")[1];
			HandleObsticles(obstacles);
			string switches = ToParse.Split("---")[2];
			// by https://prnt.sc/pgb2iDRkQyUQ
			HandleSwitches(switches);
			string restInformation = ToParse.Split("---")[3];
			HandleRest(restInformation);
			LoadToLists();
		}

		private void ClearLists()
		{
			RailList.Clear();
		}

		private void LoadToLists()
		{
			RailList.RailPathList = graph.GetAllEdges();
			RailList.RailVertexList = graph.GetAllVertexes();
			foreach (RailPath rp in RailList.RailPathList)
			{
				if(rp.Obstacles.Count>0)
				{
					rp.Obstacles.ForEach(p => RailList.RailObstacleList.Add(p));
				}
			}
		}

		private void HandleRest(string restInformationString)
		{
			string[] restInfo = restInformationString.Trim().Split("\n");
			if (restInfo[0].ToLower().StartsWith("start") && restInfo[1].ToLower().StartsWith("finish"))
			{
				string[] start = restInfo[0].Trim().Split(",");
				if (int.TryParse(start[1], out int startVertex) && double.TryParse(start[2],out double lengthOfTrain)
					&& int.TryParse(start[3], out int railPath))
				{
					RailVertex rv = graph.GetVertex(new RailVertex { ID = startVertex });
					RailPath rp = graph.GetEdge(new RailPath { ID = railPath });
					RailVertex lastV = graph.GetOtherVertex(rp, rv);
					StartTrain = new Train() { CurrentVertex = rv, TrainLenght = lengthOfTrain, RailTheTrainIsOn = rp, LastVisitedVertex = lastV};
				}
				else
				{
					throw new Exception("Parsing start -> some information is not valid.");
				}
				string[] finish = restInfo[1].Trim().Split(",");
				if (int.TryParse(finish[1], out int finishPath) && double.TryParse(finish[2], out double finishLength)
					&& double.TryParse(finish[3], out double distanceFromOrigin))
				{

					RailObstacle finishObstacle = new RailObstacle 
					{
						isFinish = true,
						Length = finishLength,
						RailObstaclePosition = ObstaclePositionPoint.FROM_ORIGIN,
						DistanceFromPositionPoint = distanceFromOrigin 
					};
					RailPath rp = graph.GetEdge(new RailPath { ID = finishPath });
					rp.isFinish = true;
					rp.Obstacles.Add(finishObstacle);
					FinishPath = rp;
				}
				else
				{
					throw new Exception("Parsing finish -> some information is not valid.");
				}
			}
			else
			{
				throw new Exception("Parsing menu -> start or finish missing.");
			}
		}
		private void HandleSwitches(string switchesString)
		{
			string[] switches = switchesString.Trim().Split("\n");
			foreach(string s in switches)
			{
				if (string.IsNullOrEmpty(s)) continue;
				string[] switchInfo = s.Trim().Split(",");
				
				switch (switchInfo[0])
				{
					case "basic":
						HandleBasicSwitch(switchInfo);
						break;
					case "single":
						HandleSingleSwitch(switchInfo);
						break;
					case "double":
						HandleDoubleSwitch(switchInfo);
						break;
					case "cross":
						HandleCrossSwitch(switchInfo);
						break;
					default: break;
				}
			}
		}

		private void HandleCrossSwitch(string[] switchInfo)
		{
			if (int.TryParse(switchInfo[1], out int v0ID) && int.TryParse(switchInfo[2], out int v1ID) &&
				int.TryParse(switchInfo[3], out int v2ID) && int.TryParse(switchInfo[4], out int v3ID) &&
				int.TryParse(switchInfo[5], out int v4ID) && double.TryParse(switchInfo[6], out double length))
			{
				RailVertex v0 = graph.GetVertex(new RailVertex { ID = v0ID });
				RailVertex v1 = graph.GetVertex(new RailVertex { ID = v1ID });
				RailVertex v2 = graph.GetVertex(new RailVertex { ID = v2ID });
				RailVertex v3 = graph.GetVertex(new RailVertex { ID = v3ID });
				RailVertex v4 = graph.GetVertex(new RailVertex { ID = v4ID });
				RailVertex[] vertexes = new RailVertex[] { v0, v1, v3, v4 };
				RailSwitch rs = new DoubleSlipSwitch(vertexes);

				v0.SwitchVertex = rs;
				v1.SwitchVertex = rs;
				v3.SwitchVertex = rs;
				v4.SwitchVertex = rs;

				List<RailPath> paths = graph.GetPossibleEdges(v2);
				var path02 = paths.First(p => graph.GetOtherVertex(p, v2) == v0);
				var path24 = paths.First(p => graph.GetOtherVertex(p, v2) == v4);
				var path12 = paths.First(p => graph.GetOtherVertex(p, v2) == v1);
				var path23 = paths.First(p => graph.GetOtherVertex(p, v2) == v3);

				RailPath rp = new RailPath
				{
					ID = path02.ID,
					Length = path24.Length + path02.Length,
					DistanceOfCrossingFromOrigin = path02.Length,
					Obstacles = path02.Obstacles.Union(path12.Obstacles).ToList(),
					OriginVertex = v0
				};
				RailPath rp2 = new RailPath
				{
					ID = path23.ID,
					Length = path12.Length + path23.Length,
					DistanceOfCrossingFromOrigin = path12.Length,
					Obstacles = path12.Obstacles.Union(path12.Obstacles).ToList(),
					OriginVertex = v1,
					CrossedBy = rp
				};
				rp.CrossedBy = rp2;
				
				graph.RemoveEdge(path02);
				graph.RemoveEdge(path12);
				graph.RemoveEdge(path23);
				graph.RemoveEdge(path24);
				graph.AddEdge(rp, v0, v4);
				graph.AddEdge(rp2, v1, v3);

			}
			else
			{
				throw new Exception("Couldn't parse some switch informations.");
			}
		}

		private void HandleDoubleSwitch(string[] switchInfo)
		{
			if (int.TryParse(switchInfo[1], out int v0ID) && int.TryParse(switchInfo[2], out int v1ID) &&
				int.TryParse(switchInfo[3], out int v2ID) && int.TryParse(switchInfo[4], out int v3ID) &&
				int.TryParse(switchInfo[5], out int v4ID) && double.TryParse(switchInfo[6], out double length))
			{
				RailVertex v0 = graph.GetVertex(new RailVertex { ID = v0ID });
				RailVertex v1 = graph.GetVertex(new RailVertex { ID = v1ID });
				RailVertex v2 = graph.GetVertex(new RailVertex { ID = v2ID });
				RailVertex v3 = graph.GetVertex(new RailVertex { ID = v3ID });
				RailVertex v4 = graph.GetVertex(new RailVertex { ID = v4ID });
				RailVertex[] vertexes = new RailVertex[] { v0, v1, v3, v4 };
				RailSwitch rs = new DoubleSlipSwitch(vertexes);

				v0.SwitchVertex = rs;
				v1.SwitchVertex = rs;
				v3.SwitchVertex = rs;
				v4.SwitchVertex = rs;

				List<RailPath> paths = graph.GetPossibleEdges(v2);
				var path02 = paths.First(p => graph.GetOtherVertex(p, v2) == v0);
				var path24 = paths.First(p => graph.GetOtherVertex(p, v2) == v4);
				var path12 = paths.First(p => graph.GetOtherVertex(p, v2) == v1);
				var path23 = paths.First(p => graph.GetOtherVertex(p, v2) == v3);

				RailPath rp = new RailPath
				{
					ID = path02.ID,
					Length = path24.Length + path02.Length,
					DistanceOfCrossingFromOrigin = path02.Length,
					Obstacles = path02.Obstacles.Union(path12.Obstacles).ToList(),
					OriginVertex = v0
				};
				RailPath rp2 = new RailPath
				{
					ID = path23.ID,
					Length = path12.Length + path23.Length,
					DistanceOfCrossingFromOrigin = path12.Length,
					Obstacles = path12.Obstacles.Union(path12.Obstacles).ToList(),
					OriginVertex = v1,
					CrossedBy = rp
				};
				rp.CrossedBy = rp2;
				RailPath rp3 = new RailPath
				{
					ID = path12.ID,
					Length = length,
					OriginVertex = v1,
				};
				RailPath rp4 = new RailPath
				{
					ID = path24.ID,
					Length = length,
					OriginVertex = v0,
				};
				graph.RemoveEdge(path02);
				graph.RemoveEdge(path12);
				graph.RemoveEdge(path23);
				graph.RemoveEdge(path24);
				graph.AddEdge(rp, v0, v4);
				graph.AddEdge(rp2, v1, v3);
				graph.AddEdge(rp3, v1, v4);
				graph.AddEdge(rp4, v0, v3);
			}
			else
			{
				throw new Exception("Couldn't parse some switch informations.");
			}
		}

		private void HandleSingleSwitch(string[] switchInfo)
		{
			if (int.TryParse(switchInfo[1], out int v0ID) && int.TryParse(switchInfo[2], out int v1ID) &&
				int.TryParse(switchInfo[3], out int v2ID) && int.TryParse(switchInfo[4], out int v3ID) &&
				int.TryParse(switchInfo[5], out int v4ID) && double.TryParse(switchInfo[6], out double length))
			{
				RailVertex v0 = graph.GetVertex(new RailVertex { ID = v0ID });
				RailVertex v1 = graph.GetVertex(new RailVertex { ID = v1ID });
				RailVertex v2 = graph.GetVertex(new RailVertex { ID = v2ID });
				RailVertex v3 = graph.GetVertex(new RailVertex { ID = v3ID });
				RailVertex v4 = graph.GetVertex(new RailVertex { ID = v4ID });
				RailVertex[] vertexes = new RailVertex[] { v0, v1, v3, v4 };
				RailSwitch rs = new SingleSlipSwitch(vertexes);

				v0.SwitchVertex = rs;
				v1.SwitchVertex = rs;
				v3.SwitchVertex = rs;
				v4.SwitchVertex = rs;

				List<RailPath> paths = graph.GetPossibleEdges(v2);
				var path02 = paths.First(p => graph.GetOtherVertex(p, v2) == v0);
				var path24 = paths.First(p => graph.GetOtherVertex(p, v2) == v4);
				var path12 = paths.First(p => graph.GetOtherVertex(p, v2) == v1);
				var path23 = paths.First(p => graph.GetOtherVertex(p, v2) == v3);

				RailPath rp = new RailPath
				{
					ID = path02.ID,
					Length = path24.Length + path02.Length,
					DistanceOfCrossingFromOrigin = path02.Length,
					Obstacles = path02.Obstacles.Union(path12.Obstacles).ToList(),
					OriginVertex = v0
				};
				RailPath rp2 = new RailPath
				{
					ID = path23.ID,
					Length = path12.Length + path23.Length,
					DistanceOfCrossingFromOrigin = path12.Length,
					Obstacles = path12.Obstacles.Union(path12.Obstacles).ToList(),
					OriginVertex = v1,
					CrossedBy = rp
				};
				rp.CrossedBy = rp2;
				RailPath rp3 = new RailPath
				{
					ID = path12.ID,
					Length = length,
					OriginVertex = v1,
				};
				graph.RemoveEdge(path02);
				graph.RemoveEdge(path12);
				graph.RemoveEdge(path23);
				graph.RemoveEdge(path24);
				graph.AddEdge(rp, v0, v4);
				graph.AddEdge(rp2, v1, v3);
				graph.AddEdge(rp3, v1, v4);

			}
			else
			{
				throw new Exception("Couldn't parse some switch informations.");
			}
		}

		private void HandleBasicSwitch(string[] switchInfo)
		{
			if (int.TryParse(switchInfo[1], out int v0ID) && int.TryParse(switchInfo[2], out int v1ID) &&
				int.TryParse(switchInfo[3], out int v2ID)) {
				RailVertex v0 = graph.GetVertex(new RailVertex { ID = v0ID });
				RailVertex v1 = graph.GetVertex(new RailVertex { ID = v1ID });
				RailVertex v2 = graph.GetVertex(new RailVertex { ID = v2ID });
				RailVertex[] vertexes = new RailVertex[] { v0, v1, v2 };
				RailSwitch rs = new BasicSwitch(vertexes);
				v0.SwitchVertex = rs;
				v1.SwitchVertex = rs;
				v2.SwitchVertex = rs;
			}
		}

		private void HandleObsticles(string obstaclesString)
		{
			// fromOrigin (true,false), length, distanceFromPoints, RailPathID
			string[] obstacles = obstaclesString.Trim().Split("\n");
			foreach(string obstacle in obstacles)
			{
				if(string.IsNullOrEmpty(obstacle)) continue;
				string[] obstacleInfo = obstacle.Trim().Split(",");
				if (obstacleInfo[0].Equals("0") || obstacleInfo[0].Equals("1"))
				{
					bool fromOrig = obstacleInfo[0] == "1";
					if (double.TryParse(obstacleInfo[1], out double length) && double.TryParse(obstacleInfo[2], out double distanceFromPoint))
					{
						ObstaclePositionPoint positionPoint = fromOrig ? ObstaclePositionPoint.FROM_ORIGIN : ObstaclePositionPoint.NOT_FROM_ORIGIN;
						RailObstacle ro = new RailObstacle
						{
							ID = Ids.Obstacle_ID,
							Length = length,
							RailObstaclePosition = positionPoint,
							DistanceFromPositionPoint = distanceFromPoint
						};
						if (int.TryParse(obstacleInfo[3],out int pathID)){
							if(graph.EdgeExistsInGraph(new RailPath { ID = pathID })){
								graph.GetEdge(new RailPath { ID = pathID}).Obstacles.Add(ro);
							}
							else
							{
								throw new Exception("Parsing Obstacles -> Edge does not exists in graph.");
							}
						}
						else
						{
							throw new Exception("Parsing Obstacles -> PathID is not an int");
						}
					}
					else
					{
						throw new Exception("Parsing Obstacles -> length or distance is not a double.");
					}
					
				}
				else
				{
					throw new Exception("Parsing Obstacles -> From origin cannot be anything except 0 / 1");
				}
				
			}
		}

		public void HandleEdges(string edgesString)
		{
			// originVertex, secondVertex, length
			string[] edges = edgesString.Split("\n");	
			foreach(string edge in edges)
			{
				if(string.IsNullOrEmpty(edge)) continue;
				string[] edgeInfo = edge.Trim().Split(",");
				if (double.TryParse(edgeInfo[2],out double length) && int.TryParse(edgeInfo[0],out int v1) &&
					int.TryParse(edgeInfo[1],out int v2)) {
					RailVertex orv = new RailVertex { ID = v1 };
					RailPath rp = new RailPath { ID = Ids.Path_ID, Length = length, OriginVertex = orv };
					
					graph.AddEdge(rp, orv, new RailVertex { ID = v2});
				}
				else
				{
					throw new Exception("Parsing Edges -> not a number for length or for vertex ids.");
				}
			}
		}
	}
}
