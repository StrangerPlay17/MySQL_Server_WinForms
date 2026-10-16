
using empresa_inventario;         // Importa el espacio de nombres del proyecto 
using MySql.Data.MySqlClient;    // Importa las clases necesarias para conectarse y trabajar con MySQL
using MySqlX.XDevAPI.Relational;
using System;                    // Importa clases básicas del lenguaje C#
using System.Data;               // Importa las clases para manejar tablas y conjuntos de datos
using System.Windows.Forms;     // Importa las herramientas necesarias para crear interfaces gráficas en WinForms

namespace empresa_inventario    // Define el espacio de nombres principal 
{
    public partial class Form1 : Form      // Declara la clase parcial Form1, que representa el formulario principal
    {
        private enum Modulo        // Declara una enumeración para identificar los modulos 
        {
            Productos,            // Modulo que indica que se esta en la seccion de "productos" en la interfaz
            Personal,            // Modulo que indica que se esta en la seccion de "personal" en la interfaz
            Inventario           // Modulo que indica que se esta en la seccion de "inventario" en la interfaz
        }
        
        // Guarda el módulo que se encuentra seleccionado actualmente
        private Modulo moduloActual = Modulo.Productos;     // Al iniciar el módulo activo en la interfaz es Productos


        // Crea un objeto de las clases para realizar las operaciones en la BD
        private readonly ProductsDAO productsDAO = new ProductsDAO();     // Objeto que representa una operacion en CatProduct
        private readonly StaffDAO staffDAO = new StaffDAO();             // Objeto que representa una operacion en CatStaff
        private readonly InventoryDAO inventoryDAO = new InventoryDAO();   //Objeto que representa una operacion en tblInventory

        // Constructor del forms principal
        public Form1()                        // Se ejecuta automáticamente al crear una instancia de Form1
        {
            InitializeComponent();           // Inicializa los controles visuales definidos en el diseñador: tablas, botones, labels, etc
            MostrarProductos();              // Metodo que carga y muestra los productos en la interfaz al iniciar la appp
        }


        // --------------------------------------------------------------------------------------------------------------
        // METODOS PARA MOSTRAR LOS CONTROLES DE (CatProductos, CatPersonal, tblInventario) EN LA INTERFAZ 
        // DE FORMA DINAMICA
        // Ej: Al presionar el boton "Personal" la interfaz despliega y oculta los controles necesarios
        // de la seccion 


        // Método que actualiza el modulo de Productos en el forms
        private void MostrarProductos()        
        {
         
            moduloActual = Modulo.Productos;   // Selecciona el modulo actual como productos

            // Actualiza el texto de los labels
            label_3.Text = "Gestión de Productos";
            label_1.Text = "ID Producto:";
            label_2.Text = "Descripción:";
            
            maskedTextBox2.Visible = true;     // Muestra el campo de descripción del producto

            label_4.Visible = false;           // Oculta el label no necesitado en la seccion
            maskedTextBox3.Visible = false;    // Oculta el txtBox usado para introducir el "Cargo" en Personal

            // Oculta las listas desplegables de productos y personal del inventario 
            comboBoxProduct.Visible = false;
            comboBoxStaff.Visible = false;

            numericUpDownQuantity.Visible = false;     // Oculta el control numérico de inventario

            // Limpia el txtBox del ID y descripción
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();

            maskedTextBox1.ReadOnly = false;    // Permite modificar el contenido del campo del ID del producto

            // Obtiene los productos de la base de datos y los muestra en la tabla en la interfaz
            dataGridView.DataSource = productsDAO.GetProducts();

            // Ajusta automáticamente el ancho de las columnas de la tabla al contenido
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Método que actualiza el modulo de Personal en el forms
        private void MostrarPersonal()
        {
            // Actualiza Personal como el módulo actual
            moduloActual = Modulo.Personal;

            // Actualiza los textos de los labels para Perosnal
            label_3.Text = "Gestión de Personal";
            label_1.Text = "ID Personal:";
            label_2.Text = "Nombre:";
            label_4.Text = "Cargo:";

            // Muestra la etiqueta Cargo del modulo
            label_4.Visible = true;

            // Muestra el txtBox para introducir el nombre 
            maskedTextBox2.Visible = true;

            // Muestra el txtBox para introducir el cargo 
            maskedTextBox3.Visible = true;

            // Oculta las listas desplegables de productos y personal al no ser necesarias en la seccion
            comboBoxProduct.Visible = false;
            comboBoxStaff.Visible = false;

            // Oculta el control de cantidades en inventario
            numericUpDownQuantity.Visible = false;

            // Limpia los txtBox
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();

            // ReadOnly false modificar el contenido del campo ID 
            maskedTextBox1.ReadOnly = false;

            // Obtiene los registros del personal y los muestra en la tabla en la interfaz
            dataGridView.DataSource = staffDAO.GetStaff();

            // Ajusta automáticamente el ancho de las columnas al contenido
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Método que actualiza el modulo Inventario en el forms
        private void MostrarInventario()
        {
            // Actualliza Inventario como el módulo actual
            moduloActual = Modulo.Inventario;

            // Actualiza los textos de los labels para inventario
            label_3.Text = "Gestión de Inventario";
            label_1.Text = "ID Inventario:";
            label_2.Text = "Producto:";
            label_4.Text = "Personal:";

            // Limpia el campo del ID
            maskedTextBox1.Clear();

            // Permite modificar el campo del ID del inventario para hacer consultas por ID
            maskedTextBox1.ReadOnly = false;

            // Oculta los txtBox utilizados en Productos y Personal
            maskedTextBox2.Visible = false;
            maskedTextBox3.Visible = false;

            // Muestra los comboBox para seleccionar productos y empleados
            comboBoxProduct.Visible = true;
            comboBoxStaff.Visible = true;

            // Muestra el control numérico en inventario
            numericUpDownQuantity.Visible = true;

            // Muestra el label de "personal"
            label_4.Visible = true;

            // Define cantidad mínima permitida en 1 del control numerico
            numericUpDownQuantity.Minimum = 1;

            // Carga los productos y empleados actuales en los comboBox consultando a la BD
            CargarCombosInventario();

            // Obtiene los registros del inventario y los muestra en la tabla de la interfaz
            dataGridView.DataSource = inventoryDAO.GetInventory();

            // Ajusta automáticamente el ancho de las columnas al contenido 
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }
        // ----------------------------------------------------------------------------------------
        // METODOS DE LIMPIEZA Y ACTUALIZACION DEL GRID Y COMBOBOXES 


        // Metodo que actualiza y muestra los registros de la tabla de la interfaz 
        private void ActualizarGrid()
        {
            switch (moduloActual)  // De acuerdo a la seccion actual en la interfaz
            {
                case Modulo.Productos:     // Consulta a la BD y muestra los datos en CatProductos
                    dataGridView.DataSource = productsDAO.GetProducts();
                    break;

                case Modulo.Personal:      // Consulta a la BD y muestra los datos en CatPersonal
                    dataGridView.DataSource = staffDAO.GetStaff();
                    break;

                case Modulo.Inventario:     // Consulta a la BD y muestra los datos en tblInventario
                    dataGridView.DataSource = inventoryDAO.GetInventory();
                    break;
            }
        }

        // Metodo que carga la lista de productos y el personal en los comboBox (seccion en Inventario)
        private void CargarCombosInventario()
        {
            // Carga la lista de productos desde la BD 
            comboBoxProduct.DataSource = inventoryDAO.ObtenerProductos();
            comboBoxProduct.DisplayMember = "Descripcion";  // Define "descripcion" como texto visible
            comboBoxProduct.ValueMember = "ID";             // Asocia el ID al producto
            comboBoxProduct.SelectedIndex = -1;             // La lista se muestra sin un elemento seleccionado previo 
            // Carga la lista de personal desde ula BD 
            comboBoxStaff.DataSource = inventoryDAO.ObtenerPersonal();
            comboBoxStaff.DisplayMember = "Nombre"; // Define "nombre" como texto visible 
            comboBoxStaff.ValueMember = "ID";       // Asocia el ID al personal
            comboBoxStaff.SelectedIndex = -1;       // La lista se muestra sin un elemento seleccionado previo 
        }

        // Metodo que limpia los controles de la interfaz a su estado por defecto
        private void LimpiarCampos() 
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();

            // Verifica si la lista de productos está vinculada a una fuente de datos
            if (comboBoxProduct.DataSource != null)
                comboBoxProduct.SelectedIndex = -1;  // Remueve la selección actual de la lista
            // Verifica si la lista de personal está vinculada a una fuente de datos
            if (comboBoxStaff.DataSource != null)
                comboBoxStaff.SelectedIndex = -1;   // Remueve la selección actual de la lista

            numericUpDownQuantity.Value = 1;
        }

        // Metodo que se ejecuta cuando un usuario hace clic en una celda de la tabla DataGridView
        private void dataGridView_CellClick(
             object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si el usuario hizo clic en el encabezado de una columna
            if (e.RowIndex < 0)
                return; //Sino se selecciono una fila valida, regresa 

            // Obtiene la fila completa en la que el usuario hizo clic
            DataGridViewRow fila = dataGridView.Rows[e.RowIndex];

            // Recupera el ID del registro seleccionado y lo muestra, al ser nulo se asigna vacio
            maskedTextBox1.Text =
                fila.Cells["ID"].Value?.ToString() ?? "";

            switch (moduloActual)  // De acuerdo al modulo actual en la interfaz 
            {
                case Modulo.Productos: // Si se esta en la seccion Productos
                    {
                        // Obtiene el valor de la descripcion desde la tabla y lo muestra en el txtBox
                        maskedTextBox2.Text =
                            fila.Cells["Descripcion"].Value?.ToString() ?? "";
                        break;
                    }

                case Modulo.Personal: // Si se esta en la seccion Personal
                    {
                        // Obtiene el valor del nombre desde la tabla y lo muestra en el txtBox
                        maskedTextBox2.Text =
                            fila.Cells["Nombre"].Value?.ToString() ?? "";
                        // Obtiene el valor del cargo desde la tabla y lo muestra en el txtBox
                        maskedTextBox3.Text =
                            fila.Cells["Cargo"].Value?.ToString() ?? "";
                        break;
                    }

                case Modulo.Inventario:  // Si se esta en la seccion Inventario 
                    {
                        // Obtiene el ID del producto asociado al registro y lo muestra en el comboBox
                        comboBoxProduct.SelectedValue =
                            Convert.ToInt32(fila.Cells["IDProducto"].Value);

                        // Obtiene el ID del personal asociado al registro y lo muestra en el comboBox
                        comboBoxStaff.SelectedValue =
                            Convert.ToInt32(fila.Cells["IDPersonal"].Value);

                        // Obtiene la cantidad desde la tabla y lo muestra en el control numerico
                        numericUpDownQuantity.Value =
                            Convert.ToDecimal(fila.Cells["Cantidad"].Value);

                        break;
                    }
            }
        }

        // ----------------------------------------------------------------------------------------
        // METODOS DE LOS EVENTOS DE LOS BOTONES EN LA INTERFAZ 


        // Boton de prueba "Test Connection" a la Base de Datos
        private void button_test_connection_Click(object sender, EventArgs e)
        { 
            try
            {   // Crea una nueva instancia de conexion para BD
                Conexion conexion = new Conexion();

                using (var conn = conexion.GetConnection()) // Utiliza el metodo publico de la clase el cual contiene 
                                                            // la informacion requerida para la conexion a MySQL
                {
                    conn.Open(); // Se abre la conexion 

                    MessageBox.Show( // Muestra un mensaje si la conexion fue exitosa 
                        "¡Conexión exitosa a la base de datos! :D");
                }
            }
            catch (Exception ex) // Se hace un catch error y lo muestra cuando falla la conexion
            {
                MessageBox.Show(
                    "Error de conexión: " + ex.Message);
            }
        }

        // Al hacer clic en el boton "Productos" actualiz la seccion en la interfaz
        private void button_products_Click_1(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        // Al hacer clic en el boton "Personal" actualiza la seccion en la interfaz
        private void button_staff_Click_1(object sender, EventArgs e)
        {
            MostrarPersonal();
        }
        // Al hacer clic en el boton "Inventario" actualiza la seccion del inventario en la interfaz  
        private void button_inventory_Click_1(object sender, EventArgs e)
        {
            MostrarInventario();
        }

        // ----------------------------------------------------------------------------------------
        // BOTONES PARA LA INICIAR LA EJECUCION DE COMANDOS DML (MANIPULACION DE DATOS) EN LA BD
        // SELECT, UPDATE, INSERT, DELETE 


        // Boton "Consultar" en la Interfaz (Consulta un registro por su ID de la BD)
        private void button_consult_Click_1(object sender, EventArgs e)
        {
            // Valida que el ID ingresado sea un número entero mayor a cero
            if (!int.TryParse(maskedTextBox1.Text.Trim(), out int id)
                || id <= 0)
            {
                // MssBox si el ID no es valido
                MessageBox.Show(
                    "Ingresa un ID válido para consultar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // El cursor regresa al txtBox 
                maskedTextBox1.Focus();
                return;
            }

            try  // Try/Catch error para manejar errores 
            {
                DataTable resultado = null;  // Inicializa la tabla que tendra los resultados de la consulta

                switch (moduloActual)       // De acuerdo al modulo actual 
                {
                    case Modulo.Productos:   // Busca un producto mediante su ID
                        resultado = productsDAO.GetProductById(id);
                        break;

                    case Modulo.Personal:   // Busca un empleado mediante su ID
                        resultado = staffDAO.GetStaffById(id);
                        break;

                    case Modulo.Inventario:  // Busca un registro del inventario con su ID
                        resultado = inventoryDAO.GetInventoryById(id);
                        break;
                }

                // Verifica que la consulta no sea null y haya al menos un registro
                if (resultado != null && resultado.Rows.Count > 0)
                {
                    // Si hay alguna, mustra los registros encontrados en el DataGridView
                    dataGridView.DataSource = resultado;

                    MessageBox.Show(
                        "Registro encontrado correctamente.",
                        "Consulta exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else  // Sino se encontro ningun registro en la BD 
                {
                    dataGridView.DataSource = resultado; // Muestra la tabla sin filas (indicando que no se encontro)

                    MessageBox.Show(
                        $"No se encontró ningún registro con el ID {id}.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex) // En caso de algun error con la BD, hace catch y lo muestra 
            {
                MessageBox.Show(
                    "Error al consultar la base de datos:\n" + ex.Message,
                    "Error MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex) // En caso de cualquier otro error en ejecucion, hace catch y lo muestra
            {
                MessageBox.Show(
                    "Ocurrió un error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Boton "Guardar" en la interfaz (Inserta un registro en la BD)
        private void button_save_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool guardado = false;   // Variable bool la cual indicara si el registro fue guardado

                switch (moduloActual)   // De acuerdo a la seccion/modulo actual en la interfaz 
                {
                    case Modulo.Productos:   // Si se esta en la seccion Productos
                        {
                            // Obteniene la descripción del producto y elimina los espacios del inicio y final
                            string descripcion = maskedTextBox2.Text.Trim();

                            // Valida que la descripción no sea null y no sea mayor a 40 caracteres
                            if (string.IsNullOrWhiteSpace(descripcion) ||
                                descripcion.Length > 40)
                            {
                                MessageBox.Show(  // MssBox si no es valida 
                                    "Ingresa una descripción válida (máximo 40 caracteres).");
                                return;
                            }

                            // Al pasar las validaciones, se llama al metodo 
                            // Insert de la clase para insertar el producto en la BD
                            guardado = productsDAO.Insert(descripcion);
                            break;
                        }

                    case Modulo.Personal:  // Si se esta en la seccion Personal
                        {
                            // Obtiene el nombre y el cargo ingresados eliminando espacios externos
                            string nombre = maskedTextBox2.Text.Trim();
                            string cargo = maskedTextBox3.Text.Trim();

                            // Valida que el cargo o nombre no sean null 
                            if (string.IsNullOrWhiteSpace(nombre) ||
                                string.IsNullOrWhiteSpace(cargo))
                            {
                                MessageBox.Show("Ingresa el nombre y el cargo.");
                                return;
                            }

                            // Valida que la longitud del nombre y cargo no sea mayor a 80 caracteres
                            if (nombre.Length > 80 || cargo.Length > 80)
                            {
                                MessageBox.Show(
                                    "El nombre y el cargo admiten máximo 80 caracteres.");
                                return;
                            }

                            // Al pasar las validaciones, se llama al metodo 
                            // Insert de la clase para insertar al empleado en la BD
                            guardado = staffDAO.Insert(nombre, cargo);
                            break;
                        }

                    case Modulo.Inventario:  // Si se esta en la seccion de Inventario 
                        {
                            // Verifica que se haya seleccionado un producto y un empleado del comboBox
                            if (comboBoxProduct.SelectedValue == null ||
                                comboBoxStaff.SelectedValue == null)
                            {
                                MessageBox.Show("Selecciona un producto y un empleado.");
                                return;
                            }

                            // Obtiene el ID del producto y el personal del comboBox y los convierte a entero
                            int idProducto =
                                Convert.ToInt32(comboBoxProduct.SelectedValue);
                            int idPersonal =
                                Convert.ToInt32(comboBoxStaff.SelectedValue);

                            // Obtiene como entero la cantidad del control numérico
                            int cantidad = (int)numericUpDownQuantity.Value;


                            // Al pasar las validaciones, se llama al metodo 
                            // Insert de la clase para insertar el registro del inventario en la BD
                            guardado = inventoryDAO.Insert(
                                idProducto, idPersonal, cantidad);

                            break;
                        }
                }

                if (guardado) // Si se hizo un Insert satisfactoriamente, se muestra un mensaje 
                {
                    MessageBox.Show("Registro guardado correctamente.");
                    ActualizarGrid();
                    LimpiarCampos();
                }
                else //Sino, se indica al usuario 
                {
                    MessageBox.Show("No se pudo guardar el registro.");
                }
            }
            catch (Exception ex) // En cualquier caso, captura una exepcion y lo muestra al usuario 
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

        }

        // Boton "Editar" en la interfaz (Actualiza un registro en la BD por su ID)
        private void button_update_Click_1(object sender, EventArgs e)
        {
            // Valida que el ID ingresado sea un número entero mayor acero
            if (!int.TryParse(maskedTextBox1.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Selecciona un registro con un ID válido.");
                return;
            }

            try // Try/catch para manejar errores en la actualizacion  
            {
                bool actualizado = false;  // Variable que indicara si un registro fue actualizado

                switch (moduloActual)     // De acuerdo al modulo actual en la interfaz
                {
                    case Modulo.Productos:     // Si se esta en Productos 
                        {
                            // Obtiene la descripción del producto y elimina espacios externos
                            string descripcion = maskedTextBox2.Text.Trim();

                            // Valida que la descripcion no sea null y no tenga mas de 40 caracteres
                            if (string.IsNullOrWhiteSpace(descripcion) ||
                                descripcion.Length > 40)
                            {
                                MessageBox.Show(
                                    "Ingresa una descripción válida (máximo 40 caracteres).");
                                return;
                            }

                            // Al pasar las validaciones, se llama al metodo Update de la clase
                            // para actualizar el registro del producto en la BD
                            actualizado = productsDAO.Update(id, descripcion);
                            break;
                        }

                    case Modulo.Personal:    // Si se esta en Personal 
                        {
                            // Obtiene el nombre y el cargo eliminando los espacios del inicio y final 
                            string nombre = maskedTextBox2.Text.Trim();
                            string cargo = maskedTextBox3.Text.Trim();

                            // Valida que nombre y cargo no sean campos null 
                            if (string.IsNullOrWhiteSpace(nombre) ||
                                string.IsNullOrWhiteSpace(cargo))
                            {
                                MessageBox.Show("Ingresa el nombre y el cargo.");
                                return;
                            }

                            // Valida que la longitud de nombre y cargo no exceda 80 caracteres 
                            if (nombre.Length > 80 || cargo.Length > 80)
                            {
                                MessageBox.Show(
                                    "El nombre y el cargo admiten máximo 80 caracteres.");
                                return;
                            }

                            // Al pasar las validaciones, se llama al metodo Update de la clase
                            // para actualizar el registro del personal en la BD
                            actualizado = staffDAO.Update(id, nombre, cargo);
                            break;
                        }

                    case Modulo.Inventario:    // Si se esta en Inventario 
                        {
                            // Verifica que se haya seleccionado un producto y un empleado
                            if (comboBoxProduct.SelectedValue == null ||
                                comboBoxStaff.SelectedValue == null)
                            {
                                MessageBox.Show("Selecciona un producto y un empleado.");
                                return;
                            }

                            // Convierte los ID seleccionados de producto y personal en enteros validos
                            int idProducto =
                                Convert.ToInt32(comboBoxProduct.SelectedValue);
                            int idPersonal =
                                Convert.ToInt32(comboBoxStaff.SelectedValue);

                            // Obtiene la cantidad como entero en el control numérico
                            int cantidad = (int)numericUpDownQuantity.Value;

                            // Al pasar las validaciones, se llama al metodo Update de la clase
                            // para actualizar el registro del inventario en la BD
                            actualizado = inventoryDAO.Update(
                                id, idProducto, idPersonal, cantidad);

                            break;
                        }
                }

                if (actualizado)   // Si el registro fue actualizado correctamente, muestra un mensaje
                {
                    MessageBox.Show("Registro actualizado correctamente.");
                    ActualizarGrid();
                    LimpiarCampos();
                }
                else  // Sino, se indica al usuario 
                {
                    MessageBox.Show(
                        "No se modificaron filas. Verifica el ID o si los datos ya eran iguales.");
                }
            }
            catch (Exception ex) // Hace catch de cualquier error inesperado en la actualizacion 
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        // Boton "Eliminar" en la interfaz (Elimina un registro de la BD por su ID)
        private void button_delete_Click_1(object sender, EventArgs e)
        {
            // Valida que el ID ingresado sea un número entero mayor a cero
            if (!int.TryParse(maskedTextBox1.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Selecciona un registro con un ID válido.");
                return;
            }

            // Muestra un mensaje de confirmación al usuario antes de eliminar el registro
            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que deseas eliminar este registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes) // Si la respuesta es "no" regresa
                return;

            try // Seccion try/catch para errores inesperados 
            {
                bool eliminado = false;   // Variable que indicara si el registro fue eliminado correctamente

                switch (moduloActual)    // De acuerdo al modulo actual (el ID a eliminar correspondra con la seccion actual)
                {
                    case Modulo.Productos:     // Elimina el producto que corresponde al ID ingresado
                        eliminado = productsDAO.Delete(id);
                        break;

                    case Modulo.Personal:     // Elimina el personal que corresponde por su ID
                        eliminado = staffDAO.Delete(id);
                        break;

                    case Modulo.Inventario:   // Elimina el registro del inventario por su ID
                        eliminado = inventoryDAO.Delete(id);
                        break;
                }

                if (eliminado)  // Si el registro fue eliminado correctamente, se muestra un mensaje
                {
                    MessageBox.Show("Registro eliminado correctamente.");
                    ActualizarGrid();
                    LimpiarCampos();
                }
                else  // Sino, se indica al usuario 
                {
                    MessageBox.Show("No se encontró el registro para eliminar.");
                }
            }
            catch (Exception ex) // Si hubo un error inesperado o de la BD, se muestra al usuario)
            {
                MessageBox.Show(
                    "No se pudo eliminar el registro debido a que se encuentra enlistado en el inventario, o hubo un error en la base de datos.\n"
                    + ex.Message);
            }
        }

    }
}
