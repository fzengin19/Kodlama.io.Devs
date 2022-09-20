using Domain.Entities;


namespace Application.Features.ProgrammingLanguageDevelopers.Dtos
{
    public class CreatedProgrammingLanguageDeveloperDto
    {
        public int Id { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public Developer Developer { get; set; }
    }
}
