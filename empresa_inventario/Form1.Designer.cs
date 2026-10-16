namespace empresa_inventario     // Espacio de nombres del proyecto 
{
    partial class Form1          // Clase parcial que representa el formulario principal de la app
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;    // Contenedor que almacena los componentes utilizados en el forms

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))  // Verifica si se deben liberar los recursos y si el contenedor existe
            {
                components.Dispose();   // Libera los componentes del forms
            }
            base.Dispose(disposing);    // Ejecuta el método Dispose de la clase base
        }
        // Codigo de los componentes de la interfaz generado por el diseñador de WinForms de forma automatica 
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button_test_connection = new Button();
            dataGridView = new DataGridView();
            label_3 = new Label();
            label_2 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            button1 = new Button();
            panel2 = new Panel();
            button_inventory = new Button();
            button_staff = new Button();
            button_products = new Button();
            panel3 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            panel5 = new Panel();
            label4 = new Label();
            button_save = new Button();
            button_consult = new Button();
            button_update = new Button();
            button_delete = new Button();
            label_1 = new Label();
            maskedTextBox3 = new MaskedTextBox();
            label_4 = new Label();
            comboBoxProduct = new ComboBox();
            comboBoxStaff = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            label1 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // button_test_connection
            // 
            button_test_connection.BackColor = SystemColors.Window;
            button_test_connection.Cursor = Cursors.Hand;
            button_test_connection.Dock = DockStyle.Bottom;
            button_test_connection.Font = new Font("Segoe UI", 15F);
            button_test_connection.ForeColor = SystemColors.InactiveCaptionText;
            button_test_connection.Location = new Point(0, 674);
            button_test_connection.Name = "button_test_connection";
            button_test_connection.Size = new Size(229, 116);
            button_test_connection.TabIndex = 0;
            button_test_connection.Text = "Test Connection";
            button_test_connection.UseVisualStyleBackColor = false;
            button_test_connection.Click += button_test_connection_Click;
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = Color.FromArgb(29, 29, 50);
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(785, 97);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(712, 469);
            dataGridView.TabIndex = 1;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // label_3
            // 
            label_3.AutoSize = true;
            label_3.BackColor = Color.Transparent;
            label_3.Dock = DockStyle.Fill;
            label_3.Font = new Font("Segoe UI", 30F);
            label_3.ForeColor = SystemColors.InactiveCaptionText;
            label_3.Location = new Point(0, 0);
            label_3.Name = "label_3";
            label_3.Size = new Size(500, 67);
            label_3.TabIndex = 2;
            label_3.Text = "Gestion de Productos";
            label_3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Font = new Font("Segoe UI", 18F);
            label_2.ForeColor = Color.LawnGreen;
            label_2.Location = new Point(301, 367);
            label_2.Name = "label_2";
            label_2.Size = new Size(173, 41);
            label_2.TabIndex = 4;
            label_2.Text = "Descripción";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = SystemColors.WindowFrame;
            maskedTextBox1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            maskedTextBox1.ForeColor = Color.Yellow;
            maskedTextBox1.Location = new Point(525, 88);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Size = new Size(174, 51);
            maskedTextBox1.TabIndex = 5;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.BackColor = Color.FromArgb(64, 64, 64);
            maskedTextBox2.Font = new Font("Segoe UI", 20F);
            maskedTextBox2.ForeColor = Color.AliceBlue;
            maskedTextBox2.Location = new Point(284, 493);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(415, 52);
            maskedTextBox2.TabIndex = 6;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.SpringGreen;
            button1.Location = new Point(12, 133);
            button1.Name = "button1";
            button1.Size = new Size(204, 59);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            panel2.Controls.Add(button_inventory);
            panel2.Controls.Add(button_staff);
            panel2.Controls.Add(button_products);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button_test_connection);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 790);
            panel2.TabIndex = 10;
            // 
            // button_inventory
            // 
            button_inventory.Cursor = Cursors.Hand;
            button_inventory.Dock = DockStyle.Top;
            button_inventory.FlatStyle = FlatStyle.Popup;
            button_inventory.Font = new Font("Segoe UI", 15F);
            button_inventory.ForeColor = SystemColors.ButtonHighlight;
            button_inventory.Location = new Point(0, 491);
            button_inventory.Name = "button_inventory";
            button_inventory.Size = new Size(229, 127);
            button_inventory.TabIndex = 13;
            button_inventory.Text = "📦 Inventario";
            button_inventory.UseVisualStyleBackColor = true;
            button_inventory.Click += button_inventory_Click_1;
            // 
            // button_staff
            // 
            button_staff.Cursor = Cursors.Hand;
            button_staff.Dock = DockStyle.Top;
            button_staff.FlatStyle = FlatStyle.Popup;
            button_staff.Font = new Font("Segoe UI", 15F);
            button_staff.ForeColor = Color.Snow;
            button_staff.Location = new Point(0, 358);
            button_staff.Name = "button_staff";
            button_staff.Size = new Size(229, 133);
            button_staff.TabIndex = 12;
            button_staff.Text = "\U0001f9d1‍💼 Personal ";
            button_staff.UseVisualStyleBackColor = true;
            button_staff.Click += button_staff_Click_1;
            // 
            // button_products
            // 
            button_products.Cursor = Cursors.Hand;
            button_products.Dock = DockStyle.Top;
            button_products.FlatStyle = FlatStyle.Popup;
            button_products.Font = new Font("Segoe UI", 15F);
            button_products.ForeColor = Color.Snow;
            button_products.Location = new Point(0, 229);
            button_products.Name = "button_products";
            button_products.Size = new Size(229, 129);
            button_products.TabIndex = 11;
            button_products.Text = "🛍️ Productos ";
            button_products.UseVisualStyleBackColor = true;
            button_products.Click += button_products_Click_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SeaShell;
            panel3.BackgroundImage = Properties.Resources.carrito__1_;
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(229, 229);
            panel3.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 75F);
            label2.ForeColor = Color.DarkBlue;
            label2.Image = Properties.Resources.logo1__1_;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 166);
            label2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SeaShell;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label_3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(229, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1268, 91);
            panel1.TabIndex = 11;
            panel1.Tag = "";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.Controls.Add(label4);
            panel5.Location = new Point(556, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(113, 114);
            panel5.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 75F);
            label4.ForeColor = Color.DarkBlue;
            label4.Image = Properties.Resources.logo1__1_;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 166);
            label4.TabIndex = 11;
            // 
            // button_save
            // 
            button_save.BackColor = Color.Green;
            button_save.Cursor = Cursors.Hand;
            button_save.Font = new Font("Segoe UI", 13F);
            button_save.ForeColor = Color.Ivory;
            button_save.Location = new Point(832, 597);
            button_save.Name = "button_save";
            button_save.Size = new Size(289, 72);
            button_save.TabIndex = 14;
            button_save.Text = "💾 Guardar";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click_1;
            // 
            // button_consult
            // 
            button_consult.BackColor = Color.Navy;
            button_consult.Cursor = Cursors.Hand;
            button_consult.Font = new Font("Segoe UI", 13F);
            button_consult.ForeColor = SystemColors.InactiveBorder;
            button_consult.Location = new Point(1169, 597);
            button_consult.Name = "button_consult";
            button_consult.Size = new Size(287, 72);
            button_consult.TabIndex = 15;
            button_consult.Text = "🔍Consultar";
            button_consult.UseVisualStyleBackColor = false;
            button_consult.Click += button_consult_Click_1;
            // 
            // button_update
            // 
            button_update.BackColor = Color.Gold;
            button_update.Cursor = Cursors.Hand;
            button_update.Font = new Font("Segoe UI", 13F);
            button_update.ForeColor = SystemColors.InactiveCaptionText;
            button_update.Location = new Point(832, 690);
            button_update.Name = "button_update";
            button_update.Size = new Size(289, 73);
            button_update.TabIndex = 16;
            button_update.Text = "✏️Editar";
            button_update.UseVisualStyleBackColor = false;
            button_update.Click += button_update_Click_1;
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.Crimson;
            button_delete.Cursor = Cursors.Hand;
            button_delete.Font = new Font("Segoe UI", 13F);
            button_delete.ForeColor = SystemColors.InactiveBorder;
            button_delete.Location = new Point(1169, 690);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(287, 73);
            button_delete.TabIndex = 17;
            button_delete.Text = "🗑️Eliminar";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click_1;
            // 
            // label_1
            // 
            label_1.AutoSize = true;
            label_1.Font = new Font("Segoe UI", 18F);
            label_1.ForeColor = Color.LawnGreen;
            label_1.Location = new Point(301, 94);
            label_1.Name = "label_1";
            label_1.Size = new Size(178, 41);
            label_1.TabIndex = 18;
            label_1.Text = "ID producto";
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.BackColor = Color.FromArgb(64, 64, 64);
            maskedTextBox3.Font = new Font("Segoe UI", 20F);
            maskedTextBox3.ForeColor = Color.AliceBlue;
            maskedTextBox3.Location = new Point(284, 635);
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(388, 52);
            maskedTextBox3.TabIndex = 19;
            maskedTextBox3.Visible = false;
            // 
            // label_4
            // 
            label_4.AutoSize = true;
            label_4.BackColor = SystemColors.InfoText;
            label_4.Font = new Font("Segoe UI", 18F);
            label_4.ForeColor = Color.LawnGreen;
            label_4.Location = new Point(284, 574);
            label_4.Name = "label_4";
            label_4.Size = new Size(98, 41);
            label_4.TabIndex = 20;
            label_4.Text = "Cargo";
            label_4.Visible = false;
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.BackColor = SystemColors.ButtonFace;
            comboBoxProduct.Font = new Font("Segoe UI", 20F);
            comboBoxProduct.ForeColor = SystemColors.WindowText;
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(284, 492);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(415, 53);
            comboBoxProduct.TabIndex = 21;
            comboBoxProduct.Visible = false;
            // 
            // comboBoxStaff
            // 
            comboBoxStaff.BackColor = SystemColors.ButtonFace;
            comboBoxStaff.Font = new Font("Segoe UI", 20F);
            comboBoxStaff.ForeColor = SystemColors.WindowText;
            comboBoxStaff.FormattingEnabled = true;
            comboBoxStaff.Location = new Point(284, 635);
            comboBoxStaff.Name = "comboBoxStaff";
            comboBoxStaff.Size = new Size(388, 53);
            comboBoxStaff.TabIndex = 22;
            comboBoxStaff.Visible = false;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.BackColor = Color.DarkSeaGreen;
            numericUpDownQuantity.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            numericUpDownQuantity.Location = new Point(284, 708);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(150, 51);
            numericUpDownQuantity.TabIndex = 23;
            numericUpDownQuantity.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Image = Properties.Resources.carrito__1_;
            label1.Location = new Point(301, 308);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 24;
            label1.Text = "label1";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BackgroundImage = (Image)resources.GetObject("panel4.BackgroundImage");
            panel4.Controls.Add(label3);
            panel4.Location = new Point(706, 620);
            panel4.Name = "panel4";
            panel4.Size = new Size(120, 116);
            panel4.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 75F);
            label3.ForeColor = Color.DarkBlue;
            label3.Image = Properties.Resources.logo1__1_;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 166);
            label3.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1497, 790);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(label_1);
            Controls.Add(comboBoxStaff);
            Controls.Add(comboBoxProduct);
            Controls.Add(label_4);
            Controls.Add(maskedTextBox3);
            Controls.Add(button_delete);
            Controls.Add(button_update);
            Controls.Add(button_consult);
            Controls.Add(button_save);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Controls.Add(label_2);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_test_connection;
        private DataGridView dataGridView;
        private Label label_3;
        private Label label_2;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private Button button_inventory;
        private Button button_staff;
        private Button button_products;
        private Panel panel3;
        private Label label2;
        private Button button_save;
        private Button button_consult;
        private Button button_update;
        private Button button_delete;
        private Label label_1;
        private MaskedTextBox maskedTextBox3;
        private Label label_4;
        private ComboBox comboBoxProduct;
        private ComboBox comboBoxStaff;
        private NumericUpDown numericUpDownQuantity;
        private Label label1;
        private Panel panel4;
        private Label label3;
        private Panel panel5;
        private Label label4;
    }
}
