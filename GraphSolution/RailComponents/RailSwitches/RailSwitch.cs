namespace GraphSolution.RailComponents.RailSwitches
{
	public abstract class RailSwitch
	{

		// Switch position of vertex static by :
		// https://prnt.sc/k9XEsRYDGG3y
		public RailVertex[] railVertices { get; set; }

		public RailSwitch(RailVertex[] vertices) { 
			railVertices = vertices;
		}
		public abstract bool IsValid(RailVertex comingFrom, RailVertex trainIs, RailVertex goingTo);
		
		public int PartOfSwitch(RailVertex vertex)
		{
			
			for (int i = 0; i < railVertices.Length; i++)
			{
				if(railVertices[i].Equals(vertex))
				{
					return i;
				}
			}
			throw new Exception("This vertex is not a part of this Switch");
		}
	}
}
