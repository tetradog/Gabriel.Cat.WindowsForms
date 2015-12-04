/*
 * Creado por SharpDevelop.
 * Usuario: pc
 * Fecha: 15/04/2015
 * Hora: 20:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Gabriel.Cat.Extension;
namespace Gabriel.Cat.Utilitats
{
	/// <summary>
	/// Description of VisorImatgesSeleccionables.
	/// </summary>
	public partial class VisorImatgesSeleccionables : UserControl
	{
		Llista<ImagenSeleccionable> imatges;
		ImagenSeleccionable[,] matriuImatges;
		int contador = 0;
		Size medidaImg;

		int columnes;
		int files;
		int index;
		public VisorImatgesSeleccionables()
		{
			files = 1;
			columnes = 1;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			imatges = new Llista<ImagenSeleccionable>();
			MouseWheel += ScrollEvent;
			MouseHover += FocusEvent;
			index=-1;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public VisorImatgesSeleccionables(IEnumerable<ImagenSeleccionable> imatges)
			: this()
		{
			Afegir(imatges);
			Index = 0;
		}

		public int Columnes {
			get {
				return columnes;
			}
			set {
				if (value < 1)
					value = 1;
				columnes = value;
				RedimensionaImagenes();
				PosaImatges();
			}
		}

		public int Files {
			get {
				return files;
			}
			set {
				if (value < 1)
					value = 1;
				files = value;
				
				RedimensionaImagenes();
				PosaImatges();
			}
		}
		public int ImatgesVisualitzades {
			get {
				if (imatges.Count < Files * Columnes)
					return imatges.Count;
				else
					return Files * Columnes;
				
			}
		}

		public int Index {
			get {
				return index;
			}
			set {
				
				if (matriuImatges != null && matriuImatges.GetLength(DimensionMatriz.Fila) >0)
					index = value % matriuImatges.GetLength(DimensionMatriz.Fila);
				else
					index = -1;
				if (index >= 0) {
					Controls.Clear();
					try {
						for(int index2=index,posY=0;index2<index+2;index2++,posY++)
							for (int x=0; x < Columnes && matriuImatges[x,index2] != null; x++) {
							matriuImatges[x,index2].MostrarImagen = true;
							matriuImatges[x,index2].Location = new Point( x *( Width / Columnes),posY * (Height / Files));
							Controls.Add(matriuImatges[x,index2]);
						}}catch{}
				}
			}
		}

		void FocusEvent(object sender, EventArgs e)
		{
			Focus();
		}

		void ScrollEvent(object sender, MouseEventArgs e)
		{
			if (contador % 5 == 0)
				if (e.Delta > 0)
					Index++;
				else
					Index--;
			
			contador++;
		}
		void PosaImatges()
		{
			ActualitzaMatriu();
			Index = 0;
		}

		void ActualitzaMatriu()
		{
			matriuImatges = imatges.ToMatriu(Columnes,DimensionMatriz.Columna);
		}

		void RedimensionaImagenes()
		{
			for (int i = 0; i < imatges.Count; i++) {
				imatges[i].Size = medidaImg;
			}
		}

		public void Buida()
		{
			for(int i=0;i<imatges.Count;i++)
			{
				imatges[i].MouseWheel -= ScrollEvent;
				imatges[i].MouseHover -= FocusEvent;
				
			}
			imatges.Buida();
			Controls.Clear();
			index = 0;
		}
		public void Afegir(IEnumerable<ImagenSeleccionable> imatges)
		{
			if(imatges!=null)
			foreach (ImagenSeleccionable img in imatges)
				Afegir(img);
			
		}
		public void Afegir(ImagenSeleccionable imatge)
		{
			if(imatge!=null){
			imatge.MouseWheel += ScrollEvent;
			imatge.MouseHover += FocusEvent;
			imatges.Afegir(imatge);
			imatge.Size = medidaImg;
			ActualitzaMatriu();}
		}
		public ImagenSeleccionable[] ImatgesSeleccionades()
		{
			return imatges.Filtra(Comprova) as ImagenSeleccionable[];
		}
		public bool Comprova(ImagenSeleccionable imatge)
		{
			return imatge.Seleccionat;
		}
		protected override void OnResize(EventArgs e)
		{
			
			if (Height > 0 && Width > 0) {
				
				int medida = Width / Columnes;
				if (Height / Files < medida)
					medida = Height / Files;
				medidaImg = new Size(medida, medida);
				RedimensionaImagenes();
			}
			base.OnResize(e);
			
		}
		
	}
}
