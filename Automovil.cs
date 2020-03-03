using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAppTPi_ProgramacionII
{
    class Automovil
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public string Modelo { get; set; }  //30 ---> cant. max de caracteres 
        public int Año { get; set; } 
        public string Dimenciones { get; set; } //30
        public string Motor { get; set; }   //20
        public int IdCombustible { get; set; }
        public int IdCajaVeloc { get; set; }
        public ushort Velocidades { get; set; } //5-9
        public int IdTipoDireccion { get; set; }
        public int IdColor { get; set; }
        public ushort CantPuertas { get; set; }
        public string TamañoLlantas { get; set; }  //5
        public ushort CantAirBags{ get; set; }
        public bool CamaraRetroceso{ get; set; }
        public bool SensorLLuvia { get; set; }
        public bool TechoCielo { get; set; }
        public bool ClimaBiZona { get; set; }
        public bool LevantaVidrioAutom { get; set; }
        public string AudioConectividad { get; set; }   //100
        public bool CierreCentralizado { get; set; }
        public int IdProducto { get; set; }

        private string ConvertirBool(bool x)
        {
            string aux;

            if (x)
            {
                aux = "Si";
            }
            else
            {
                aux = "No";
            }

            return aux;
        }

        public override string ToString()
        {

            return $"{Id}\t{IdMarca}\t{Modelo}\t\t{Año}\t{Motor}";

            //Completo
            /*return $"{Id}   {IdMarca}   {Modelo}   {Año}   {Dimenciones}   {Motor}   {IdCombustible}   {IdCajaVeloc}   {Velocidades}" +
                $"   {IdTipoDireccion}   {IdColor}   {CantPuertas}   {TamañoLlantas}   {CantAirBags}   {ConvertirBool(CamaraRetroceso)}" +
                $"   {ConvertirBool(SensorLLuvia)}   {ConvertirBool(TechoCielo)}   {ConvertirBool(ClimaBiZona)}   {ConvertirBool(LevantaVidrioAutom)}" +
                $"   {AudioConectividad}   {ConvertirBool(CierreCentralizado)}";*/
        }

    }
}
