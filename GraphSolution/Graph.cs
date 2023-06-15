using System.Linq;

namespace GraphSolution
{
	public class GraphADT<T, I>
	{
		private class Vertex<T>
		{
			public T Data { get; set; }
			public List<Edge<I,T>> Edges { get; set; } = new List<Edge<I, T>>();

			public Vertex(T data)
			{
				Data = data;
			}
		}
		private class Edge<I,T>
		{
			public I Data { get; set; }

			public Vertex<T>[] Vertexes { get; } = new Vertex<T>[2];

			public Edge(I data, Vertex<T> vertex1, Vertex<T> vertex2)
			{
				Data = data;
				Vertexes[0] = vertex1;
				Vertexes[1] = vertex2;
			}
		}

		private List<Edge<I,T>> Edges { get; set; } = new List<Edge<I,T>>();
		public int EdgeCount { get { return Edges.Count; } }
		public int VertexCount { get; private set; }
		public void AddEdge(I Data,T DataVertex1, T DataVertex2)
		{
			if(EdgeExistsInGraph(Data))
				throw new Exception("This edge is already in the graph");

			Vertex<T>? v1, v2;
			v1 = VertexExistsInGraph(DataVertex1) ? 
				GetVertexFromGraph(DataVertex1) : CreateNewVertex(DataVertex1);
			v2 = VertexExistsInGraph(DataVertex2) ?
				GetVertexFromGraph(DataVertex2) : CreateNewVertex(DataVertex2);

			if(v1 == null && v2 == null) 
				throw new Exception("Something went wrong..");

			var edge = new Edge<I,T>(Data, v1, v2);
			v1.Edges.Add(edge);
			v2.Edges.Add(edge);
			Edges.Add(edge);
		}

		private Vertex<T> CreateNewVertex(T dataVertex)
		{
			VertexCount++;
			return new Vertex<T>(dataVertex);
		}

		public I RemoveEdge(I data)
		{
			if (!EdgeExistsInGraph(data))
				throw new Exception("Edge does not exists.");
			
			var edgeToRemove = Edges.First(p => p.Data.Equals(data));
			edgeToRemove.Vertexes[0].Edges.Remove(edgeToRemove);
			edgeToRemove.Vertexes[1].Edges.Remove(edgeToRemove);
			Edges.Remove(edgeToRemove);
			
			return edgeToRemove.Data;
		}
		public Tuple<T,T> GetVertexesOfEdge(I data)
		{
			if (!Edges.Exists(p => p.Data.Equals(data)))
				throw new Exception("This Edge does not exists in this graph");
			var edge = Edges.First(e => e.Data.Equals(data));

			return Tuple.Create(edge.Vertexes[0].Data, edge.Vertexes[1].Data);
		}
		public List<I> GetNextEdges(T vertex, I originEdge)
		{
			List<I> l = new List<I>();
			var v = GetVertexFromGraph(vertex);
			foreach(var edge in v.Edges)
			{
				if (!edge.Data.Equals(originEdge))
					l.Add(edge.Data);
			}
			return l;
		}
		public List<I> GetPossibleEdges(T data)
		{
			if (!VertexExistsInGraph(data))
				throw new Exception("This Vertex does not exists in this graph");
			Vertex<T> v = GetVertexFromGraph(data);
			List<I> list = new List<I>();
			foreach(Edge<I,T> e in v.Edges)
				list.Add(e.Data);
			
			return list;
		}
		public bool VertexExistsInGraph(T dataVertex1)
		{
			foreach(var e in Edges)
			{
				if (e.Vertexes[0].Data.Equals(dataVertex1)) return true;
				if (e.Vertexes[1].Data.Equals(dataVertex1)) return true;
			}
			return false;
		}
		public bool EdgeExistsInGraph(I dataEdge)
		{
			return Edges.Exists(p => p.Data.Equals(dataEdge));
		}
		public I GetEdge(I edgeData)
		{
			return Edges.First(p => p.Data.Equals(edgeData)).Data;
		}
		public T GetVertex(T vertexData)
		{
			return GetVertexFromGraph(vertexData)!.Data;
		}
		public T GetOtherVertex(I edgeData, T vertexData)
		{
			var vertexes = GetVertexesOfEdge(edgeData);
			T v = vertexes.Item1.Equals(vertexData) ? vertexes.Item2 : vertexes.Item1;
			return v;
		}

		public List<I> GetAllEdges()
		{
			return Edges.Select(e => e.Data).ToList();
		}
		public List<T> GetAllVertexes()
		{
			List<T> vertexes = new List<T>();
			Edges.ForEach(e => { e.Vertexes.ToList<Vertex<T>>().ForEach(v => vertexes.Add(v.Data)); });
			return vertexes.Distinct().ToList();
		}
		public I GetEdge(T vertex1, T vertex2)
		{
			Vertex<T>? v1 = GetVertexFromGraph(vertex1);
			Vertex<T>? v2 = GetVertexFromGraph(vertex2);
			if(v1 == null || v2 == null)
			{
				throw new Exception("At least one vertex does not exist in graph.");
			}
			return Edges.First(p => p.Vertexes.ToList().Contains(v1) && p.Vertexes.ToList().Contains(v2)).Data;
		}
		private Vertex<T>? GetVertexFromGraph(T data)
		{
			foreach (var e in Edges)
			{
				if (e.Vertexes[0].Data.Equals(data)) return e.Vertexes[0];
				if (e.Vertexes[1].Data.Equals(data)) return e.Vertexes[1];
			}
			return null;
		}
	}
}