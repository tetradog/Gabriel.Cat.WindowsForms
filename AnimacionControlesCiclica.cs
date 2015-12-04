/*
 * Creado por SharpDevelop.
 * Usuario: pc
 * Fecha: 08/04/2015
 * Hora: 20:33
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using Gabriel.Cat.Extension;

namespace Gabriel.Cat.WindowsForms
{
	public delegate void  HagoConElControlEventHandler(Control control);
	/// <summary>
	/// Description of AnimacionControlesCiclica.
	/// </summary>
	public partial class AnimacionControlesCiclica : UserControl
	{
		Control[] controlesAMover;
		const int SEPARACIONCONTROLES = 3;
		const int DESPLAZAMIENTOX = 10;
		const int SEGUNDOSREANUDACION = 30;
			 int velocidadAnimacion = 120;
		Thread hiloPrincipalAnimacion;
		HagoConElControlEventHandler queHago;
		System.Timers.Timer temporizador;
		int contadorClic = 1;
		public AnimacionControlesCiclica()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//

			temporizador = new System.Timers.Timer();
			temporizador.Interval = SEGUNDOSREANUDACION * 1000;
			temporizador.Elapsed += ReanudaAnimacionEvento;
		}
		~ AnimacionControlesCiclica()
		{
			AcabaAnimacion();
		}
		public double TiempoAutoReanudacion {
			get{return temporizador.Interval;}
			set{temporizador.Interval=value;}
		}

		public void IniciaAnimacion(IEnumerable<Control> controles, HagoConElControlEventHandler queHagoAlDarLAVuelta = null)
		{
			this.queHago = queHagoAlDarLAVuelta;
			int posX = 0;
			AcabaAnimacion();//paro la animacion si hay una activa
			Controls.Clear();
			Controls.AddRange(controles.ToTaula());
			this.controlesAMover = Controls.OfType<Control>().ToTaula();
			for (int i = 0; i < controlesAMover.Length; i++) {
				controlesAMover[i].Location = new Point(posX, 0);
				posX += controlesAMover[i].Width + SEPARACIONCONTROLES;
				controlesAMover[i].MouseClick += ParaAnimacionEvento;
			}
			hiloPrincipalAnimacion = new Thread(() => EmpiezaAnimacion());
			hiloPrincipalAnimacion.Start();
		}

		void ParaAnimacionEvento(object sender, dynamic e)
		{
			if (contadorClic++ % 2 == 0) {
				temporizador.Start();
				PararAnimacion();
			} else {
				temporizador.Stop();
				ReanudaAnimacion();
			}
		}

		void ReanudaAnimacionEvento(object sender, System.Timers.ElapsedEventArgs e)
		{
			try {
				ReanudaAnimacion();
				temporizador.Stop();
			} catch {
			}
		}

		public int VelocidadAnimacion {
			get {
				return velocidadAnimacion;
			}
			set {
				velocidadAnimacion = value;
			}
		}

		void EmpiezaAnimacion()
		{
			int posicionSiguiente = 0;
			while (true) {
				Thread.Sleep(VelocidadAnimacion);
				for (int i = 0; i < controlesAMover.Length; i++)
					if (controlesAMover[i].Location.X + controlesAMover[i].Width <= 0) {
						//el visor tiene que ir detras del ultimo si este no ha salido aun del Width sino se pone a whidth...
						if (i == 0)
							posicionSiguiente = controlesAMover.Length - 1;
						else
							posicionSiguiente = i - 1;
						if (controlesAMover[posicionSiguiente].Location.X + controlesAMover[posicionSiguiente].Width >= Width)
							MueveControl(controlesAMover[i], new Point(controlesAMover[posicionSiguiente].Location.X + controlesAMover[posicionSiguiente].Width + 5, 0));
						else
							MueveControl(controlesAMover[i], new Point(Width, 0));
						if (queHago != null) {
							try{ queHago(controlesAMover[i]);
							
							Thread.Sleep(100);}catch{}
						}
					} else
						MueveControl(controlesAMover[i], new Point(controlesAMover[i].Location.X - DESPLAZAMIENTOX, 0));
				
			}
		}

		void MueveControl(Control userControl, Point point)
		{
			Action act = () => userControl.Location = point;
			try {
				BeginInvoke(act);
			} catch {
			}
			
		}

		public void PararAnimacion()
		{
			if (hiloPrincipalAnimacion != null && hiloPrincipalAnimacion.IsAlive)
				try {
				hiloPrincipalAnimacion.Suspend();
				} catch {
				}
		}
		public void ReanudaAnimacion()
		{
			if (hiloPrincipalAnimacion != null && hiloPrincipalAnimacion.IsAlive)
				try {
				hiloPrincipalAnimacion.Resume();
				} catch {
				}
		}

		public	void AcabaAnimacion()
		{
			ReanudaAnimacion();
			if (hiloPrincipalAnimacion != null && hiloPrincipalAnimacion.IsAlive)
				hiloPrincipalAnimacion.Abort();
		}
	}

}
