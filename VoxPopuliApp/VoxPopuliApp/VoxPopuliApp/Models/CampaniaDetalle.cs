using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class CampaniaDetalleP
    {
        //public CampaniaDetalle()
        //{
        //    this.RespuestaCampanias = new List<RespuestaCampania>();
        //}

        public int CampaniaDetalleId { get; set; }
        public int CampaniaId { get; set; }
        public int PreguntaId { get; set; }
        public int Orden { get; set; }
        public DateTime Fecha { get; set; }

        public Campania Campania { get; set; }
        public Pregunta Pregunta { get; set; }
        public RespuestaCampania[] RespuestaCampanias { get; set; }
    }
}
