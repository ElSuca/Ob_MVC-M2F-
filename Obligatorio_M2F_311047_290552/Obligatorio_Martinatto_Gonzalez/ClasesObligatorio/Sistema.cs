using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesObligatorio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private static Usuario s_usuarioLogeado;
        private static Sistema _instancia;
        public static Sistema GetInstancia()
        {
            if (_instancia == null) _instancia = new Sistema();
            return _instancia;
        }
        private void precargaAdmin()
        {
            RegisterAdmin(new Administrador("elAdmin@gmail.com", "laContrasena123"));
        }
        private Sistema() 
        {
            precargaAdmin();
        }
        public Usuario UsuarioLogeado { get { return s_usuarioLogeado; } set { s_usuarioLogeado = value; } }
        public List<Usuario> GetUsuarios() { return _usuarios; }
        public void AddUsuario(Usuario unUsuario) { _usuarios.Add(unUsuario); }
        public List<Publicacion> GetPublicaciones() { return _publicaciones; }
        public void AddPublicacion(Publicacion unaPublicacion) { _publicaciones.Add(unaPublicacion); }
        public Usuario GetUsuario(string email)
        {
            Usuario elUsuario = null;
            foreach (Usuario usuario in _usuarios)
            {
                if(usuario.Email == email)
                {
                    elUsuario = usuario;
                }
            }
            return elUsuario;
        }
        public Boolean RealizarPost(string titulo, string texto, string imagen, char privacidad, DateTime fecha)
        {
            Boolean esPublico;
            Boolean resultado = false;
            Miembro autor = (Miembro)s_usuarioLogeado;
            Post post = new Post();
            if (post.ValidarTitulo(titulo) && post.ValidarContenido(texto))
            {
                if (privacidad == 'S') esPublico = true; // Si es true es publico, de lo contrario false. 
                else esPublico = false;                  // No está implementado en consola pero en el caso de que si, habría un mensaje parecido a lo siguente:
                if (!autor.Bloqueado)                    // Desea que su post sea publico? S - Si | N - No.
                {
                    Post elPost = new Post(titulo, fecha, autor, texto, esPublico, imagen);
                    AddPublicacion(elPost);
                    resultado = true;
                }
            }
            return resultado;
        }
        public Boolean ValidarUsuario(string email) // Valida que el email exista en el sistema.
        {
            Boolean resultado = true;
            if (email != null)
            {
                foreach (Usuario usuario in _usuarios)
                {
                    if (usuario.Email == email) resultado = false;
                }
            }
            return resultado;
        }
        public Boolean RealizarComentario(int idPost, string titulo, string texto)
        {
            Boolean esPublico;
            Boolean resultado = false;
            Publicacion laPublicacion = null;
            Miembro autor = (Miembro)s_usuarioLogeado;
            Comentario comentario = new Comentario();
            DateTime fecha = DateTime.Today;

            if (!autor.Bloqueado)
            {
                foreach (Publicacion unaPublicacion in _publicaciones)
                {
                    if (unaPublicacion is Post && unaPublicacion.Id == idPost) // Se revisa la lista de publicaciones y se chequea que la publicación no solo sea un post, sino que tenga la misma id.
                    {
                        laPublicacion = unaPublicacion;
                    }
                }
                if (comentario.ValidarTitulo(titulo) && comentario.ValidarContenido(texto) && laPublicacion != null)
                {
                    esPublico = laPublicacion.Privacidad; // Si un post es publico, el comentario también lo va a ser.
                    Comentario elComentario = new Comentario(titulo, fecha, autor, texto, esPublico);
                    AddPublicacion(elComentario);
                    (laPublicacion as Post).AddComentario(elComentario);
                    resultado = true;
                }
                resultado = true;

            }
            return resultado;
        }
        public Boolean BloquearUsuario(string email) // Only admin
        {
            Boolean resultado = false;
            if (s_usuarioLogeado is Administrador) // Si el usuario logueado es administrador, realiza el bloqueo, de lo contrario devuelve false.
            {
                foreach (Miembro miembro in _usuarios)
                {
                    if (miembro.Email == email) // Si el email coincide, se bloquea al usuario, de lo contrario, devuelve false.
                    {
                        miembro.Bloqueado = true;
                        resultado = true;
                    }
                }
            }
            return resultado;
        }
        public Boolean EnviarSolicitud(string emailReceptor)
        {
            Boolean resultado = false;
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Miembro) // Solo un usuario puede enviar solicitudes
                {
                    if (emailReceptor == usuario.Email)
                    {
                        if (s_usuarioLogeado is Miembro miembroEmisor && !miembroEmisor.Bloqueado)
                        {
                            Solicitud solicitud = new Solicitud((s_usuarioLogeado as Miembro), (usuario as Miembro));
                            resultado = true;
                        }
                    }
                }
            }
            return resultado;
        }

        public string RegisterAdmin(Administrador admin) // Devuelve un mensaje, sea de exito o de error.
        {
            string resultado = "";
            Boolean emailValidado = ValidarUsuario(admin.Email);
            if (admin.Email == "") resultado = "| El email no es valido. No puede ser vacío. |";
            if (!emailValidado) resultado += " | El email proporcionado ya existe. | ";
            Boolean passwordValidada = admin.ValidarPassword(admin.Password);
            if (!passwordValidada) resultado += "| La contraseña no es valida. Recuerde que debe ser mayor que 8 caracteres, debe utilizar mayusculasm, minusculas y numeros. |";
            if (emailValidado && passwordValidada)
            {
                AddUsuario(admin);
            }
            return resultado;
        }
        public string RegisterMiembro(Miembro miembro) // Devuelve un mensaje, sea de exito o de error.
        {
            string resultado = "";
            Boolean emailValidado = ValidarUsuario(miembro.Email);
            if (miembro.Email != "")
            {
                if (!emailValidado) resultado += " | El email ya existe. | ";
                Boolean passwordValidada = miembro.ValidarPassword(miembro.Password);
                if (!passwordValidada) resultado += "| La contraseña no es valida. Recuerde que debe ser mayor que 8 caracteres, debe utilizar mayusculasm, minusculas y numeros. |";
                Boolean nomYapeValidados = miembro.ValidarNomYapellido(miembro.Nombre, miembro.Apellido);
                if (!nomYapeValidados) resultado += "| Su nombre y/o apellido no son validos. No pueden contener numeros o ser vacíos. |";
                if (emailValidado && passwordValidada && nomYapeValidados)
                {;
                    resultado = "El miembro fue registrado exitosamente.";
                    AddUsuario(miembro);
                }
            }
            else resultado = "| El email no es valido. No puede ser vacío. |";
            
            return resultado;
        }
        public Boolean Login(string email, string password) // Revisa la lista de usuarios y chequea que coincida email y contraseña.
        {
            Boolean resultado = false;
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario.Email == email && usuario.Password == password)
                {
                    resultado = true;
                    s_usuarioLogeado = usuario; // Convierte al usuario logueado en el encontrado.
                }
            }
            return resultado;
        }
        public List<string> BuscarPorEmail(string email) // Revisa la lista de miembros, si encuentra un miembro que coincida busca las publicaciones hechas por el miembro encontrado.
        {
            List<string> lista = new List<string>();
            Miembro miembro = new Miembro();
            bool result = ValidarUsuario(email);
            if (!result)
            {
                foreach (Publicacion publicacion in _publicaciones)
                {
                    if (publicacion.Autor.Email == email) lista.Add(publicacion.ToString());
                }
                if (lista.Count == 0) { lista.Add(email + " no ha realizado ninguna publicación todavía."); }
            }
            else
            {
                lista.Add(email + " no existe.");
            }
            return lista;
        }

        public List<string> BuscarComentarios(string email) // Busca todos los posts COMENTADOS de un miembro especifico. Si no encuentra ninguno o no existe, devuelve un mensaje.
        {
            List<string> lista = new List<string>();
            Miembro miembro = new Miembro();
            bool result = ValidarUsuario(email);
            if (!result)
            {
                foreach (Publicacion publicacion in _publicaciones)
                {
                    if (publicacion is Post)
                    {
                        bool coincide = false;
                        foreach (Comentario comentario in (publicacion as Post).GetComentarios())
                        {
                            if (comentario.Autor.Email == email) coincide = true;
                        }
                        if (coincide) { lista.Add(publicacion.ToString()); }
                    }
                }
                if (lista.Count == 0) { lista.Add(email + " no ha realizado ninguna publicación todavía."); }
            } else
            {
                lista.Add(email + " no existe.");
            }
            return lista;
        }
        public List<string> BuscarPorFecha(DateTime fecha, DateTime fecha2)
        {
            List<string> lista = new List<string>();
            List<Publicacion> listaPub = new List<Publicacion>(_publicaciones);
            listaPub.Sort();
            foreach (Publicacion publicacion in listaPub)
            {
                if (publicacion is Post && publicacion.Fecha <= fecha && publicacion.Fecha >= fecha2)
                {
                    Publicacion laPublicacion = publicacion;
                    if (laPublicacion.Contenido.Length > 50) laPublicacion.Contenido = laPublicacion.Contenido.Substring(0, 49);
                    lista.Add(laPublicacion.ToString());
                }
            }
            if (lista.Count == 0) lista.Add("No se han encontrado posts entre las fechas " + fecha + " y " + fecha2);
            return lista;
        }
        public Boolean AceptarSolicitud(int id)
        {
            Boolean solicitudEncontrada = false;
            Miembro miembro = new Miembro();
            foreach (Solicitud solicitud in miembro.GetSolicitudes())
            {
                if (id == solicitud.Id)
                {
                    solicitud.EstadoSolicitud = Invitacion.APROBADA;
                    solicitudEncontrada = true;
                    (solicitud.Emisor).AddAmigo(solicitud.Receptor);
                    (solicitud.Receptor).AddAmigo(solicitud.Emisor);
                }
            }
            return solicitudEncontrada;
        }
        public Boolean RechazarSolicitud(int id)
        {
            Boolean solicitudEncontrada = false;
            Miembro miembro = new Miembro();
            foreach (Solicitud solicitud in miembro.GetSolicitudes())
            {
                if (id == solicitud.Id)
                {
                    solicitud.EstadoSolicitud = Invitacion.RECHAZADA;
                    solicitudEncontrada = true;
                }
            }
            return solicitudEncontrada;
        }

        public void Reaccionar(string tipoReaccion, int id)     // No está implementado en consola, placeholder para implementar: 
        {                                                       // Que reaccion desea hacer en $POST_TITLE$ ? 1 - like | 2 - dislike
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.Id == id)
                {
                    if (tipoReaccion == "like")
                    {
                        Reaccion unaReaccion = new Reaccion(TipoReaccion.like, (Miembro)UsuarioLogeado);
                        publicacion.AddReaccion(unaReaccion);
                    }
                    else
                    {
                        Reaccion unaReaccion = new Reaccion(TipoReaccion.dislike, (Miembro)UsuarioLogeado);
                        publicacion.AddReaccion(unaReaccion);
                    }
                }
            }
        }
        public List<string> GetMiembrosActivos() // Devuelve los miembros que más posts han hecho.
        {
            List<string> lista = new List<string>();
            int postsMax = 0;
            foreach(Usuario usuario in _usuarios)
            {
                int numPosts = 0;
                if(usuario is Miembro)
                { 
                    foreach (Publicacion publicacion in _publicaciones)
                    {
                        if (publicacion.Autor == usuario) numPosts++;
                    }
                    if (numPosts >= postsMax)
                    {
                        postsMax = numPosts;
                        lista.Add((usuario.ToString()));
                    }
                }
            }
            if (lista.Count == 0) lista.Add("No se han encontrado registros.");
            return lista;
        }
    }
}

