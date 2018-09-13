using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioIClips.Models
{
    public class Person
    {
        public String Nome { get; set; }
        public String Email { get; set; }
        //0 = em andamento 1 = atrasado
        public EnumSituacao Situacao { get; set; }
    }
}