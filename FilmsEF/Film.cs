using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsEF
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Director { get; set; }
        public DateTime Modified { get; set; }
    }
}
