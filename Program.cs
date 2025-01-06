namespace EFTest;
using EFTest.Data;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        //Create an instance of DbContext to retrieve the .options object
        var options = new DbContextOptionsBuilder<SchoolDbContext>()
            .UseSqlServer("Server=localhost,2022;Database=SchoolDb;User Id=sa;Password=Fr00t_L00pth;")
            .Options;
        
        //Try-Catch if connection to Dbo is succesful
        using var context = new SchoolDbContext(options);               
        try
        {
            context.Database.CanConnect();
            Console.WriteLine("Database connection successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database connection failed: {ex.Message}");
        }

        void FetchStudents()
        {
            using (var studentFetch = new SchoolDbContext())
            {
                // Fetch all students
                var students = context.Students.ToList();

                // Example: Print student details
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentId} - {student.Name}");
                }
            }
        }
        
        void FetchStaff()
        {
            using (var staffFetch = new SchoolDbContext())
            {
                // Fetch all staff
                var staffs = context.Staff.ToList();

                // Example: Print staff details
                foreach (var staff in staffs)
                {
                    Console.WriteLine($"{staff.StaffId} - {staff.Name}");
                }
            }
        }

        void FetchStudentsByClass()
        {
            using (var context = new SchoolDbContext())
            {
                Console.WriteLine("Enter classname");
                string targetClassName = Console.ReadLine(); // Replace with the desired class name

                var studentsInClass = context.Students
                    .Where(s => s.Class == targetClassName)
                    .ToList();

                foreach (var student in studentsInClass)
                {
                    Console.WriteLine($"{student.StudentId}: {student.Name} - {student.Class}");
                }
            }
        }
        
        //Run the switch menu
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the School System!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Fetch all students");
            Console.WriteLine("2. Fetch students by class");
            Console.WriteLine("3. Fetch all staff");
            Console.WriteLine("4. Exit");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FetchStudents();
                    break;

                case "2":
                    FetchStudentsByClass();
                    break;

                case "3":
                    FetchStaff();
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("\nExiting... Goodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
        
    }
}





