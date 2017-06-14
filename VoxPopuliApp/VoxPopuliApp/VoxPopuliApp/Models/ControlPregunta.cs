using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class ControlPreguntaP
    {
        public int PreguntaId { get; set; }
        public int RespuestaId { get; set; }
        public int Orden { get; set; }
        public DateTime Fecha { get; set; }

        public PreguntaP Pregunta { get; set; }
        public RespuestaP Respuesta { get; set; }
    }
}
