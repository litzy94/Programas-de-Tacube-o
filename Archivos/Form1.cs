using System.Windows.Forms;
using System.IO;
using System;

namespace Archivos
{
    public partial class frmAlumnos : Form
    {
        public frmAlumnos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            guardarDatosBinario();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            cancelarAccion();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            AvanzaInicio();
        }

        //Esta sección es para las operaciones en Binario
        Alumno alumno;
        public void guardarDatosBinario()
        {
            alumno = new Alumno(txtID.Text, txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtDomicilio.Text, float.Parse(txtPeso.Text), int.Parse(txtEdad.Text));
            if (alumno.guardarDatosBinario()) MessageBox.Show("registro almacenado con exito");
            else MessageBox.Show("error no se pudo guardar la información");
            cancelarAccion();

        }
        public void AvanzaInicio()
        {
            alumno = new Alumno();
            alumno.AvanzaInicio();
            txtID.Text = alumno.Id;
            txtNombre.Text = alumno.Nombre;
            txtApellidoPaterno.Text = alumno.ApellidoPaterno;
            txtApellidoMaterno.Text = alumno.ApellidoMaterno;
            txtDomicilio.Text = alumno.Domicilio;
            txtPeso.Text = alumno.Peso.ToString();
            txtEdad.Text = alumno.Edad.ToString();
        }
        public void cancelarAccion()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtDomicilio.Clear();
            txtPeso.Clear();
            txtEdad.Clear();
        }

        //Esta sección es para las operaciones en Archivo de texto normal
        public void MostrarLista()
        {
            rtbMostrar.Clear();
            FileStream fileStream = new FileStream("Alumno.txt", FileMode.Open, FileAccess.Read);

            if (File.Exists("Alumno.txt"))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                streamReader = File.OpenText("Alumno.txt");
                int x = 0;
                string[] mostrar;
                string separar = streamReader.ReadToEnd();
                mostrar = separar.Split('|');

                while (x < mostrar.Length)
                {
                    rtbMostrar.Text += mostrar[x];
                    rtbMostrar.Text += "  ";
                    x++;
                }
                streamReader.Close();
            }
            else
            {
                MessageBox.Show("El archivo no existe");
            }

            fileStream.Close();
        }

        public void Buscar()
        {
            FileStream fileStream = new FileStream("Alumno.txt", FileMode.Open, FileAccess.Read);
            bool x = true;

            if (File.Exists("Alumno.txt"))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                String IdBusqueda = txtID.Text;

                while (!streamReader.EndOfStream)
                {
                    String textoLinea = streamReader.ReadLine();
                    string[] separar = textoLinea.Split('|');
                    if (separar[0] == IdBusqueda)
                    {
                        txtNombre.Text = separar[1];
                        txtApellidoPaterno.Text = separar[2];
                        txtApellidoMaterno.Text = separar[3];
                        txtDomicilio.Text = separar[4];
                        x = false;
                    }
                }
                if (x)
                {
                    MessageBox.Show("El ID que ingreso es incorrecto,o no existe");
                    cancelarAccion();
                }
                streamReader.Close();
            }
            else
                MessageBox.Show("El archivo no existe");
            fileStream.Close();
        }
    }
}
