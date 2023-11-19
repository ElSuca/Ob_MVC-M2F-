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
        private void precargaUsers()
        {
            RegisterAdmin(new Administrador("elAdmin@gmail.com", "laContrasena123"));
            RegisterMiembro(new Miembro("elCosoLoco@gmail.com", "laReContrasena123", "elTuki", "Martinez", new DateTime(11 / 09 / 2001)));
            RegisterMiembro(new Miembro("elGordoHater@yahoo.com", "losOdioATodos39", "ElHater", "Lopez", new DateTime(25 / 05 / 1989)));
        }
        private void precargaPublicaciones()
        {
            s_usuarioLogeado = GetUsuario("elCosoLoco@gmail.com");
            RealizarPost(new Post("El Coso", s_usuarioLogeado, "El coso va a revolucionar el universo. Diganme que estoy equivcado.", "coso.jpg", false));
            RealizarPost(new Post("Reseña de Libro: 'Cómo Hablar con Plantas'", s_usuarioLogeado, "Una guía hilarante para establecer una comunicación profunda con tu ficus.", "libro_plantas.jpg", false));
            RealizarPost(new Post("Aventura en el País de las Mariposas Psicodélicas", s_usuarioLogeado, "Sumérgete en un mundo de colores y mariposas que te guiarán a través de un viaje alucinante.", "mariposas_psicodelicas.jpg", false));
            RealizarPost(new Post("Receta para Hacer Galletas que te Hacen Volar", s_usuarioLogeado, "Ingredientes mágicos para galletas que desafían la gravedad. ¡No intentes esto en casa!", "galletas_voladoras.jpg", false));
            RealizarPost(new Post("Oferta de Abrazos Gratis", s_usuarioLogeado, "¡Hoy y siempre! Pasa por nuestra tienda y reclama tu abrazo gratis. ¡No se aceptan devoluciones!", "abrazos.jpg", false));
            RealizarPost(new Post("El Futuro es hoy, ¿Oíste viejo?", s_usuarioLogeado, "Les enseño como hacer un switch anidado.", "switch.png", false));
            RealizarPost(new Post("Como desinstalar Zoom: Un tutorial", s_usuarioLogeado, "Hoy les voy a enseñar como borrar Zoom de su computadora.", "tutorial.png", false));
            s_usuarioLogeado = GetUsuario("elGordoHater@yahoo.com");
            RealizarComentario(new Comentario("Absurdo e Incomprensible",s_usuarioLogeado, "Este 'Coso' es una locura sin sentido. No veo cómo puede revolucionar nada.", false), 0);
            RealizarComentario(new Comentario("Libro Ridículo", s_usuarioLogeado, "Hablar con plantas... ¿en serio? Este libro es una pérdida de papel.", false),1);
            RealizarComentario(new Comentario("Viaje Alucinante o Alucinado", s_usuarioLogeado, "Esa aventura suena más como un mal viaje. ¿Mariposas psicodélicas? ¡No gracias!", false),2);
            RealizarComentario(new Comentario("Receta Confusa", s_usuarioLogeado, "Los pasos son re confusos y me salieron horribles. Como vas a dejar las galletas en el horno por 3 dias?! cuando las saqué del horno parecían carbón.", false),3);
            RealizarComentario(new Comentario("Te viste en el espejo?", s_usuarioLogeado, "Nadie te va a querer abrazar a vos !!", false),4);
            RealizarComentario(new Comentario("Tutorial Inútil", s_usuarioLogeado, "Horrible tu tutorial.", false),5);
            RealizarComentario(new Comentario("Tutorial Confuso", s_usuarioLogeado, "Este tutorial sobre cómo desinstalar Zoom solo me dejó más confundido. Y me parece que sos un bobo.", false),6);
        }
        private Sistema() 
        {
            precargaUsers();
            precargaPublicaciones();
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
        public Boolean RealizarPost(Post elPost)
        {
            Boolean resultado = false;
            Miembro autor = (Miembro)s_usuarioLogeado;
            Post post = new Post();
            if (post.ValidarTitulo(elPost.Titulo) && post.ValidarContenido(elPost.Contenido))
            {
                if (!autor.Bloqueado)
                {
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
        public Boolean RealizarComentario(Comentario elComentario, int idPost)
        {
            Boolean resultado = false;
            Publicacion laPublicacion = null;
            Miembro autor = (Miembro)s_usuarioLogeado;
            Comentario comentario = new Comentario();

            if (!autor.Bloqueado)
            {
                foreach (Publicacion unaPublicacion in _publicaciones)
                {
                    if (unaPublicacion is Post && unaPublicacion.Id == idPost) // Se revisa la lista de publicaciones y se chequea que la publicación no solo sea un post, sino que tenga la misma id.
                    {
                        laPublicacion = unaPublicacion;
                    }
                }
                if (comentario.ValidarTitulo(elComentario.Titulo) && comentario.ValidarContenido(elComentario.Contenido) && laPublicacion != null)
                {
                    elComentario.EsPrivado = laPublicacion.EsPrivado; // Si un post es publico, el comentario también lo va a ser.
                    AddPublicacion(elComentario);
                    (laPublicacion as Post).AddComentario(elComentario);
                    resultado = true;
                }
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
        {                                                       // Que reaccion desea hacer en $POST_TITLE$ ? 1 - like | 2 - dislike   <----- al final esto no se hace xd
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

