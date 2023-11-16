/*using ClasesObligatorio;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Globalization;
using System.Security.AccessControl;

int opcion = -1;
Sistema miSistema = Sistema.GetInstancia();
#region precarga de datos

miSistema.RegisterMiembro("email1@example.com", "Password1", "Xiomara", "Sandoval", new DateTime(1990, 5, 15));
miSistema.RegisterMiembro("email2@example.com", "Password2", "Zephyr", "Montenegro", new DateTime(2003, 3, 2));
miSistema.RegisterMiembro("email3@example.com", "Password3", "Kai", "López", new DateTime(1993, 11, 10));
miSistema.RegisterMiembro("email4@example.com", "Password4", "Cleopatra", "González", new DateTime(2003, 3, 7));
miSistema.RegisterMiembro("email5@example.com", "Password5", "Osiris", "Pérez", new DateTime(1998, 7, 30));
miSistema.RegisterMiembro("email6@example.com", "Password6", "Thalía", "Ramírez", new DateTime(1996, 1, 5));
miSistema.RegisterMiembro("email7@example.com", "Password7", "Anubis", "Silva", new DateTime(2005, 9, 18));
miSistema.RegisterMiembro("email8@example.com", "Password8", "Isis", "Hernández", new DateTime(1991, 12, 3));
miSistema.RegisterMiembro("email9@example.com", "Password9", "Alberto", "Torres", new DateTime(2001, 9, 11));
miSistema.RegisterMiembro("email10@example.com", "Password10", "Horus", "Martínez", new DateTime(1995, 6, 12));

miSistema.RegisterAdmin("elAdmin@gmail.com", "laMejorPassword325XD");

miSistema.Login("email3@example.com", "Password3");
    miSistema.EnviarSolicitud("email10@example.com");
    miSistema.EnviarSolicitud("email4@example.com");
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(0, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(0, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(0, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(0, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(0, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(1, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(1, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(1, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(2, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(2, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(2, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(3, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(3, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(3, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(4, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(4, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(4, "Comentario", "Este es un comentario de ejemplo");



miSistema.Login("email4@example.com", "Password4");
    miSistema.AceptarSolicitud(1);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.EnviarSolicitud("email9@example.com");
    miSistema.EnviarSolicitud("email5@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11)); 
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(22, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(22, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(22, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(22, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(22, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(23, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(23, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(23, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(24, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(24, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(24, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(25, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(25, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(25, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(26, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(26, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(26, "Comentario", "Este es un comentario de ejemplo");

miSistema.Login("email5@example.com", "Password5");
    miSistema.AceptarSolicitud(7);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.EnviarSolicitud("email8@example.com");
    miSistema.EnviarSolicitud("email6@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post que voy a alargar hasta los 50 caracteres porque ando re al pedo", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(44, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(44, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(44, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(45, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(45, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(45, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(46, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(46, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(46, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(47, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(47, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(47, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(48, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(48, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(48, "Comentario", "Este es un comentario de ejemplo");

miSistema.Login("email6@example.com", "Password6");
    miSistema.AceptarSolicitud(11);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.EnviarSolicitud("email7@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(64, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(64, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(64, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(65, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(65, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(65, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(66, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(66, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(66, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(67, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(67, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(67, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(68, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(68, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(68, "Comentario", "Este es un comentario de ejemplo");


miSistema.Login("email7@example.com", "Password7");
    miSistema.AceptarSolicitud(14);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.EnviarSolicitud("email8@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(84, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(84, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(84, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(85, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(85, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(85, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(86, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(86, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(86, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(87, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(87, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(87, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(88, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(88, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(88, "Comentario", "Este es un comentario de ejemplo");


miSistema.Login("email8@example.com", "Password8");
    miSistema.AceptarSolicitud(17);
    miSistema.RechazarSolicitud(10);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.EnviarSolicitud("email9@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(104, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(104, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(104, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(105, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(105, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(105, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(106, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(106, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(106, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(107, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(107, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(107, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(108, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(108, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(108, "Comentario", "Este es un comentario de ejemplo");



miSistema.Login("email9@example.com", "Password9");
    miSistema.AceptarSolicitud(20);
    miSistema.RechazarSolicitud(6);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.EnviarSolicitud("email10@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(124, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(124, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(124, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(125, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(125, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(125, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(126, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(126, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(126, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(127, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(127, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(127, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(128, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(128, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(128, "Comentario", "Este es un comentario de ejemplo");


miSistema.Login("email10@example.com", "Password10");
    miSistema.AceptarSolicitud(23);
    miSistema.RechazarSolicitud(0);
    miSistema.EnviarSolicitud("email1@example.com");
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(144, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(144, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(144, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(145, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(145, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(145, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(146, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(146, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(146, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(147, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(147, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(147, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(148, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(148, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(148, "Comentario", "Este es un comentario de ejemplo");

    miSistema.Reaccionar("like", 0);
    miSistema.Reaccionar("dislike", 1);
    miSistema.Reaccionar("like", 2);
    miSistema.Reaccionar("dislike", 3);

miSistema.Login("email1@example.com", "Password1");
    miSistema.AceptarSolicitud(2);
    miSistema.AceptarSolicitud(4);
    miSistema.AceptarSolicitud(8);
    miSistema.AceptarSolicitud(12);
    miSistema.AceptarSolicitud(15);
    miSistema.AceptarSolicitud(18);
    miSistema.AceptarSolicitud(22);
    miSistema.AceptarSolicitud(21);
    miSistema.AceptarSolicitud(24);
    miSistema.EnviarSolicitud("email2@example.com");
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(164, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(164, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(164, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(165, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(165, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(165, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(166, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(166, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(166, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(167, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(167, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(167, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(168, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(168, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(168, "Comentario", "Este es un comentario de ejemplo");

miSistema.Login("email2@example.com", "Password2");
    miSistema.AceptarSolicitud(3);
    miSistema.AceptarSolicitud(5);
    miSistema.AceptarSolicitud(9);
    miSistema.AceptarSolicitud(13);
    miSistema.AceptarSolicitud(16);
    miSistema.AceptarSolicitud(29);
    miSistema.AceptarSolicitud(22);
    miSistema.AceptarSolicitud(25);
    miSistema.RealizarPost("Título del primer post", "Texto del primer post", "imagen1.jpg", 'N', new DateTime(2023, 9, 11));
    miSistema.RealizarPost("Título del segundo post", "Texto del segundo post", "imagen2.png", 'S', new DateTime(2022, 1, 21));
    miSistema.RealizarPost("Título del tercer post", "Texto del tercer post", "imagen3.jpg", 'N', new DateTime(2022, 3, 22));
    miSistema.RealizarPost("Título del cuarto post", "Texto del cuarto post", "imagen4.png", 'S', new DateTime(2023, 6, 19));
    miSistema.RealizarPost("Título del quinto post", "Texto del quinto post", "imagen5.jpg", 'N', new DateTime(2022, 8, 22));
    miSistema.RealizarComentario(184, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(184, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(184, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(185, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(185, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(185, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(186, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(186, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(186, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(187, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(187, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(187, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(188, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(188, "Comentario", "Este es un comentario de ejemplo");
    miSistema.RealizarComentario(188, "Comentario", "Este es un comentario de ejemplo");

#endregion


while (opcion != 6)
{
    Console.WriteLine("");
    Console.WriteLine("-.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.-");
    Console.WriteLine("1 - Alta de miembro.");
    Console.WriteLine("");
    Console.WriteLine("2 - Listar publicaciones (dado un email).");
    Console.WriteLine("");
    Console.WriteLine("3 - Listar Posts comentados (dado un email).");
    Console.WriteLine("");
    Console.WriteLine("4 - Listar Posts realizado entre fechas.");
    Console.WriteLine("");
    Console.WriteLine("5 - Listar todos los miembros que hayan posteado.");
    Console.WriteLine("");
    Console.WriteLine("6 - Salir del programa.");
    Console.WriteLine("_.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__._");
    Console.WriteLine("");
    int.TryParse(Console.ReadLine(), out opcion);
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese su email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Ingrese una contraseña (Debe ser de más de 8 caracteres y deber tener mayúsculas y minúsculas: ");
            string password = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese un apellido: ");
            string apellido = Console.ReadLine();
            bool correctFormat = false;
            DateTime fecha = new DateTime();
            do
            {
                try
                {
                    Console.WriteLine("Ingrese su fecha de nacimiento: ");
                    fecha = DateTime.Parse(Console.ReadLine());
                    correctFormat = true;
                }
                catch (Exception ex) { Console.WriteLine("El formato de la fecha es incorrecto, por favor intente nuevamente."); }
            } while (!correctFormat);
            Miembro miembro = new Miembro();
            miembro.Email = email;
            miembro.Nombre = nombre;
            miembro.Password = password;
            miembro.Apellido = apellido;
            miembro.FechaNacimiento = fecha;
            Console.WriteLine("-.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.--.-");
            Console.WriteLine(miSistema.RegisterMiembro(miembro));
            Console.WriteLine("_.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__.__._");
            break;
        case 2:
            Console.WriteLine("Ingrese un email: ");
            email = Console.ReadLine();
            List<string> lista = miSistema.BuscarPorEmail(email); 
            foreach(string publicacion in lista)                  
            {
                Console.WriteLine(publicacion);
            }
            break;
        case 3:
            Console.WriteLine("Ingrese un email: ");
            email = Console.ReadLine();
            lista = miSistema.BuscarComentarios(email);
            foreach (string publicacion in lista)
            {
                Console.WriteLine(publicacion);
            }
            break;
        case 4: 
            try
            {
                Console.WriteLine("Ingrese una fecha: ");
                fecha = DateTime.Now;
                DateTime fecha2 = DateTime.Now;
                fecha = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese una segunda fecha: ");
                fecha2 = DateTime.Parse(Console.ReadLine());
                List<string> listaPub = new List<string>();
                if (fecha > fecha2) // Condicion para fijarse si la primer fecha es mayor a la segunda y vice versa. Hace la comparación más fácil en el metodo de Sistema.
                {
                    listaPub = miSistema.BuscarPorFecha(fecha, fecha2);
                } else listaPub = miSistema.BuscarPorFecha(fecha2, fecha);
                foreach (string pub in listaPub) 
                { 
                    Console.WriteLine(pub.ToString()); 
                }
            }
            catch (Exception ex) { Console.WriteLine("Una de las fechas fue inválida, asegurese que sea en el formato YYYY/MM/DD"); }
            break;
        case 5:
            List<string> listaMiemb = new List<string>();
            listaMiemb = miSistema.GetMiembrosActivos();
            foreach(string miembro in listaMiemb)
            {
                Console.WriteLine(miembro);
            }
            break;
        case 6:
            break;
        default:
            Console.WriteLine("Por favor elija una opcion de las que se muestran en el menu.");
            break;
    }
}
*/