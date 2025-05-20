namespace MSRP.Domain.Entities.DifficultyOption
{
	public class DifficultyOption(int id, string name)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
	}
}
