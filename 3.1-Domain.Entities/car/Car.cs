namespace Domain.Entities.car
{
    /// <summary>
    /// Es la identidad Carro.
    /// Se puede transportar entre las capas.
    /// Nota: No se encuentra en la capa Transversal porque hace parte de la logica del negocio (capa del dominio)
    /// Nota: En otras literaturas de DDD llaman a esta capa 'Shared Kernel'
    /// </summary>
    public class Car
    {
        public Car(){}
        public Car(string name, string engine, string model)
        {
            this.Name = name;
            this.Engine = engine;
            this.Model = model;
        }
        public Car(int id, string name, string engine, string model)
        {
            this.Id = id;
            this.Name = name;
            this.Engine = engine;
            this.Model = model;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Model { get; set; }
    }
}