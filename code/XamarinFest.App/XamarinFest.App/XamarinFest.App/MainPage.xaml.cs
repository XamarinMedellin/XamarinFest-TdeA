using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Text;
using Xamarin.Forms;
namespace XamarinFest.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BtnEnviarCorreo.Clicked += BtnEnviarCorreo_Clicked;
        }

        private void BtnEnviarCorreo_Clicked(object sender, EventArgs e)
        {
            EnviarCorreo(new Correo() { Destinatario = destinatario.Text, Asunto = asunto.Text, Mensaje = mensaje.Text });
        }

        async private void EnviarCorreo(Correo correo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string bodyRequest = JsonConvert.SerializeObject(correo);
                    await client.PostAsync("https://xamarinmed.azurewebsites.net/api/HttpTriggerCSharp1?code=VJ575b2M2otR6ynbCHz9J2tthGU7FfwxNguaUxOiP1wuorBGjoWJqA=="
                        , new StringContent(bodyRequest, Encoding.UTF8, "application/json"));
                    await DisplayAlert("Completado", "Correo enviado correctamente.", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ha ocurrido un error intentando consumir el servicio de Azure para enviar el correo.", "Aceptar");
            }
        }

    }
}
