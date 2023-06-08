DROP SCHEMA IF EXISTS darkesttimes_BD;
CREATE SCHEMA darkesttimes_BD;
USE darkesttimes_BD;

-- Tabla usuario
CREATE TABLE usuarios(
id_usuario INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
nombre VARCHAR(45) NOT NULL comment "Nombre del personaje",
correo VARCHAR(45) NOT NULL comment "Correo del usuario",
contraseña VARCHAR(45) NOT NULL comment "Password",
horas_jugadas SMALLINT NOT NULL comment "Horas que lleva dela sesion",
juegos_completados SMALLINT NOT NULL comment "Veces en las que se termino el juego",
muertes_totales SMALLINT NOT NULL comment "Veces que perdio el jugador",
PRIMARY KEY (id_usuario)
)ENGINE=InnoDB;


-- Tabla de personaje
CREATE TABLE personaje(
id_personaje INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT comment "LLave primaria",
vida_actual SMALLINT NOT NULL comment "Vida que tiene en el momento el personaje",
vida_max SMALLINT NOT NULL comment "Vida que puede llegar a tener el personaje",
nivel SMALLINT NOT NULL comment "El nivel en que se encuentra el personaje - progresion",
xp SMALLINT not NULL comment "Experiencia que tiene antes de subir de nivel",
suerte FLOAT NOT NULL comment "Suerte del personaje",
ataque SMALLINT NOT NULL comment "ataque del personaje",
stamina SMALLINT NOT NULL comment "Stamina del personaje",
inventario SMALLINT NOT NULL comment "Espacio de inventario",
multiplicador_monedas FLOAT NOT NULL comment "Multiplicador de las monedas",
monedas SMALLINT NOT NULL comment "Cantidad de monedas adquiridas",
muertes SMALLINT NOT NULL comment "Muertes que lleva el personaje",
PRIMARY KEY (id_personaje))
ENGINE=InnoDB;


-- Tabla inventario
CREATE TABLE inventario(
id_inventario INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
pocionQM SMALLINT NOT NULL comment "Las veces que tiene el elemento, 0 No tiene, 1+ las que tenga",
escudoQM SMALLINT NOT NULL,
antorchaQM SMALLINT NOT NULL,
linternaQM SMALLINT NOT NULL,
mecheroQM SMALLINT NOT NULL,
bengala_gunQM SMALLINT NOT NULL,
ballesta BOOL NOT NULL,
espada BOOL NOT NULL,
bat BOOL NOT NULL,
staff BOOL NOT NULL,
rifle BOOL NOT NULL,
PRIMARY KEY (id_inventario)
)ENGINE=InnoDB;


-- Tabla de Nivel
CREATE TABLE nivel(
id_nivel INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT comment "LLave primaria",
index_nivel SMALLINT NOT NULL comment "indice de donde se encuentra el personaje en guardada",
index_forest_lvl SMALLINT NOT NULL comment "nivel en que se encuentra la mazmorra del bosque",
index_hospital_lvl SMALLINT NOT NULL comment "nivel en que se encuentra la mazmorra del hospital",
PRIMARY KEY (id_nivel)
)ENGINE=InnoDB;

-- Tabla de Checkpoints
CREATE TABLE checkpoints(
id_checkpoint INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
id_usuario INT UNSIGNED NOT NULL comment "Llave foranea",
id_personaje INT UNSIGNED NOT NULL comment "Llave foranea",
id_inventario INT UNSIGNED NOT NULL comment "Llave foranea",
id_nivel INT UNSIGNED NOT NULL comment "Llave foranea",
fecha date NOT NULL,
PRIMARY KEY (id_checkpoint),
CONSTRAINT fk_id_usuario FOREIGN KEY (id_usuario) REFERENCES usuarios (id_usuario) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_id_personaje FOREIGN KEY (id_personaje) REFERENCES personaje (id_personaje) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_id_inventario FOREIGN KEY (id_inventario) REFERENCES inventario (id_inventario) ON DELETE RESTRICT ON UPDATE CASCADE,
CONSTRAINT fk_id_nivel FOREIGN KEY (id_nivel) REFERENCES nivel (id_nivel) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB;

-- Tabla de Enemigos
CREATE TABLE enemigos(
id_enemigo SMALLINT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT comment "Llave primaria",
asesinatos INT UNSIGNED NOT NULL comment "Veces que ha matado al jugador",
PRIMARY KEY (id_enemigo)
)ENGINE=InnoDB;

-- Tabla de Enemigos-nombres
CREATE TABLE enemigos_nombres(
id_enemigo SMALLINT UNSIGNED NOT NULL comment "Llave foranea",
nombre_enemigo VARCHAR(45) NOT NULL comment "Nombre de los enemigos",
CONSTRAINT fk_id_enemigo FOREIGN KEY (id_enemigo) REFERENCES enemigos (id_enemigo) ON DELETE RESTRICT ON UPDATE CASCADE
)ENGINE=InnoDB;



USE darkesttimes_BD;
SELECT * FROM usuarios;