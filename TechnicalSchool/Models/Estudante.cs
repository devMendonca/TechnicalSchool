using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalSchool.Models
{

    public class Estudante
    {
      
        public int ID { get; set; }
        public string Sobrenome { get; set; }
        public string Nome { get; set; }
        public DateTime DataInscricao { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
    }
}