using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Dtos
{
    public class DeletedDeveloperDto
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
