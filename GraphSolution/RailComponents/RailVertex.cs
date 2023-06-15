using GraphSolution.RailComponents.RailSwitches;

namespace GraphSolution.RailComponents
{

	public class RailVertex
	{
		public int ID { get; set; }
		public RailSwitch? SwitchVertex { get; set; }
		public double Value { get; set; } = double.MaxValue;
		public override bool Equals(object? obj)
		{
			if (obj == null) return false;
			RailVertex? v = obj as RailVertex;
			if(v == null) return false;
			return v.ID == ID;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(ID, SwitchVertex, Value);
		}

		public override string? ToString()
		{
			return $"ID: {ID}";
		}
	}
}
