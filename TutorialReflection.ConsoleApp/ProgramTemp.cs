using TutorialReflection.Entities;

namespace TutorialReflection.ConsoleApp {
    internal class ProgramTemp {
        static void Main2(string[] args) {
            Employee emp = new Employee();
            emp.Name = "Luis";
            Console.WriteLine($"Hello, World! {emp.Name}");
        }
    }
}