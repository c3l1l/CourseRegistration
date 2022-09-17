using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRegistration.API;
using ClassRegistration.Business.Abstract;
using ClassRegistration.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit;

namespace ClassRegistration.Test
{
    public class LessonsControllerTest
    {
        private readonly Mock<ILessonService> _mockService;
        private readonly LessonsController lessonsController;

        public LessonsControllerTest()
        {
            _mockService = new Mock<ILessonService>();
            lessonsController = new LessonsController(_mockService.Object);
        }


        [Fact]
        public void GetLessons_ActionExecute_ReturnLessons()
        {
            //arrange

            var lessonList = GetLessonData();
            _mockService.Setup(m => m.GetAllLessons()).Returns(lessonList);
            //act

            // IEnumerable<Lesson> result = lessonsController.Get();
            var result = lessonsController.Get();

            //assert
            //Assert.NotEmpty(result);
            //Assert.Equal(3,result.Count());
            //Assert.NotNull(result);
            //Assert.True(lessonList[0].Id == result.FirstOrDefault().Id);

            Assert.IsAssignableFrom<IEnumerable<Lesson>>(result);
            Assert.Equal<int>(5,result.ToList().Count());

        }

        [Theory]
        [InlineData(2)]
        public void GetLesson_IdValid_ReturnLesson(int lessonId)
        {
            var lesson = GetLessonData().First(h => h.id == lessonId);
            _mockService.Setup(m => m.GetLessonById(lessonId)).Returns(lesson);

            var result = lessonsController.Get(lessonId);

            Assert.Equal(lessonId, result.id);
            Assert.Equal(lesson.Name, result.Name);
        }
        [Theory]
        [InlineData(0)]
        public void GetLesson_IdInValid_ReturnNull(int lessonId)
        {
            Lesson lesson = null;
            _mockService.Setup(m => m.GetLessonById(lessonId)).Returns(lesson);

            var result = lessonsController.Get(lessonId);

            Assert.Null(result);

        }

        [Theory]
        [InlineData(3)]
        public void PutLesson_ActionExecute_ReturnLesson(int lessonId)
        {
            var lesson = GetLessonData().First(h => h.id == lessonId);
            _mockService.Setup(m => m.UpdateLesson(lesson)).Returns(lesson);
            var result = lessonsController.Put(lesson);
            _mockService.Verify(m => m.UpdateLesson(lesson), Times.Once());
            //Assert.IsAssignableFrom<Lesson>(result);
            Assert.IsType<Lesson>(result);
            Assert.Equal(lessonId, result.id);
        }

        [Fact]
        public void PostLesson_ActionExecute_ReturnLesson()
        {
            var lesson = GetLessonData().First();
            _mockService.Setup(m => m.CreateLesson(lesson)).Returns(lesson);
            var result = lessonsController.Post(lesson);
            _mockService.Verify(m => m.CreateLesson(lesson), Times.Once());
            Assert.IsAssignableFrom<Lesson>(result);
            Assert.Equal(lesson.Name, result.Name);
        }

        /*SEED DATA*/
        private List<Lesson> GetLessonData()
        {
            List<Lesson> lessonData = new List<Lesson>()
            {
                new Lesson {id = 1, Name = "Computer Networks", Credit =5 ,Department = "Computer Engineering"},
                new Lesson {id = 2, Name = "Database Management Systems", Credit =4 ,Department = "Computer Engineering"},
                new Lesson {id = 3, Name = "Object Oriented Programming", Credit =5 ,Department = "Computer Engineering"},
                new Lesson {id = 4, Name = "Digital Control Systems", Credit =3 ,Department = "Electronic Engineering"},
                new Lesson {id = 4, Name = "Image Processing", Credit =3 ,Department = "Mechatronics Engineering"}

            };
            return lessonData;
        }

    }
}
