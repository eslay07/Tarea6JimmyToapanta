using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea6JimmyToapanta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentanaIngreso : ContentPage
    {
        public VentanaIngreso()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            WebClient empleado = new WebClient();

            try
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtcodigo.Text);
                parametros.Add("nombre", txtnombre.Text);
                parametros.Add("apellido", txtapellido.Text);
                parametros.Add("edad", txtedad.Text);
                parametros.Add("cedula", txtcedula.Text);
                parametros.Add("num_licencia", txtlicencia.Text);
                parametros.Add("tipo_sangre", txtTSangre.Text);
                

                empleado.UploadValues("http://192.168.1.116/empleados/post.php", "POST", parametros);


            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
         
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());

        }
    }
}