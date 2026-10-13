
using empresa_inventario;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace empresa_inventario
{
    public partial class Form1 : Form
    {
        private enum Modulo
        {
            Productos,
            Personal,
            Inventario
        }

        private Modulo moduloActual = Modulo.Productos;

        private readonly ProductsDAO productsDAO = new ProductsDAO();
        private readonly StaffDAO staffDAO = new StaffDAO();
        private readonly InventoryDAO inventoryDAO = new InventoryDAO();

        public Form1()
        {
            InitializeComponent();
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            moduloActual = Modulo.Productos;

            label_3.Text = "Gestión de Productos";
            label_1.Text = "ID Producto:";
            label_2.Text = "Descripción:";
            label_4.Visible = false;
            maskedTextBox2.Visible = true;
            maskedTextBox3.Visible = false;
            comboBoxProduct.Visible = false;
            comboBoxStaff.Visible = false;
            numericUpDownQuantity.Visible = false;

            maskedTextBox1.Clear();
            maskedTextBox2.Clear();

            maskedTextBox1.ReadOnly = false;

            dataGridView.DataSource = productsDAO.GetProducts();
            // Ajustar automáticamente el ancho de las columnas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarPersonal()
        {
            moduloActual = Modulo.Personal;

            label_3.Text = "Gestión de Personal";
            label_1.Text = "ID Personal:";
            label_2.Text = "Nombre:";
            label_4.Text = "Cargo:";
            label_4.Visible = true;
            maskedTextBox2.Visible = true;
            maskedTextBox3.Visible = true;
            comboBoxProduct.Visible = false;
            comboBoxStaff.Visible = false;
            numericUpDownQuantity.Visible = false;

            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();

            maskedTextBox1.ReadOnly = false;

            dataGridView.DataSource = staffDAO.GetStaff();
            // Ajustar automáticamente el ancho de las columnas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void MostrarInventario()
        {
            moduloActual = Modulo.Inventario;

            label_3.Text = "Gestión de Inventario";
            label_1.Text = "ID Inventario:";
            label_2.Text = "Producto:";
            label_4.Text = "Personal:";

            // El ID se genera automáticamente.
            maskedTextBox1.Clear();
            maskedTextBox1.ReadOnly = false;

            // Ocultar campos de Productos y Personal.
            maskedTextBox2.Visible = false;
            maskedTextBox3.Visible = false;

            // Mostrar controles de Inventario.
            comboBoxProduct.Visible = true;
            comboBoxStaff.Visible = true;
            numericUpDownQuantity.Visible = true;

            label_4.Visible = true;

            // Configurar cantidad mínima.
            numericUpDownQuantity.Minimum = 1;

            // Cargar productos y empleados.
            CargarCombosInventario();

            // Mostrar registros.
            dataGridView.DataSource = inventoryDAO.GetInventory();
            // Ajustar automáticamente el ancho de las columnas
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void ActualizarGrid()
        {
            switch (moduloActual)
            {
                case Modulo.Productos:
                    dataGridView.DataSource = productsDAO.GetProducts();
                    break;

                case Modulo.Personal:
                    dataGridView.DataSource = staffDAO.GetStaff();
                    break;

                case Modulo.Inventario:
                    dataGridView.DataSource = inventoryDAO.GetInventory();
                    break;
            }
        }



        private void LimpiarCampos()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();

            if (comboBoxProduct.DataSource != null)
                comboBoxProduct.SelectedIndex = -1;

            if (comboBoxStaff.DataSource != null)
                comboBoxStaff.SelectedIndex = -1;

            numericUpDownQuantity.Value = 1;
        }

        private void CargarCombosInventario()
        {
            comboBoxProduct.DataSource = inventoryDAO.ObtenerProductos();
            comboBoxProduct.DisplayMember = "Descripcion";
            comboBoxProduct.ValueMember = "ID";
            comboBoxProduct.SelectedIndex = -1;

            comboBoxStaff.DataSource = inventoryDAO.ObtenerPersonal();
            comboBoxStaff.DisplayMember = "Nombre";
            comboBoxStaff.ValueMember = "ID";
            comboBoxStaff.SelectedIndex = -1;
        }



















        private void button_test_connection_Click(object sender, EventArgs e)
        { // Boton de prueba de la conexion a la Base de Datos
            try
            {   // Crea una nueva instancia de conexion para BD
                Conexion conexion = new Conexion();

                using (var conn = conexion.GetConnection()) // Utiliza el metodo publico de la clase el cual contiene 
                                                            // la informacion requerida para la conexion a MySQL
                {
                    conn.Open(); // Se abre la conexion 

                    MessageBox.Show( // Muestra un mensaje si la conexion fue exitosa 
                        "¡Conexión exitosa a empresa_inventario!");
                }
            }
            catch (Exception ex) // Se hace un catch error y lo muestra cuando falla la conexion
            {
                MessageBox.Show(
                    "Error de conexión: " + ex.Message);
            }
        }

        private void dataGridView_CellClick(
             object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dataGridView.Rows[e.RowIndex];

            // ID del registro seleccionado.
            maskedTextBox1.Text =
                fila.Cells["ID"].Value?.ToString() ?? "";

            switch (moduloActual)
            {
                case Modulo.Productos:
                    {
                        maskedTextBox2.Text =
                            fila.Cells["Descripcion"].Value?.ToString() ?? "";
                        break;
                    }

                case Modulo.Personal:
                    {
                        maskedTextBox2.Text =
                            fila.Cells["Nombre"].Value?.ToString() ?? "";

                        maskedTextBox3.Text =
                            fila.Cells["Cargo"].Value?.ToString() ?? "";
                        break;
                    }

                case Modulo.Inventario:
                    {
                        // Seleccionar el producto por su ID.
                        comboBoxProduct.SelectedValue =
                            Convert.ToInt32(fila.Cells["IDProducto"].Value);

                        // Seleccionar al empleado por su ID.
                        comboBoxStaff.SelectedValue =
                            Convert.ToInt32(fila.Cells["IDPersonal"].Value);

                        // Recuperar la cantidad.
                        numericUpDownQuantity.Value =
                            Convert.ToDecimal(fila.Cells["Cantidad"].Value);

                        break;
                    }
            }
        }

        private void button_consult_Click_1(object sender, EventArgs e)
        {
            // Validar el ID ingresado
            if (!int.TryParse(maskedTextBox1.Text.Trim(), out int id)
                || id <= 0)
            {
                MessageBox.Show(
                    "Ingresa un ID válido para consultar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                maskedTextBox1.Focus();
                return;
            }

            try
            {
                DataTable resultado = null;

                switch (moduloActual)
                {
                    case Modulo.Productos:
                        resultado = productsDAO.GetProductById(id);
                        break;

                    case Modulo.Personal:
                        resultado = staffDAO.GetStaffById(id);
                        break;

                    case Modulo.Inventario:
                        resultado = inventoryDAO.GetInventoryById(id);
                        break;
                }

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    dataGridView.DataSource = resultado;

                    MessageBox.Show(
                        "Registro encontrado correctamente.",
                        "Consulta exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView.DataSource = resultado;

                    MessageBox.Show(
                        $"No se encontró ningún registro con el ID {id}.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al consultar la base de datos:\n" + ex.Message,
                    "Error MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Boton que guarda un registro en una tabla de la BD 
        private void button_save_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool guardado = false;

                switch (moduloActual)
                {
                    case Modulo.Productos:
                        {
                            string descripcion = maskedTextBox2.Text.Trim();

                            if (string.IsNullOrWhiteSpace(descripcion) ||
                                descripcion.Length > 40)
                            {
                                MessageBox.Show(
                                    "Ingresa una descripción válida (máximo 40 caracteres).");
                                return;
                            }

                            guardado = productsDAO.Insertar(descripcion);
                            break;
                        }

                    case Modulo.Personal:
                        {
                            string nombre = maskedTextBox2.Text.Trim();
                            string cargo = maskedTextBox3.Text.Trim();

                            if (string.IsNullOrWhiteSpace(nombre) ||
                                string.IsNullOrWhiteSpace(cargo))
                            {
                                MessageBox.Show("Ingresa el nombre y el cargo.");
                                return;
                            }

                            if (nombre.Length > 80 || cargo.Length > 80)
                            {
                                MessageBox.Show(
                                    "El nombre y el cargo admiten máximo 80 caracteres.");
                                return;
                            }

                            guardado = staffDAO.Insertar(nombre, cargo);
                            break;
                        }

                    case Modulo.Inventario:
                        {
                            if (comboBoxProduct.SelectedValue == null ||
                                comboBoxStaff.SelectedValue == null)
                            {
                                MessageBox.Show("Selecciona un producto y un empleado.");
                                return;
                            }

                            int idProducto =
                                Convert.ToInt32(comboBoxProduct.SelectedValue);

                            int idPersonal =
                                Convert.ToInt32(comboBoxStaff.SelectedValue);

                            int cantidad = (int)numericUpDownQuantity.Value;

                            guardado = inventoryDAO.Insertar(
                                idProducto, idPersonal, cantidad);

                            break;
                        }
                }

                if (guardado)
                {
                    MessageBox.Show("Registro guardado correctamente.");
                    ActualizarGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

        }

        // Al hacer clic en el boton productos muestra el catalogo
        private void button_products_Click_1(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        // Al hacer clic en el boton personal muestra el catalogo personal
        private void button_staff_Click_1(object sender, EventArgs e)
        {
            MostrarPersonal();
        }
        // Al hacer clic en inventario muestra el inventario actual 
        private void button_inventory_Click_1(object sender, EventArgs e)
        {
            MostrarInventario();
        }

        // Boton que edita un registro de una tabla en: CatProducts, CatPersonal, Inventario
        private void button_update_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(maskedTextBox1.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Selecciona un registro con un ID válido.");
                return;
            }

            try
            {
                bool actualizado = false;

                switch (moduloActual)
                {
                    case Modulo.Productos:
                        {
                            string descripcion = maskedTextBox2.Text.Trim();

                            if (string.IsNullOrWhiteSpace(descripcion) ||
                                descripcion.Length > 40)
                            {
                                MessageBox.Show(
                                    "Ingresa una descripción válida (máximo 40 caracteres).");
                                return;
                            }

                            actualizado = productsDAO.Actualizar(id, descripcion);
                            break;
                        }

                    case Modulo.Personal:
                        {
                            string nombre = maskedTextBox2.Text.Trim();
                            string cargo = maskedTextBox3.Text.Trim();

                            if (string.IsNullOrWhiteSpace(nombre) ||
                                string.IsNullOrWhiteSpace(cargo))
                            {
                                MessageBox.Show("Ingresa el nombre y el cargo.");
                                return;
                            }

                            if (nombre.Length > 80 || cargo.Length > 80)
                            {
                                MessageBox.Show(
                                    "El nombre y el cargo admiten máximo 80 caracteres.");
                                return;
                            }

                            actualizado = staffDAO.Actualizar(id, nombre, cargo);
                            break;
                        }

                    case Modulo.Inventario:
                        {
                            if (comboBoxProduct.SelectedValue == null ||
                                comboBoxStaff.SelectedValue == null)
                            {
                                MessageBox.Show("Selecciona un producto y un empleado.");
                                return;
                            }

                            int idProducto =
                                Convert.ToInt32(comboBoxProduct.SelectedValue);

                            int idPersonal =
                                Convert.ToInt32(comboBoxStaff.SelectedValue);

                            int cantidad = (int)numericUpDownQuantity.Value;

                            actualizado = inventoryDAO.Actualizar(
                                id, idProducto, idPersonal, cantidad);

                            break;
                        }
                }

                if (actualizado)
                {
                    MessageBox.Show("Registro actualizado correctamente.");
                    ActualizarGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se modificaron filas. Verifica el ID o si los datos ya eran iguales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void button_delete_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(maskedTextBox1.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Selecciona un registro con un ID válido.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que deseas eliminar este registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                bool eliminado = false;

                switch (moduloActual)
                {
                    case Modulo.Productos:
                        eliminado = productsDAO.Eliminar(id);
                        break;

                    case Modulo.Personal:
                        eliminado = staffDAO.Eliminar(id);
                        break;

                    case Modulo.Inventario:
                        eliminado = inventoryDAO.Eliminar(id);
                        break;
                }

                if (eliminado)
                {
                    MessageBox.Show("Registro eliminado correctamente.");
                    ActualizarGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se encontró el registro para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el registro debido a que se encuentra enlistado en el inventario.\n"
                    + ex.Message);
            }
        }

    }
}
