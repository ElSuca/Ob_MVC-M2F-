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
        #region precargas Locas
        private void precargaUsers()
        {
            RegisterAdmin(new Administrador("elAdmin@gmail.com", "laContrasena123"));
            RegisterMiembro(new Miembro("elCosoLoco@gmail.com", "laReContrasena123", "elTuki", "Martinez", new DateTime(11 / 09 / 2001)));
            RegisterMiembro(new Miembro("elGordoHater@yahoo.com", "losOdioATodos39", "ElHater", "Lopez", new DateTime(25 / 05 / 1989)));
            RegisterMiembro(new Miembro("laGordaHater@yahoo.com", "amoAlGordo25", "LaHater", "García", new DateTime(30 / 01 / 1993)));
            RegisterMiembro(new Miembro("pizzaMuzza@gmail.com", "MargaritaIT235", "MammaMia", "Tortollini", new DateTime(16 / 12 / 1990)));
            RegisterMiembro(new Miembro("amo_a_platon@gmail.com", "polisGriega427", "AristotélisTróiAftíMe", "Demo", new DateTime(8 / 08 / 1969)));
            RegisterMiembro(new Miembro("elSukaBliat@mail.ru", "adidas_Vodka1989", "HarasheeHieytier", "Vodkanov", new DateTime(11 / 03 / 1991)));
            RegisterMiembro(new Miembro("hulalaSrFrances@gmail.com", "croisantFR1799", "ComeBaguette", "Mbappe", new DateTime(15 / 07 / 2005)));
            RegisterMiembro(new Miembro("cadeOHexaEin@gmail.com", "oReiDoFuchibol70", "OCachorrão", "Neyzinho", new DateTime(20 / 06 / 2002)));
            RegisterMiembro(new Miembro("dasDeutsch@gmail.com", "oderNeuer2014", "SiebenIstMeahrAlsEins", "Mueller", new DateTime(1 / 07 / 2014)));
            RegisterMiembro(new Miembro("elBTSChino@gmail.com", "winnieDePooh69", "soyKoleanoNoChino>_<", "MingSon", new DateTime(30 / 04 / 1999)));
            RegisterMiembro(new Miembro("theSir@gmail.com", "hahaxdXDXD123", "MURICAFUCKYEA", "Tyler", new DateTime(9 / 02 / 1979)));
        }
        private void precargaPublicaciones()
        {
            s_usuarioLogeado = GetUsuario("elCosoLoco@gmail.com");
            RealizarPost(new Post("El Coso", s_usuarioLogeado, "El coso va a revolucionar el universo. Diganme que estoy equivcado.", "gatoputo.jpg", false));
            RealizarPost(new Post("Reseña de Libro: 'Cómo Hablar con Plantas'", s_usuarioLogeado, "Una guía hilarante para establecer una comunicación profunda con tu ficus.", "libro_plantas.png", false));
            RealizarPost(new Post("Aventura en el País de las Mariposas Psicodélicas", s_usuarioLogeado, "Sumérgete en un mundo de colores y mariposas que te guiarán a través de un viaje alucinante.", "mariposas_psicodelicas.png", false));
            RealizarPost(new Post("Receta para Hacer Galletas que te Hacen Volar", s_usuarioLogeado, "Ingredientes mágicos para galletas que desafían la gravedad. ¡No intentes esto en casa!", "henchman.png", false));
            RealizarPost(new Post("Oferta de Abrazos Gratis", s_usuarioLogeado, "¡Hoy y siempre! Pasa por nuestra tienda y reclama tu abrazo gratis. ¡No se aceptan devoluciones!", "onedolar.jpg", false));
            RealizarPost(new Post("El Futuro es hoy, ¿Oíste viejo?", s_usuarioLogeado, "Les enseño como hacer un switch anidado.", "nerd.jpg", false));
            s_usuarioLogeado = GetUsuario("hulalaSrFrances@gmail.com");
            RealizarPost(new Post("Como desinstalar Zoom: Un tutorial", s_usuarioLogeado, "Hoy les voy a enseñar como borrar Zoom de su computadora.", "tutorial.png", false)); //6
            s_usuarioLogeado = GetUsuario("elGordoHater@yahoo.com");
            RealizarComentario(new Comentario("Absurdo e Incomprensible", s_usuarioLogeado, "Este 'Coso' es una locura sin sentido. No veo cómo puede revolucionar nada.", false), 0);
            RealizarComentario(new Comentario("Libro Ridículo", s_usuarioLogeado, "Hablar con plantas... ¿en serio? Este libro es una pérdida de papel.", false), 1);
            RealizarComentario(new Comentario("Viaje Alucinante o Alucinado", s_usuarioLogeado, "Esa aventura suena más como un mal viaje. ¿Mariposas psicodélicas? ¡No gracias!", false), 2);
            RealizarComentario(new Comentario("Receta Confusa", s_usuarioLogeado, "Los pasos son re confusos y me salieron horribles. Como vas a dejar las galletas en el horno por 3 dias?! cuando las saqué del horno parecían carbón.", false), 3);
            RealizarComentario(new Comentario("Te viste en el espejo?", s_usuarioLogeado, "Nadie te va a querer abrazar a vos !!", false), 4);
            RealizarComentario(new Comentario("Tutorial Inútil", s_usuarioLogeado, "Horrible tu tutorial.", false), 5);
            RealizarComentario(new Comentario("Tutorial Confuso", s_usuarioLogeado, "Este tutorial sobre cómo desinstalar Zoom solo me dejó más confundido. Y me parece que sos un bobo.", false), 6);  //13
            s_usuarioLogeado = GetUsuario("elSukaBliat@mail.ru");
            RealizarPost(new Post("Amigovich para una partidovich", s_usuarioLogeado, "Un oso ruso se unió a la party chat... y solo quiere jugar Among Us. ¿Quién para una ronda?", "oso_ruso.jpg", false));
            s_usuarioLogeado = GetUsuario("pizzaMuzza@gmail.com");
            RealizarPost(new Post("Siete stronzi o porci?", s_usuarioLogeado, "Ma che peccato, la pizza ha l'ananas...", "pizza_ananas.jpg", false));
            RealizarPost(new Post("Experimento: ¿Gatos o Perros Dominarán el Mundo?", s_usuarioLogeado, "Iniciando un experimento para determinar quiénes dominarán el mundo: ¿gatos o perros? ¿Tienes tu apuesta lista?", "carpincho.jpg", false));
            s_usuarioLogeado = GetUsuario("theSir@gmail.com");
            RealizarPost(new Post("Let that sink in mate", s_usuarioLogeado, "Let that Sink...in", "precio-y-detalles.png", false));
            RealizarPost(new Post("Wich is the most popular and important sport event in the world? and why is the SUPER BOWL?!", s_usuarioLogeado, "Soccer LOL", "lets_fuckin_go.jpeg", false));
            s_usuarioLogeado = GetUsuario("cadeOHexaEin@gmail.com");
            RealizarPost(new Post("Quem para tomar uma sopa de macaco?", s_usuarioLogeado, "... um elissir", "macaco.jpg", false));
            RealizarPost(new Post("Hoje tem jogo da copa Roblox", s_usuarioLogeado, "quem ganhar joga a final kkkk, vem no capricho", "cachorrao.jpg", true));
            s_usuarioLogeado = GetUsuario("elBTSChino@gmail.com");
            RealizarPost(new Post("No soy chino, soy coleano >_<", s_usuarioLogeado, "GANGAM STYLE OH", "winnie.jpg", false));
            s_usuarioLogeado = GetUsuario("amo_a_platon@gmail.com");
            RealizarPost(new Post("Pra vcs, qual é o melhor champ???", s_usuarioLogeado, "Só eu acho que o morde é o melhor do lolzinho? O cara pega vc e manda embora de volta ao Brasil KKKKKKKKK, ta suchera na lane", "morde_br.jpg", false));
            RealizarComentario(new Comentario("Con el oso si, contigo no", s_usuarioLogeado, "Quien se va a juntar contigo, anda a tocar pasto", false), 14);
            s_usuarioLogeado = GetUsuario("amo_a_platon@gmail.com");
            RealizarComentario(new Comentario("De acuerdo, pero...", s_usuarioLogeado, "Aguante la pizza con chocolate", false), 15);
            RealizarComentario(new Comentario("Uma delicia", s_usuarioLogeado, "BLUE LABEL", false), 19);
            s_usuarioLogeado = GetUsuario("dasDeutsch@gmail.com");
            RealizarComentario(new Comentario("1-7 HAHAHA", s_usuarioLogeado, "Du bist mein Sohn", false), 22);
            RealizarComentario(new Comentario("Sehr gut", s_usuarioLogeado, "Das is Falsch >:()", false), 18);
        }
        private void precargaSolicitudes()
        {
            s_usuarioLogeado = GetUsuario("laGordaHater@yahoo.com");
            EnviarSolicitud("elGordoHater@yahoo.com");
            EnviarSolicitud("dasDeutsch@gmail.com");
            EnviarSolicitud("amo_a_platon@gmail.com");
            EnviarSolicitud("hulalaSrFrances@gmail.com");
            EnviarSolicitud("elBTSChino@gmail.com");
            EnviarSolicitud("cadeOHexaEin@gmail.com");
            EnviarSolicitud("theSir@gmail.com");
            EnviarSolicitud("pizzaMuzza@gmail.com");
            EnviarSolicitud("elSukaBliat@mail.ru");//8
            s_usuarioLogeado = GetUsuario("elGordoHater@yahoo.com");
            EnviarSolicitud("dasDeutsch@gmail.com");
            EnviarSolicitud("amo_a_platon@gmail.com");
            EnviarSolicitud("hulalaSrFrances@gmail.com");
            EnviarSolicitud("elBTSChino@gmail.com");
            EnviarSolicitud("cadeOHexaEin@gmail.com");
            EnviarSolicitud("theSir@gmail.com");
            EnviarSolicitud("pizzaMuzza@gmail.com");
            EnviarSolicitud("elSukaBliat@mail.ru");//16
            AceptarSolicitud(0);
            s_usuarioLogeado = GetUsuario("dasDeutsch@gmail.com");
            EnviarSolicitud("cadeOHexaEin@gmail.com");
            EnviarSolicitud("elSukaBliat@mail.ru");//18
            RechazarSolicitud(1);
            RechazarSolicitud(9);
            s_usuarioLogeado = GetUsuario("elBTSChino@gmail.com");
            EnviarSolicitud("dasDeutsch@gmail.com");
            EnviarSolicitud("amo_a_platon@gmail.com");
            EnviarSolicitud("hulalaSrFrances@gmail.com");
            EnviarSolicitud("pizzaMuzza@gmail.com");//22
            RechazarSolicitud(12);
            RechazarSolicitud(3);
            s_usuarioLogeado = GetUsuario("amo_a_platon@gmail.com");
            EnviarSolicitud("hulalaSrFrances@gmail.com");
            EnviarSolicitud("cadeOHexaEin@gmail.com");
            EnviarSolicitud("theSir@gmail.com");
            EnviarSolicitud("pizzaMuzza@gmail.com");
            EnviarSolicitud("elSukaBliat@mail.ru");//27
            AceptarSolicitud(20);
            RechazarSolicitud(10);
            RechazarSolicitud(1);
            s_usuarioLogeado = GetUsuario("hulalaSrFrances@gmail.com");
            EnviarSolicitud("dasDeutsch@gmail.com");
            EnviarSolicitud("amo_a_platon@gmail.com");
            EnviarSolicitud("theSir@gmail.com");
            EnviarSolicitud("pizzaMuzza@gmail.com");//31
            AceptarSolicitud(23);
            AceptarSolicitud(21);
            RechazarSolicitud(2);
            RechazarSolicitud(11);
            s_usuarioLogeado = GetUsuario("theSir@gmail.com");
            EnviarSolicitud("dasDeutsch@gmail.com");
            EnviarSolicitud("elBTSChino@gmail.com");
            EnviarSolicitud("elSukaBliat@mail.ru");//34
            AceptarSolicitud(25);
            RechazarSolicitud(5);
            RechazarSolicitud(14);
            s_usuarioLogeado = GetUsuario("elSukaBliat@mail.ru");
            EnviarSolicitud("dasDeutsch@gmail.com");
            EnviarSolicitud("hulalaSrFrances@gmail.com");
            EnviarSolicitud("elBTSChino@gmail.com");
            EnviarSolicitud("cadeOHexaEin@gmail.com");
            EnviarSolicitud("theSir@gmail.com");//39
            AceptarSolicitud(18);
            RechazarSolicitud(7);
            RechazarSolicitud(16);
            s_usuarioLogeado = GetUsuario("laGordaHater@yahoo.com");
            EnviarSolicitud("elCosoLoco@gmail.com");
            s_usuarioLogeado = GetUsuario("cadeOHexaEin@gmail.com");
            AceptarSolicitud(38);

        }
        private void precargaReacciones()
        {
            s_usuarioLogeado = GetUsuario("laGordaHater@yahoo.com");
            Miembro miembro = s_usuarioLogeado as Miembro;
            for (int i = 0; i < 27; i++)
            {
                Publicacion publicacion = GetPublicacion(i);
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.dislike, miembro));
            }
            s_usuarioLogeado = GetUsuario("elGordoHater@yahoo.com");
            miembro = s_usuarioLogeado as Miembro;
            for (int i = 7; i < 14; i++)
            {
                Publicacion publicacion = GetPublicacion(i);
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.like, miembro));
            }
            for (int i = 0; i < 7; i++)
            {
                Publicacion publicacion = GetPublicacion(i);
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.dislike, miembro));
            }
            for (int i = 14; i < 27; i++)
            {
                Publicacion publicacion = GetPublicacion(i);
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.dislike, miembro));
            }
            s_usuarioLogeado = GetUsuario("elBTSChino@gmail.com");
            miembro = s_usuarioLogeado as Miembro;
            for (int i = 0; i < 27; i = i+2)
            {
                Publicacion publicacion = GetPublicacion(i);
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.like, miembro));
            }
            s_usuarioLogeado = GetUsuario("elSukaBliat@mail.ru");
            miembro = s_usuarioLogeado as Miembro;
            for (int i = 0; i < 27; i = i+3)
            {
                Publicacion publicacion = GetPublicacion(i);
                publicacion.Reacciones.Add(new Reaccion(TipoReaccion.like, miembro));
            }

        }
        #endregion
        private Sistema()
        {
            precargaUsers();
            precargaPublicaciones();
            precargaSolicitudes();
            precargaReacciones();
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
                if (usuario.Email == email)
                {
                    elUsuario = usuario;
                }
            }
            return elUsuario;
        }
        public Publicacion GetPublicacion(int id)
        {
            Publicacion laPublicacion = null;
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.Id == id)
                {
                    laPublicacion = publicacion;
                }
            }
            return laPublicacion;
        }
        public Boolean RealizarPost(Post elPost)
        {
            Boolean resultado = false;
            Miembro autor = s_usuarioLogeado as Miembro;
            Post post = new Post();
            elPost.Autor = autor;
            elPost.Fecha = DateTime.Now;
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
        public Boolean CensurarPublicacion(int idPost)
        {
            Boolean resultado = false;
            Post elPost = GetPublicacion(idPost) as Post;
            if (elPost != null)
            {
                elPost.Censurado = true;
                resultado = true;
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
                foreach (Usuario miembro in _usuarios)
                {
                    if (miembro.Email == email) // Si el email coincide, se bloquea al usuario, de lo contrario, devuelve false.
                    {
                        (miembro as Miembro).Bloqueado = true;
                        resultado = true;
                    }
                }
            }
            return resultado;
        }
        public Boolean EnviarSolicitud(string emailReceptor)
        {
            Boolean resultado = false;
            Miembro receptor = GetUsuario(emailReceptor) as Miembro;

            if (s_usuarioLogeado is Miembro miembroEmisor && !miembroEmisor.Bloqueado)
            {
                Solicitud solicitud = new Solicitud((s_usuarioLogeado as Miembro), (receptor));
                if (!receptor.ValidarSolicitud(solicitud))
                {
                    receptor.AddSolicitud(solicitud);
                    resultado = true;
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
                {
                    ;
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
        public Boolean AceptarSolicitud(int id)
        {
            Boolean solicitudEncontrada = false;
            Miembro miembro = s_usuarioLogeado as Miembro;
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
            Miembro miembro = s_usuarioLogeado as Miembro;
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

        public List<Miembro> GetMiembrosOrdenados()
        {
            List<Miembro> miembros = new List<Miembro>();
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Miembro)
                {
                    miembros.Add(usuario as Miembro);
                }
            }
            miembros.Sort(new OrdenarPorNombreYApe());
            return miembros;
        }
    }
}

