# TC2005B_MejorEquipo_5 Repositorio con toda la implementación del videojuego Darkest Times
## Integrantes
- David Medina Domínguez A01783155

- Juan Pablo Cruz Rodriguez A01783208

- Angel Adrian Afonso Castellanos A01782545

- Daniel Soult Gómez A01782985

## Resumen
En este repositorio se podrá encontrar un resumen, prototipo, desarrollo y producto final de la creación de nuestro videojuego RPG llamado 'Darkest Times'. No solo eso, pero también la interconexión entre el videojuego con una base de datos para recopilar información e implementar un sistema de guardado, iniciar sesión y registro. También se hizo una interconexión con una página web para que se pueda acceder al videojuego de forma remota dado que es requerimiento que el videojuego tenga que estar hospedado en un servidor. Finalmente, esto se puede llevar a cabo mediante la conexión de estos elementos con la introducción de una API que comunique entre los deferentes elementos mencionados.

## Tabla de contenidos

- [TC2005B\_MejorEquipo\_5 Repositorio con toda la implementación del videojuego Darkest Times](#tc2005b_mejorequipo_5-repositorio-con-toda-la-implementación-del-videojuego-darkest-times)
  - [Integrantes](#integrantes)
  - [Resumen](#resumen)
  - [Tabla de contenidos](#tabla-de-contenidos)
  - [Manual de uso](#manual-de-uso)
    - [Instalación versión 1](#instalación-versión-1)
      - [MySQL](#mysql)
      - [Servidor](#servidor)

## Manual de uso

Para poder jugar el videojuego sin ningun problema van a haber dos opciones

### Instalación versión 1

Para poder instalar y poder jugar el videojuego completamente en la web, con un servidor y base de datos local, se deben tener los siguientes elementos instalados:
- Node.js -> Nos va a servir para empezar el servidor que comunicara entre el videojuego, base de datos y web mediante la API.
- nodemon -> Con nodeJs instalado, instalar este paquete porque este elemento es que realmente nos va a iniciar el serivdor, instalarlo después de haber instalado nodeJS.
- mysql2 -> Con nodeJs instalado, instalar este paquete porque este elemento ayudara con la comunicación base de datos y la API.
- MySQL -> Se debe de instalar MySQL, preferiblemente el workbench, para poder generar la base de datos, al igual que para dar permisos de usuario para que pueda acceder y utilizar la base de datos.

#### MySQL

Lo siguiente que vamos a hacer, después de haber instalado todos los elementos y paquetería para que el servidor funcione plenamente, vamos a tener que entrar al workbench instalado e iniciar una nueva conexión, dejar el puerto predeterminado y poner cualquier nombre en la conexión. Una vez inicializado eso, se va a tener que correr todas las tablas, datos base y vistas para que el programa corra debidamente. Estos se pueden encontrar aquí en el repositorio dentro de la carpeta 'base de datos'.

Finalmente, se tiene que inicializar el usuario con el que vamos a tener acceso a la información. Dicho esto nos tenemos que ir a 'Administration' y después a 'Users and privileges', para a continuación agregar un nuevo usuario con el nombre de: '<span style="color: #00FF66;">test_API</span>', el nombre si importa, y poner la contraseña de: '<span style="color: #00FF66;">Hola_123</span>', la contraseña también importa. Si es necesario cambiar la contraseña, nombre de usuario, o nombre del schema de la base de datos, es necesario también cambiarlo dentro de la carpeta 'app.js' dentro de la carpeta de "Pagina Web", ya que es aquí donde se establecerá el medio de comunicación entre la base de datos - API - Servidor.

#### Servidor

Lo siguiente que se va a tener que hacer es prender el serivdor, pero para instalar los paquetes mencionados, se tiene que primero instalar la configuracion base del serivdor. Solo se tiene que poner la siguiente linea de comando en la terminal (dentro de la carpeta Pagina Web): '<span style="color: #00FF66;">npm init</span>', dar enter a todo y esperar a que termine la ocnfiguración. Despues de que se halla terminado de instalar, se requieren instalar las paqueterias mencionadas, principalmente nodemon y mysql2. Estas se pueden instalar de la siguiente manera: '<span style="color: #00FF66;">npm install nodemon</span>' y '<span style="color: #00FF66;">npm install mysql2</span>'. Es recomendable instalar las otras paqueterias que vienen enlistadas en 'package.json' para su mejor experiencia. 

Finalmente se va a tener que prender el servidor con el comando: '<span style="color: #00FF66;">npm start</span>'. Si ocurre que el servidor no se inicia y no reconoce el comando 'start', se tendrá que escribir la siguiente linea de codigo: '<span style="color: #00FF66;">"start": "nodemon app.js",</span>' abajo de la linea: '<span style="color: #00FF66;">"scripts": {</span>'.

#### Instrucciones del Prototipo

A continuacion se mostrara una serie de pasos para reconocer el prototipo V1, el cual lleva la mayoria de requerimientos funcionales completos:

<p style=text-align:justify>

1. Identificamos que la carpeta de Darkest Times Alpha es la carpeta que contiene el juego, al igual que los elementos como assets y escenas.

</p>
<p style=text-align:justify>

2. Abre Unity Hub y elige la opcion de abrir un proyecto. Selecciona la carpeta mencionada en el punto numero 1. Tambien verifica que tengas la version 2021.3.23.f1 instalada en tu equipo.

</p>
<p style=text-align:justify>

3. Abre el proyecto.

</p>
<p style=text-align:justify>

4. Una vez dentro de unity en la carpeta de assets, identifica la carpeta Scenes. Dentro de esta carpeta encontraras otra que se llama ***PrincipalScenes***, la cual contiene todas las escenas en las que principalmete se han trabajado.

</p>
<p style=text-align:justify>

5. Te invitamos a pobrar cada una de las escenas principales para observar sus funcionalidades. **Importante:** Para entender las mecanicas de los niveles, te recomendamos leer el GDD_Template para tener un mejor conocimientos de nuestro desarrollo.
[Documento GDD](/Videojuego/GDD_Template.md)

</p>
<p style=text-align:justify>

6. Actualmente el juego esta formado por las siguientes escenas principales: Tutorial,Lobby,Hospital,Tienda y Dentro Tienda. El orden para probar el videojuego es asi como se presentan cada una de las escenas.

</p>
<p style=text-align:justify>

7. A parte de las escenas principales, encontaras mas carpetas como ***ExtraScenes***, ***Menu***, y ***PruebasDavid***, en las cuales se han trabajado funcionalidades que enriquecen nuestro videojuego como aspectos graficos y mecanicos.

</p>
<p style=text-align:justify>

Recordamos que es un prototipo, por lo tanto el juego esta una etapa muy temprana-media de desarrollo y no es la version completa.

</p>


Y listo, ya quedo la base de datos y el servidor esta prendido, solo queda ingresar a la pagina web para poder observar las graficas de estadisticas y jugar el videojuego.
