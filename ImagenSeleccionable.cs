/*
 * Creado por SharpDevelop.
 * Usuario: pc
 * Fecha: 15/04/2015
 * Hora: 17:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using Gabriel.Cat.Utilitats;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Gabriel.Cat.Extension;
namespace Gabriel.Cat
{
	/// <summary>
	/// Description of ImagenSeleccionable.
	/// </summary>
	public partial class ImagenSeleccionable : ControlUsuari
	{
		string ruta;
		bool mostrarImagen=false;
		public ImagenSeleccionable()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			pbImg.Click+=ChekedEvent;
			pbImg.DoubleClick+=AbrirImgEvent;
			Click+=ChekedEvent;
			DoubleClick+=AbrirImgEvent;
			splitContainer1.DoubleClick+=AbrirImgEvent;
			splitContainer1.Click+=ChekedEvent;
			splitContainer1.IsSplitterFixed=true;
			
//
			// TODO: Add constructor code after the InitializeComponent() call.
//
		}

		void AbrirImgEvent(object sender, EventArgs e)
		{
			new System.IO.FileInfo(Ruta).Abrir();
		}
		void ChekedEvent(object sender, EventArgs e)
		{
			ckbDescripcion.Checked=!ckbDescripcion.Checked;
		}

		public ImagenSeleccionable(string rutaImg)
			: this()
		{
			Ruta = rutaImg;

		}
		public string Ruta {
			get {
				return ruta;
			}
			set {
				ruta = value;
							try{
					if(mostrarImagen)
				pbImg.Image=new Bitmap(ruta);}
			catch{
				throw new Exception("La imatge no s'ha pogut obrir! "+ruta);
			}
			}
		}
		public bool MostrarImagen
		{
			get{return mostrarImagen;}
			set{mostrarImagen=value;
				if(mostrarImagen)
					pbImg.Image=new Bitmap(ruta);
				else
					pbImg.Image=new Bitmap(1,1);}
		}
		public string Descripcio
		{
			get{return ckbDescripcion.Text;}
			set{ckbDescripcion.Text=value;}
		}
		public bool Seleccionat
		{
			get{return ckbDescripcion.Checked;}
			set{ckbDescripcion.Checked=value;}
		}
		public Color ForeColor
		{
			get{return ckbDescripcion.ForeColor;}
			set{ckbDescripcion.ForeColor=value;}
		}
	}
}
