using StudentsApp.Data;
using StudentsApp.Models;
using StudentsApp.Requests;
using StudentsApp.Responses;
using StudentsApp.Serialization;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentsApp.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly AppDbContext _context = new AppDbContext();

        [HttpGet]
        public async Task<IHttpActionResult> GetStudents([FromUri] string format, [FromUri] GetStudentsRequest request)
        {
            var sqlQuery = new StringBuilder(300)
                .Append($"SELECT {string.Join(",", Student.Columns).TrimEnd(',')} FROM STUDENTS ")
                .Append($"WHERE (ID >= {request.MinId} AND ID <= {request.MaxId}) ")
                .Append($"AND UPPER(NAME) LIKE '%{request.Like.ToUpper()}%' ")
                .Append($"AND UPPER(CONCAT(ID, CONCAT(NAME, PHONE))) LIKE '%{request.GlobalLike.ToUpper()}%' ")
                .Append($"ORDER BY {request.Sort} ")
                .Append($"OFFSET {request.Offset} ROWS ")
                .Append($"FETCH NEXT {request.Limit} ROWS ONLY;")
                .ToString();

            var students = await _context.Students.SqlQuery(sqlQuery).ToListAsync();

            var response = students.ToList().ConvertAll(x =>
            {
                var baseUrl = $"api/students.{format}/{x.Id}";

                return (Success<StudentResponse>)ResponseBuilder<StudentResponse>
                    .Success(new StudentResponse(x.Id, x.Name, x.Phone))
                        .AddLink(new LinkResponse("self", baseUrl, "GET"))
                        .AddLink(new LinkResponse("update", baseUrl, "PUT"))
                        .AddLink(new LinkResponse("delete", baseUrl, "DELETE"))
                        .Create();
            });

            var excludedFields = Student.Columns
                .Where(x => !request.Columns.Split(',').ToList().Contains(x))
                .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower())
                .ToList();

            return SuccessBuilder<List<Success<StudentResponse>>>.Success(response)
                .Formatter(SerializeHelper.CreateMediaTypeFormatter(format, excludedFields))
                .Create();
        }

        [HttpGet] 
        public async Task<IHttpActionResult> GetStudentById([FromUri] string format, [FromUri] int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null) 
                return GetErrorResponse(format);

            return GetSuccessResponse(format, student, $"/api/students.{format}/{student.Id}");
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddStudent([FromUri] string format, [FromBody] CreateStudentRequest request)
        {
            var student = new Student(request.Name, request.Phone);
            _context.Students.Add(student);

            if (await _context.SaveChangesAsync() == 0) 
                return GetErrorResponse(format);

            return GetSuccessResponse(format, student, $"/api/students.{format}/{student.Id}");
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudent([FromUri] string format, [FromUri] int id, [FromBody] UpdateStudentRequest request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null) 
                return GetErrorResponse(format);

            student.Update(request.Name, request.Phone);
            await _context.SaveChangesAsync();

            return GetSuccessResponse(format, student, $"/api/students.{format}/{student.Id}");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStudent([FromUri] string format, [FromUri] int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null) 
                return GetErrorResponse(format);

            _context.Students.Remove(student);

            if (await _context.SaveChangesAsync() == 0) 
                return GetErrorResponse(format);

            return Ok();
        }

        private IHttpActionResult GetSuccessResponse(string format, Student student, string baseUrl) => ResponseBuilder<StudentResponse>
            .Success(new StudentResponse(student.Id, student.Name, student.Phone))
            .AddLink(new LinkResponse("self", baseUrl, "GET"))
            .AddLink(new LinkResponse("update", baseUrl, "PUT"))
            .AddLink(new LinkResponse("delete", baseUrl, "DELETE"))
            .Formatter(SerializeHelper.CreateMediaTypeFormatter(format))
            .Create();

        private IHttpActionResult GetErrorResponse(string format) => ResponseBuilder<StudentResponse>
            .Error(400)
            .AddLink(new LinkResponse("info", "https://en.wikipedia.org/wiki/List_of_HTTP_status_codes#400", "GET"))
            .Formatter(SerializeHelper.CreateMediaTypeFormatter(format))
            .Create();
    }
}