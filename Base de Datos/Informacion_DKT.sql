USE darkesttimes;

-- Tabla usuario
CREATE TABLE usuario(
id_usuario INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_personaje INT NOT NULL comment "Llave foranea",
correo VARCHAR(45) NOT NULL comment "Correo del usuario",
usuario VARCHAR(45) NOT NULL comment "Nombre de usuario",
contraseña VARCHAR(45) NOT NULL comment "Password",
horas_jugadas INT NOT NULL comment "Horas que lleva dela sesion",
easter_eggs INT NOT NULL comment "Easter Eggs encontrados",
PRIMARY KEY (id_usuario),
CONSTRAINT fk_personaje FOREIGN KEY (id_personaje) REFERENCES personaje (id_personaje) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;

-- Tabla de personaje
CREATE TABLE personaje(
id_personaje INT NOT NULL UNIQUE AUTO_INCREMENT comment "LLave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del personaje",
vida_max INT NOT NULL comment "Vida que puede llegar a tener el personaje",
vida_actual INT NOT NULL comment "Vida que tiene en el momento el personaje",
suerte INT NOT NULL comment "Suerte del personaje",
stamina INT NOT NULL comment "Stamina del personaje",
multiplicador_monedas INT NOT NULL comment "Multiplicador de las monedas",
muertes INT NOT NULL comment "Muertes que lleva el personaje",
PRIMARY KEY (id_personaje))
ENGINE=InnoDB;

-- Tabla de Checkpoints
CREATE TABLE checkpoint(
id_checkpoint INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_personaje INT NOT NULL comment "Llave Foranea",
id_nivel INT NOT NULL comment "LLave Foranea",
nombre_checkpoint VARCHAR(45) NOT NULL comment "Nombre del checkpoint en el que esta el personaje",
PRIMARY KEY (id_checkpoint),
CONSTRAINT fk_personajeC FOREIGN KEY (id_personaje) REFERENCES personaje (id_personaje) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_nivel FOREIGN KEY (id_nivel) REFERENCES nivel (id_nivel) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;

-- Tabla de Nivel
CREATE TABLE nivel(
id_nivel INT NOT NULL UNIQUE AUTO_INCREMENT comment "LLave primaria",
id_enemigo INT NOT NULL comment "Llave foranea",
id_arma INT NOT NULL comment "Llave foranea",
id_tienda INT NOT NULL comment "Llave foranea",
id_objeto INT NOT NULL comment "Llave foranea",
id_npc INT NOT NULL comment "Llave foranea",
nombre_nivel VARCHAR(45) NOT NULL,
PRIMARY KEY (id_nivel),
CONSTRAINT fk_enemigo FOREIGN KEY (id_enemigo) REFERENCES enemigo (id_enemigo) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_arma FOREIGN KEY (id_arma) REFERENCES arma (id_arma) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_tienda FOREIGN KEY (id_tienda) REFERENCES tienda (id_tienda) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_objeto FOREIGN KEY (id_objeto) REFERENCES objeto (id_objeto) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_npc FOREIGN KEY (id_npc) REFERENCES non_player (id_npc) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;

-- Tabla de Enemigos
CREATE TABLE enemigo(
id_enemigo INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del enemigo",
tipo VARCHAR(45) NOT NULL comment "Tipo del enemigo phobia ,oscuridad o glitch",
vida INT NOT NULL comment "Vida del enemigo",
daño INT NOT NULL comment "Daño que hace el enemigo",
asesinatos INT NOT NULL comment "Cantidad de veces que asesino el enemigo al jugador",
PRIMARY KEY (id_enemigo))
ENGINE=InnoDB;

-- Tabla de Armas
CREATE TABLE arma(
id_arma INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_clase INT NOT NULL comment "Llave foranea",
nombre VARCHAR(45) NOT NULL comment "Nombre del arma",
tipo VARCHAR(45) NOT NULL comment "Tipo del arma: corta media o larga",
daño INT NOT NULL comment "Daño que produce el arma",
PRIMARY KEY (id_arma),
CONSTRAINT fk_claseA FOREIGN KEY (id_clase) REFERENCES clase (id_clase) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;

-- Tabla de Tiendas
CREATE TABLE tienda(
id_tienda INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nivel VARCHAR(45) NOT NULL comment "Nombre del nivel en el que esta la tienda Lobby, Hospital o Bosque",
PRIMARY KEY (id_tienda))
ENGINE=InnoDB;

-- Tabla de NPC
CREATE TABLE non_player(
id_npc INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del npc",
PRIMARY KEY (id_npc))
ENGINE=InnoDB;

-- Tabla Objeto
CREATE TABLE objeto(
id_objeto INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_clase INT NOT NULL comment "Llave foranea",
duracion INT NOT NULL comment "Tiempo que dura el efecto del objeto",
precio INT NOT NULL comment "Precio del objeto en tienda",
PRIMARY KEY (id_objeto),
CONSTRAINT fk_claseO FOREIGN KEY (id_clase) REFERENCES clase (id_clase) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;

-- Tabla CLase
CREATE TABLE clase(
id_clase INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
clase VARCHAR(45) NOT NULL comment "Clases: comun, rara, epica, legendaria",
tipo VARCHAR(45) NOT NULL comment "Tipo: arma u objeto",
ocurrencia INT NOT NULL comment "Cual es la probabilidad de que aparezca",
PRIMARY KEY (id_clase))
ENGINE=InnoDB;

-- Tabla de Relacion: Nivel_Objetos
CREATE TABLE nivel_objetos(
id_nivelO INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_nivel INT NOT NULL comment "Llave foranea",
id_objeto INT NOT NULL comment "Llave foranea",
PRIMARY KEY (id_nivelO),
CONSTRAINT fk_nivelR FOREIGN KEY (id_nivel) REFERENCES nivel (id_nivel) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_objetoR FOREIGN KEY (id_objeto) REFERENCES objeto (id_objeto) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;

-- Dummy Data

-- Tabla Usuario
SET AUTOCOMMIT=0;
INSERT INTO usuario VALUES
(1,1,"email@gmail0.com","dummy1","password1",5,2,3),
(2,2,"email@gmail1.com","dummy2","password2",16,5,3),
(3,3,"email@gmail2.com","dummy3","password3",24,4,3),
(4,4,"email@gmail3.com","dummy4","password4",87,8,6),
(5,5,"email@gmail4.com","dummy5","password5",2,1,8),
(6,6,"email@gmail5.com","dummy6","password6",1,3,6),
(7,7,"email@gmail6.com","dummy7","password7",23,6,2),
(8,8,"email@gmail7.com","dummy8","password8",8,9,2),
(9,9,"email@gmail8.com","dummy9","password9",6,3,1),
(10,10,"email@gmail9.com","dummy10","password10",3,10,6);
COMMIT;

-- Tabla Personaje
SET AUTOCOMMIT=0;
INSERT INTO personaje VALUES
(1,"Jp",10,4,5,5,1.2,3),
(2,"Dani",8,5,5,8,1.2,6),
(3,"David",6,2,10,7,1.5,7),
(4,"Angel",6,1,7,10,2.0,6),
(5,"Jp",10,8,5,5,1.2,2),
(6,"Dani",8,3,5,8,1.2,6),
(7,"David",6,5,10,7,1.5,10),
(8,"Angel",6,6,7,10,2.0,4),
(9,"Jp",10,1,5,5,1.2,0),
(10,"Dani",8,4,5,8,1.2,20);
COMMIT;

-- Tabla Checkpoints
SET AUTOCOMMIT=0;
INSERT INTO checkpoint VALUES
(1,1,1,"checkpoint tutorial1"),
(2,2,2,"checkpoint lobby0"),
(3,3,3,"checkpoint hospital0"),
(4,4,4,"checkpoint bosque3"),
(5,5,5,"checkpoint tutorial0"),
(6,6,6,"checkpoint lobby1"),
(7,7,7,"checkpoint hospital0"),
(8,8,8,"checkpoint bosque0"),
(9,9,9,"checkpoint bosque1"),
(10,10,10,"checkpoint lobby2");
COMMIT;

-- Tabla Niveles
SET AUTOCOMMIT=0;
INSERT INTO nivel VALUES
(1,1,1,1,1,1,"Tutorial"),
(2,2,2,2,2,2,"Lobby"),
(3,3,3,3,3,3,"Hospital"),
(4,4,4,4,4,4,"Bosque"),
(5,5,5,5,5,5,"Tutorial"),
(6,6,6,6,6,6,"Lobby"),
(7,7,7,7,7,7,"Hospital"),
(8,8,8,8,8,8,"Bosque"),
(9,9,9,9,9,9,"Bosque"),
(10,10,10,10,10,10,"Lobby");
COMMIT;

-- Tabla Enemigos
SET AUTOCOMMIT=0;
INSERT INTO enemigo VALUES
(1,"Facelings","Entidad",20,3,10),
(2,"Facelings","Entidad",20,3,5),
(3,"Clumps","Trampa",5,1,6),
(4,"Spider","Phobia",10,2,2),
(5,"Facelings","Entidad",20,3,7),
(6,"Facelings","Entidad",20,3,1),
(7,"Smilers","Entidad",10,10,8),
(8,"Statue","Phobia",30,4,2),
(9,"Statue","Phobia",30,4,8),
(10,"Ambush","Entidad",50,10,3);
COMMIT;

-- Tabla Armas
SET AUTOCOMMIT=0;
INSERT INTO arma VALUES
(1,1,"Flashlight","distancia media",5),
(2,2,"Lighter","distancia corta",2),
(3,3,"Crossbow","distancia larga",8),
(4,4,"Crossbow","distancia larga",8),
(5,5,"Flashlight","distancia media",5),
(6,6,"Crossbow","distancia larga",8),
(7,7,"Bat","distancia corta",6),
(8,8,"Flashlight","distancia media",5),
(9,9,"Bat","distancia corta",6),
(10,10,"Lighter","distancia corta",2);
COMMIT;

-- Tabla NPC
SET AUTOCOMMIT=0;
INSERT INTO non_player VALUES
(1,"Crow"),
(2,"Crow"),
(3,"Viking"),
(4,"Witch"),
(5,"Witch"),
(6,"Viking"),
(7,"Witch"),
(8,"Crow"),
(9,"Hanged Man"),
(10,"Viking");
COMMIT;

-- Tabla Tienda
SET AUTOCOMMIT=0;
INSERT INTO tienda VALUES
(1,"Tienda Lobby"),
(2,"Tienda Hospital"),
(3,"Tienda Bosque"),
(4,"Tienda Bosque"),
(5,"Tienda Hospital"),
(6,"Tienda Bosque"),
(7,"Tienda Bosque"),
(8,"Tienda Lobby"),
(9,"Tienda Lobby"),
(10,"Tienda Lobby");
COMMIT;

-- Tabla Objetos
SET AUTOCOMMIT=0;
INSERT INTO objeto VALUES
(1,1,"Pocion Vida",10,15),
(2,2,"Pocion Escudo",5,20),
(3,3,"Pocion Stamina",3,10),
(4,4,"Pocion Escudo",5,20),
(5,5,"Pocion Escudo",5,20),
(6,6,"Pocion Vida",10,15),
(7,7,"Pocion Stamina",3,10),
(8,8,"Pocion Daño",4,20),
(9,9,"Pocion Vida",10,15),
(10,10,"Pocion Daño",4,20);
COMMIT;

-- Tabla Clase
SET AUTOCOMMIT=0;
INSERT INTO clase VALUES
(1,"Comun",80),
(2,"Rara",50),
(3,"Epica",30),
(4,"Legendaria",10),
(5,"Epica",30),
(6,"Comun",80),
(7,"Rara",50),
(8,"Comun",80),
(9,"Rara",50),
(10,"Comun",80);
COMMIT;

-- Tabla relacion
SET AUTOCOMMIT=0;
INSERT INTO nivel_objetos VALUES
(1,1,1),
(2,2,2),
(3,3,3),
(4,4,4),
(5,5,5),
(6,6,6),
(7,7,7),
(8,8,8),
(9,9,9),
(10,10,10);
COMMIT;

-- VIEWS

-- 1. El usuario con el mayor de veces completadas del juego
CREATE VIEW usuario_completado AS
SELECT usuario
FROM darkesttimes.usuario
WHERE Juego_completado = (SELECT MAX(Juego_completado) FROM usuario);

-- 2. Armas Legendarias
CREATE VIEW info_armas_nivel AS
SELECT a.nombre AS nombre_arma, a.tipo, a.daño
FROM nivel n
INNER JOIN arma a ON n.id_arma = a.id_arma;

-- 3. El enemigo que ha matado mas veces a los jugadores
CREATE VIEW enemigo_peligroso AS
SELECT nombre
FROM darkesttimes.enemigo
WHERE asesinatos = (SELECT MAX(asesinatos) FROM enemigo);

-- 4. El objeto consumible mas caro
CREATE VIEW objeto_caro AS
SELECT nombre
FROM darkesttimes.objeto
WHERE precio = (SELECT MAX(precio) FROM objeto);





