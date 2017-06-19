using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VoxPopuliApp.Helpers;
using VoxPopuliApp.Models;
using Xamarin.Forms;

namespace VoxPopuliApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Rootobject Item { get; set; }
        public ObservableRangeCollection<Respuesta> Respuestas { get; set; }
        public Command CargaRespuesta { get; set; }
        public Command CargarSiguiente { get; set; }
        private int index = 0;
        private int CampaniaID;
        private string textoBoton;
        HttpClient client;

        public Respuesta respuestaSeleccionada { get; set; }

        public ItemDetailViewModel(Rootobject item)
        {
            cargarEncuesta(item);
        }
        private void cargarEncuesta(Rootobject item = null)
        {
            try
            {
                if (item.CampaniaDetalle.Count() > 1)
                {
                    Title = item.CampaniaDetalle.First().Pregunta.Nombre;
                    Item = item;
                    CampaniaID = item.CampaniaId;
                    TextoBoton = "Siguiente";
                    Respuestas = new ObservableRangeCollection<Respuesta>();
                    CargaRespuesta = new Command(async () => await ExecuteLoadRespuestasCommand());
                    CargarSiguiente = new Command(() => ExecuteCargaSiguienteCommand());
                    client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000; 
                }
                else
                {
                    MessagingCenter.Send<ItemDetailViewModel, string>(this, "ErrLoad", "La encuesta no tiene preguntas! :(");
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<ItemDetailViewModel, string>(this, "ErrLoad", "Error al cargar encuesta.");
            }
        }

        private async void ExecuteCargaSiguienteCommand()
        {
            try
            {
                if (index <= Item.CampaniaDetalle.Count() - 1)
                {
                    await insertarRespuesta();
                    index++;
                    if (index >= Item.CampaniaDetalle.Count() - 1)
                    {
                        TextoBoton = "Terminar";
                    }
                    Respuestas.Clear();
                    Title = Item.CampaniaDetalle[index].Pregunta.Nombre;
                    GetRespuestas();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al insertar " + ex.Message);
            }
        }
        private async Task insertarRespuesta()
        {
            string RestUrl = string.Format(@"http://eysvirtual.centralus.cloudapp.azure.com/voxpopuli/api/RespuestaCampanias/");
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            RespuestaCampania entidad = new RespuestaCampania
            {

                CampaniaDetalleId = 0,
                CampaniaId = 1,
                ContadorRespuesta = 1,
                RespuestaId = respuestaSeleccionada.RespuestaId,
                OpcionRespuesta = 1,
                PreguntaId = 1,
                Fecha = DateTime.Now,
                Comentarios = "",
                //PreguntaId = Item.CampaniaDetalle[index].PreguntaId
            };

            var json = JsonConvert.SerializeObject(entidad);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Todo fain");
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task ExecuteLoadRespuestasCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Respuestas.Clear();
                GetRespuestas();
                //List<Respuesta> respuestas = GetRespuestas();
                //Respuestas.ReplaceRange(respuestas);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Imposible cargar campañas.",
                    Cancel = "Aceptar"
                }, "Aviso");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private List<Respuesta> GetRespuestas()
        {
            List<ListView> preguntas = new List<ListView>();
            List<Campaniadetalle> companiasdetalle = Item.CampaniaDetalle.ToList();
            companiasdetalle = companiasdetalle.Where(w => w.CampaniaId == CampaniaID).ToList();
            List<Respuesta> respuestasOut = null;

            Label resp = new Label();
            foreach (Controlpregunta item in companiasdetalle[index].Pregunta.ControlPregunta)
            {
                Respuestas.Add(item.Respuesta);
            }
            return respuestasOut;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public string TextoBoton
        {
            get
            {
                return textoBoton;
            }

            set
            {                
                SetProperty(ref textoBoton, value);
            }
        }
    }
}