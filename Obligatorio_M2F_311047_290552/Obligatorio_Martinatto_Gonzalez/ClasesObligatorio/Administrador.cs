using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Administrador : Usuario
    {
        public Administrador(string email, string password) 
        {
            Email = email;
            Password = password;
        }
    }
}
