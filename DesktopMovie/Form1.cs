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
    public partial class Form1 : Form
    {
        public Form1()
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
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            myServices.updateMovie(int.Parse(dgvResult.CurrentCell.Value.ToString()), txtTitle.Text, int.Parse(txtTime.Text), int.Parse(txtYear.Text));
            dgvResult.DataSource = myServices.getMovies();
        }

        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            dgvResult.DataSource = myServices.searchMovies(txtTitle.Text);
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            myServices.deleteMovie(int.Parse(dgvResult.CurrentCell.Value.ToString()));
            dgvResult.DataSource = myServices.getMovies();
        }

        private void btnLoadMovie_Click(object sender, EventArgs e)
        {
            myServices.loadMovie(int.Parse(dgvResult.CurrentCell.Value.ToString()), txtTitle, txtTime, txtYear);
        }
    }
}
