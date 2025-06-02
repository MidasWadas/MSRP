namespace MSRP.Domain.Cuisine
{
	public class Cuisine(int id, string name, string description)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
		public string Description { get; set; } = description;
	}
}
