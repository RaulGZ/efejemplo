using System;
using Ejercicio01.mibd;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Ejercicio01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
                {
                if (Regex.IsMatch(txtSueldo.Text, @"\d+$"))
                {
                    //1.- Instanciar la "Base de Datos"
                    demoEF db = new demoEF();
                    //2.- Instanciar "Tabla empleados"
                    Empleado emp = new Empleado();
                    emp.Nombre = txtNombre.Text;
                    emp.Sueldo = int.Parse(txtSueldo.Text);
                    emp.DepartamentoId = (int)CbDepartamento.SelectedValue;
                    //agregar los datos capturados
                    db.Empleados.Add(emp);
                    db.SaveChanges();
                }
                else { MessageBox.Show("Solo numeros #sueldo"); }
                }
            else { MessageBox.Show("Solo letras #Nombre"); }   
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
                {
                    if (Regex.IsMatch(txtid.Text, @"\d+$") && Regex.IsMatch(txtSueldo.Text, @"\d+$"))
                {
                //1.- Instanciar "Base de Datos"
                demoEF db = new demoEF();
                //2.- Buscar el id capturado en la caja de texto
                int id = int.Parse(txtid.Text);
                //var es una variable dinamica
                var emp = db.Empleados.SingleOrDefault(x => x.id == id);
                if (emp != null) {
                    //asignar los nuevos valores
                    emp.Nombre = txtNombre.Text;
                    emp.Sueldo = int.Parse(txtSueldo.Text);
                    db.SaveChanges();
                }
                }
                else { MessageBox.Show("Verifique que solo sean numeros en #id y #sueldo"); }
                }
            else { MessageBox.Show("Solo letras #Nombre"); }   

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
            {
                demoEF db = new demoEF();
                //Buscar el id capturado en la caja de texto
                int id = int.Parse(txtid.Text);
                var emp = db.Empleados.SingleOrDefault(x => x.id == id);
                if (emp != null)
                {
                    //eliminar el registros
                    db.Empleados.Remove(emp);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"\d+$"))
                {
            //Consultar solo por ID
            demoEF db = new demoEF();
            int id = int.Parse(txtid.Text);
            var registros = from s in db.Empleados
                            where s.id == id
                            select new
                            {
                                s.Nombre,
                                s.Sueldo
                            };
            dbgrid.ItemsSource = registros.ToList();
                }
            else { MessageBox.Show("Solo numeros #id"); }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Consultar solo por ID
            demoEF db = new demoEF();
            var registros = from s in db.Empleados
                            select s;
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtDep.Text, @"^[a-zA-Z]+$"))
            {
                    //1.- Instanciar la "Base de Datos"
                    demoEF db = new demoEF();
                    //2.- Instanciar "Tabla Departamento"
                    Departamento dep = new Departamento();
                    dep.Nombre = txtDep.Text;
                    //agregar los datos capturados
                    db.Departamentos.Add(dep);
                    db.SaveChanges();
            }
            else { MessageBox.Show("Solo letras #Nombre Departamento"); }   
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            demoEF db = new demoEF();
            CbDepartamento.ItemsSource = db.Departamentos.ToList();
            CbDepartamento.DisplayMemberPath = "Nombre";
            CbDepartamento.SelectedValuePath = "id";
        }
    }
}
