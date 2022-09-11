using Core.Persistence.Repositories;


namespace Domain.Entities
{
    public class ProgrammingLanguage :Entity
    {
        public string Name { get; set; }
        public DateTime DevelopmentDate { get; set; }
        public virtual List<Technology>? Technologies { get; set; }
        public ProgrammingLanguage()
        {
                
        }
        public ProgrammingLanguage(int id, string name, DateTime developmentDate):this()
        {
            Id = id;
            Name = name;
            DevelopmentDate = developmentDate;
        }


    }
}
