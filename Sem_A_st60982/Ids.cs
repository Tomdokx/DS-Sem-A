using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_A_st60982
{
	internal static class Ids
	{
		private static int _path_id = 1;
		public static int Path_ID { get { return _path_id++; } }

		private static int _obstacle_id = 1;
		public static int Obstacle_ID { get { return _obstacle_id++; } }

		public static void ResetCounters()
		{
			_path_id = 1;
			_obstacle_id = 1;
		}
	}
}
