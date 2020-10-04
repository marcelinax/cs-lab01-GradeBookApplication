using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var n = Students.Count;
            int overAverageGrade = 0;
            if (n < 5)
                throw new InvalidOperationException();
            foreach(Student s in this.Students)
            {
                foreach(double grade in s.Grades)
                {
                    if (averageGrade < grade)
                    {
                        overAverageGrade += 1;
                    }
                }
            }
            int higherPercent = overAverageGrade * 100 / n;

            if (higherPercent < 20)
            {
                return 'A';
            }
            if (higherPercent < 40)
            {
                return 'B';
            }
            if (higherPercent < 60)
            {
                return 'C';
            }
            if (higherPercent < 80)
            {
                return 'D';
            }

            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
