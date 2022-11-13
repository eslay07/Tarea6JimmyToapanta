using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tarea6JimmyToapanta
{
    public partial class MainPage : ContentPage

    {
        private const string Url = "http://192.168.1.116/empleados/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Tarea6JimmyToapanta.ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Tarea6JimmyToapanta.ws.Datos> posts=JsonConvert.DeserializeObject<List<Tarea6JimmyToapanta.ws.Datos>>(content);
            _post = new ObservableCollection<Tarea6JimmyToapanta.ws.Datos>(posts);

            MyListView.ItemsSource = _post;
        }
    }
}
