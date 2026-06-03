string?region = null;

string? upperRegion = region?.ToUpper();
Console.WriteLine($"Region(conditional):{upperRegion}");

string displayRegion = region?? "Unassigned";
Console.WriteLine($"Region(coalesced):{displayRegion}");

region??= "Addis Ababa";
Console.WriteLine($"Region(assigned):{region}");

Console.WriteLine("\n");

string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;

Console.WriteLine($"Student: {studentName}({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant: {grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt: yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");

Console.WriteLine("\n Exercise 2: The Ministry Audit Failure \n");

decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100000;

Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
Console.WriteLine($"Total allocated(formatted): {totalAllocation:F2}");

Console.WriteLine("\n Exercise 3: Pipeline Data Corruption \n");

public class Enrollment
{
    public string StudentId {get; set;} = string.Empty;
    public string CourseCode {get; set;} = string.Empty;
    public DateTime processedAt {get; set;}
}


