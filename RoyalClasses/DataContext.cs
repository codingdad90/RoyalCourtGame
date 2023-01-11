using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalClasses
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options)  : base(options) { }

        public DbSet<House> Houses=> Set<House>();
        public DbSet<Character > Characters => Set<Character>();
        public DbSet<Opinion> Opinions=> Set<Opinion>();
        public DbSet<Court> Courts => Set<Court>(); 
        public DbSet<Title> Titles => Set<Title>();
        public DbSet<DailyEvent> DailyEvents => Set<DailyEvent>();
        public DbSet<WeeklyEvent> WeeklyEvents=> Set<WeeklyEvent>();
        public DbSet<YearlyEvent> YearlyEvents => Set<YearlyEvent>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Palace> Palaces => Set<Palace>();
        public DbSet<Holdings> Holdings => Set<Holdings>();

    }
}
