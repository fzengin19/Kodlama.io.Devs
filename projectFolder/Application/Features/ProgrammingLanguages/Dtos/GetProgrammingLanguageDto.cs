

using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class GetProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Developer Developer { get; set; }
        public DateTime DevelopmentDate { get; set; }
    }
}
