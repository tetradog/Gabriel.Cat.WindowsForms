/*
 * Creado por SharpDevelop.
 * Usuario: pc
 * Fecha: 15/04/2015
 * Hora: 17:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Gabriel.Cat;

namespace Gabriel.Cat
{
	/// <summary>
	/// Description of ControlUsuari.
	/// </summary>
	public partial class ControlUsuari : UserControl
	{
		dynamic objecte;
		public ControlUsuari()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//


		}

		public dynamic Objecte {
			get {
				return objecte;
			}
			set {
				objecte = value;
			}
		}
	}
}
