using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxPopuliApp.Views.Inicio
{

    public class InicioMenuItem
    {
        public InicioMenuItem()
        {
            TargetType = typeof(InicioDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
