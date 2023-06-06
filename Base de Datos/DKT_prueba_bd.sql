DROP SCHEMA IF EXISTS darkesttimes_test;
CREATE SCHEMA darkesttimes_test;
USE darkesttimes_test;

-- Tabla de personaje
CREATE TABLE personaje(
id_personaje INT NOT NULL UNIQUE AUTO_INCREMENT comment "LLave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del personaje",
vida_max INT NOT NULL comment "Vida que puede llegar a tener el personaje",
vida_actual INT NOT NULL comment "Vida que tiene en el momento el personaje",
ataque INT NOT NULL comment "ataque del personaje",
suerte INT NOT NULL comment "Suerte del personaje",
stamina INT NOT NULL comment "Stamina del personaje",
multiplicador_monedas INT NOT NULL comment "Multiplicador de las monedas",
muertes INT NOT NULL comment "Muertes que lleva el personaje",
PRIMARY KEY (id_personaje))
ENGINE=InnoDB;

-- Tabla usuario
CREATE TABLE usuario(
id_usuario INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
correo VARCHAR(45) NOT NULL comment "Correo del usuario",
contraseña VARCHAR(45) NOT NULL comment "Password",
horas_jugadas INT NOT NULL comment "Horas que lleva dela sesion",
Juego_completado INT NOT NULL comment "Veces en las que se termino el juego",
PRIMARY KEY (id_usuario)
)ENGINE=InnoDB;

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
PRIMARY KEY (id_arma))
ENGINE=InnoDB;

-- Tabla de Tiendas
CREATE TABLE tienda(
id_tienda INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nivel VARCHAR(45) NOT NULL comment "Nombre del nivel en el que esta la tienda Lobby, Hospital o Bosque",
PRIMARY KEY (id_tienda))
ENGINE=InnoDB;

-- Tabla Objeto
CREATE TABLE objeto(
id_objeto INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del objeto, como por ejemplo, rifle, espada, linterna, antorcha, posion",
duracion INT NOT NULL comment "Tiempo que dura el efecto del objeto",
precio INT NOT NULL comment "Precio del objeto en tienda",
PRIMARY KEY (id_objeto))
ENGINE=InnoDB;

-- Tabla de NPC
CREATE TABLE non_player(
id_npc INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del npc",
PRIMARY KEY (id_npc))
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

-- Tabla de Relacion: Nivel_Objetos
CREATE TABLE nivel_objetos(
id_nivelO INT NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_nivel INT NOT NULL comment "Llave foranea",
id_objeto INT NOT NULL comment "Llave foranea",
PRIMARY KEY (id_nivelO),
CONSTRAINT fk_nivelR FOREIGN KEY (id_nivel) REFERENCES nivel (id_nivel) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_objetoR FOREIGN KEY (id_objeto) REFERENCES objeto (id_objeto) ON DELETE RESTRICT ON UPDATE CASCADE)
ENGINE=InnoDB;