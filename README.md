TutorLiveMentor
TutorLiveMentor is an ASP.NET Core MVC application allowing students to select their preferred faculty for each subject. Each subject has competitive faculty (e.g. 3 per subject). Real-time selection counts are displayed for each faculty using SignalR. The system strictly enforces department and year filtering so students only see and select from eligible faculty.

🚀 Features
Faculty Profile Management: Edit/view department, email, and personal details.
Department & Year Filtering: Only faculties matching the student's department/year per subject are shown.
Competitive Selection: For each subject, students see their options among 3 eligible faculty and select one.
Live Seat Count: Faculty selection counts update instantly across all devices using SignalR.
EF Core Database & Secure Login: Modern database with migrations for compatibility and futureproofing.


Tool/Package                             |  Version                    
-----------------------------------------+-----------------------------
.NET SDK                                 |  9.0.305                    
Target Framework                         |  net8.0                     
Microsoft.EntityFrameworkCore            |  9.0.9                      
Microsoft.EntityFrameworkCore.SqlServer  |  9.0.9                      
Microsoft.EntityFrameworkCore.Tools      |  9.0.9                      
Visual Studio                            |  2022 17.14.13 (August 2025)


📦 Project Structure
text
/Controllers           // C# controller logic (MVC)
/Models                // Data+entity classes (Faculty, AssignedSubject, Student, ...)
/Views                 // All Razor pages
/Migrations            // All EF Core DB migration scripts
appsettings.json       // Config (including DB connection string)
Program.cs             // App startup logic


🗄 Database Setup
Database Models
Faculty: All basic faculty info (name, email, department, ...).
AssignedSubject: Links faculty to [subject, department, year], and tracks live seat (selection) count.
Student: Student information (name, email, year, department, registration details).

Connection String
Located in appsettings.json:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TutorLiveMentorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

Database Provider
SQL Server LocalDB (default for development)
SQL Server Express/Full (for production)



Migrations
All database changes are tracked via EF Core migrations:
Initial migration: Creates base tables (Faculty, Student, etc.)
AddPasswordColumn: Adds password field to Faculty table
AddFacultyAndAssignedSubjects: Creates AssignedSubjects table for faculty-subject mapping
AddSelectedSubjectToStudent: Tracks student selections
AddDepartmentToFaculty: Adds department filtering

⚡ Setup
1. Install Required Versions
Match all versions in the table above exactly.

2. Clone & Restore
bash
git clone <your-repo-url>
cd TutorLiveMentor
dotnet restore
3. Database Configuration
Option A: Use LocalDB (Recommended for Development)
json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TutorLiveMentorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
Option B: Use SQL Server Express
json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=TutorLiveMentorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
Option C: Use SQL Server with Credentials
json
"DefaultConnection": "Server=your-server;Database=TutorLiveMentorDB;User Id=your-username;Password=your-password;MultipleActiveResultSets=true"
4. Apply Database Migrations
bash
dotnet ef database update
5. Run the Application
bash
dotnet run
or use Visual Studio Debug (F5).

🎯 Database Schema
Faculty Table
sql
- FacultyId (int, PK)
- Name (nvarchar)
- Email (nvarchar)
- Password (nvarchar)
- Department (nvarchar)
AssignedSubject Table
sql
- AssignedSubjectId (int, PK)
- FacultyId (int, FK)
- SubjectName (nvarchar)
- Year (int)
- SelectedCount (int) -- Live selection tracking
Student Table
sql
- StudentId (int, PK)
- Name (nvarchar)
- Email (nvarchar)
- Year (int)
- Department (nvarchar)

  
👤 Usage
Faculty: Login, edit/view profile, see assigned subjects.

Student: Login, select year/department, show subjects with eligible faculty.

Subject Selection: For each subject, student sees 3 eligible faculty with real-time seat count and makes a selection.

Live Updates: All selection counts update instantly due to SignalR.


🔧 Database Commands
Create New Migration
bash
dotnet ef migrations add MigrationName
Update Database
bash
dotnet ef database update
Remove Last Migration
bash
dotnet ef migrations remove
Generate SQL Script
bash
dotnet ef script


🔑 Important Notes
Faculty-Subject Assignment: Ensure correct data in AssignedSubjects table (3 faculty per subject/year/department).

Database Backup: Always backup before major changes.

Connection String Security: Use environment variables for production credentials.

EF Core Migrations: Always use migrations for schema changes to maintain compatibility.

🐛 Troubleshooting
Database Connection Issues
Verify connection string in appsettings.json

Ensure SQL Server/LocalDB is running

Check Windows Authentication settings

Migration Errors
Run dotnet ef database update
If errors persist, check migration files in /Migrations folder
For fresh start: Delete database and run dotnet ef database update

📝 Version Verification
bash
dotnet --version          # Check .NET SDK
dotnet list package       # Check NuGet packages
dotnet ef --version       # Check EF Core tools

Any collaborators should match all versions above, configure their database connection string, run migrations, and restore packages for smooth setup!
