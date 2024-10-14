using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace ActualizarClienteDapper
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();
        
        public Form1()
        {
            InitializeComponent();
        }

        public void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodo();
            dgvCustomer.DataSource = cliente;
        }

        public void btnObtenerID_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerPorID(tboxObtenerID.Text);
            dgvCustomer.DataSource = new List<Customers> { cliente };
            if (cliente != null)
            {
                RellenarForm(cliente);
            }
        }

        private void RellenarForm(Customers customers)
        {
            txtID.Text = customers.Id.ToString();
            txtNombre.Text = customers.Nombre;
            txtDescripcion.Text = customers.Descripcion;
            txtPrecio.Text = customers.Precio.ToString();
            txtStock.Text = customers.Stock.ToString();
            txtMarca.Text = customers.Marca;
            txtCategoria.Text = customers.Categoria;
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                Id = int.TryParse(txtID.Text, out var id) ? id : 0,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.TryParse(txtPrecio.Text, out var precio) ? precio : 0m,
                Stock = int.TryParse(txtStock.Text, out var stock) ? stock : 0,
                Marca = txtMarca.Text,
                Categoria = txtCategoria.Text,

            };
            return nuevo;
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            var clienteActualizado = CrearCliente();
            var actualizados = customerR.ActualizarCliente(clienteActualizado);
            var cliente = customerR.ObtenerPorID(clienteActualizado.Id.ToString());
            dgvCustomer.DataSource = new List<Customers> { cliente };


            MessageBox.Show($"Filas actualizadas {actualizados} , {clienteActualizado.Id}");

        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Para permitir solo dígitos, el punto decimal y el carácter de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Si no es válido, cancela el carácter (evita que se ingrese)
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Para verificar si el carácter ingresado no es un control (como Backspace) y no es un dígito
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es válido, cancela el carácter (evita que se ingrese)
                e.Handled = true;
            }
        }

    }
}
