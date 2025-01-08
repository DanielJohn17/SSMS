using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<ParentAnnouncement> ParentAnnouncements { get; set; }
        public DbSet<TeacherSection> TeacherSections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CourseSchedule>(x => x.HasKey(cs => new { cs.CourseId, cs.ScheduleId}));

            builder.Entity<CourseStudent>(x => x.HasKey(cs => new { cs.CourseId, cs.StudentId}));

            builder.Entity<ParentAnnouncement>(x => x.HasKey(pa => new { pa.ParentId, pa.AnnouncementId}));

            builder.Entity<TeacherSection>(x => x.HasKey(ts => new { ts.TeacherId, ts.SectionId}));

            builder.Entity<CourseSchedule>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSchedules)
                .HasForeignKey(cs => cs.CourseId);

            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);

            builder.Entity<ParentAnnouncement>()
                .HasOne(pa => pa.Parent)
                .WithMany(p => p.ParentAnnouncements)
                .HasForeignKey(pa => pa.ParentId);

            builder.Entity<TeacherSection>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSections)
                .HasForeignKey(ts => ts.TeacherId);

            //  Configure Adminstrator entity later
        }
    }
}