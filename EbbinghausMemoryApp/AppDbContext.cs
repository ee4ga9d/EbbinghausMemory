/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      EF6 数据库类定义。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbbinghausMemoryApp
{
    using System.Data.Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserNo { get; set; }
        public virtual ICollection<StudyItem> StudyItems { get; set; }
    }

    public class Category
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookItem> BookItems { get; set; }
    }

    public class BookItem
    {
        [Key]
        public int? Id { get; set; }
        public string Content { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public virtual ICollection<StudyItem> StudyItems { get; set; }
    }

    public class StudyItem
    {
        [Key]
        public int? Id { get; set; }
        public string Content { get; set; }
        public string Experience { get; set; }
        
        public int? BookId { get; set; }
        [ForeignKey("BookId")]
        public BookItem BookItem { get; set; }

        public virtual ICollection<ReviewTime> ReviewTimes { get; set; }
    }

    public class ReviewTime
    {
        [Key]
        public int? Id { get; set; }
        public int StudyItemId { get; set; }
        [ForeignKey("StudyItemId")]
        public StudyItem StudyItem { get; set; }

        public string ReviewDateTime { get; set; }
        public bool Reviewed { get; set; }

        public string Experience { get; set; }
    }


    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookItem> BookItems { get; set; }
        public DbSet<StudyItem> StudyItems { get; set; }
        public DbSet<ReviewTime> ReviewTimes { get; set; }

        public AppDbContext() : base("name=SQLiteConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<ReviewTime>()
            //.Property(r => r.ReviewDateTime)
            //.HasColumnType("DATETIME");

            // 配置 Category 和 BookItem 的关系
            modelBuilder.Entity<BookItem>()
                .HasRequired(b => b.Category)
                .WithMany(c => c.BookItems)
                .HasForeignKey(b => b.CategoryId);

            // 配置 BookItem 和 StudyItem 的关系
            modelBuilder.Entity<StudyItem>()
                .HasRequired(s => s.BookItem)
                .WithMany(b => b.StudyItems)
                .HasForeignKey(s => s.BookId);

            // 配置 StudyItem 和 ReviewTimes 的关系
            modelBuilder.Entity<ReviewTime>()
                .HasRequired(r => r.StudyItem)
                .WithMany(s => s.ReviewTimes)
                .HasForeignKey(r => r.StudyItemId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
