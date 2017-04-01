![recursos](images/XamarinFest.png)


# Tabla de contenido

- [Objetivo del Laboratorio](#Objetivo-del-Laboratorio)
- [Indicaciones antes de comenzar](#Indicaciones-antes-de-comenzar)
- [Introducción](#Introducción)
- [Pasos](#Pasos)
- [Vinculos recomendados](#Vinculos-recomendados)
- [Patrocinadores](#Patrocinadores)




# Objetivo del Laboratorio

Construir una aplicación para Android, iOS y Windows 10, con Xamarin Forms con un mismo código compartido, que permita consumir una Azure function creada, la cual envia un correo electronico utilizando un servicio de azure conocido como SendGrid, agregando un destinatario, asunto y contenido del mensaje en la misma aplicación .


# Indicaciones antes de comenzar

### IDE

- Instala **Xamarin en Visual Studio**. Favor ver el siguiente enlace [Guía de instalación ambiente de desarrollo de Xamarin](https://aka.ms/installXamarin).
    - Si ya tienes Visual Studio instalado pero sin **Xamarin**, puedes agregar el complemento con esta [Guía de actualización para ambiente de desarrollo Xamarin](https://aka.ms/updateVSXamarin).

### Emuladores 

Se recomienda instalar emuladores Android para probar la aplicación, tambien puedes probar en iOS pero requiere de conexión a una Mac para compilar.

- **Genymotion**: [https://www.genymotion.com/download](https://www.genymotion.com/download)
- **Visual Studio Emulator**: [https://aka.ms/vscomemudownload](https://aka.ms/vscomemudownload)
- **Xamarin Player**: [https://developer.xamarin.com/releases/android/android-player/](https://developer.xamarin.com/releases/android/android-player/)

# Introducción

Este proyecto es el ejercicio pensado para considerar que tienes ya todo instalado para un ambiente de desarrollo con Xamarin.

A continuación, se describen los pasos correspondientes para realizar un app disponible para Android, iOS y Windows con Xamarin Forms, consumiendo uno de los servicios de Microsoft Azure ya creados para el envio de correo. Recuerda que tambien puedes descargar el codigo de la solución ya realizado que se encuentra en la carpeta [code](https://github.com/aminespinoza/EnviaCorreosXamarinApp/tree/master/EjercicioBase).

Como lo dice la primera parte, si logras ejecutar los siguientes pasos sin problemas en tu equipo significará entonces que ya tienes todo listo para participar en varias iniciativas y además comenzar a desarrollar aplicaciones multiplataforma.

# Pasos

**Nota** Este ejercicio esta realizado en **visual studio 2015 community** y en idioma ingles, puede ser realizado de igual forma en visual studio 2017, xamarin studio o visual studio para MAC.


**XamarinFest.App**

-  Abrimos nuestro visual studio y procedemos a dar click en **Nuevo proyecto**.
-  Abierta nuestra ventana de creación de nuevo proyecto buscamos la plantilla de C# --> Cross-Platform.
-  Seleccionamos **Cross Platform App**.
-  Indicamos el nombre de nuestro proyecto **XamarinFest.App**.
-  Damos click en **Ok**.

    ![recursos](images/1.png)

-  Al crear nuestro proyecto web se abrirá la ventana correspondiente para seleccionar nuestra plantilla.
-  Seleccionamos la plantilla **Blank App**, **Xamarin Forms** y cambiamos la estrategia de codigo compartido a **Portable Class Library (PCL)**.
-  Damos click en **Ok** y esperemos que se creen los proyectos correspondientes a la solución.

    ![recursos](images/2.png)

-  Si observas bien, se han creado 4 proyectos correspondientes a la solución generados automaticamente con su respectivo nombramiento, a continuación se detalle para que es cada proyecto.    

    - **XamarinFest.App** : Proyecto de librerias de clases portables, cuyo objetivo es contener la mayor cantidad de codigo que pueda ser compartido entre plataformas, como son las vistas (.xaml) y clases (.cs) con logica de negocio de nuestra aplicación.
	
    - **XamarinFest.App.Android** : Proyecto correspondiente a la aplicación Android, contiene los recursos necesarios para empaquetar nuestra aplicación Android, imagenes, permisos de accesos, información, etc. **Requiere SDK Android, generalmente incluido en SDK Xamarin**

    - **XamarinFest.App.iOS** : Proyecto correspondiente a la aplicación iOS, contiene los recursos necesarios para empaquetar nuestra aplicación iOS, imagenes, permisos de accesos,  información, etc. **Incluido con SDK Xamarin, pero requiere conexion a una MAC para compilar (puede ser virtualizada)**

    - **XamarinFest.App.UWP** : Proyecto correspondiente a la aplicación Universal Windows Platforms (Windows 10), contiene los recursos necesarios para empaquetar nuestra aplicación Windows 10 (Windows mobile, Windows 10 desktop, Windows Hub, Windows Xbox...), imagenes, permisos de accesos, información, etc. **Requiere SDK Universal Windows Platforms (windos 10)**    

    ![recursos](images/3.png)

-  Vamos a darle un poco de diseño a nuestra aplicación, abrimos el archivo **MainPage.xaml** ubicado en el proyecto **XamarinFest.App** ya que esta asignado como pagina principal en **App.xaml.cs**

    - **Nota** : Si no visualizas la vista de diseño, probablemente requieras configurar el **Xamarin Previewer** , aunque para el ejercicio no es necesario que lo tengas configurado, solo requerimos la vista de codificación.

    ![recursos](images/4.png)

-  Escribe el siguiente código para crear una interfaz amigable que permita ingresar **destinatario, asunto, descripción y un botón para enviar**.
    - Cuando escribimos codigo Xaml para nuestras vistas, estamos reutilizando la misma interfaz para todas las plataformas.

```xml
<?xml version="- 0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:XamarinFest.App"
             x:Class="XamarinFest.App.MainPage">
    <ContentPage.Resources>
        <ResourceDictionary>
            <Color x:Key="PrimaryColor">#468847</Color>
            <Color x:Key="BackgroundEntryColor">#E1E1E1</Color>
        </ResourceDictionary>
    </ContentPage.Resources>
    <ScrollView>
        <Grid BackgroundColor="#F2F2F2" Padding="10">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="Auto"/>
            </Grid.RowDefinitions>
            <Grid Grid.Row="0">
                <StackLayout>
                    <Label Text="Xamarin Fest" HorizontalOptions="CenterAndExpand" FontSize="Large" TextColor="Gray"/>
                    <Label Text="Destinatario" FontSize="Medium" TextColor="{StaticResource PrimaryColor}"/>
                    <Entry x:Name="destinatario" BackgroundColor="{StaticResource BackgroundEntryColor}" TextColor="Black" />
                    <Label Text="Asunto" FontSize="Medium" TextColor="{StaticResource PrimaryColor}"/>
                    <Entry x:Name="asunto" BackgroundColor="{StaticResource BackgroundEntryColor}" TextColor="Black"/>
                    <Label Text="Mensaje" FontSize="Medium" TextColor="{StaticResource PrimaryColor}"/>
                    <Editor x:Name="mensaje" HeightRequest="200"  BackgroundColor="{StaticResource BackgroundEntryColor}" TextColor="Black"/>
                </StackLayout>
            </Grid>
            <Grid Grid.Row="1">
                <Button x:Name="BtnEnviarCorreo" Text="Enviar Correo" FontSize="Medium" BackgroundColor="{StaticResource PrimaryColor}" TextColor="#FFFFFF"/>
            </Grid>
        </Grid>
    </ScrollView>
</ContentPage>
```

   ![recursos](images/5.png)

-  Puedes probar el resultado ejecutando la aplicación en un emulador o dispositivo movil configurado, solo basta con hacer click derecho sobre el proyecto de la plataforma movil a probar y establecer como **proyecto de inicio**
    - **Android**

   ![recursos](images/6.png)

   - **Universal Windows Platforms (Windows 10)**

   ![recursos](images/7.png)

-  Ahora vamos a crear el evento click para el boton de enviar correo el cual debe consumir el servicio construido en azure, abre el archivo **MainPage.xaml.cs**

   ![recursos](images/8.png)

```csharp
        public MainPage()
        {
            InitializeComponent();
            BtnEnviarCorreo.Clicked += BtnEnviarCorreo_Clicked;
        }
        private void BtnEnviarCorreo_Clicked(object sender, EventArgs e)
        {

        }
```

-  Ahora es necesario consumir la Azure Function que envia los correos, pero primero es necesario instalar en nuestro proyecto portable **XamarinFest.App** el paquete requerido para peticiones Http.
Damos click derecho en **References** y seleccionamos --> **Manage Nuget Packages**

-  Buscamos con la palabra **Http** y seleccionamos el paquete llamado **Microsoft.Net.Http** y damos click en **instalar**.

   ![recursos](images/9.png)

-  Realizamos el mismo proceso con la libreria **Newtonsoft.Json** buscando con la palabra **json**.

   ![recursos](images/9-1.png)

-  Luego vamos a crear una clase llamada **Correo.cs**, para ello da click derecho sobre el proyecto **XamarinFest.App** Add --> class...

   ![recursos](images/10.png)

-  Crea las variables requeridas para el objeto correo.   

   ![recursos](images/11.png)

```csharp
namespace XamarinFest.App
{
    public class Correo
    {
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }
}
```
-  Volvamos al archivo **MainPage.xaml.cs** y ahora agreguemos un metodo respectivamente para el envio de datos al servicio, creando el objeto **Correo**.

-  Primero agregamos las referencias respectivas de las librerias que hemos instalado en el encabezado del archivo.

```csharp
using Newtonsoft.Json;
using System.Net.Http;
```

-  Vamos a crear el metodo correspondiente a el consumo del servicio que envia el correo electronico, allí se encuentra toda la configuración correspondiente al punto de acceso del servicio api.

    - Además, vamos a agregar una alerta cuando se envie el correo o cuando ocurra una excepción.

   ![recursos](images/12.png)

```csharp
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
```

-  Si procedemos a ejecutar el aplicativo especificamente en Android, podemos evidenciar que inmediatamente se muestra el error intentando consumir el servicio.

- **Nota**: el error es debido a que la aplicación no puede acceder al servicio de azure, debido a que no hemos dado permisos a nuestra plataforma de acceder al recurso de internet.
    
   ![recursos](images/13.png)

-  Para solucionar el inconveniente, es necesario ir a la configuración de cada plataforma y proporcionar el permiso necesario de acceder a **Internet** (iOS y UWP ya esta activo por defecto).
    - En **Android** damos click derecho propiedades y seleccionamos **Android Manifest**, buscamos la opción INTERNET en **Required permissions** y la checkeamos.

   ![recursos](images/14.png)

 
-  Procedemos a ejecutar nuestra aplicación en Android y Windows Platforms, iOS tambien es posible pero requiere Mac para compilar.

### **UWP(Universal Windows Platform)**

   ![recursos](images/15.png)

   ![recursos](images/16.png)

### **Android**

   ![recursos](images/17.png) 

   ![recursos](images/18.png) 


Verificamos la cuenta de correo y visualizaremos los mensajes enviados desde las plataformas :D .

   ![recursos](images/19.png)  

   ![recursos](images/20.png) 

# Vinculos recomendados

* **Documentación Xamarin**: [https://developer.xamarin.com/](https://developer.xamarin.com/)

    - Ejemplos: [https://developer.xamarin.com/samples-all](https://developer.xamarin.com/samples-all)

* **Documentación Azure**: [https://docs.microsoft.com/en-us/azure/](https://docs.microsoft.com/en-us/azure/)
* **Kit Dev Essential**: [https://www.visualstudio.com/es/dev-essentials/](https://www.visualstudio.com/es/dev-essentials/)
 
# Patrocinadores


[Únete a la comunidad-Xamarin Medellin](https://www.meetup.com/es-ES/Xamarin-Medellin/)

- <img src="images/XamarinMedellin.jpeg" style="height:80px;text-align:center" />


- <img src="images/microsoft-logo.jpg" style="height:80px;text-align:center;margin:0 auto;width:350px" />


- <img src="images/avanet.png" style="height:120px;text-align:center;margin:0 auto;width:auto" />
