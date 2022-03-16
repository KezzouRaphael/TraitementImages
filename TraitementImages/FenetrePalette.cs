using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraitementImages
{
    public partial class FenetrePalette : Form
    {
        Color _Arrive;
        public Color Arrive
        {
            get { return _Arrive; }
            set { _Arrive = value; }
        }
        public FenetrePalette()
        {
            InitializeComponent();
        }


        private void BoutonArrive_Click(object sender, EventArgs e)
        {
            ColorDialog ChoixCouleur = new ColorDialog();
            ChoixCouleur.AnyColor = true;
            ChoixCouleur.Color = BoutonArrive.BackColor;
            if (ChoixCouleur.ShowDialog() == DialogResult.OK)
            {
                BoutonArrive.BackColor = ChoixCouleur.Color;
                Arrive = BoutonArrive.BackColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
