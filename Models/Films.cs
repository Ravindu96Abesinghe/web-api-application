namespace WebApplicationApi.Models
{
    public class Films 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int ParentId { get; set; }
        public Details Details { get; set; }
    }
}
