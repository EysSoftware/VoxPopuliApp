using System;
using System.Collections.Generic;

namespace VoxPopuliApp.Models
{
    public class CampaniaP
    {
        //public Campania()
        //{
        //    this.CampaniaDetalles = new List<CampaniaDetalle>();
        //    this.ControlVotaciones = new List<ControlVotacion>();
        //}

        public int CampaniaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte Estatus { get; set; }
        public int TipoCampaniaId { get; set; }
        public DateTime FechaInicia { get; set; }
        public DateTime FechaFinaliza { get; set; }

        //public CampaniaDetalle[] CampaniaDetalles { get; set; }
        public ControlVotacion[] ControlVotaciones { get; set; }
    }
}
