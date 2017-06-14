using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class RespuestaP
    {
        public RespuestaP()
        {
           // this.ControlPreguntas = new List<ControlPregunta>();
            this.RespuestaCampanias = new List<RespuestaCampania>();
        }

        public int RespuestaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

       // public List<ControlPregunta> ControlPreguntas { get; set; }
        public List<RespuestaCampania> RespuestaCampanias { get; set; }
    }
}
