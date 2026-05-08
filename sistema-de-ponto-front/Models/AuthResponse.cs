using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_de_ponto_front.Models
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;

        public string TokenType { get; set; } = string.Empty;

        public UserProfile User { get; set; } = new();
    }
}
