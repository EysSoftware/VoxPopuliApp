using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class PreguntaP
    {
        public PreguntaP()
        {
            //this.CampaniaDetalles = new List<CampaniaDetalle>();
            //this.ControlPreguntas = new List<ControlPregunta>();
        }

        public int PreguntaId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoControlId { get; set; }

        public TipoControl TipoControl { get; set; }
        //public List<CampaniaDetalle> CampaniaDetalles { get; set; }
        //public List<ControlPregunta> ControlPreguntas { get; set; }
    }
}
