using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguage :Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public DateTime DevelopmentDate { get; set; }
        public ProgrammingLanguage()
        {
                
        }
        public ProgrammingLanguage(int ıd, string name, DateTime developmentDate, string developer)
        {
            Id = ıd;
            Name = name;
            DevelopmentDate = developmentDate;
            Developer = developer;
        }


    }
}
