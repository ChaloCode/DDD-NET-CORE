namespace Domain.Entities.car
{
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