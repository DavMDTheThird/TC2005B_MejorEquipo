USE darkesttimes_BD;

-- VIEWS
-- Usuarios con mas partidas completadas
CREATE VIEW usuarios_juegosGanados AS
SELECT nombre, juegos_completados FROM darkesttimes_BD.usuarios
ORDER BY juegos_completados DESC;
SELECT * FROM usuarios_juegosGanados;

SELECT * FROM usuarios;

-- Mobs que han matado mas al usuario
CREATE VIEW mobs_masAsesinatos AS
SELECT enemigos_nombres.nombre_enemigo, enemigos.asesinatos FROM enemigos_nombres
JOIN enemigos ON enemigos_nombres.id_enemigo = enemigos.id_enemigo ORDER BY asesinatos DESC;
SELECT * FROM mobs_masAsesinatos;

-- Usuario que ha metido mas horas al juego
CREATE VIEW usuario_viciado AS
SELECT nombre, horas_jugadas FROM darkesttimes_BD.usuarios
ORDER BY horas_jugadas DESC;
SELECT * FROM usuario_viciado;

-- Usuarios con mas muertes acumuladas
CREATE VIEW usuario_masMalo AS
SELECT nombre, muertes_totales FROM darkesttimes_BD.usuarios
ORDER BY muertes_totales DESC;
SELECT * FROM usuario_masMalo;

-- Usuarios y nombre
CREATE VIEW usuarios_nombre AS
SELECT id_usuario, nombre, correo FROM darkesttimes_BD.usuarios;
SELECT * FROM usuarios_nombre;


USE darkesttimes_BD;
CREATE VIEW get_id_personaje AS
SELECT p.id_personaje
FROM darkesttimes_BD.checkpoints AS c
JOIN darkesttimes_BD.personaje AS p ON p.id_personaje = c.id_checkpoint
JOIN darkesttimes_BD.usuarios AS u ON c.id_usuario = u.id_usuario
WHERE u.id_usuario = 10 ORDER BY p.id_personaje DESC LIMIT 1;
SELECT * FROM get_id_personaje;



USE darkesttimes_BD;
SELECT * FROM darkesttimes_BD.usuarios;
SELECT * FROM darkesttimes_BD.personaje;
SELECT * FROM darkesttimes_BD.checkpoints;
SELECT * FROM darkesttimes_BD.inventario;

SELECT *
FROM darkesttimes_BD.checkpoints AS c
JOIN darkesttimes_BD.personaje AS p ON p.id_personaje = c.id_checkpoint
JOIN darkesttimes_BD.usuarios AS u ON c.id_usuario = u.id_usuario
WHERE u.id_usuario = 10 ORDER BY p.id_personaje DESC LIMIT 1;

SELECT p.vida_actual, p.vida_max, p.nivel, p.xp, p.suerte, p.ataque, p.stamina,
       p.inventario, p.multiplicador_monedas, p.monedas
FROM darkesttimes_BD.checkpoints AS c
JOIN darkesttimes_BD.personaje AS p ON p.id_personaje = c.id_checkpoint
JOIN darkesttimes_BD.usuarios AS u ON c.id_usuario = u.id_usuario
WHERE u.id_usuario = 10 ORDER BY p.id_personaje DESC LIMIT 1;



