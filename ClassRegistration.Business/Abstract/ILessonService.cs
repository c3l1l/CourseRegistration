using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRegistration.Entities;

namespace ClassRegistration.Business.Abstract
{
   public interface ILessonService
    {
        List<Lesson> GetAllLessons();
        Lesson GetLessonById(int id);
        Lesson CreateLesson(Lesson lesson);
        Lesson UpdateLesson(Lesson lesson);
        void DeleteLesson(int id);
    }
}
