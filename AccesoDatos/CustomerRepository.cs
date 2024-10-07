using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public List<Customers> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String SeleccionarTodo = "";
                SeleccionarTodo = SeleccionarTodo + "SELECT [Id] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "      ,[Nombre] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "      ,[Descripcion] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "      ,[Precio] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "      ,[Stock] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "      ,[Marca] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "      ,[Categoria] " + "\n";
                SeleccionarTodo = SeleccionarTodo + "  FROM [dbo].[Productos]";
                var cliente = conexion.Query<Customers>(SeleccionarTodo).ToList();
                return cliente;
            }
        }

        public Customers ObtenerPorID(string id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {
                String seleccionarPorID = "";
                seleccionarPorID = seleccionarPorID + "SELECT [Id] " + "\n";
                seleccionarPorID = seleccionarPorID + "      ,[Nombre] " + "\n";
                seleccionarPorID = seleccionarPorID + "      ,[Descripcion] " + "\n";
                seleccionarPorID = seleccionarPorID + "      ,[Precio] " + "\n";
                seleccionarPorID = seleccionarPorID + "      ,[Stock] " + "\n";
                seleccionarPorID = seleccionarPorID + "      ,[Marca] " + "\n";
                seleccionarPorID = seleccionarPorID + "      ,[Categoria] " + "\n";
                seleccionarPorID = seleccionarPorID + "  FROM [dbo].[Productos] " + "\n";
                seleccionarPorID = seleccionarPorID + "  WHERE Id = @Id";

                var cliente = conexion.QueryFirstOrDefault<Customers>(seleccionarPorID, new { Id = id });
                return cliente;
            }
        }

        public int ActualizarCliente(Customers customers)
        {
            using(var conexion = DataBase.GetSqlConnection())
            {
                String actualizarCustomer = "";
                actualizarCustomer = actualizarCustomer + "UPDATE [dbo].[Productos] " + "\n";
                actualizarCustomer = actualizarCustomer + "   SET [Id] = @Id " + "\n";
                actualizarCustomer = actualizarCustomer + "      ,[Nombre] = @Nombre " + "\n";
                actualizarCustomer = actualizarCustomer + "      ,[Descripcion] = @Descripcion " + "\n";
                actualizarCustomer = actualizarCustomer + "      ,[Precio] = @Precio " + "\n";
                actualizarCustomer = actualizarCustomer + "      ,[Stock] = @Stock " + "\n";
                actualizarCustomer = actualizarCustomer + "      ,[Marca] = @Marca " + "\n";
                actualizarCustomer = actualizarCustomer + "      ,[Categoria] = @Categoria " + "\n";
                actualizarCustomer = actualizarCustomer + " WHERE Id = @Id";

                var actualizadas =
                 conexion.Execute(actualizarCustomer, new
                 {
                     Id = customers.Id,
                     Nombre = customers.Nombre,
                     Descripcion = customers.Descripcion,
                     Precio = customers.Precio,
                     Stock = customers.Stock,
                     Marca = customers.Marca,
                     Categoria = customers.Categoria,
                 });
                return actualizadas;
            }
        }

    }
}
