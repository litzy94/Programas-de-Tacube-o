using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Archivos
{
    class Alumno
    {
        private string id;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string domicilio;
        private float peso;
        private int edad;

        public Alumno()
        {

        }

        public Alumno(string id, string nombre, string apellidoPaterno, string apellidoMaterno, string domicilio, float peso, int edad)
        {
            this.Id = id; //12
            this.Nombre = nombre; //30 
            this.ApellidoPaterno = apellidoPaterno; //25
            this.ApellidoMaterno = apellidoMaterno; //25
            this.Domicilio = domicilio; //50
            this.Peso = peso; //4
            this.Edad = edad;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public float Peso { get => peso; set => peso = value; }
        public int Edad { get => edad; set => edad = value; }

        //Archivos de Texto normal
        public bool guardarDatos()
        {
            try
            {

                //Probar con el openorcreate en FileMode
                FileStream fileStream = new FileStream("Alumno.txt", FileMode.Append, FileAccess.Write);
                StreamWriter stremWriter = new StreamWriter(fileStream);
                stremWriter.Write(id + "|");
                stremWriter.Write(nombre + "|");
                stremWriter.Write(apellidoPaterno + "|");
                stremWriter.Write(apellidoMaterno + "|");
                stremWriter.WriteLine(domicilio + "|");
                stremWriter.Flush();
                stremWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Archivos de Texto Binario
        FileStream fileStrem = new FileStream("AlumnoBinario.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public bool guardarDatosBinario()
        {
            BinaryWriter binaryWriter = new BinaryWriter(fileStrem);
            try
            {
                binaryWriter.Seek(0, SeekOrigin.End);
                binaryWriter.Write(id.PadRight(12));
                binaryWriter.Write(nombre.PadRight(30));
                binaryWriter.Write(apellidoPaterno.PadRight(25));
                binaryWriter.Write(apellidoMaterno.PadRight(25));
                binaryWriter.Write(domicilio.PadRight(50));
                binaryWriter.Write(peso);
                binaryWriter.Write(edad);
                binaryWriter.Flush();
                //MessageBox.Show(fileStrem.Length.ToString());
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                binaryWriter.Close();
                fileStrem.Close();
            }
        }

        public void AvanzaInicio()
        {
            BinaryReader binaryReader = new BinaryReader(fileStrem);
            try
            {
                fileStrem.Seek(0, SeekOrigin.Begin);
                id = binaryReader.ReadString();
                nombre = binaryReader.ReadString();
                apellidoPaterno = binaryReader.ReadString();
                apellidoMaterno =  binaryReader.ReadString();
                domicilio = binaryReader.ReadString();
                peso = binaryReader.ReadSingle();
                edad = binaryReader.ReadInt32();
            }
            catch
            {

            }
            finally
            {
                binaryReader.Close();
                fileStrem.Close();
            }

        }
    }
}
