﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Miembro : Usuario
    {
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;
        private Boolean _bloqueado;
        private List<Miembro> _amigos = new List<Miembro>();
        private List<Solicitud> _solicitudes = new List<Solicitud>();

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public DateTime FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public Boolean Bloqueado { get { return _bloqueado;  } set {  _bloqueado = value; } }
        public List<Miembro> GetAmigos() {  return _amigos; }
        public void AddAmigo(Miembro unAmigo) { _amigos.Add(unAmigo); }
        public List<Solicitud> GetSolicitudes() { return _solicitudes; }
        public void AddSolicitud(Solicitud unaSolicitud) { _solicitudes.Add(unaSolicitud); }
        public Miembro(string email, string password, string nombre, string apellido, DateTime fechaNacimiento)
        {
            this.Email = email;
            this.Password = password;
            this._nombre = nombre;
            this._apellido = apellido;
            this._fechaNacimiento = fechaNacimiento;
            this._bloqueado = false;
            this._amigos = new List<Miembro>();
            this._solicitudes = new List<Solicitud>();
        }
        public Miembro(){ }

        public Boolean ValidarNomYapellido(string nombre, string apellido) // Valida que el nombre y apellido no sean vacíos.
        {
            Boolean resultado = false;
            bool tieneNum = false;
            if (nombre != "" && apellido != "")
            {
                string numeros = "1234567890";
                for (int i = 0; i < numeros.Length; i++)
                {
                    string numero = numeros.Substring(i, 1);
                    if(nombre.Contains(numero)) tieneNum = true;
                    if(apellido.Contains(numero)) tieneNum = true;
                }
                if(!tieneNum) resultado=true;
            }
            return resultado;
        }
        public Boolean EsAmigo(Miembro miembro)
        {
            Boolean resultado = false;
            foreach(Miembro amigo in this._amigos)
            {
                if (amigo == miembro) resultado = true;
            }
            return resultado;
        }
        public Boolean ValidarSolicitud(Solicitud solicitud)
        {
            Boolean resultado = false;
            foreach(Solicitud similar in _solicitudes)
            {
                if(similar.Emisor == solicitud.Emisor && similar.EstadoSolicitud == Invitacion.PENDIENTE_APROBACION) resultado = true;
            }
            return resultado;
        }
    }
}

