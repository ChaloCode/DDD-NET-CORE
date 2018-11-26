namespace Domain.Entities.car
{
    /// <summary>
    /// Representa la entrada de un carro.
    /// Nota: En otras literaturas llaman a ValueObject como DTO, 
    /// tiene la responsabilidad de representar un comportamiento de un objeto.
    /// Es valido tener ValueObjects que repitan propiedades, pero no es valido herencia entre ValueObjects,
    /// al menos que se aplique a todos los ValueObject.
    /// </summary>
    public class CarCreateInput
    {
        public CarCreateInput(){}
        public CarCreateInput(string name, string engine, string model)
        {
            this.Name = name;
            this.Engine = engine;
            this.Model = model;
        }
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Model { get; set; }
    }
}