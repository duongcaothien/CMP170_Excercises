﻿using Microsoft.AspNetCore.Mvc;
using static StudentManagementWithWS.s;

namespace StudentManagementWithWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService m_studentService;
        public StudentsController(IStudentService studentService)
        {
            m_studentService = studentService;
        }
        [HttpGet]
        public IActionResult SearchStudent(string keyword, string hutechClass)
{

            return Ok(m_studentService.SearchStudent(keyword, hutechClass));
        }
        [HttpGet("{id}")]
        public IActionResult LoadStudentById(int id)
        {
            m_studentService.LoadStudentById(id);
            return Ok(new Student());
        }

        [HttpPost]
        public IActionResult UploadOfCreateStudent(Student student)
        {
            m_studentService.UpdateOrCreateStudent(student);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            m_studentService.DeleteStudentById(id);
            return Ok();
        }
    }
}