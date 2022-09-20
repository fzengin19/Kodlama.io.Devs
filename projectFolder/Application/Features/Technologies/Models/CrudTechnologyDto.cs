using Domain.Entities;


namespace Application.Features.Technologies.Models
{
    public class CrudTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
