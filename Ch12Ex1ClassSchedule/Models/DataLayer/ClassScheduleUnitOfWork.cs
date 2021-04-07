using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Models
{
    public class ClassScheduleUnitOfWork : IClassScheduleUnitOfWork
    {
        private ClassScheduleContext context { get; set; }
        public ClassScheduleUnitOfWork(ClassScheduleContext ctx) => context = ctx;

        private Repository<Class> classData;
        public Repository<Class> classes{
            get{
                if (classData == null)
                    classData = new Repository<Class>(context);
                return classData;
            }
        }

        private Repository<Teacher> teacherData;
        public Repository<Teacher> teachers{
            get{
                if (teacherData == null)
                    teacherData = new Repository<Teacher>(context);
                return teacherData;
            }
        }

        private Repository<Day> dayData;
        public Repository<Day> days{
            get{
                if (dayData == null)
                    dayData = new Repository<Day>(context);
                return dayData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
