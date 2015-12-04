/*
 * Creado por SharpDevelop.
 * Usuario: pc
 * Fecha: 01/05/2015
 * Hora: 13:29
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using Gabriel.Cat.Utilitats;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Gabriel.Cat.Extension;
namespace Gabriel.Cat
{
	/// <summary>
	/// Description of ColorListBox.
	/// </summary>
	public partial class ColorListBox : Panel,IEnumerable<ColorItemList>
	{
		Point ultimaPos;
		ColorItemList item;
		Semaphore semafor;
		public event EventHandler SelectedItemChanged;
		int index = 0;
		public ColorListBox()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			ultimaPos = new Point(0, 0);
			AutoScroll = true;
			item = new ColorItemList();
			BorderStyle = BorderStyle.FixedSingle;
			semafor = new Semaphore(1, 1);
		}
		public void Add(object obj)
		{
			Add(obj, SystemColors.Control);
		}
		public void Add(object obj, Color color)
		{
			if (InvokeRequired) {
				Action act = () => Add(obj, color);
				BeginInvoke(act);
			} else {
				semafor.WaitOne();
				int amplada = Width;
				ColorItemList item = new ColorItemList() {
					ObjectToView = obj,
					ColorItem = color,
					Width = amplada,
					Location = ultimaPos
				};
				item.ControlSeleccionado += DeseleccionaISelecciona;
				ultimaPos = new Point(ultimaPos.X, ultimaPos.Y + item.Height);
				Controls.Add(item);
				semafor.Release();
			}
			
		}
		public void AddRange(IEnumerable<object> objs)
		{
			AddRange(objs, SystemColors.Control);
		}
		public void AddRange(IEnumerable<object> objs, Color color)
		{
			foreach (object obj in objs)
				Add(obj, color);
			Compacta();
		}
		public void Remove(IEnumerable<object> objs)
		{
			foreach (object obj in objs)
				Remove(obj, false);
			Compacta();
		}
		public void Remove(object obj)
		{
			Remove(obj, true);
		}
		private void Remove(object obj, bool compacta)
		{
			if (InvokeRequired) {
				Action act = () => Remove(obj, compacta);
				BeginInvoke(act);
			} else {
				semafor.WaitOne();
				ColorItemList[] items = Controls.Casting<ColorItemList>().Filtra((controlItem) => {
					return Equals(obj, controlItem.ObjectToView);
				}).ToTaula();
				for (int i = 0; i < items.Length; i++)
					Controls.Remove(items[i]);
				if (compacta) {
					Compacta();
				}
				semafor.Release();
			}
		}

		public	void Compacta()
		{
			if (InvokeRequired) {
				Action act = () => Compacta();
				BeginInvoke(act);
			} else {
				Refresh();
				AutoScrollPosition = new Point(0, 0);
				ultimaPos = new Point(0, 0);
				Control[] controles = Controls.Casting<Control>().ToTaula();
				for (int i = 0; i < controles.Length; i++) {
					controles[i].Location = ultimaPos;
					ultimaPos = new Point(ultimaPos.X, ultimaPos.Y + controles[i].Height);
				}

			}
		}
		public void Clear()
		{
			if (InvokeRequired) {
				Action act = () => Clear();
				BeginInvoke(act);
			} else {
				semafor.WaitOne();
				ultimaPos = new Point(0, 0);
				Controls.Clear();
				semafor.Release();
			}
		}

		void SeleccionaItem(int index, bool selecionado)
		{
			if (index > Controls.Count)
				index = Controls.Count - 1;
			if (index < 0)
				index = 0;
			if (Controls.Count > index)
				((ColorItemList)(Controls[index])).Seleccionado = selecionado;
		}
		public int SelectedIndex {
			get{ return index; }
			set {
				SeleccionaItem(index, false);
				index = value;
				SeleccionaItem(index, true);
			}
		}

		public void CambiaColor(object obj, Color color)
		{
			ColorItemList[] items = Controls.Casting<ColorItemList>().Filtra((controlItem) => {
				return Equals(obj, controlItem.ObjectToView);
			}).ToTaula();
			for (int i = 0; i < items.Length; i++) {
				items[i].ColorItem = color;
				items[i].ObjectToView = obj;
			}
		}
		public int Count {
			get{ return Controls.Count; }
		}
		void DeseleccionaISelecciona(object sender, EventArgs e)
		{
			item.Seleccionado = false;
			item = sender as ColorItemList;
			if (SelectedItemChanged != null)
				SelectedItemChanged(item.ObjectToView, e);
		}

		#region IEnumerable implementation

		public IEnumerator<ColorItemList> GetEnumerator()
		{
			return Controls.Casting<ColorItemList>().ObtieneEnumerador();
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
	public class ColorItemList:UserControl
	{
		Color colorSinSeleccionar;
		Panel pnlItem;
		object obj;
		Label lblDescripcion;
		bool seleccionado;
		bool seleccionColorInvertido;
		public event EventHandler ControlSeleccionado;
		public ColorItemList()
		{
			seleccionColorInvertido = false;
			seleccionado = false;
			pnlItem = new Panel();
			lblDescripcion = new Label();
			lblDescripcion.Text = "ToString";
			pnlItem.Controls.Add(lblDescripcion);
			pnlItem.Dock = DockStyle.Fill;
			lblDescripcion.Dock = DockStyle.Fill;
			Controls.Add(pnlItem);
			pnlItem.Click += ClickEvent;
			lblDescripcion.Click += ClickEvent;
			Click += ClickEvent;
		}
		public Color ColorItem {
			get{ return colorSinSeleccionar; }
			set {
				if (InvokeRequired) {
					Action act = () => ColorItem = value;
					BeginInvoke(act);
				} else {
					colorSinSeleccionar = value;
					if (!Seleccionado)
						pnlItem.BackColor = colorSinSeleccionar;
					else {
						if (seleccionColorInvertido)
							pnlItem.BackColor = colorSinSeleccionar.Invertir();
						else
							pnlItem.BackColor = Color.Turquoise;
					}
					if (pnlItem.BackColor.EsColorClaro())
						lblDescripcion.ForeColor = Color.White;
					else
						lblDescripcion.ForeColor = Color.Black;
				}
			}
		}

		public bool SeleccionColorInvertido {
			get {
				return seleccionColorInvertido;
			}
			set {
				seleccionColorInvertido = value;
			}
		}

		public object ObjectToView {
			get{ return obj; }
			set {
				if (InvokeRequired) {
					Action act = () => ObjectToView = value;
					BeginInvoke(act);
				} else {
					obj = value;
					lblDescripcion.Text = obj.ToString();
				}
			}
		}

		public bool Seleccionado {
			get {
				return seleccionado;
			}
			set {
				if (InvokeRequired) {
					Action act = () => Seleccionado = value;
					BeginInvoke(act);
				} else {
					seleccionado = value;
					ColorItem = ColorItem;
					if (ControlSeleccionado != null && seleccionado)
						ControlSeleccionado(this, new EventArgs());
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Height = lblDescripcion.PreferredHeight;
		}
			
		
		void ClickEvent(object sender, EventArgs e)
		{
			Seleccionado = !Seleccionado;
		}
	}
}
