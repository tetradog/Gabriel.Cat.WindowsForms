/*
 * Creado por SharpDevelop.
 * Usuario: Pingu
 * Fecha: 24/03/2015
 * Hora: 18:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gabriel.Cat.WindowsForms
{
	/// <summary>
	/// Description of Etiqueta.
	/// </summary>
	public partial class Etiqueta : Label
	{
		public Etiqueta()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Text = " ";
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			EscalarFuente(this);
			
		}
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			OnResize(new EventArgs());
		}
		public static void EscalarFuente(Label lab)
		{
			Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
			Graphics graphics = Graphics.FromImage(fakeImage);


			SizeF extent = graphics.MeasureString(lab.Text, lab.Font);


			float hRatio = lab.Height / (extent.Height*1.20f);
			float wRatio = lab.Width / (extent.Width*1.20f);
			float ratio = (hRatio < wRatio) ? hRatio : wRatio;

			float newSize = lab.Font.Size * ratio;



			lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
			

		}
	}
}
