/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      UI和数据库模型的辅助类。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EbbinghausMemoryApp
{
    using System.Data.Entity;
    public class HelperClass : IDisposable
    {
        public BookItem AddBook()
        {
            using (var db = new AppDbContext())
            {
                List<string> categories = db.Categories.Select(m => m.Name).ToList();
                FormBookInfo f = new FormBookInfo(categories);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string cName = f.BookName;
                    string categoryName = f.CatlogName;
                    Category c = null;
                    if (categories.Contains(categoryName))
                        c = db.Categories.Where(m => m.Name == categoryName).FirstOrDefault();
                    else
                    {
                        int categoryId = (int)db.Categories.Max(m => m.Id).GetValueOrDefault();
                        categoryId++;
                        c = new Category()
                        {
                            Id = categoryId,
                            Name = categoryName
                        };
                    }

                    int maxId = (int)db.BookItems.Max(m => m.Id).GetValueOrDefault();
                    BookItem b = new BookItem()
                    {
                        Id = maxId + 1,
                        Content = cName,
                        Category = c
                    };

                    db.BookItems.Add(b);
                    db.SaveChanges();
                    LoggingService.Info($"AddBook id={maxId + 1}");
                    return b;
                }
                return null;
            }


        }
        public bool HasBooks
        {
            get
            {
                using (var db = new AppDbContext())
                {
                    return db.BookItems.Count() > 0;
                }
            }
        }
        public bool DeleteBookItem(int bookId)
        {
            using (var db = new AppDbContext())
            {
                var bookitem = db.BookItems.Where(m => m.Id == bookId).FirstOrDefault();
                db.BookItems.Remove(bookitem);
                db.SaveChanges();
                LoggingService.Info($"DeleteBookItem id={bookId}");
                return true;
            }
            return false;
        }
        public bool HasLessons(int bookId)
        {
            using (var db = new AppDbContext())
            {
                return db.StudyItems.Where(m => m.BookId == bookId).Count() > 0;
            }
        }
        public StudyItem AddLesson(DateTime date)
        {
            using (var db = new AppDbContext())
            {
                List<string> books = db.BookItems.Select(m => m.Content).ToList();

                FormLessonInfo f = new FormLessonInfo(books);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string cName = f.LessonName;
                    string bookName = f.BookName;
                    BookItem bi = db.BookItems.Where(m => m.Content == bookName).FirstOrDefault();
                    int maxId = (int)db.StudyItems.Max(m => m.Id).GetValueOrDefault();
                    int cId = maxId + 1;
                    StudyItem c = new StudyItem()
                    {
                        Id = cId,
                        Content = cName,
                        BookItem = bi,
                        ReviewTimes = GenerateReviewTimes(date, cId)
                    };
                    db.StudyItems.Add(c);
                    db.SaveChanges();
                    LoggingService.Info($"AddLesson id={cId}");
                    return c;
                }
                return null;
            }
        }
        public bool DeleteLesson(int lessonId)
        {
            using (var db = new AppDbContext())
            {
                var studyItem = db.StudyItems.Include(o => o.ReviewTimes)
                                          .FirstOrDefault(o => o.Id == lessonId);
                if (studyItem != null)
                {
                    db.ReviewTimes.RemoveRange(studyItem.ReviewTimes);
                    db.StudyItems.Remove(studyItem);
                    db.SaveChanges();
                    
                    LoggingService.Info("Lesson deleted successfully.");
                }
                else
                {
                    LoggingService.Info($"lessonId {lessonId} not found.");
                }
                return true;
            }
            return false;
        }

        public bool DeleteLessonByBookId(int bookId)
        {
            using (var db = new AppDbContext())
            {
                var bookItem = db.BookItems
          .Include(b => b.StudyItems.Select(s => s.ReviewTimes))
          .SingleOrDefault(b => b.Id == bookId);

                if (bookItem != null)
                {
                    foreach (var studyItem in bookItem.StudyItems.ToList())
                    {
                        foreach (var reviewTime in studyItem.ReviewTimes.ToList())
                        {
                            db.ReviewTimes.Remove(reviewTime);
                        }
                        db.StudyItems.Remove(studyItem);
                    }
                    db.BookItems.Remove(bookItem);
                    db.SaveChanges();
                    LoggingService.Info($"DeleteLessonByBookId ={bookId}");
                    return true;
                }
            }
            return false;
        }
        public void AddLesson4Test(int bookId, string cName, DateTime dtFrom)
        {
            // int bookId = 1;
            using (var db = new AppDbContext())
            {
                int maxId = (int)db.StudyItems.Max(m => m.Id).GetValueOrDefault();

                int cId = maxId + 1;
                StudyItem c = new StudyItem()
                {
                    Id = cId,
                    Content = cName,
                    BookId = bookId,
                    ReviewTimes = GenerateReviewTimes(dtFrom, cId)
                };
                db.StudyItems.Add(c);
                db.SaveChanges();
            }
        }
        private ICollection<ReviewTime> GenerateReviewTimes(DateTime startTime, int studyId)
        {
            var intervals = new TimeSpan[]
 {
                //TimeSpan.FromMinutes(10),
                //TimeSpan.FromMinutes(30),
                //TimeSpan.FromHours(12),
                 TimeSpan.FromDays(0),
                TimeSpan.FromDays(1),
                TimeSpan.FromDays(2),
                TimeSpan.FromDays(7),
                TimeSpan.FromDays(15),
                TimeSpan.FromDays(30)
 };

            return intervals.Select(interval => new ReviewTime { ReviewDateTime = startTime.Add(interval).ToString("yyyy-MM-dd"), StudyItemId = studyId, Reviewed = false }).ToList();
        }

        public bool PopulateTreeView(ref Dictionary<int, Category> DicCategory,
           ref Dictionary<int, BookItem> DicBookItem,
          ref Dictionary<int, StudyItem> DicStudyItem)
        {
            using (var db = new AppDbContext())
            {
                DicCategory = db.Categories
              .Where(c => c.Id.HasValue)
              .ToDictionary(c => c.Id.Value, c => c);

                DicBookItem = db.BookItems
              .Where(c => c.Id.HasValue)
              .ToDictionary(c => c.Id.Value, c => c);

                DicStudyItem = db.StudyItems
          .Where(c => c.Id.HasValue)
          .ToDictionary(c => c.Id.Value, c => c);
                return true;
            }

            return false;
        }

        public Dictionary<DateTime, List<ToDoItem>> QueryMouthTask(DateTime dateQuery)
        {
            Dictionary<DateTime, List<ToDoItem>> list = new Dictionary<DateTime, List<ToDoItem>>();

            using (var db = new AppDbContext())
            {
                DateTime currentM = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
                DateTime nextM = currentM.AddMonths(1);

                var reviewTimes = db.Database.SqlQuery<ToDoItem>($@"Select a.Id,a.[ReviewDateTime],a.[Reviewed] as IsCompleted,b.[Content] as Description,a.Experience From  ReviewTimes a ,studyitems b 
                where reviewdatetime>='{currentM.ToString("yyyy-MM-dd")}' and   reviewdatetime< '{nextM.ToString("yyyy-MM-dd")}'
                and 
                a.studyitemid=b.id").ToList();

                foreach (var rt in reviewTimes)
                {
                    DateTime dt = rt.ReviewDateTime;
                    if (!list.ContainsKey(dt))
                        list.Add(dt, new List<ToDoItem>());

                    ToDoItem item = new ToDoItem((int)rt.Id,
                        rt.Description, rt.IsCompleted);
                    item.Experience = rt.Experience;
                    list[dt].Add(item);
                }
            }
            return list;
        }

        public bool QueryTaskCountByDate(DateTime date)
        {
            using (var db = new AppDbContext())
            {
                var todayStr = date.ToString("yyyy-MM-dd");
                return db.ReviewTimes.Where(m => m.ReviewDateTime.Substring(0, 10) == todayStr &&
                m.Reviewed == false).Count() == 0;
            }
        }

        public bool SaveReviewState(int reviewId, bool state, string desc)
        {
            using (var db = new AppDbContext())
            {
                var item = db.ReviewTimes.Where(m => m.Id == reviewId).FirstOrDefault();
                item.Reviewed = state;
                item.Experience = desc;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool SaveReviewStates(Dictionary<int, ToDoItem> dic)
        {
            using (var db = new AppDbContext())
            {
                var items = db.ReviewTimes.Where(m => dic.Keys.Contains((int)m.Id)).ToList();
                foreach (var item in items)
                {
                    ToDoItem todo = dic[(int)item.Id];
                    item.Reviewed = todo.IsCompleted;
                    item.Experience = todo.Experience;
                }
                db.SaveChanges();
                LoggingService.Info($"SaveReviewStates ={string.Join(",", dic.Keys)}");
                return true;
            }
            return false;
        }
        public static bool FinishTask(List<ViewTodayTask> list)
        {
            using (var db = new AppDbContext())
            {
                foreach (ViewTodayTask v in list)
                {
                    db.ReviewTimes.Where(m => m.Id == v.Id).FirstOrDefault().Reviewed = true;
                }

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public class ViewTodayTask
        {
            public int Id { get; set; }
            public string StudyContent { get; set; }
            public System.Drawing.Color BackColor { get; set; }
            public string BookContent { get; set; }
            public string ReviewDateTime { get; set; }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~HelperClass() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        void IDisposable.Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
