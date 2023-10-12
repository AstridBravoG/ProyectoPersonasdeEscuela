using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoPersonasdeEscuela
{
    public partial class Form1 : Form
    {
        private int n = 0;
        DataTable tabla = new DataTable();
        public Form1()
        {
            InitializeComponent();
            InicializarTabla();
        }
        private void InicializarTabla()
        {

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Nombre";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Sueldo";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Calificacion";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Tipo de persona";
            tabla.Columns.Add(column);

            //dtgListaDatos.DataSource = tabla;

        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            StringBuilder datos = new StringBuilder();

            foreach (DataRow row in tabla.Rows)
            {
                datos.AppendLine("Nombre: " + row["Nombre"].ToString());
                datos.AppendLine("Sueldo: " + row["Sueldo"].ToString());
                datos.AppendLine("Calificación: " + row["Calificacion"].ToString());
                datos.AppendLine("Tipo de persona: " + row["Tipo de persona"].ToString());
                datos.AppendLine();
            }

            if (datos.Length > 0)
            {
                MessageBox.Show("Datos almacenados:\n\n" + datos.ToString(), "Datos Guardados");
            }
            else
            {
                MessageBox.Show("No hay datos almacenados.", "Datos Guardados");
            }
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radEstudiante_CheckedChanged(object sender, EventArgs e)
        {
            if (radEstudiante.Checked)
            {

                txtNombre.ReadOnly = false;
                txtSueldo.ReadOnly = true;
                txtCalificacion.ReadOnly = false;
            }
        }

        private void radProfesor_CheckedChanged(object sender, EventArgs e)
        {
            if (radProfesor.Checked)
            {

                txtNombre.ReadOnly = false;
                txtSueldo.ReadOnly = false;
                txtCalificacion.ReadOnly = true;
            }
        }

        private void btnCapturarDatos_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int sueldo, calificacion;

            // adicionamos nuevo renglon
            int n = datagvMostrar.Rows.Add();

            // Colocamos la informacion

            datagvMostrar.Rows[n].Cells[0].Value = txtNombre.Text;
            datagvMostrar.Rows[n].Cells[1].Value = txtSueldo.Text;
            datagvMostrar.Rows[n].Cells[2].Value = txtCalificacion.Text;

            if (radEstudiante.Checked)
            {
                if (int.TryParse(txtCalificacion.Text, out calificacion))
                {
                    DataRow newRow = tabla.NewRow();
                    newRow["Nombre"] = nombre;
                    newRow["Calificacion"] = calificacion;
                    newRow["Tipo de persona"] = "Estudiante";
                    tabla.Rows.Add(newRow);


                    txtNombre.Text = "";
                    txtCalificacion.Text = "";
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor válido para Calificación.");
                }
            }
            else if (radProfesor.Checked)
            {
                if (int.TryParse(txtSueldo.Text, out sueldo))
                {
                    DataRow newRow = tabla.NewRow();
                    newRow["Nombre"] = nombre;
                    newRow["Sueldo"] = sueldo;
                    newRow["Tipo de persona"] = "Profesor";
                    tabla.Rows.Add(newRow);


                    txtNombre.Text = "";
                    txtSueldo.Text = "";
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor válido para Sueldo.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de persona (Estudiante o Profesor).");
            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (n != -1);
            {
                datagvMostrar.Rows.RemoveAt(n);
            }
        }
    }
}

