namespace Domain.Entities.car
{
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