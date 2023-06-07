USE darkesttimes_BD;

-- VIEWS
-- Usuarios con mas partidas completadas
CREATE VIEW usuarios_juegosGanados AS
SELECT nombre, juegos_completados FROM darkesttimes_BD.usuarios
ORDER BY juegos_completados DESC;
SELECT * FROM usuarios_juegosGanados;

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

