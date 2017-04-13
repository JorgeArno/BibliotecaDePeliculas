using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace DesktopMovie
{
    public partial class ListMovie : Form
    {
        public ListMovie()
        {
            InitializeComponent();
        }

        SerivicesProcess myServices = new SerivicesProcess();

        private void Form1_Load(object sender, EventArgs e)
        {           

            dgvResult.DataSource = myServices.getMovies();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            myServices.addMovie(txtTitle.Text, int.Parse(txtTime.Text), int.Parse(txtYear.Text));
            dgvResult.DataSource = myServices.getMovies();
            clearText();
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            myServices.updateMovie(int.Parse(dgvResult.CurrentCell.Value.ToString()), txtTitle.Text, int.Parse(txtTime.Text), int.Parse(txtYear.Text));
            dgvResult.DataSource = myServices.getMovies();
            clearText();
        }

        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            dgvResult.DataSource = myServices.searchMovies(txtTitle.Text);
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            try
            {
                myServices.deleteMovie(int.Parse(dgvResult.CurrentCell.Value.ToString()));
                dgvResult.DataSource = myServices.getMovies();
            }
            catch(Exception error)
            {
                MessageBox.Show("Para eliminar una pelicula seleccione el ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadMovie_Click(object sender, EventArgs e)
        {
            try
            {
                myServices.loadMovie(int.Parse(dgvResult.CurrentCell.Value.ToString()), txtTitle, txtTime, txtYear);
            }
            catch(Exception error)
            {
                MessageBox.Show("Para cargar una pelicula seleccione el ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearText()
        {
            txtTime.Clear();
            txtTitle.Clear();
            txtYear.Clear();
        }
     
    }

    
}
