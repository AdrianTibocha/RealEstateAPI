# RealEstate Api

Interfaz que provee un conjunto de servicios para realizar tareas de administracion sobre propiedades de lujo.

## Tecnologias

* Backend en .net5
* Base de datos en SQL Server

## Herramientas de ejecucion

* Visual Studio IIS Express
* Sql Server Management

## Servicios Backend

Una vez se inicie el api mediante Visual Studio se abrira una ventana en el navegador que reflejara el consumo de los endpoint del proyecto y permitira su ejecucion en un entorno de pruebas.

## Anotaciones

* Para la ejecucion del endpoint 'api/v1/Property/{attribute}/{value}/{filter}' los valores aceptados son:
  
  * attribute: name, address, codeinternal, price, year.
  * value: valor correspondiente al atributo, para (price, year) se espera un dato de tipo numerico, caso contrario se espera un dato de tipo cadena de caracteres
  * filter: condicion de busqueda, en caso de ser numerico se aceptan (equal, greaterthan, smallerthan ) y en caso de ser cadena de caracteres se acepta (equal, contains)

* La creacion de una propiedad en el endpoint 'api/v1/Property' debe tener relacionado un idOwner de un propietario (Owner) previamente creado
* En la carpeta configuration se encuentran scripts de creacion, configuracion e insercion de datos iniciales en sql server e imagen relacionando los servicios disponibles para su uso.
