namespace WebApplicationApi.Models
{
    public class Actors
    {
        public Films Films { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool AcademicWinner { get; set; }
    }
}
