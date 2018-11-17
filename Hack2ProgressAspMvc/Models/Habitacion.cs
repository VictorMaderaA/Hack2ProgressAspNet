﻿using Newtonsoft.Json;

namespace Hack2ProgressAspMvc.Models
{
    public class Habitacion
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "tipo")]
        public TipoHabitacionEnum Tipo { get; set; }


        public TipoHabitacionEnum Tamaño { get; set; }

        public int IdHogar { get; set; }
    }

    public enum TipoHabitacionEnum
    {
        Bathroom,
        Cocina,
        Salón,
        Habitacion,
        SalónExterior,
        Otros

    }

    public enum TamañoHabitacion
    {
        Small,
        medium,
        Large
    }
}