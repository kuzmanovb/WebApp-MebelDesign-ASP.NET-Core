using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string inputPatient = Console.ReadLine();
            while (inputPatient != "Output")
            {
                string[] token = inputPatient.Split();
                var departament = token[0];
                var firstName = token[1];
                var lastName = token[2];
                var patient = token[3];
                var fullName = firstName + lastName;

                AddDoctorsIfNotExist(doctors, fullName);
                AddDepartmenIfNotExist(departments, departament);

                bool checkFreeBed = departments[departament].SelectMany(x => x).Count() < 60;
                if (checkFreeBed)
                {
                    PlacementPatient(doctors, departments, departament, patient, fullName);
                }

                inputPatient = Console.ReadLine();
            }

            var commandsForPrint = Console.ReadLine().Split();

            while (commandsForPrint[0] != "End")
            {

                Print(doctors, departments, commandsForPrint);

                commandsForPrint = Console.ReadLine().Split();
            }
        }

        private static void Print(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] commandsForPrint)
        {
            if (commandsForPrint.Length == 1)
            {
                Console.WriteLine(string.Join(Environment.NewLine, departments[commandsForPrint[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (commandsForPrint.Length == 2 && int.TryParse(commandsForPrint[1], out int staq))
            {
                Console.WriteLine(string.Join(Environment.NewLine, departments[commandsForPrint[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, doctors[commandsForPrint[0] + commandsForPrint[1]].OrderBy(x => x)));
            }
        }

        private static void PlacementPatient(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName)
        {
            int bedInRoom = 0;
            doctors[fullName].Add(patient);
            for (int numberRoom = 0; numberRoom < departments[departament].Count; numberRoom++)
            {
                if (departments[departament][numberRoom].Count < 3)
                {
                    bedInRoom = numberRoom;
                    break;
                }
            }
            departments[departament][bedInRoom].Add(patient);
        }

        private static void AddDepartmenIfNotExist(Dictionary<string, List<List<string>>> departments, string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void AddDoctorsIfNotExist(Dictionary<string, List<string>> doctors, string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
