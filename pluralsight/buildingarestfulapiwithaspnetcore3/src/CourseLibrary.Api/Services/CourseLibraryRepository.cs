using System;
using System.Collections.Generic;
using System.Linq;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.ResourcesParameters;

namespace CourseLibrary.Api.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository
    {
        private readonly ApplicationContext _context;

        public CourseLibraryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors(AuthorsResourceParameter authorsResourceParameter)
        {
            var result = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrEmpty(authorsResourceParameter.MainCategory))
            {
                result = result.Where(it => it.MainCategory == authorsResourceParameter.MainCategory);
            }

            if (!string.IsNullOrEmpty(authorsResourceParameter.SearchQuery))
            {
                result = result.Where(it =>
                    it.MainCategory.Contains(authorsResourceParameter.SearchQuery) ||
                    it.FirstName.Contains(authorsResourceParameter.SearchQuery) ||
                    it.LastName.Contains(authorsResourceParameter.SearchQuery)
                );
            }

            return result;
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> ids)
        {
            return _context.Authors.Where(it => ids.Contains(it.Id));
        }

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(it => it.Id == authorId);
        }

        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(it => it.Id == authorId);
        }

        public void AddAuthor(Author author)
        {
            author.Id = Guid.NewGuid();

            foreach (var it in author.Courses)
            {
                it.AuthorId = author.Id;
            }

            _context.Authors.Add(author);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public IEnumerable<Course> GetCourses(Guid authorId)
        {
            return _context.Courses.Where(it => it.AuthorId == authorId);
        }

        public Course GetCourse(Guid authorId, Guid courseId)
        {
            return _context.Courses.FirstOrDefault(it => it.AuthorId == authorId && it.Id == courseId);
        }

        public void AddCourse(Guid authorId, Course course)
        {
            course.AuthorId = authorId;

            _context.Courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {

        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
