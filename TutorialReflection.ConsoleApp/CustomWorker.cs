namespace TutorialReflection.ConsoleApp;

internal class CustomWorker {
    public List<string> Names { get; set; } = new List<string>();
    public int Code { get; set; }

    public CustomWorker() { }

    public CustomWorker(int code) {
        Code = code;
    }

    public CustomWorker(string code) {
        Code = Convert.ToInt32(code);
    }

    public CustomWorker(int code, List<string> names) {
        Code = code;
        Names = names;
    }

    public string GetCodeWithTransformation() {
        return $"{Code} + transformation: {Code}";
    }

    private void RemoveNames(List<string> namesToDelete) {
        Names.RemoveAll(x => namesToDelete.Contains(x));
    }
}
