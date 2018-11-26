using GraphQL.Types;

namespace Issues.Schemas
{
    public class CarStatusesEnum: EnumerationGraphType
    {
        public CarStatusesEnum()
        {
            Name = "CarStatuses";
            AddValue("CREADO", "Carro creado", 1);
            AddValue("ACTUALIZADO", "Carro actulizado", 2);
            AddValue("CONSULTADO", "Carro consultado", 3);
            AddValue("BORRADO", "Carro borrado", 4);
        }
    }
}