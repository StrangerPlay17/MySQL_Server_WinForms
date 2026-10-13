namespace empresa_inventario
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // button_test_connection
            // 
            button_test_connection.BackColor = SystemColors.ControlLightLight;
            button_test_connection.Cursor = Cursors.Hand;
            button_test_connection.Dock = DockStyle.Bottom;
            button_test_connection.Font = new Font("Segoe UI", 13F);
            button_test_connection.ForeColor = SystemColors.InactiveCaptionText;
            button_test_connection.Location = new Point(0, 666);
            button_test_connection.Name = "button_test_connection";
            button_test_connection.Size = new Size(251, 124);
            button_test_connection.TabIndex = 0;
            button_test_connection.Text = "Test Connection";
            button_test_connection.UseVisualStyleBackColor = false;
            button_test_connection.Click += button_test_connection_Click;
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = Color.FromArgb(29, 29, 50);
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(676, 97);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(722, 451);
            dataGridView.TabIndex = 1;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // label_3
            // 
            label_3.AutoSize = true;
            label_3.Dock = DockStyle.Fill;
            label_3.Font = new Font("Segoe UI", 30F);
            label_3.ForeColor = SystemColors.InactiveCaptionText;
            label_3.Location = new Point(0, 0);
            label_3.Name = "label_3";
            label_3.Size = new Size(724, 67);
            label_3.TabIndex = 2;
            label_3.Text = "                Gestion de Productos";
            label_3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Font = new Font("Segoe UI", 18F);
            label_2.ForeColor = Color.LawnGreen;
            label_2.Location = new Point(284, 244);
            label_2.Name = "label_2";
            label_2.Size = new Size(173, 41);
            label_2.TabIndex = 4;
            label_2.Text = "Descripción";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = Color.Bisque;
            maskedTextBox1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            maskedTextBox1.ForeColor = Color.Red;
            maskedTextBox1.Location = new Point(274, 168);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Size = new Size(388, 51);
            maskedTextBox1.TabIndex = 5;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.BackColor = Color.FromArgb(64, 64, 64);
            maskedTextBox2.Font = new Font("Segoe UI", 20F);
            maskedTextBox2.ForeColor = Color.AliceBlue;
            maskedTextBox2.Location = new Point(274, 303);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(388, 52);
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
            panel2.Size = new Size(251, 790);
            panel2.TabIndex = 10;
            // 
            // button_inventory
            // 
            button_inventory.Cursor = Cursors.Hand;
            button_inventory.Dock = DockStyle.Top;
            button_inventory.FlatStyle = FlatStyle.Popup;
            button_inventory.Font = new Font("Segoe UI", 12F);
            button_inventory.ForeColor = SystemColors.ButtonFace;
            button_inventory.Location = new Point(0, 418);
            button_inventory.Name = "button_inventory";
            button_inventory.Size = new Size(251, 127);
            button_inventory.TabIndex = 13;
            button_inventory.Text = "Inventario 📦";
            button_inventory.UseVisualStyleBackColor = true;
            button_inventory.Click += button_inventory_Click_1;
            // 
            // button_staff
            // 
            button_staff.Cursor = Cursors.Hand;
            button_staff.Dock = DockStyle.Top;
            button_staff.FlatStyle = FlatStyle.Popup;
            button_staff.Font = new Font("Segoe UI", 12F);
            button_staff.ForeColor = Color.Snow;
            button_staff.Location = new Point(0, 285);
            button_staff.Name = "button_staff";
            button_staff.Size = new Size(251, 133);
            button_staff.TabIndex = 12;
            button_staff.Text = "Personal \U0001f9d1‍💼";
            button_staff.UseVisualStyleBackColor = true;
            button_staff.Click += button_staff_Click_1;
            // 
            // button_products
            // 
            button_products.Cursor = Cursors.Hand;
            button_products.Dock = DockStyle.Top;
            button_products.FlatStyle = FlatStyle.Popup;
            button_products.Font = new Font("Segoe UI", 12F);
            button_products.ForeColor = Color.Snow;
            button_products.Location = new Point(0, 156);
            button_products.Name = "button_products";
            button_products.Size = new Size(251, 129);
            button_products.TabIndex = 11;
            button_products.Text = "Productos 🛍️";
            button_products.UseVisualStyleBackColor = true;
            button_products.Click += button_products_Click_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(39, 39, 36);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(251, 156);
            panel3.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(39, 39, 46);
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 75F);
            label2.ForeColor = Color.Cornsilk;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(242, 166);
            label2.TabIndex = 11;
            label2.Text = "🏢";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Turquoise;
            panel1.Controls.Add(label_3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(251, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1147, 91);
            panel1.TabIndex = 11;
            panel1.Tag = "";
            // 
            // button_save
            // 
            button_save.BackColor = Color.Green;
            button_save.Cursor = Cursors.Hand;
            button_save.Font = new Font("Segoe UI", 13F);
            button_save.ForeColor = Color.Ivory;
            button_save.Location = new Point(729, 593);
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
            button_consult.Location = new Point(1066, 593);
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
            button_update.Location = new Point(729, 686);
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
            button_delete.Location = new Point(1066, 686);
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
            label_1.Location = new Point(284, 101);
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
            maskedTextBox3.Location = new Point(274, 453);
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(388, 52);
            maskedTextBox3.TabIndex = 19;
            maskedTextBox3.Visible = false;
            // 
            // label_4
            // 
            label_4.AutoSize = true;
            label_4.Font = new Font("Segoe UI", 18F);
            label_4.ForeColor = Color.LawnGreen;
            label_4.Location = new Point(284, 392);
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
            comboBoxProduct.Location = new Point(274, 303);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(388, 53);
            comboBoxProduct.TabIndex = 21;
            comboBoxProduct.Visible = false;
            // 
            // comboBoxStaff
            // 
            comboBoxStaff.BackColor = SystemColors.ButtonFace;
            comboBoxStaff.Font = new Font("Segoe UI", 20F);
            comboBoxStaff.ForeColor = SystemColors.WindowText;
            comboBoxStaff.FormattingEnabled = true;
            comboBoxStaff.Location = new Point(274, 453);
            comboBoxStaff.Name = "comboBoxStaff";
            comboBoxStaff.Size = new Size(388, 53);
            comboBoxStaff.TabIndex = 22;
            comboBoxStaff.Visible = false;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.BackColor = Color.DarkSeaGreen;
            numericUpDownQuantity.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            numericUpDownQuantity.Location = new Point(274, 575);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(150, 51);
            numericUpDownQuantity.TabIndex = 23;
            numericUpDownQuantity.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1398, 790);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxStaff);
            Controls.Add(comboBoxProduct);
            Controls.Add(label_4);
            Controls.Add(maskedTextBox3);
            Controls.Add(label_1);
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
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_test_connection;
        private DataGridView dataGridView;
        private Label label_3;
        private Label id_product_label;
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
    }
}
