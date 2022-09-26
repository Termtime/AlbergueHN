# AlbergueHN
Aplicación de escritorio para llevar inventario y datos de personas de un Albergue, desarrollado en voluntariado por estudiantes de la carrera de Ingeniería en Sistemas de UNAH-VS junto al apoyo del Ingeniero Norman Alberto Cubilla como respuesta a los huracanes ETA e IOTA del 2020.

# Instalación
En la sección de lanzamientos en GitHub, puede encontrar la lista de versiones de la aplicación. [Descargar aquí](https://github.com/Termtime/AlbergueHN/releases/tag/v1.2.2)

## Instalar la base de datos y crear nuestro usuario SQL
AlbergueHN está basado en una base de datos MySQL, puedes descargar MySQL para Windows desde [aqui](https://dev.mysql.com/downloads/installer/)

AlbergueHN requiere que se cree un usuario llamado `albergue` en el servidor MySQL y que se le den los permisos requeridos al schema `unahvs_al`

NOTA: Recuerda anotar la contraseña utilizada, ya que la utilizaremos más adelante en la configuración inicial de AlbergueHN

![configUsuarioSQL](https://i.imgur.com/XU09hwI.png)

## Configuración de tablas, stored procedures y functions

- Baja el script `albergue_hn_schema_con_datos.sql` que se encuentra en la carpeta `DB` de este repositorio, o alternativamente que se encuentre en los archivos del lanzamiento de la versión de AlbergueHN
  - Esta versión "con datos" contiene datos iniciales para una experiencia más rápida de configurar, esta incluye los 18 departamentos de Honduras, y un usuario admin para que puedas ingresar con el app.
    - Si optaste por la versión sin datos, recuerda mirar la sección: `Primer Login y cómo crear nuevos usuarios de AlbergueHN`, ya que no podrás entrar con el app aún.
- Conectate a la base de datos utilizando el usuario `root`
  - También puedes utilizar el usuario `albergue` recientemente creado, pero ten en cuenta que pueden haber pasos extra de configuración necesarios que no están detallados en esta guía. (Así como errores corriendo el script por configuraciónes de seguridad estrictas del servidor MySQL)
- Estás listo para iniciar!

## Conectando AlbergueHN a tu base de datos

Una vez creada y configurada nuestra base de datos, procedemos a abrir AlbergueHN, nos encontraremos la pantalla de inicio de sesión:
![loginPage](https://i.imgur.com/7jCBLJS.jpg)

Pero antes de hacer nuestro primer inicio de sesión, debemos conectar AlbergueHN a nuestra recien configurada base de datos, podemos hacer eso haciendo click en el ícono de configuración en la esquina inferior derecha. Esto abrirá la siguiente pantalla:
![configConexionPage](https://i.imgur.com/yxwHSYR.jpg)

Aquí ingresaremos los datos de conexión a *nuestra base de datos*, el usuario será albergue, y la contraseña será la que configuramos cuando creamos nuestro usuario SQL en el primer paso.

Una vez conectados a nuestra base de datos, procederemos a iniciar sesión para poder utilizar el sistema

## Primer Login y cómo crear nuevos usuarios de AlbergueHN

Si utilizaste la versión del schema con datos, esto incluirá un usuario para AlbergueHN por defecto
```
Identidad: 0501202012345
contraseña: 12345
```

Puedes cambiar estos datos antes de ejecutar el script de creación.

Si optaste por la versión solo del schema, tendrás que ir manualmente a la base de datos y agregar manualmente un registro a la tabla `usuarios`, y así para cada nuevo usuario que quieras agregar.

# Creando nuevas versiones

Si deseas apoyar y contribuir a AlbergueHN, te invito a hacer un fork de este proyecto y agregar tus cambios para que tengas control total del flujo de desarrollo.

Por el momento el versionamiento de AlbergueHN es básico, recuerda hacer tu respectivo commit de haciendo el version bump en la [siguiente parte del código](https://github.com/Termtime/AlbergueHN/blob/fa149ce97b4c0cd0cd0e4fc3e20e9d8f042aa59c/AlbergueHN/Source/Forms/PantallaPrincipal.cs#L742), y si gustas también agregarte a la lista de desarrolladores que han apoyado este proyecto

## Empaquetando y lanzando

Utilizamos [InnoSetup](https://jrsoftware.org/isdl.php#stable) para crear un archivo de instalación ejecutable para Windows.

Para empaquetar una nueva versión de AlbergueHN:
- Corre Visual Studio
- Clona el repositorio y abre la solución
- En la pestaña `Compilar` (`Build` en inglés) seleccióna la opción de `Compilar Solución`
- Abre InnoSetup
- Carga el script de creación de instalador
- Presiona la tecla en la barra superior que dice "Compile", esto debería crear un instalador en la ubicación de tu proyecto
- Distribuye!

# Equipo de desarrollo

* Mario Fernando Mejia Inestroza
* Jorge Alejandro Arita Marthel
* Andrea Nohemy Archila Cáceres
* Maria Fernanda Barahona Duarte
* Brénedin Enrique Gómez Núñez
* Carlos Adonay Menjivar Alemán
* Jonathan Javier Sevilla
* Raúl Edgardo Cruz

# Funciones y Caracteristicas

* Sistema de Login
* Conexion a base de datos configurable
* Registro de personas y productos
* Despacho e ingreso de inventario
* Creacion de productos e ingreso de personas
* Exportar inventario de productos a excel

# Imagenes

* Pantalla principal

![mainPage](https://i.imgur.com/5ySuUYA.jpg)

* Despacho de productos

![despachoProductosPage](https://i.imgur.com/ty1JkSu.jpg)
