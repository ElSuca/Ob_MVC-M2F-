using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public abstract class Usuario
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Boolean ValidarPassword(string password) // Revisa que tenga mayusculas, minusculas y que sea mayor o igual a 8 caracteres.
        {
            Boolean resultado = false;
            Boolean tieneMayus = false;
            Boolean tieneMinus = false;
            Boolean tieneNum = false;
            string mayus = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string minus = "abcdefghijklnmopqrstuvwxyz";
            string numeros = "1234567890";
            if (password.Length >= 8)
            {
                for (int i = 0; i < mayus.Length; i++)
                {
                    string letra = mayus.Substring(i, 1);
                    if (password.Contains(letra)) tieneMayus = true;
                }
                for (int i = 0; i < minus.Length; i++)
                {
                    string letra = minus.Substring(i, 1);
                    if (password.Contains(letra)) tieneMinus = true;
                }
                for (int i = 0; i < numeros.Length; i++)
                {
                    string numero = numeros.Substring(i, 1);
                    if (password.Contains(numero)) tieneNum = true;
                }
                if (tieneMayus && tieneMinus && tieneNum) resultado = true;
            }
            return resultado;
        }
    }
    
}
