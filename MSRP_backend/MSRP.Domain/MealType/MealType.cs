namespace MSRP.Domain.MealType
{
	public class MealType(int id, string name)
	{
		public int Id { get; set; } = id;
		public string Name { get; set; } = name;
	}
}
