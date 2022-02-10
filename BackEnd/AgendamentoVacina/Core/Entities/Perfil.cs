using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}