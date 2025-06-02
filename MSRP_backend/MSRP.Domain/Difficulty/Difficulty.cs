namespace MSRP.Domain.Difficulty
{
	public class Difficulty(int id, string name)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
	}
}
