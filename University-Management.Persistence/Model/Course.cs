using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management.Core.Common;

namespace University_Management.Core
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set;}

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
