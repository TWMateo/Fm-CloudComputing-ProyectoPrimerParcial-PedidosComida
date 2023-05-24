// See https://aka.ms/new-console-template for more information
using PedidosComida.UAPI;
using PedidosComida.Modelos;
var uapi = new Crud<Cliente>();
Console.WriteLine("Hello, World!");
//***AL COLOCAR EL 0 EN LOS ID ESTAMOS DICIENDO QUE ESTOS SE AUTOINCREMENTEN SEGUN EL ULTIMO VALOR
//DEL ULTIMO DATO***//

//ACTUALIZAR DATOS -> CONSULTO EL DATO, MODIFICO Y LUEGO ACTUALIZO
var clientes = uapi.Select("https://localhost:7212/api/Clientes");
var cli = uapi.Select_ById("https://localhost:7212/api/Clientes", 1);

cli.nombre = "Maria";
cli.apellido = "Muenala";
cli.cedula = "1213";

uapi.Update("https://localhost:7212/api/Clientes", 1, cli);

////CREO UN NUEVO CLIENTE
//var ncli = new Cliente
//{
//    nombre = "MayDay",
//    apellido = "Parker",
//    cedula = "1111",
//    telefono = "09",
//    IdCliente = 0
//};
//var nuevoPais = uapi.Insert("https://localhost:7212/api/Clientes", ncli);

////BORRAR EL PAIS SEGUN EL ID
//uapi.Delete("https://localhost:7212/api/Clientes", 3);

//CREO UN NUEVO CANTON
var pedido = new Crud<PedidoComida>();
var nuevoPedido = pedido.Insert("https://localhost:7212/api/PedidoComidas", new PedidoComida
{
    Descripcion = "Papas Fritas",
    Total = 2.75,
    ClienteIdCliente = 1,
    Id = 0
});


