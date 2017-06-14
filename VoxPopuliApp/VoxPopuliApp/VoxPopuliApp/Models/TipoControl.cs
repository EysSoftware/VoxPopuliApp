using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class TipoControl
    {
        public TipoControl()
        {
            this.Preguntas = new List<PreguntaP>();
        }

        public int TipoControlId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public List<PreguntaP> Preguntas { get; set; }
    }
}
