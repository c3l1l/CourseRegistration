using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRegistration.DataAccess.Abstract;
using ClassRegistration.Entities;

namespace ClassRegistration.DataAccess.Concrete
{
    public class LessonRepository:ILessonRepository
    {
        private LessonDbContext _db;

        public LessonRepository(LessonDbContext db)
        {
            _db = db;
        }
        public List<Lesson> GetAllLessons()
        {
            return _db.Lessons.ToList();
        }

        public Lesson GetLessonById(int id)
        {
            return _db.Lessons.Find(id);
        }

        public Lesson CreateLesson(Lesson lesson)
        {
            _db.Lessons.Add(lesson);
            _db.SaveChanges();
            return lesson;
        }

        public Lesson UpdateLesson(Lesson lesson)
        {
            _db.Lessons.Update(lesson);
            _db.SaveChanges();
            return lesson;
        }

        public void DeleteLesson(int id)
        {
            var lesson = GetLessonById(id);
            _db.Lessons.Remove(lesson);
            _db.SaveChanges();
        }
    }
}
