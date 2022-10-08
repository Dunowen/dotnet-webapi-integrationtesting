namespace SimpleWebApp.Domain.Entities
{
	public class User
	{
		public User(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public int Age { get; private set; }
	}
}
