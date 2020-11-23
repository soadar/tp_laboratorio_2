namespace TP4
{
    partial class Cerveceria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridInforme = new System.Windows.Forms.DataGridView();
            this.bntSalir = new System.Windows.Forms.Button();
            this.btnInforme = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnAgregarStock = new System.Windows.Forms.Button();
            this.bntLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInforme)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridInforme
            // 
            this.dataGridInforme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridInforme.Location = new System.Drawing.Point(130, 212);
            this.dataGridInforme.Name = "dataGridInforme";
            this.dataGridInforme.RowHeadersVisible = false;
            this.dataGridInforme.Size = new System.Drawing.Size(516, 150);
            this.dataGridInforme.TabIndex = 0;
            // 
            // bntSalir
            // 
            this.bntSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSalir.Image = global::TP4.Properties.Resources.sad___copia;
            this.bntSalir.Location = new System.Drawing.Point(536, 72);
            this.bntSalir.Name = "bntSalir";
            this.bntSalir.Size = new System.Drawing.Size(110, 110);
            this.bntSalir.TabIndex = 4;
            this.bntSalir.Text = "Salir";
            this.bntSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bntSalir.UseVisualStyleBackColor = true;
            this.bntSalir.Click += new System.EventHandler(this.bntSalir_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInforme.Image = global::TP4.Properties.Resources.oktoberfest___copia;
            this.btnInforme.Location = new System.Drawing.Point(403, 72);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(110, 110);
            this.btnInforme.TabIndex = 3;
            this.btnInforme.Text = "Informe de stock";
            this.btnInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInforme.UseVisualStyleBackColor = true;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Image = global::TP4.Properties.Resources.cerveza__1____copia;
            this.btnVentas.Location = new System.Drawing.Point(271, 72);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(110, 110);
            this.btnVentas.TabIndex = 2;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnAgregarStock
            // 
            this.btnAgregarStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarStock.Image = global::TP4.Properties.Resources.aditivos___copia;
            this.btnAgregarStock.Location = new System.Drawing.Point(130, 72);
            this.btnAgregarStock.Name = "btnAgregarStock";
            this.btnAgregarStock.Size = new System.Drawing.Size(110, 110);
            this.btnAgregarStock.TabIndex = 1;
            this.btnAgregarStock.Text = "Agregar Stock";
            this.btnAgregarStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarStock.UseVisualStyleBackColor = true;
            this.btnAgregarStock.Click += new System.EventHandler(this.btnAgregarStock_Click);
            // 
            // bntLog
            // 
            this.bntLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLog.Location = new System.Drawing.Point(303, 390);
            this.bntLog.Name = "bntLog";
            this.bntLog.Size = new System.Drawing.Size(163, 48);
            this.bntLog.TabIndex = 5;
            this.bntLog.Text = "Ver Log";
            this.bntLog.UseVisualStyleBackColor = true;
            this.bntLog.Click += new System.EventHandler(this.bntLog_Click);
            // 
            // Cerveceria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP4.Properties.Resources.vasos;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntLog);
            this.Controls.Add(this.dataGridInforme);
            this.Controls.Add(this.bntSalir);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnAgregarStock);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cerveceria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerveceria Dario Salas 2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cerveceria_FormClosing);
            this.Load += new System.EventHandler(this.Cerveceria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInforme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridInforme;
        private System.Windows.Forms.Button bntSalir;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnAgregarStock;
        private System.Windows.Forms.Button bntLog;
    }
}

