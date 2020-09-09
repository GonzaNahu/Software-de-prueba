namespace WindowsFormsApplication1
{
    partial class pruductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_ag = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.txttel = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnmod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ag
            // 
            this.btn_ag.Location = new System.Drawing.Point(114, 102);
            this.btn_ag.Name = "btn_ag";
            this.btn_ag.Size = new System.Drawing.Size(134, 34);
            this.btn_ag.TabIndex = 19;
            this.btn_ag.Text = "Agregar";
            this.btn_ag.UseVisualStyleBackColor = true;
            this.btn_ag.Click += new System.EventHandler(this.btn_ag_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(254, 103);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(134, 34);
            this.btn_exit.TabIndex = 18;
            this.btn_exit.Text = "Salir";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(124, 66);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(156, 20);
            this.txtmail.TabIndex = 25;
            // 
            // txttel
            // 
            this.txttel.Location = new System.Drawing.Point(124, 37);
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(100, 20);
            this.txttel.TabIndex = 24;
            this.txttel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttel_KeyPress);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(124, 9);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(156, 20);
            this.txtname.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombre del producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // btnmod
            // 
            this.btnmod.Location = new System.Drawing.Point(114, 102);
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(134, 34);
            this.btnmod.TabIndex = 27;
            this.btnmod.Text = "Modificar";
            this.btnmod.UseVisualStyleBackColor = true;
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // pruductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 146);
            this.ControlBox = false;
            this.Controls.Add(this.btnmod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.txttel);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ag);
            this.Controls.Add(this.btn_exit);
            this.Name = "pruductos";
            this.Text = "pruductos";
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtmail;
        public System.Windows.Forms.TextBox txttel;
        public System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btn_ag;
        public System.Windows.Forms.Button btn_exit;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider Error;
        public System.Windows.Forms.Button btnmod;
    }
}