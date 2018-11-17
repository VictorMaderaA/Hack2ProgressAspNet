using System;
using Newtonsoft.Json;

namespace Hack2ProgressAspMvc.Models.temp
{
    public class Consumo
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "consumoHabitacion")]
        public ConsumoHabitacion ConsumoHabitacion { get; set; }

    }

    public class ConsumoHabitacion
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "mesConsumo")]
        public MesConsumo MesConsumo { get; set; }

    }

     public class MesConsumo
     {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

     }

    
}