using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegistration.Business.Abstract;
using ClassRegistration.Entities;

namespace ClassRegistration.API
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpGet]
        public List<Lesson> Get()
        {
            return _lessonService.GetAllLessons();
        }
        [HttpGet("{id}")]
        public Lesson Get(int id)
        {
            return _lessonService.GetLessonById(id);
        }
        [HttpPost]
        public Lesson Post(Lesson lesson)
        {
            return _lessonService.CreateLesson(lesson);
        }
        [HttpPut]
        public Lesson Put([FromBody] Lesson lesson)
        {
            return _lessonService.UpdateLesson(lesson);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _lessonService.DeleteLesson(id);
        }

    }
}
