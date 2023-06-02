USE darkesttimes;


-- VIEWS

-- 1. El usuario con el mayor de veces completadas del juego
CREATE VIEW usuario_completado AS
SELECT usuario, Juego_completado  FROM darkesttimes.usuario
WHERE Juego_completado = (SELECT MAX(Juego_completado) FROM usuario);
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
WHERE asesinatos = (SELECT MAX(asesinatos) FROM enemigo);
SELECT * FROM enemigo_peligroso;
DROP VIEW enemigo_peligroso;

-- 4. El objeto consumible mas caro
CREATE VIEW objeto_caro AS
SELECT nombre, precio FROM darkesttimes.objeto
WHERE precio = (SELECT MAX(precio) FROM objeto);
SELECT * FROM objeto_caro;
DROP VIEW objeto_caro;

-- Busquedas que se implementaran para el videojuego
-- 5. obtener el ultimo checkpoint registrado para aparecer en pantalla, nos ayudara en cambio de scene
SELECT * FROM







