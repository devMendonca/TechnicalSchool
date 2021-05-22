using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnicalSchool.Models
{
    public class Curso
    {
        /* esse atributo permite que você insira a chave 
         * primária do curso, em vez de fazer com que ela 
         * seja gerada pelo banco de dados */
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
    }
}