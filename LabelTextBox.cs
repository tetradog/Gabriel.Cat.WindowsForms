using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabriel.Cat.WindowsForms
{
    public partial class LabelTextBox : UserControl
    {
        bool esPotEditar;


        public LabelTextBox()
        {
            InitializeComponent();
            EsPotEditar = false;
            lblText.Location = new Point(0, 0);
            txtBxText.Location = new Point(0, 0);
            LabelTextBox_Resize(null, null);

        }
        public bool EsPotEditar
        {
            get { return esPotEditar; }
            set { esPotEditar = value; lblText.Visible = !esPotEditar; txtBxText.Visible = esPotEditar;
            if (esPotEditar)
                txtBxText.Text = lblText.Text;
            else
                lblText.Text = txtBxText.Text;
            }
        }
        private void LabelTextBox_Resize(object sender, EventArgs e)
        {
            if (!lblText.Size.Equals(lblText.PreferredSize))
            {

                lblText.Size = lblText.PreferredSize;
                txtBxText.Size = lblText.Size;
                Size = lblText.Size;
            }
        }
        public string Text
        {
        	get{return lblText.Text;}
        	set{if(value==null)value="";
        		lblText.Text=value;
        		LabelTextBox_Resize(null, null);}
        		
        	
        }
        public Font FontText
        {
        	get{return lblText.Font;}
        	set{lblText.Font=value;}
        }
    }
}
