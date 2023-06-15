namespace GraphSolution.RailComponents.RailSwitches
{
	public class BasicSwitch : RailSwitch
	{
		public BasicSwitch(RailVertex[] vertices) : base(vertices)
		{
		}

		public override bool IsValid(RailVertex comingFrom, RailVertex trainIs, RailVertex goingTo)
		{
			if (railVertices[0] == trainIs && railVertices[1] == comingFrom && railVertices[2] == goingTo)
				return false;
			else if (railVertices[0] == trainIs && railVertices[2] == comingFrom && railVertices[1] == goingTo)
				return false;
			return true;
		}
	}
}
