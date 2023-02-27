namespace Shared.Core.DataTransferObject.Identity.RoleController
{
	public record RoleDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public RoleDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
