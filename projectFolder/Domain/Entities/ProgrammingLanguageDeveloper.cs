using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguageDeveloper : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public int DeveloperId { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
        public virtual Developer Developer { get; set; }
        public ProgrammingLanguageDeveloper()
        {

        }
        public ProgrammingLanguageDeveloper(int id, int programmingLanguageId, int developerId):base(id)
        {
            ProgrammingLanguageId = programmingLanguageId;
            DeveloperId = developerId;
        }
    }
}
