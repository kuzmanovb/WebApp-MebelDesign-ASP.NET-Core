using System;
using System.Reflection;
using VehiclesExtension.Core;
using VehiclesExtension.Models;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //var engine = new Engine();
            //engine.Run();


            
            Type proba = typeof(Vehicle);
            Type proba2 = Type.GetType("VehiclesExtension.Models.Vehicle");
            Type proba3 = typeof(Car);


            Type probaBase = proba.BaseType;
            Type probaBase2 = proba3.BaseType;
            Type[] probaInter = proba.GetInterfaces();
            Type[] probaInter2 = proba3.GetInterfaces();

            FieldInfo[] field = proba.GetFields();

            ;
        }
    }
}
