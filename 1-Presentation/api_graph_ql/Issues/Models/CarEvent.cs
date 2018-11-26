using System;

namespace Issues.Models
{
    public class CarEvent
    {
        public CarEvent(int id, string name, string engine, string model, CarStatuses status)
        {
            this.Id = id;
            this.Name = name;
            this.Engine = engine;
            this.Model = model;
            this.Status = status;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Model { get; set; }
        public CarStatuses Status { get; set; }
    }

    public enum CarStatuses
    {
        CREADO = 1,
        ACTUALIZADO = 2,
        CONSULTADO = 3,
        BORRADO = 4,
    }

}
