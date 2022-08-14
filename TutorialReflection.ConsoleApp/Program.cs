using System.Reflection;
using TutorialReflection.Entities;
using TutorialReflection.Entities.InterfacesSection;

namespace TutorialReflection.ConsoleApp {
    internal class Program {
        static void GetAllTypes() {
            Assembly? currentAssembly = Assembly.GetAssembly(typeof(Teacher));
            if (currentAssembly == null) return;
            Type[] assemblyTypes = currentAssembly.GetTypes();
            assemblyTypes.ToList().ForEach(x => Console.WriteLine(x.FullName));
        }

        static void GetTypesWithInterfaces() {
            Assembly? currentAssembly = Assembly.GetAssembly(typeof(Teacher));
            if (currentAssembly == null) return;
            Type[] assemblyTypes = currentAssembly.GetTypes()
                .Where(x => x.IsAssignableTo(typeof(ICustomFlag))).ToArray();
            assemblyTypes.ToList().ForEach(x => Console.WriteLine(x.FullName));
        }

        static void InvokePublicMethod() {
            CustomWorker newWorker = new CustomWorker(2140);
            MethodInfo? getCodeMethod = newWorker.GetType().GetMethod("GetCodeWithTransformation");
            if (getCodeMethod == null) return;
            string? codeResult = getCodeMethod.Invoke(newWorker, null) as string;
            Console.WriteLine($"Execution result: {codeResult}");
        }

        static void InvokeInternalMethod() {
            CustomWorker newWorker = new CustomWorker(
                2140,
                new List<string>() {
                    "Luis",
                    "Gustavo",
                    "Fernández",
                    "Batres"
                }
            );
            List<string> namesToDelete = new List<string>() {
                "Luis",
                "Gustavo",
            };
            Console.WriteLine($"Names before execution: {newWorker.Names.Count}");

            //MethodInfo? getCodeMethod = newWorker.GetType().GetMethod("RemoveNames");
            MethodInfo? getCodeMethod = newWorker.GetType().GetMethod("RemoveNames", BindingFlags.NonPublic | BindingFlags.Instance);
            if (getCodeMethod == null) return;
            getCodeMethod.Invoke(newWorker, new object[] { namesToDelete });

            Console.WriteLine($"Names after execution: {newWorker.Names.Count}");
        }

        static void Main(string[] args) { 
            GetAllTypes();
            GetTypesWithInterfaces();
            InvokePublicMethod();
            InvokeInternalMethod();
            Console.WriteLine("Hello, World!");
        }
    }
}