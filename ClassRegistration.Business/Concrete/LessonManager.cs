using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRegistration.Business.Abstract;
using ClassRegistration.DataAccess.Abstract;
using ClassRegistration.Entities;

namespace ClassRegistration.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonRepository _lessonRepository;

        public LessonManager(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public Lesson CreateLesson(Lesson lesson)
        {
            return _lessonRepository.CreateLesson(lesson);
        }

        public void DeleteLesson(int id)
        {
            _lessonRepository.DeleteLesson(id);
        }

        public List<Lesson> GetAllLessons()
        {
            return _lessonRepository.GetAllLessons();
        }

        public Lesson GetLessonById(int id)
        {
            return _lessonRepository.GetLessonById(id);
        }

        public Lesson UpdateLesson(Lesson lesson)
        {
            return _lessonRepository.UpdateLesson(lesson);
        }
    }
}
