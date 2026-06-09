using System.Diagnostics;

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

//.....Exercise 3: Pipeline Data Corruption.......

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

Console.WriteLine("\n Exercise 3:  —  Part 3: Student Model \n");

var student = new Student { Id = "S1", Name ="Abeba", Age = 20, GPA= 3.8m };
Console.WriteLine($"Student: {student.Name}, GPA: {student.GPA}");

Console.WriteLine("\n Exercise  3B: Interface Contract Wiring \n");

void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    Console.WriteLine("--- Grade Report---");
    foreach (var item in assessments)
    {
        Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
    }
}
// Test it — one array holds two completely different types
IGradable[] cohortAssessments = [
    new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
    new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =85m}
    ];
    
PrintGradeReport(cohortAssessments);

//....... Session 2 Exercise 4 ...........

Console.WriteLine("\n Exercise 4: Defeating the Pyramid of Doom (LO 1.6: Pattern Matching & Guards) \n");

var service = new EnrollmentService();
 
// Test 1: Valid registration 
var validStudent = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
 
var validCourse = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
 
var result = service.ProcessRegistration(validStudent, validCourse);
 
Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");
 
// Test 2: Null student should throw 
try 
{ 
    service.ProcessRegistration(null, validCourse); 
} 
catch (ArgumentNullException ex)
{ 
    Console.WriteLine($"Guard caught: {ex.ParamName}"); 
}
 
// Test 3: Full course should throw
 
var fullCourse = new Course { Code = "CS-402", Title = "Full Course", Capacity = 1 };
 
fullCourse.EnrolledCount = 1;
 
try 
{ 
    service.ProcessRegistration(validStudent, fullCourse); 
} 
catch (InvalidOperationException ex) 
{ 
    Console.WriteLine($"Business rule: {ex.Message}"); 
}

Console.WriteLine("\n Exercise 5: The Analytics Dashboard (Lo 1.5: Collections & LINQ) \n");

List<Student> students = [

    new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
    new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
    new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
    new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
    new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
    new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
    new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }
];

// Filter and sort students for the honors leaderboard

var leaderboard = students
    .Where(s => s.GPA >= 3.5m)
    .OrderByDescending(s => s.GPA)
    .Select(s => s.Name)
    .ToList();

Console.WriteLine($"\nFound {leaderboard.Count} Honors Students:");

foreach (var name in leaderboard)
{
    Console.WriteLine($"- {name}");
}

// Calculate the average GPA for the class

decimal averageGpa = students.Average(s => s.GPA);

Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

// Group students by academic standing based on GPA thresholds

var standingGroups = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "Good Standing",
    >= 2.0m => "Probation",
    _ => "Academic Warning"
});

Console.WriteLine("\n--- Academic Standing Report ---");

foreach (var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key} ({group.Count()}):");

    foreach (var s in group)
    {
        Console.WriteLine($" {s.Name} GPA: {s.GPA}");
    }
}

// Collection Spread Operator 

string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];

string[] allCourses =
[
    ..backendCourses,
    ..frontendCourses,
    "Capstone"
];

Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");

//....... Session 3 Exercise 6 ...........

Console.WriteLine("\n Exercise 6: Connection Dropping Under Load (LO 1.7: Async/Await) \n");

var sw =Stopwatch.StartNew();
for (int i = 0; i < 5; i++)
{
Thread.Sleep(300); // Thread is HELD for 300ms cannot serve anyone else
}
Console.WriteLine($"Blocking sequential: {sw.ElapsedMilliseconds}ms");
// ASYNC BUTSTILL SEQUENTIAL: Thread released, but calls are one-at-a-time
sw.Restart();
for (int i = 0; i < 5; i++)
{
await Task.Delay(300); // Thread released while waiting but still sequential
}
Console.WriteLine($"Async sequential: {sw.ElapsedMilliseconds}ms");
// THE RIGHT WAY:Asyncparallel all 5 start simultaneously
sw.Restart();
var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
await Task.WhenAll(tasks);
Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");

async Task<Student> FetchStudentAsync(string id)
{
    Console.WriteLine($" Fetching {id}...");
    await Task.Delay(300); // Simulate database latency
    return new Student
    {
        Id = id,
        Name = $"Student-{id}",
        Age = 20,
        GPA = id switch
        {
            "S1" => 3.8m,
            "S2" => 2.4m,
            "S3" => 3.5m,
            "S4" => 1.9m,
            "S5" => 3.2m,
            _ => 2.5m
        }
    };
}

async Task<Course> FetchCourseAsync(string code)
{
    Console.WriteLine($" Fetching course {code}...");
    await Task.Delay(200); // Simulate database latency
    return new Course
    {
        Code = code,
        Title = $"Course-{code}",
        Capacity = code switch
        {
            "CRS-101" => 2,
            "CRS-201" => 30,
            "CRS-301" => 15,
            _ => 25
        }
    };
}

sw.Restart();

// Start all fetches simultaneously students AND courses
string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];

var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));

// Both arrays load concurrently
Student[] stud = await Task.WhenAll(studentTasks);
Course[] courses = await Task.WhenAll(courseTasks);

Console.WriteLine($"\nLoaded {stud.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms");
foreach (var s in stud)
{
Console.WriteLine($" {s.Name} GPA: {s.GPA}");
}