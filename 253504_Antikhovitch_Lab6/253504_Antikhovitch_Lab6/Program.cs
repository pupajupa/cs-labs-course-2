using Newtonsoft.Json;
using System.Reflection;

namespace _253504_Antikhovitch_Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new()
            { 
            new Employee { EmployeeID = 1, Name = "Ivan", Age = 18, IsMaster = false },
            new Employee { EmployeeID = 2, Name = "Lina", Age = 22, IsMaster= false },
            new Employee { EmployeeID = 3, Name = "Aleksandr", Age = 25, IsMaster= true },
            new Employee { EmployeeID = 4, Name = "Kirill", Age = 41, IsMaster= true },
            new Employee { EmployeeID = 5, Name = "Alice", Age = 21, IsMaster= false },
            };
            string assemblyPath = "E:\\BSUIR\\2\\C# labs\\Solution\\Library\\bin\\Debug\\net6.0\\Library.dll";
            // Загрузка библиотеки
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            //тип класса FileService
            Type fileServiceType = assembly.GetType("Library.FileService`1");
            //FileService<Employee>
            Type closedType = fileServiceType.MakeGenericType(typeof(Employee));
            //экземпляр
            object fileService = Activator.CreateInstance(closedType);

            MethodInfo saveDataMethod = closedType.GetMethod("SaveData");
            saveDataMethod.Invoke(fileService, new object[] { employees, "employees.json" });
            MethodInfo readFileMethod = closedType.GetMethod("ReadFile");

            IEnumerable<Employee> loadedEmployees = (IEnumerable<Employee>)readFileMethod.Invoke(fileService, new object[] { "employees.json" });

            foreach (var employee in loadedEmployees)
            {
                Console.WriteLine($"ID: {employee.EmployeeID}, Name: {employee.Name}, Age: {employee.Age}, Master: {employee.IsMaster}");
            }
        }
    }
}