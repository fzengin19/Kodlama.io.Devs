using Domain.Entities;


namespace Application.Features.ProgrammingLanguageDevelopers.Dtos
{
    public class DeletedProgrammingLanguageDeveloperDto
    {
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public Developer Developer { get; set; }
    }
}
