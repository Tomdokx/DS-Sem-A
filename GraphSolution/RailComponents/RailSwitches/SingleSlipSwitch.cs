namespace GraphSolution.RailComponents.RailSwitches
{
	public class SingleSlipSwitch : RailSwitch
	{
		public SingleSlipSwitch(RailVertex[] vertices) : base(vertices)
		{
		}

		public override bool IsValid(RailVertex comingFrom, RailVertex trainIs, RailVertex goingTo)
		{
			if (railVertices[3] == trainIs && railVertices[0] == comingFrom && railVertices[1] == goingTo) 
				return false;
			else if (railVertices[3] == trainIs && railVertices[1] == comingFrom && railVertices[0] == goingTo) 
				return false;
			else if (railVertices[1] == trainIs && railVertices[2] == comingFrom && railVertices[3] == goingTo) 
				return false;
			else if (railVertices[1] == trainIs && railVertices[3] == comingFrom && railVertices[2] == goingTo) 
				return false;
			return true;
		}
	}
}
