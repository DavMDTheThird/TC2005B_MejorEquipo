USE darkesttimes;

-- Dummy Data

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

-- Tabla Usuario
SET AUTOCOMMIT=0;
INSERT INTO usuario VALUES
(1,1,"email@gmail0.com","dummy1","password1",5, 3, 1),
(2,2,"email@gmail1.com","dummy2","password2",16, 3, 5),
(3,3,"email@gmail2.com","dummy3","password3",24, 3, 2),
(4,4,"email@gmail3.com","dummy4","password4",87, 6, 4),
(5,3,"email@gmail4.com","dummy5","password5",2, 1, 6),
(6,4,"email@gmail5.com","dummy6","password6",1, 6, 3),
(7,1,"email@gmail6.com","dummy7","password7",23, 2, 10),
(8,2,"email@gmail7.com","dummy8","password8",8, 2, 8),
(9,1,"email@gmail8.com","dummy9","password9",6, 1, 4),
(10,1,"email@gmail9.com","dummy10","password10",3, 6, 2);
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

-- Tabla Clase
SET AUTOCOMMIT=0;
INSERT INTO clase VALUES
(1,"Comun", "arma", 80),
(2,"Rara","arma",50),
(3,"Epica","objeto",30),
(4,"Legendaria","arma",10),
(5,"Epica","objeto",30),
(6,"Comun","objeto",80),
(7,"Rara","arma",50),
(8,"Comun","objeto",80),
(9,"Rara","objeto",50),
(10,"Comun","objeto",80);
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
