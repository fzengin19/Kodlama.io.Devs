using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class GetProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public DateTime DevelopmentDate { get; set; }
    }
}
