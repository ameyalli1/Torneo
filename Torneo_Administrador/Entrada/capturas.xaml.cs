using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
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
using System.Windows.Shapes;
using Torneo.BIZ;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;
using Torneo.COMMON.PuntosGrafica;
using Torneo.DAL;

namespace Entrada
{
    /// <summary>
    /// Lógica de interacción para capturas.xaml
    /// </summary>
    public partial class capturas : Window
    {
        Generadora generadora;
        Random ran = new Random();
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorDeporte manejadorDeporte;
        IManejadorEquipo manejadorEquipo;
        IManejadorUsuario manejadorUsuario;
        IManejadorTorneo manejadorTorneo;
        accion accionn;
        List<TipoDeporte> a = new List<TipoDeporte>();
        List<TipoDeporte> impar = new List<TipoDeporte>();
        string equipo1, equipo2;
        public capturas()
        {
            InitializeComponent();
            manejadorDeporte = new ManejadorDeporte(new RepositorioGenerico<Deporte>());
            manejadorEquipo = new ManejadorEquipos(new RepositorioGenerico<Equipos>());
            manejadorUsuario = new ManejadorUsuario(new RepositorioGenerico<Usuarios>());
            manejadorTorneo = new ManejadorTorneo(new RepositorioGenerico<Torneos>());
            CargaCombos();


            /*Para Estadisticos*/
           // btnVerEstadisticos.Click += btnVerEstadisticos_Click;
            //generadora = new Generadora();
            /*Para Estadisticos*/


            PonerBotonesDeportesEnEdicion(false);
            LimpiarCamposDeDeportes();
            ActualizarTablaDeportes();

            PonerBotonesEquiposEnEdicion(false);
            LimpiarCamposDeEquipos();
            ActualizarTablaEquipos();

            PonerBotonesUsuarioEnEdicion(false);
            LimpiarCamposDeUsuario();
            ActualizarTablaUsuario();


            ActualizarTablaTorneos();

            ActualizarTorneos();

            ActualizarTorneosTorneos();
        }

        private void ActualizarTorneosTorneos() {
            dtgTorneo.ItemsSource = null;
            dtgTorneo.ItemsSource = manejadorTorneo.Listar;
        }

        private void ActualizarTorneos()
        {
            cmbDeporteTorneo.ItemsSource = null;
            cmbDeporteTorneo.ItemsSource = manejadorDeporte.Listar;
           
        }


        private void ActualizarTablaUsuario()
        {
            dtgUsuarios.ItemsSource = null;
            dtgUsuarios.ItemsSource = manejadorUsuario.Listar;

        }
 
        private void LimpiarCamposDeUsuario()
        {
            txtNombreUsuario.Clear();
            txtContraceñaUsuario.Clear();
            txbIdusuario.Text = "";
        }

        private void PonerBotonesUsuarioEnEdicion(bool v)
        {
            btnCancelarUsuario.IsEnabled = v;
            btnEditarUsuario.IsEnabled = !v;
            btnEliminarUsuario.IsEnabled = !v;
            btnGuardarUsuario.IsEnabled = v;
            btnNuevoUsuario.IsEnabled = !v;
         //   btnreguistroUsuario.IsEnabled 
        }


        private void ActualizarTablaEquipos()
        {
            dtgEquipos.ItemsSource = null;
            dtgEquipos.ItemsSource = manejadorEquipo.Listar;
           
        }

        private void LimpiarCamposDeEquipos()
        {
            txbEquiposNombre.Clear();
            txbNumJugadoresEquipos.Clear();
            txbEquiposId.Text = "";
        }

        private void PonerBotonesEquiposEnEdicion(bool v)
        {
            btnCancelarEquipos.IsEnabled = v;
            btnEditarEquipos.IsEnabled = !v;
            btnEliminarEquipos.IsEnabled = !v;
            btnGuardarEquipos.IsEnabled = v;
            btnNuevoEquipos.IsEnabled = !v;
        }


        private void ActualizarTablaDeportes()
        {
            dtgTablaDeporte.ItemsSource = null;
            dtgTablaDeporte.ItemsSource = manejadorDeporte.Listar;

            cmbEquipos.ItemsSource = null;
            cmbEquipos.ItemsSource = manejadorDeporte.Listar;
            //    CargarCombox();
            CargaCombos();
        }

        private void LimpiarCamposDeDeportes()
        {
            txbDeporte.Clear();
            txbIdDeporte.Text = "";
        }

        private void PonerBotonesDeportesEnEdicion(bool v)
        {
            btnCancelarDeporte.IsEnabled = v;
            btnEditarDeporte.IsEnabled = !v;
            btnEliminarDeporte.IsEnabled = !v;
            btnGuardarDeporte.IsEnabled = v;
            btnNuevoDeporte.IsEnabled = !v;
        }


        private void ActualizarTablaTorneos()
        {
            dtgTorneo.ItemsSource = null;
            dtgTorneo.ItemsSource = manejadorTorneo.Listar;

        }

        private void CargaCombos()

        {

            // Hay que checar el combo que no se actualiza 
            // el de el deporte 

            cmbEquipos.ItemsSource = null;
            cmbEquipos.ItemsSource = manejadorDeporte.Listar;


            cmbDeporteTorneo.ItemsSource = null;
            cmbDeporteTorneo.ItemsSource = manejadorDeporte.Listar;

            //cmbEquipoTorneo.ItemsSource = null;
            //cmbEquipoTorneo.ItemsSource = manejadorEquipo.Listar;


        }



        private void btnNuevoDeporte_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeDeportes();
            PonerBotonesDeportesEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnEditarDeporte_Click(object sender, RoutedEventArgs e)
        {
            Deporte emp = dtgTablaDeporte.SelectedItem as Deporte;
            if (emp != null)
            {
                txbIdDeporte.Text = emp.Id.ToString();
                txbDeporte.Text = emp.deporte;

                accionn = accion.Editar;
                PonerBotonesDeportesEnEdicion(true);

            }
        }

        private void btnGuardarDeporte_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txbDeporte.Text))
            {
                MessageBox.Show("Falta el deporte ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (accionn == accion.Nuevo)
            {
                Deporte emp = new Deporte()
                {
                    // Identificador = txbEmpleadoId.Text,
                    deporte = txbDeporte.Text,



                };
                if (manejadorDeporte.Agregar(emp))
                {
                    MessageBox.Show("Deporte agregado correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeDeportes();
                    ActualizarTablaDeportes();
                    PonerBotonesDeportesEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El deporte no se pudo agregar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Deporte emp = dtgTablaDeporte.SelectedItem as Deporte;
                emp.deporte = txbDeporte.Text;



                if (manejadorDeporte.Modificar(emp))
                {
                    MessageBox.Show("Deporte modificado correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeDeportes();
                    ActualizarTablaDeportes();
                    PonerBotonesDeportesEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Deporte no se pudo actualizar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelarDeporte_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeDeportes();
            PonerBotonesDeportesEnEdicion(false);
        }

        private void btnEliminarDeporte_Click(object sender, RoutedEventArgs e)
        {
            Deporte emp = dtgTablaDeporte.SelectedItem as Deporte;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este deporte ", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDeporte.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Deporte  eliminado", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaDeportes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el deporte", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }


        private void btnNuevoEquipos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEquipos();
            PonerBotonesEquiposEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnEditarEquipos_Click(object sender, RoutedEventArgs e)
        {
          
            Equipos emp = dtgEquipos.SelectedItem as Equipos;
            if (emp != null)
            {
                txbEquiposId.Text = emp.Id.ToString();
                //iria el combo
                cmbEquipos.Text = emp.NumeroJugadores;
                txbEquiposNombre.Text = emp.Nombre;
                txbNumJugadoresEquipos.Text = emp.NumeroJugadores;

                accionn = accion.Editar;
                PonerBotonesEquiposEnEdicion(true);

            }
        }

        private void btnGuardarEquipos_Click(object sender, RoutedEventArgs e)
        {

           if (string.IsNullOrEmpty(txbEquiposNombre.Text))
           {
                MessageBox.Show("Falta el Nombre ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               return;
            }
            if (string.IsNullOrEmpty(cmbEquipos.Text))
            {
                MessageBox.Show("Falta seleccionar un deporte ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbNumJugadoresEquipos.Text))
            {
                MessageBox.Show("Falta ingresar el numeor de jugadores", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (accionn == accion.Nuevo)
            {
                Equipos emp = new Equipos()
                {
                    // Identificador = txbEmpleadoId.Text,
                    Nombre = txbEquiposNombre.Text,
                   NumeroJugadores=txbNumJugadoresEquipos.Text,
                   Deporte=cmbEquipos.Text,



                };
                if (manejadorEquipo.Agregar(emp))
                {
                    MessageBox.Show("Equipo agregado correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEquipos();
                    ActualizarTablaEquipos();
                    PonerBotonesEquiposEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El equipo no se pudo agregar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Equipos emp = dtgEquipos.SelectedItem as Equipos;
                emp.Nombre = txbEquiposNombre.Text;
                emp.NumeroJugadores = txbNumJugadoresEquipos.Text;
                emp.Deporte = cmbEquipos.Text;


                if (manejadorEquipo.Modificar(emp))
                {
                    MessageBox.Show("Equipo modificado correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEquipos();
                    ActualizarTablaEquipos();
                    PonerBotonesEquiposEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Equipo no se pudo actualizar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelarEquipos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEquipos();
            PonerBotonesEquiposEnEdicion(false);
        }

        private void btnEliminarEquipos_Click(object sender, RoutedEventArgs e)
        {
            Equipos emp = dtgEquipos.SelectedItem as Equipos;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este equipo ", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEquipo.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Equipo  eliminado", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEquipos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el equipo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }


        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeUsuario();
            PonerBotonesUsuarioEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (accionn == accion.Nuevo)
            {
                Usuarios emp = new Usuarios()
                {
                    // Identificador = txbEmpleadoId.Text,
                    NombreUsuario = txtNombreUsuario.Text,
                    Contraceña = txtContraceñaUsuario.Text,
                   



                };
                if (manejadorUsuario.Agregar(emp))
                {
                    MessageBox.Show("Usuario agregado correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeUsuario();
                    ActualizarTablaUsuario();
                    PonerBotonesUsuarioEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Usuario no se pudo agregar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Usuarios emp = dtgUsuarios.SelectedItem as Usuarios;
                emp.NombreUsuario = txtNombreUsuario.Text;
                emp.Contraceña= txtContraceñaUsuario.Text;
               // emp.Deporte = cmbEquipos.Text;


                if (manejadorUsuario.Modificar(emp))
                {
                    MessageBox.Show("Usuario modificado correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeUsuario();
                    ActualizarTablaUsuario();
                    PonerBotonesUsuarioEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Usuario no se pudo actualizar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuarios emp = dtgUsuarios.SelectedItem as Usuarios;
            if (emp != null)
            {
                txbIdusuario.Text = emp.Id.ToString();
                //iria el combo
                txtNombreUsuario.Text = emp.NombreUsuario;
                txtContraceñaUsuario.Text = emp.Contraceña;
                accionn = accion.Editar;
                PonerBotonesUsuarioEnEdicion(true);

            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeUsuario();
            PonerBotonesUsuarioEnEdicion(false);
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuarios emp = dtgUsuarios.SelectedItem as Usuarios;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este Usuario ", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorUsuario.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Usuario  eliminado", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaUsuario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }


        private void ListaDeporte()
        {
            if (cmbDeporteTorneo != null)
            {
                string pal = cmbDeporteTorneo.Text;
                
                foreach (var item in manejadorEquipo.Listar)
                {
                    if (pal == item.Deporte)
                    {
                        TipoDeporte r = new TipoDeporte();
                        r.Datos = item.Nombre;
                        a.Add(r);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la lista desplegable", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Equipo2() {
            if (a.Count >= 1)
            {

                int contador = 0;
                Random random = new Random();
                int v = random.Next(1, a.Count);
                foreach (var item in a)
                {
                    contador++;
                    if (contador == v)
                    {
                        TipoDeporte r = new TipoDeporte();
                        equipo1 = item.Datos;
                        r.Datos = item.Datos;
                        a.Remove(item);
                        impar.Add(r);
                        break;
                    }
                }
            }
        }
       
        private void Equipo1()
        {
            if (a.Count >= 1)
            {
                int contador = 0;
                Random random = new Random();
                int v = random.Next(1, a.Count);
                foreach (var item in a)
                {
                    contador++;
                    if (contador == v)
                    {
                        equipo2 = item.Datos;
                        a.Remove(item);
                        break;
                    }
                }
            }
        }

        private void Equipo3()
        {
            if (a.Count >= 1)
            {
                int contador = 0;
                Random random = new Random();
                int v = random.Next(1, a.Count);
                foreach (var item in impar)
                {
                    contador++;
                    if (contador == v)
                    {
                        equipo2 = item.Datos;
                        a.Remove(item);
                        break;
                    }
                }
            }
        }



        private void IngresarLosDatos() {         
            Equipo1();
                Equipo2();
                Torneos b = new Torneos();
            b.FechaProgramada = clFechaTorneo.Text;
            b.Tipo_Deporte = cmbDeporteTorneo.Text;
                b.Equipo1 = equipo1;
                b.Equipo2 = equipo2;
            manejadorTorneo.Agregar(b);
            ActualizarTorneosTorneos();
            //aqui va el manejador
        }

        private void IngresarLosDatosImpar()
        {
            Equipo1();
            Equipo3();
            Torneos b = new Torneos();
            b.FechaProgramada = clFechaTorneo.Text;
            b.Tipo_Deporte = cmbDeporteTorneo.Text;
            b.Equipo1 = equipo1;
            b.Equipo2 = equipo2;
            manejadorTorneo.Agregar(b);
            ActualizarTorneosTorneos();
            //aqui va el manejador
        }



        private void btnNuevoTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDeporteTorneo.SelectedItem == null)
            {
                MessageBox.Show("Error...No ha seleccionado ningun deporte!!!", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string palabra = cmbDeporteTorneo.Text;
            if (manejadorEquipo.ContadorDeBuscarEquipo(palabra) <= 1)
            {
                MessageBox.Show("No se puede realizar los torneos con un solo equipo\nAgregue más equipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(clFechaTorneo.Text))
            {
                MessageBox.Show("Agregue la fecha programada del torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorEquipo.Listar)
            {
                if (item.Deporte == palabra)
                {
                    TipoDeporte equipos = new TipoDeporte();
                    equipos.Datos = item.Nombre;
                    a.Add(equipos);
                }
            }
            ListaDeporte();
            if (a.Count % 2 == 0)
            {
                while ((a.Count) / 2 > 0)
                {
                    IngresarLosDatos();
                }
            }
            else {
                while ((a.Count) / 2 > 0)
                {
                    IngresarLosDatos();
                }
                IngresarLosDatosImpar();
            } 
        }

        private void btnpuntuacion_Click(object sender, RoutedEventArgs e)
        {
           // puntuacion abrir = new puntuacion();
            //abrir.Show();
            //this.Close();

          /*  if (dtgTorneo.SelectedItem != null)
            {
                Torneos a = dtgTorneo.SelectedItem as Torneos;
                if (a != null)
                {
                    // puntuacion r = new puntuacion();

                    //txbTorneoId.Text = a.Id.ToString();
                    txbEquipo1.Text = a.Equipo1;
                    txbEquipo2.Text = a.Equipo2;
                    E1.Text = a.Marcador_1.ToString();
                    E2.Text = a.Marcador_2.ToString();


                    MessageBox.Show("Selecciona la pestaña de puntuacion para ver la puntuacion y la grafica", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);


                }
                */
                /* else
                 {
                     TemporarDeporteTipo b = dtgTorneo.SelectedItem as TemporarDeporteTipo;
                     foreach (var item in manejadorTorneo.Listar)
                     {
                         if (b.Id == item.Id.ToString())
                         {
                             puntuacion r = new puntuacion();
                            // r.txbTorneoId.Text = item.Id.ToString();
                             r.txbEquipo1.Text = item.Equipo1;
                             r.txbEquipo2.Text = item.Equipo2;
                             r.E1.Text = item.Marcador_1.ToString();
                             r.E2.Text = item.Marcador_2.ToString();
                         }
                     }
                 }
             }
             else
             {
                 MessageBox.Show("No ha seleccionado ningun elemento de la tabla", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);

             }*/


                /*Torneos emp = dtgTorneo.SelectedItem as Torneos;
                if (emp != null)
                {

                    puntuacion abrir = new puntuacion();
                    abrir.Show();
                    this.Close();





                }
                else
                {
                    MessageBox.Show("No a seleccionado nada", "Puntuacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                */
            //}
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            capturas abrir = new capturas();
            abrir.Show();
            this.Close();
        }

       

        private void btnEstadisticoss_Click(object sender, RoutedEventArgs e)
        {
            puntuacion abrir = new puntuacion();
            abrir.Show();
            this.Close();
        }

        private void dtgTorneo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            puntuacion abrir = new puntuacion();
            abrir.Show();
            this.Close();
          /*  if (dtgTorneo.SelectedItem != null)
            {
                Torneos a = dtgTorneo.SelectedItem as Torneos;
                if (a != null)
                {
                    txbEquipo1.Text = a.Equipo1;
                    txbEquipo2.Text = a.Equipo2;
                    E1.Text = a.Marcador_1.ToString();
                    E2.Text = a.Marcador_2.ToString();
                    // txtPuntosMarcador2.Text = a.Marcador_2.ToString();
                }
                else
                {
                    TemporarDeporteTipo b = dtgTorneo.SelectedItem as TemporarDeporteTipo;
                    foreach (var item in manejadorTorneo.Listar)
                    {
                        if (b.Id == item.Id.ToString())
                        {
                            // txtPuntosToneroIdentificador.Text = item.Id.ToString();
                            txbEquipo1.Text = item.Equipo1;
                            txbEquipo2.Text = item.Equipo2;
                            E1.Text = item.Marcador_1.ToString();
                            E2.Text = item.Marcador_2.ToString();
                        }
                    }
                }
            }
            */
        }

       

        /*private void btnActualizarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (accionn == accion.Nuevo)
            {
                Torneos emp = new Torneos()
                {
                    // Identificador = txbEmpleadoId.Text,
                    Marcador_1 = int.Parse(E1.Text),
                    Marcador_2 = int.Parse(E2.Text),
                };
                if (manejadorTorneo.Agregar(emp))
                {
                    MessageBox.Show("Puntuaciones agregadas correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    //  LimpiarCamposDeUsuario();
                    ActualizarTablaTorneos();
                   // PonerBotonesUsuarioEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("Las puntuaciones no se pudieron actualizar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Torneos emp = dtgTorneo.SelectedItem as Torneos;
                emp.Marcador_1 = int.Parse(E1.Text);
                emp.Marcador_2 = int.Parse(E2.Text);
                // emp.Deporte = cmbEquipos.Text;


                if (manejadorTorneo.Modificar(emp))
                {
                    MessageBox.Show("Puntuacion Actualizada correctamente  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                 //   LimpiarCamposDeUsuario();
                    ActualizarTablaTorneos();
                 //   PonerBotonesUsuarioEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("La puntuacion no se pudo actualizar  ", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        */



            /*
        private void btnEliminarTorneo_Click(object sender, RoutedEventArgs e)
        {
            Torneos emp = dtgTorneo.SelectedItem as Torneos;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este Torneo ", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorTorneo.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Torneo  eliminado", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTorneosTorneos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

    */




        


       



    }
}
