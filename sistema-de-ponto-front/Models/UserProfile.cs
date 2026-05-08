using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_ponto_front.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}
