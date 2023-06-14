USE darkesttimes_BD;

-- Dummy Data

-- Tabla usuarios
SET AUTOCOMMIT=0;
INSERT INTO usuarios VALUES
(1, "David", "test1@gmail.com", "OFW23%$DWW", 20, 1, 15),
(2, "Gil", "test2@gmail.com", "vekjSgui%__", 16, 2,32),
(3, "Angel", "test3@gmail.com", "RfffDSDA9856", 21, 0, 21),
(4, "Alan", "test4@gmail.com", "@$#$IKQkdjbde", 10, 4, 10),
(5, "Juanpa", "test5@gmail.com", "Hola_1029312fe", 15, 1, 18),
(6, "Oswa", "test6@gmail.com", "DWLJAD123456", 7, 3, 27),
(7, "Daniel", "test7@gmail.com", "MIra44!@4567", 5, 1, 14),
(8, "Octavio", "test8@gmail.com", "dwkjabdk$%$_", 10, 6, 29),
(9, "Andrea", "test9@gmail.com", "HolaComoEstas", 13, 1, 16),
(10, "Esteban", "test10@gmail.com", "987654321", 19, 10, 53);
COMMIT;

-- Tabla personaje
SET AUTOCOMMIT=0;
INSERT INTO personaje VALUES
(1, 1, 10, 10, 3, 99, 0.80, 5, 3, 6, 1, 30, 6),
(2, 1, 3, 6, 5, 30, 0.70, 4, 5, 6, 2, 90, 10),
(3, 2, 5, 8, 2, 45, 0.60, 3, 2, 6, 3, 15, 3),
(4, 4, 8, 12, 4, 60, 0.75, 7, 4, 6, 4, 45, 5),
(5, 3, 4, 10, 1, 75, 0.85, 2, 1, 6, 5, 60, 12),
(6, 1, 7, 14, 6, 20, 0.55, 6, 6, 6, 6, 75, 8),
(7, 3, 6, 9, 2, 85, 0.90, 5, 2, 6, 7, 90, 15),
(8, 4, 2, 5, 4, 50, 0.65, 4, 4, 6, 8, 105, 20),
(9, 2, 9, 13, 5, 35, 0.50, 9, 5, 6, 9, 30, 4),
(10, 2, 1, 7, 3, 70, 0.80, 1, 3, 6, 10, 15, 2);
COMMIT;

-- Tabla inventario
SET AUTOCOMMIT=0;
INSERT INTO inventario VALUES
(1, 3, 1, 1, 1, 0, 0, TRUE, FALSE, FALSE, FALSE, TRUE),
(2, 1, 1, 1, 1, 0, 1, TRUE, FALSE, FALSE, FALSE, TRUE),
(3, 1, 2, 1, 1, 0, 2, TRUE, FALSE, FALSE, FALSE, TRUE),
(4, 1, 3, 1, 1, 0, 3, TRUE, FALSE, FALSE, FALSE, TRUE),
(5, 1, 1, 2, 1, 0, 4, TRUE, FALSE, FALSE, FALSE, TRUE),
(6, 1, 1, 3, 1, 0, 5, TRUE, FALSE, FALSE, FALSE, TRUE),
(7, 1, 1, 1, 2, 0, 6, TRUE, FALSE, FALSE, FALSE, TRUE),
(8, 1, 1, 1, 3, 0, 0, TRUE, TRUE, FALSE, FALSE, TRUE),
(9, 1, 1, 1, 1, 1, 1, TRUE, TRUE, FALSE, FALSE, TRUE),
(10, 1, 1, 1, 1, 1, 2, TRUE, TRUE, FALSE, FALSE, TRUE);
COMMIT;



-- Tabla nivel
SET AUTOCOMMIT=0;
INSERT INTO nivel VALUES
(1, 2, 3, 4),
(2, 1, 1, 2),
(3, 1, 3, 4),
(4, 3, 2, 3),
(5, 2, 1, 5),
(6, 3, 1, 4),
(7, 4, 5, 3),
(8, 4, 3, 2),
(9, 4, 2, 1),
(10, 4, 3, 1);
COMMIT;

-- Tabla checkpoints
SET AUTOCOMMIT=0;
INSERT INTO checkpoints VALUES
(1, 1, 1, 6, 3, '2023-07-22'),
(2, 2, 2, 6, 5, '2023-05-26'),
(3, 3, 3, 6, 3, '2023-09-15'),
(4, 4, 4, 6, 4, '2023-11-10'),
(5, 5, 5, 6, 2, '2023-03-07'),
(6, 6, 6, 6, 1, '2023-12-19'),
(7, 7, 7, 6, 4, '2023-08-30'),
(8, 8, 8, 6, 5, '2023-06-08'),
(9, 9, 9, 6, 2, '2023-04-12'),
(10, 10, 10, 6, 3, '2023-01-03');
COMMIT;

-- Tabla enemigos
SET AUTOCOMMIT=0;
INSERT INTO enemigos VALUES
(1, 7),
(2, 25),
(3, 1),
(4, 12),
(5, 18),
(6, 5),
(7, 9),
(8, 3),
(9, 14),
(10, 22);
COMMIT;

-- Tabla enemigos-nombre
SET AUTOCOMMIT=0;
INSERT INTO enemigos_nombres VALUES
(1, "Araña"),
(2, "Araña venenosa"),
(3, "Estatua"),
(4, "Oculista"),
(5, "The Sculpture"),
(6, "Bacteria"),
(7, "Howler"),
(8, "Windows"),
(9, "Facelings"),
(10, "Hound");
COMMIT;
