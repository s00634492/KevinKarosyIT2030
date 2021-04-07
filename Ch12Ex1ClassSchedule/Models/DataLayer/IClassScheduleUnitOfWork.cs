using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassSchedule.Models
{
    public interface IClassScheduleUnitOfWork
    {
        Repository<Class> classes { get; }
        Repository<Teacher> teachers { get; }
        Repository<Day> days { get; }
        void Save();
    }
}
