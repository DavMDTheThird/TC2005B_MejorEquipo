USE darkesttimes;


-- VIEWS

-- 1. Los usuarios con el mayor de veces completadas del juego
CREATE VIEW usuario_completado AS
SELECT usuario, Juego_completado FROM darkesttimes.usuario
ORDER BY Juego_completado DESC LIMIT 5;
SELECT * FROM usuario_completado;
DROP VIEW usuario_completado;

-- 2. Armas Legendarias
CREATE VIEW info_armas_nivel AS
SELECT a.nombre AS nombre_arma, a.tipo, a.daño
FROM nivel n INNER JOIN arma a ON n.id_arma = a.id_arma;
SELECT * FROM info_armas_nivel;
DROP VIEW info_armas_nivel;

-- 3. El enemigo que ha matado mas veces a los jugadores
CREATE VIEW enemigo_peligroso AS
SELECT nombre, asesinatos FROM darkesttimes.enemigo
ORDER BY asesinatos DESC LIMIT 5;
SELECT * FROM enemigo_peligroso;
DROP VIEW enemigo_peligroso;

-- 4. El objeto consumible mas caro
CREATE VIEW objeto_caro AS
SELECT nombre, precio FROM darkesttimes.objeto
WHERE precio = (SELECT MAX(precio) FROM objeto);
SELECT * FROM objeto_caro;
DROP VIEW objeto_caro;

-- 5. Jugadores con mas horas jugadas
CREATE VIEW usuario_masRata AS
SELECT usuario, horas_jugadas FROM darkesttimes.usuario
ORDER BY horas_jugadas DESC LIMIT 10;
SELECT * FROM usuario_masRata;
DROP VIEW usuario_masRata;

-- 6. Jugadores con mas easter eggs
CREATE VIEW usuario_masEggs AS
SELECT usuario, easter_eggs FROM darkesttimes.usuario
ORDER BY easter_eggs DESC LIMIT 10;
SELECT * FROM usuario_masEggs;
DROP VIEW usuario_masEggs;

-- Busquedas que se implementaran para el videojuego
-- 5. obtener el ultimo checkpoint registrado para aparecer en pantalla, nos ayudara en cambio de scene
-- SELECT * FROM darkesttimes.checkpoint WHERE id_personaje







