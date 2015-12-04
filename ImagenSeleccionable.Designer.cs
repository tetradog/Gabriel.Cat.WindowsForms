/*
 * Creado por SharpDevelop.
 * Usuario: pc
 * Fecha: 15/04/2015
 * Hora: 17:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Gabriel.Cat
{
	partial class ImagenSeleccionable
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox pbImg;
		private System.Windows.Forms.CheckBox ckbDescripcion;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pbImg = new System.Windows.Forms.PictureBox();
			this.ckbDescripcion = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pbImg);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.ckbDescripcion);
			this.splitContainer1.Size = new System.Drawing.Size(150, 137);
			this.splitContainer1.SplitterDistance = 103;
			this.splitContainer1.TabIndex = 0;
			// 
			// pbImg
			// 
			this.pbImg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbImg.Location = new System.Drawing.Point(0, 0);
			this.pbImg.Name = "pbImg";
			this.pbImg.Size = new System.Drawing.Size(150, 103);
			this.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbImg.TabIndex = 0;
			this.pbImg.TabStop = false;
			// 
			// ckbDescripcion
			// 
			this.ckbDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ckbDescripcion.Location = new System.Drawing.Point(0, 0);
			this.ckbDescripcion.Name = "ckbDescripcion";
			this.ckbDescripcion.Size = new System.Drawing.Size(150, 30);
			this.ckbDescripcion.TabIndex = 0;
			this.ckbDescripcion.Text = "Descripcion IMG";
			this.ckbDescripcion.UseVisualStyleBackColor = true;
			// 
			// ImagenSeleccionable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "ImagenSeleccionable";
			this.Size = new System.Drawing.Size(150, 137);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
