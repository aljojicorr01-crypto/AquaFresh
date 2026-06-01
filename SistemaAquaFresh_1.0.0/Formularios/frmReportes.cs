using SistemaAquaFresh_1._0._0.Controlador;
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
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generarReporteVentaEnEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ventasEnEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. LINQ + VAR: Filtramos la lista global buscando solo transacciones en Efectivo concretadas
            var ventasEfectivo = Venta_Controler.Lista_Clientes
                .Where(c => c.Producto_comprado != null &&
                            c.Tipo_pago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase) &&
                            c.Estado_venta == "Realizada")
                .Select(c => new
                {
                    Cédula = c.Id_cedula,
                    Cliente = c.ObtenerNombreCompleto(),
                    Producto = c.Producto_comprado.Nombre,
                    Cantidad = c.Cantidad_comprada,
                    Precio = c.Precio_venta_pactado,
                    Total_Pago = c.TotalTransaccion, // Multiplicación automática interna de la entidad
                    Estado = c.Estado_venta,
                    Fecha_Hora = c.Fecha_hora_venta.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

            // 2. Control de datos: Si no hay ventas, avisamos al operador
            if (ventasEfectivo.Count == 0)
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("No se encontraron registros de ventas en efectivo realizadas el día de hoy.",
                                "Reporte Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ventasEfectivo;

            // 4. Estilos rápidos para que las monedas muestren los decimales correctos (los 0,60 centavos)
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Total_Pago"].DefaultCellStyle.Format = "N2";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            // 5. Métrica rápida en barra de título para que el jefe vea el total de un vistazo
            var granTotalEfectivo = ventasEfectivo.Sum(v => v.Total_Pago);
            this.Text = $"Reporte de Ventas en Efectivo — Total Recaudado: ${granTotalEfectivo:F2}";
        }

        private void ventasEnDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. LINQ + VAR: Filtramos la lista global buscando solo transacciones por Transferencia/Depósito concretadas
            var ventasDeposito = Venta_Controler.Lista_Clientes
                .Where(c => c.Producto_comprado != null &&
                            c.Tipo_pago.Equals("Transferencia", StringComparison.OrdinalIgnoreCase) &&
                            c.Estado_venta == "Realizada")
                .Select(c => new
                {
                    Cédula = c.Id_cedula,
                    Cliente = c.ObtenerNombreCompleto(),
                    Producto = c.Producto_comprado.Nombre,
                    Cantidad = c.Cantidad_comprada,
                    Precio_Pactado = c.Precio_venta_pactado,
                    Total_Cobrado = c.TotalTransaccion, // Propiedad calculada automática de tu entidad Cliente
                    Forma_Pago = c.Tipo_pago,
                    Estado = c.Estado_venta,
                    Fecha_Hora = c.Fecha_hora_venta.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

            // 2. Control de datos: Si no hay ventas por banco, avisamos al operador limpiando la cuadrícula
            if (ventasDeposito.Count == 0)
            {
                dataGridView1.DataSource = null;
                this.Text = "Reporte de Ventas en Depósito — Total Recaudado: $0.00";
                MessageBox.Show("No se encontraron registros de ventas por transferencia bancaria realizadas el día de hoy.",
                                "Reporte Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Cargamos los datos filtrados en la tabla gigante (que ya tiene Dock = Fill)
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ventasDeposito;

            // 4. Estilos de cuadrícula para que los decimales y la distribución se vean impecables
            dataGridView1.Columns["Precio_Pactado"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Total_Cobrado"].DefaultCellStyle.Format = "N2";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            // 5. Métrica rápida en la barra de título del formulario para control del arqueo de cuentas bancarias
            var granTotalDeposito = ventasDeposito.Sum(v => v.Total_Cobrado);
            this.Text = $"Reporte de Ventas en Depósito/Transferencia — Total en Banco: ${granTotalDeposito:F2}";
        }

        private void ventasGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. LINQ + VAR: Jalamos todo el historial sin filtros de pago ni de estados
            var todasLasVentas = Venta_Controler.Lista_Clientes
                .Where(c => c.Producto_comprado != null) // Solo clientes con transacciones registradas
                .Select(c => new
                {
                    Cédula = c.Id_cedula,
                    Cliente = c.ObtenerNombreCompleto(),
                    Producto = c.Producto_comprado.Nombre,
                    Cantidad = c.Cantidad_comprada,
                    Precio_Pactado = c.Precio_venta_pactado,
                    Total_Venta = c.TotalTransaccion, // Propiedad automática de tu entidad Cliente
                    Forma_Pago = c.Tipo_pago,
                    Estado = c.Estado_venta,
                    Fecha_Hora = c.Fecha_hora_venta.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

            // 2. Control de datos: Si la distribuidora no ha vendido nada en todo el día
            if (todasLasVentas.Count == 0)
            {
                dataGridView1.DataSource = null;
                this.Text = "Reporte de Ventas Generales — Total Bruto: $0.00";
                MessageBox.Show("No se registra ningún movimiento comercial o venta el día de hoy en el sistema.",
                                "Reporte Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Cargamos la lista completa en tu tabla gigante (Dock = Fill)
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = todasLasVentas;

            // 4. Estilos de cuadrícula profesionales para las columnas de dinero
            dataGridView1.Columns["Precio_Pactado"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Total_Venta"].DefaultCellStyle.Format = "N2";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            // 5. LINQ + VAR: Calculamos el gran total bruto combinado (Realizadas + Pendientes)
            var granTotalGeneral = todasLasVentas.Sum(v => v.Total_Venta);

            // Mostramos el resumen global en la barra de título del formulario hijo
            this.Text = $"Reporte de Ventas Generales — Movimiento Total del Día: ${granTotalGeneral:F2}";
        }

        private void visualizarPagosPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. LINQ + VAR: Filtramos la lista global buscando solo transacciones con estado 'Pendiente'
            var cuentasPendientes = Venta_Controler.Lista_Clientes
                .Where(c => c.Producto_comprado != null &&
                            c.Estado_venta.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                .Select(c => new
                {
                    Cédula = c.Id_cedula,
                    Cliente = c.ObtenerNombreCompleto(),
                    Producto = c.Producto_comprado.Nombre,
                    Cantidad = c.Cantidad_comprada,
                    Precio_Pactado = c.Precio_venta_pactado,
                    Total_Por_Cobrar = c.TotalTransaccion, // Propiedad calculada automática de tu entidad Cliente
                    Forma_Pago_Sugerida = c.Tipo_pago,
                    Estado = c.Estado_venta,
                    Fecha_Registro = c.Fecha_hora_venta.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

            // 2. Control de datos: Si no hay cuentas pendientes por cobrar hoy
            if (cuentasPendientes.Count == 0)
            {
                dataGridView1.DataSource = null;
                this.Text = "Reporte de Cuentas Pendientes — Total a Cobrar: $0.00";
                MessageBox.Show("¡Excelente! No se registran pagos o cuentas pendientes por cobrar el día de hoy.",
                                "Cartera Limpia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Cargamos los datos filtrados en tu tabla gigante (Dock = Fill)
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cuentasPendientes;

            // 4. Estilos de cuadrícula profesionales para las columnas de dinero
            dataGridView1.Columns["Precio_Pactado"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Total_Por_Cobrar"].DefaultCellStyle.Format = "N2";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            // 5. LINQ + VAR: Calculamos el monto total exacto que está en la calle por cobrar
            var totalPorCobrar = cuentasPendientes.Sum(v => v.Total_Por_Cobrar);

            // Mostramos el balance de deuda directamente en la barra de título del formulario
            this.Text = $"Reporte de Cuentas Pendientes — TOTAL POR COBRAR: ${totalPorCobrar:F2}";
        }

        private void generarReporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

