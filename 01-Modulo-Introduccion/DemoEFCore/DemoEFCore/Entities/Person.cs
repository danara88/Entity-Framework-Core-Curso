namespace DemoEFCore.Entities
{
    /// <summary>
    /// Person Entity.
    /// This will represent a table in the database.
    /// </summary>
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
