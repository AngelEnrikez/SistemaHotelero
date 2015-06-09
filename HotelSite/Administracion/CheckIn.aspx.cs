using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioReservas;

public partial class Mantenimientos_CheckIn : System.Web.UI.Page
{

    //Acá se implementará el código de búsqueda y checkin de huéspedes
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnConsultarReserva_Click(object sender, EventArgs e)
    {
        if (txtCodigoReserva.Text.Trim() != string.Empty)
        {
            ConsultarReserva(Int32.Parse(txtCodigoReserva.Text.Trim()));
        }
        else
        {
            MostrarMensaje("Ingrese un código de reserva");
        }
    }

    public void ConsultarReserva(int codReserva)
    {
        try
        {
            Reserva reserva = null;

            using (ReservasClient objReserva = new ReservasClient())
            {

                /*Data de Prueba*/
                reserva = new Reserva();
                reserva.IdReserva = codReserva;
                reserva.Cliente = new Cliente();
                reserva.Cliente.Nombre = "Cynthia";
                reserva.Cliente.ApellidoPaterno = "Carbonel";
                reserva.Cliente.ApellidoMaterno = "Arce";
                reserva.Habitacion = new Habitacion();
                reserva.Habitacion.TipoHabitacion = new TipoHabitacion();
                reserva.Habitacion.TipoHabitacion.Descripcion = "Duplex";
                /*Data de Prueba*/

                //reserva = objReserva.ObtenerReserva(codReserva);
                if (reserva != null)
                {
                    hdfCodigoReserva.Value = string.Empty + reserva.IdReserva;
                    txtNombre.Text = reserva.Cliente.Nombre;
                    txtApePat.Text = reserva.Cliente.ApellidoPaterno;
                    txtApeMat.Text = reserva.Cliente.ApellidoMaterno;
                    txtTipoHabitacion.Text = reserva.Habitacion.TipoHabitacion.Descripcion;
                    ClearMessage();
                }
                else
                {
                    MostrarMensaje("Reserva no encontrada");
                    hdfCodigoReserva.Value = "-1";
                }
            }
        }
        catch (Exception ex)
        {
            hdfCodigoReserva.Value = "-1";
            throw ex;
        }
    }

    public void MostrarMensaje(string mensaje)
    {
        lblMessage.Text = mensaje;
        lblMessage.Visible = true;
    }

    public void ClearMessage()
    {
        lblMessage.Text = string.Empty;
        lblMessage.Visible = false;
    }

    protected void btnCheckIn_Click(object sender, EventArgs e)
    {
        try{
            if (hdfCodigoReserva.Value != "-1")
            {

                DateTime In = DateTime.Parse(txtDateIn.Text);
                DateTime Out = DateTime.Parse(txtDateOut.Text);

                if (Out > In)
                {
                    MostrarMensaje("La fecha de Entrada debe de ser mayor a la fecha de Salida.");
                }
                else{
                    RealizarCheckIn(In, Out, txtComentarios.Text);
                }
                
            }
            else
            {
                MostrarMensaje("Debe consultar la reserva primero.");
            }     
        }
        catch {
            MostrarMensaje("Fechas inválidas.");
        }
       
    }

    private void RealizarCheckIn(DateTime In, DateTime Out, string ComentarioCheckIn)
    {
        try{
            using (ReservasClient objReserva = new ReservasClient())
            {
                Reserva reserva = objReserva.ObtenerReserva(Int32.Parse(hdfCodigoReserva.Value));
                reserva.FechaHoraCheckin = DateTime.Parse(txtDateIn.Text);
                reserva.FechaLlegada = DateTime.Parse(txtDateIn.Text);
                reserva.FechaSalida = DateTime.Parse(txtDateOut.Text);
                reserva.ComentarioCheckin = ComentarioCheckIn;

                //objReserva.RegistrarCheckIn(reserva);
                //ServicioCheckIn.CheckInClient CheckInClient = new ServicioCheckIn.CheckInClient();
                //CheckInClient.RegistrarCheckIn(reserva);
            }
           
            ClearMessage();
            MostrarMensaje("Checkin Exitoso");
        }
        catch(Exception ex){
            throw ex;
        }
    }
}