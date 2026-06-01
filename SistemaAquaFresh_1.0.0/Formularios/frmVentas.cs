using SistemaAquaFresh_1._0._0.Controlador;
using SistemaAquaFresh_1._0._0.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAquaFresh_1._0._0.Formularios
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();

        }

        private Cliente clienteSeleccionado = null;

        private void Buscar_Cliente_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que se haya seleccionado un elemento válido y que sea un objeto de la clase Cliente
            if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedItem is Cliente cliente)
            {
                // Guardamos el objeto completo en nuestra variable de control
                clienteSeleccionado = cliente;

                // RELLENO AUTOMÁTICO: Colocamos las propiedades del objeto directamente en tus TextBox
                txtCedula.Text = cliente.Id_cedula.ToString();
                txtApellido.Text = cliente.Apellido;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                txtTipoCliente.Text = cliente.Tipo_cliente;
                txtTipoPago.Text = cliente.Tipo_pago;
            }
            else
            {
                // Si se limpia el combo, limpiamos también los campos del formulario
                LimpiarCamposCliente();
            }
        }

        private void LimpiarCamposCliente()
        {
            clienteSeleccionado = null;
            //txtIdCliente.Clear();
            txtCedula.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtTipoCliente.Clear();
            txtTipoPago.Clear();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            LlenarComboBoxClientes();
            LlenarComboBoxProductos();

        }

        private void LlenarComboBoxClientes()
        {
            // Limpiamos cualquier vinculación previa
            comboBox1.DataSource = null;

            if (Venta_Controler.Lista_Clientes.Count > 0)
            {
                // Asignamos la lista que ya tiene el cliente que creamos en el controlador
                comboBox1.DataSource = Venta_Controler.Lista_Clientes;

                // Lo que el usuario verá en la lista desplegable
                comboBox1.DisplayMember = "Nombre";

                // El valor interno que representará esa opción (su ID único)
                comboBox1.ValueMember = "Id_cliente";

                // Iniciamos el combo sin ningún cliente seleccionado por defecto
                comboBox1.SelectedIndex = -1;
            }
        }

        private void LlenarComboBoxProductos()
        {
            // Similar al método de clientes, pero para productos
            cmbProductos.DataSource = null;
            if (Venta_Controler.Lista_Productos.Count > 0)
            {
                cmbProductos.DataSource = Venta_Controler.Lista_Productos;
                cmbProductos.DisplayMember = "Nombre";
                cmbProductos.ValueMember = "Id_producto";
                cmbProductos.SelectedIndex = -1;
            }
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. CONTROL DE ERRORES: Validar que se haya seleccionado un cliente del ComboBox
                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("Operación rechazada: Por favor, seleccione un cliente válido del menú desplegable.",
                                    "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. CONTROL DE ERRORES: Validar que se haya seleccionado un producto
                Producto productoElegido = (Producto)cmbProductos.SelectedItem;
                if (productoElegido == null)
                {
                    MessageBox.Show("Operación rechazada: Debe seleccionar un producto del inventario para procesar la venta.",
                                    "Producto Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. CONTROL DE ERRORES: Validar la cantidad ingresada (mayor a cero)
                if (!int.TryParse(txtCantidad.Text, out int cantidadValida) || cantidadValida <= 0)
                {
                    MessageBox.Show("Operación rechazada: Ingrese una cantidad numérica entera que sea mayor a cero.",
                                    "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. CONTROL DE ERRORES: Validar el precio pactado (permite valores como 0.70 para mayoristas)
                if (!decimal.TryParse(txtValor.Text, out decimal precioPactado) || precioPactado <= 0)
                {
                    MessageBox.Show("Operación rechazada: Ingrese un precio de venta válido y mayor a $0.00.",
                                    "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. Capturar los estados y métodos de pago desde la UI
                string estadoSeleccionado = cmbEstadoVenta.SelectedItem?.ToString() ?? "Realizada";
                string metodoPago = txtTipoPago.Text.Trim();

                // 6. ENVIAR AL CONTROLADOR: Pasamos los datos puros para que se actualice el stock global
                Venta_Controler.ProcesarVentaDirecta(clienteSeleccionado, productoElegido, cantidadValida, precioPactado, metodoPago, estadoSeleccionado);

                // =========================================================================
                // 7. EL CLIENTE RESPONDE EL PAGO: Consultamos el total calculado por la entidad
                // =========================================================================
                MessageBox.Show($"¡Venta procesada con éxito!\n\n" +
                                $"Cliente: {clienteSeleccionado.ObtenerNombreCompleto()}\n" +
                                $"Producto: {productoElegido.Nombre}\n" +
                                $"Precio Aplicado: ${clienteSeleccionado.Precio_venta_pactado:F2}\n" +
                                $"Cantidad: {clienteSeleccionado.Cantidad_comprada}\n" +
                                $"Monto Total Cobrado: ${clienteSeleccionado.TotalTransaccion:F2}\n" +
                                $"Estado final: {clienteSeleccionado.Estado_venta}",
                                "Transacción Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 8. LIMPIEZA: Dejar listos los campos de la transacción para el siguiente movimiento
                txtCantidad.Clear();
                txtValor.Clear();
                cmbProductos.SelectedIndex = -1;
            }
            catch (InvalidOperationException ex)
            {
                // Captura fallos controlados de lógica de negocio (como cuando el controlador detecta que no hay stock)
                MessageBox.Show(ex.Message, "Inventario Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Captura fallos críticos o de formato inesperados para proteger la ejecución del sistema
                MessageBox.Show($"Ocurrió un error inesperado al registrar la venta: {ex.Message}",
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposCliente();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            // 1. CONTROL DE ERRORES: Validar que la cantidad ingresada sea un número entero válido
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida mayor a cero antes de calcular el pago.",
                                "Cantidad Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            // 2. CONTROL DE ERRORES: Preparar el texto del precio para que soporte comas o puntos según tu Windows
            string precioTexto = txtValor.Text.Replace('.', ',');

            if (!decimal.TryParse(precioTexto, out decimal precioPactado) || precioPactado <= 0)
            {
                // Intento de respaldo usando formato invariante (por si acaso)
                if (!decimal.TryParse(txtValor.Text, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out precioPactado) || precioPactado <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un precio unitario válido (ejemplo: 0,60) antes de calcular el pago.",
                                    "Precio Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValor.Focus();
                    return;
                }
            }

            // =========================================================================
            // 3. LOGICA DEL BOTÓN: Multiplicar y pintar el resultado en txtTotalPago
            // =========================================================================
            decimal totalCalculado = cantidad * precioPactado;

            // Colocamos el resultado con formato de dos decimales fijados
            txtTotalPago.Text = totalCalculado.ToString("F2");
        }
    }
}
