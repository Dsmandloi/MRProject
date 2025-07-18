
//using Microsoft.EntityFrameworkCore;
//using StudentResultApi.Data;
//using StudentResultApi.Models;
//using Microsoft.OpenApi.Models;

//var builder = WebApplication.CreateBuilder(args);

//// ✅ Swagger & API Explorer
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Result API", Version = "v1" });
//});

//// ✅ Database Connection
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

//// ✅ Enable Swagger
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Result API v1");
//    });
//}

//app.UseHttpsRedirection();

//// ✅ Home route
//app.MapGet("/", () => "API Running ✅");


//// ✅ POST: Add Student
//app.MapPost("/api/students", async (Student student, AppDbContext context) =>
//{
//    context.Students.Add(student);
//    await context.SaveChangesAsync();

//    return Results.Ok(new
//    {
//        status = "success",
//        message = "Student added successfully"
//    });
//});


//// ✅ POST: Generate Result
//app.MapPost("/api/result/generate", async (ResultGenerateRequest request, AppDbContext context) =>
//{
//    var student = await context.Students.FindAsync(request.StudentId);
//    if (student == null)
//    {
//        return Results.NotFound(new { status = "error", message = "Student not found" });
//    }

//    var subjects = new List<Subject>();
//    int total = 0;

//    foreach (var s in request.Subjects)
//    {
//        total += s.Marks;

//        string grade = GetGrade((double)s.Marks / s.MaxMarks * 100);

//        subjects.Add(new Subject
//        {
//            StudentId = request.StudentId,
//            SubjectName = s.Subject,
//            MarksObtained = s.Marks,
//            MaximumMarks = s.MaxMarks,
//            Grade = grade
//        });
//    }

//    double percentage = (double)total / request.Subjects.Sum(s => s.MaxMarks) * 100;
//    string finalGrade = GetGrade(percentage);
//    string status = percentage >= 33 ? "Pass" : "Fail";

//    var result = new Result
//    {
//        StudentId = request.StudentId,
//        TotalMarks = request.Subjects.Sum(s => s.MaxMarks),
//        ObtainedMarks = total,
//        Percentage = percentage,
//        FinalGrade = finalGrade,
//        ResultStatus = status
//    };

//    context.Subjects.AddRange(subjects);
//    context.Results.Add(result);
//    await context.SaveChangesAsync();

//    return Results.Ok(new
//    {
//        status = "success",
//        message = "Result generated",
//        fileUrl = $"http://localhost:7191/result/{request.StudentId}.pdf" // Placeholder
//    });
//});


//// ✅ GET: Fetch Result by Student ID
//app.MapGet("/api/students/{id}/result", async (int id, AppDbContext context) =>
//{
//    var student = await context.Students.FindAsync(id);
//    if (student == null)
//    {
//        return Results.NotFound(new { status = "error", message = "Student not found" });
//    }

//    var result = await context.Results.FirstOrDefaultAsync(r => r.StudentId == id);
//    if (result == null)
//    {
//        return Results.NotFound(new { status = "error", message = "Result not found" });
//    }

//    var subjectEntities = await context.Subjects
//        .Where(s => s.StudentId == id)
//        .ToListAsync();

//    var subjects = subjectEntities.Select(s => new
//    {
//        subject = s.SubjectName,
//        marks = s.MarksObtained,
//        grade = s.Grade
//    });

//    return Results.Ok(new
//    {
//        name = student.Name,
//        rollNumber = student.RollNumber,
//        @class = student.Class,
//        section = student.Section,
//        subjects,
//        result.TotalMarks,
//        result.ObtainedMarks,
//        result.Percentage,
//        finalGrade = result.FinalGrade,
//        resultStatus = result.ResultStatus
//    });
//});

//app.Run();


//// ✅ Local Grade Logic
//string GetGrade(double percentage)
//{
//    if (percentage >= 90) return "A+";
//    else if (percentage >= 80) return "A";
//    else if (percentage >= 70) return "B+";
//    else if (percentage >= 60) return "B";
//    else if (percentage >= 50) return "C";
//    else if (percentage >= 33) return "D";
//    else return "F";
//}

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentResultApi.Data;
using StudentResultApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Result API", Version = "v1" });
});

// ✅ Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Result API v1");
    });
}

app.UseHttpsRedirection();

// ✅ Test route
app.MapGet("/", () => "✅ Student Result API is Running!");

// ✅ POST: Add Student
app.MapPost("/api/students", async (Student student, AppDbContext context) =>
{
    context.Students.Add(student);
    await context.SaveChangesAsync();

    return Results.Ok(new
    {
        status = "success",
        message = "Student added successfully"
    });
});

// ✅ POST: Generate Result
//app.MapPost("/api/result/generate", async (ResultGenerateRequest request, AppDbContext context) =>
//{
//    var student = await context.Students.FindAsync(request.StudentId);
//    if (student == null)
//    {
//        return Results.NotFound(new { status = "error", message = "Student not found" });
//    }

//    var subjects = request.Subjects.Select(sub => new ResultSubject
//    {
//        SubjectName = sub.Subject,
//        MarksObtained = sub.Marks,
//        MaximumMarks = sub.MaxMarks,
//        Grade = GetGrade((double)sub.Marks / sub.MaxMarks * 100)
//    }).ToList();

//    double totalMax = request.Subjects.Sum(sub => sub.MaxMarks);
//    double totalObtained = request.Subjects.Sum(sub => sub.Marks);
//    double percentage = (totalObtained / totalMax) * 100;
//    string finalGrade = GetGrade(percentage);
//    string status = percentage >= 33 ? "Pass" : "Fail";

//    var result = new Result
//    {
//        StudentId = request.StudentId,
//        TotalMaximumMarks = totalMax,
//        TotalMarksObtained = totalObtained,
//        Percentage = percentage,
//        Grade = finalGrade,
//        Status = status,
//        Comments = request.Comments,
//        CreatedAt = DateTime.Now,
//        Subjects = subjects
//    };

//    context.Results.Add(result);
//    await context.SaveChangesAsync();

//    return Results.Ok(new
//    {
//        status = "success",
//        message = "Result generated",
//        fileUrl = $"http://localhost:7191/result/{request.StudentId}.pdf" // Placeholder
//    });
//});
//app.MapPost("/api/result/generate", async (ResultGenerateRequest request, AppDbContext context) =>
//{
//    try
//    {
//        var student = await context.Students.FindAsync(request.StudentId);
//        if (student == null)
//        {
//            return Results.NotFound(new { status = "error", message = "Student not found" });
//        }

//        var resultSubjects = new List<ResultSubject>();
//        double totalObtained = 0;
//        double totalMax = 0;

//        foreach (var s in request.Subjects)
//        {
//            string grade = GetGrade((double)s.Marks / s.MaxMarks * 100);

//            resultSubjects.Add(new ResultSubject
//            {
//                SubjectName = s.Subject,
//                MarksObtained = s.Marks,
//                MaximumMarks = s.MaxMarks,
//                Grade = grade
//            });

//            totalObtained += s.Marks;
//            totalMax += s.MaxMarks;
//        }

//        double percentage = totalObtained / totalMax * 100;
//        string finalGrade = GetGrade(percentage);
//        string status = percentage >= 33 ? "Pass" : "Fail";

//        var result = new Result
//        {
//            StudentId = request.StudentId,
//            TotalMarksObtained = totalObtained,
//            TotalMaximumMarks = totalMax,
//            Percentage = percentage,
//            Grade = finalGrade,
//            Status = status,
//            Comments = request.Comments,
//            CreatedAt = DateTime.Now,
//            Subjects = resultSubjects
//        };

//        context.Results.Add(result);
//        await context.SaveChangesAsync();

//        return Results.Ok(new
//        {
//            status = "success",
//            message = "Result generated successfully!"
//        });
//    }
//    catch (Exception ex)
//    {
//        return Results.Problem("❌ Internal Error: " + ex.Message + " | Inner: " + ex.InnerException?.Message);
//    }
//});
app.MapPost("/api/result/generate", async (ResultGenerateRequest request, AppDbContext db) =>
{
    if (request == null || request.StudentId <= 0 || request.Subjects == null || request.Subjects.Count == 0)
    {
        return Results.BadRequest(new { status = "error", message = "Invalid request" });
    }

    var student = await db.Students.FindAsync(request.StudentId);
    if (student == null)
    {
        return Results.NotFound(new { status = "error", message = "Student not found" });
    }

    decimal totalMarks = 0;
    decimal totalMaxMarks = 0;
    var subjectResults = new List<ResultSubject>();

    foreach (var s in request.Subjects)
    {
        decimal obtained = (decimal)s.MarksObtained;
        decimal maximum = (decimal)s.MaximumMarks;

        string grade = GetGrade((double)(obtained / maximum * 100));

        subjectResults.Add(new ResultSubject
        {
            SubjectName = s.SubjectName,
            MarksObtained = obtained,
            MaximumMarks = maximum,
            Grade = grade
        });

        totalMarks += obtained;
        totalMaxMarks += maximum;
    }

    decimal percentage = totalMaxMarks > 0 ? (totalMarks / totalMaxMarks) * 100 : 0;
    string finalGrade = GetGrade((double)percentage);
    string status = percentage >= 33 ? "Pass" : "Fail";
    string comments = $"Student has {status}ed with {percentage:F2}%.";

    var result = new Result
    {
        //StudentId = request.StudentId,
        //TotalMarksObtained = totalMarks,
        //TotalMaximumMarks = totalMaxMarks,
        //Percentage = percentage,
        StudentId = request.StudentId,
        TotalMarksObtained = (double)totalMarks,
        TotalMaximumMarks = (double)totalMaxMarks,
        Percentage = (double)percentage,

        Grade = finalGrade,
        Status = status,
        Comments = comments,
        CreatedAt = DateTime.Now,
        Subjects = subjectResults
    };

    db.Results.Add(result);
    await db.SaveChangesAsync();

    return Results.Ok(new { status = "success", message = "Result generated successfully", resultId = result.Id });
});

// ✅ GET: Fetch Result by Student ID
//app.MapGet("/api/students/{id}/result", async (int id, AppDbContext context) =>
//{
//    var student = await context.Students.FindAsync(id);
//    if (student == null)
//    {
//        return Results.NotFound(new { status = "error", message = "Student not found" });
//    }

//    var result = await context.Results
//        .Include(r => r.Subjects)
//        .FirstOrDefaultAsync(r => r.StudentId == id);

//    if (result == null)
//    {
//        return Results.NotFound(new { status = "error", message = "Result not found" });
//    }

//    var subjects = result.Subjects.Select(s => new
//    {
//        subject = s.SubjectName,
//        marks = s.MarksObtained,
//        grade = s.Grade
//    });

//    return Results.Ok(new
//    {
//        name = student.Name,
//        rollNumber = student.RollNumber,
//        subjects,
//        result.TotalMaximumMarks,
//        result.TotalMarksObtained,
//        result.Percentage,
//        finalGrade = result.Grade,
//        resultStatus = result.Status,
//        result.Comments,
//        result.CreatedAt
//    });
//});
app.MapGet("/api/students/{id}/result", async (int id, AppDbContext db) =>
{
    var student = await db.Students
        .Include(s => s.Results.OrderByDescending(r => r.CreatedAt))
            .ThenInclude(r => r.Subjects)
        .FirstOrDefaultAsync(s => s.Id == id);

    if (student == null)
        return Results.NotFound($"Student with ID {id} not found.");

    var latestResult = student.Results.FirstOrDefault();

    if (latestResult == null)
        return Results.NotFound($"No result found for student ID {id}.");

    var response = new
    {
        Student = new
        {
            student.Id,
            student.Name,
            student.RollNumber
        },
        Result = new
        {
            latestResult.Id,
            latestResult.TotalMarksObtained,
            latestResult.TotalMaximumMarks,
            latestResult.Percentage,
            latestResult.Grade,
            latestResult.Status,
            latestResult.Comments,
            latestResult.CreatedAt,
            Subjects = latestResult.Subjects.Select(s => new
            {
                s.SubjectName,
                s.MarksObtained,
                s.MaximumMarks,
                s.Grade
            }).ToList()
        }
    };

    return Results.Ok(response);
});

app.Run();

// ✅ Grade logic
string GetGrade(double percentage)
{
    if (percentage >= 90) return "A+";
    if (percentage >= 80) return "A";
    if (percentage >= 70) return "B+";
    if (percentage >= 60) return "B";
    if (percentage >= 50) return "C";
    if (percentage >= 33) return "D";
    return "F";
}

