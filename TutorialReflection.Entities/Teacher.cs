namespace TutorialReflection.Entities;

public class Teacher : Employee {
    public Guid TearcherId { get; set; }
    public string Speciality { get; set; } = null!;
}
