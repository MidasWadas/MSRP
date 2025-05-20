namespace MSRP.Domain.Entities.CuisineOption
{
	public class CuisineOption(int id, string name, string description)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
		public string Description { get; set; } = description;
	}
}
