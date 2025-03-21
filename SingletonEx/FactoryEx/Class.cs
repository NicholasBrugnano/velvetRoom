using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryEx
{
    public abstract class IVehicle
    {
        public string ModeOfTransportation { get; set; }
    }
    public class Car : IVehicle
    {
        public Car() { ModeOfTransportation = "Land"; }
    }
    public class Boat : IVehicle
    {
        public Boat() { ModeOfTransportation = "Water"; }
    }
    public class VehicleCreator
    {
        public IVehicle GetVehicle(string type)
        {
            switch(type)
            {
                case "Car":
                    return new Car();
                case "Boat":
                    return new Boat();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
