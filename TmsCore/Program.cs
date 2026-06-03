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

//public class Enrollment
//{
//    public string StudentId {get; set;} = string.Empty;
//    public string CourseCode {get; set;} = string.Empty;
//    public DateTime processedAt {get; set;}
//}

var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine(enrollment);

var corrected = enrollment with { CourseCode = "CS-402" };
Console.WriteLine(corrected);

var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}"); 

Console.WriteLine("\n Exercise 3:  — Part 2: Course Capacity with the field Keyword \n");

// public class Course
// {
//     private int _capacity; 
//     public int Capacity
//     {
//         get => _capacity;
//         set
//         {
//             if (value <= 0)
//                 throw newArgumentOutOfRangeException("Capacity must be positive.");
//             _capacity = value;
//         }
//     }
//}

var course = new Course{ Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");
// Invalid capacity — should throw
try
{
    course.Capacity =-5;
}

catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}
// Invalid title — should throw
try
{
    course.Title = "";
}

catch (ArgumentException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}