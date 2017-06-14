using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class RespuestaCampaniaP
    {
        public int CampaniaDetalleId { get; set; }
        public int CampaniaId { get; set; }
        public int RespuestaId { get; set; }
        public byte OpcionRespuesta { get; set; }
        public int ContadorRespuesta { get; set; }
        public string Comentarios { get; set; }
        public DateTime Fecha { get; set; }
        //public CampaniaDetalle CampaniaDetalle { get; set; }
        public RespuestaP Respuesta { get; set; }
    }
}
