using GraphSolution.RailComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_A_st60982
{
	public static class RailList
	{
		public static List<RailVertex> RailVertexList { get; set; } = new List<RailVertex>();
		public static List<RailPath> RailPathList { get; set;} = new List<RailPath>();
		public static List<RailObstacle> RailObstacleList { get; set; } = new List<RailObstacle>();

		public static void Clear()
		{
			RailVertexList.Clear();
			RailPathList.Clear();
			RailObstacleList.Clear();
		}
	}
}
