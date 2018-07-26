using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked-grading requires a minimum of 5 students to work.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked-grading requires a minimum of 5 students to work.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");

            var fifth = (int)Math.Ceiling(0.2 * Students.Count);
            int nHigher = 0;
            foreach (Student student in Students)
                if (student.AverageGrade > averageGrade) nHigher++;
            var numGrade = (int)Math.Floor((double)nHigher / fifth) + 1;
            if (numGrade < 5)
                return Convert.ToChar((byte)(numGrade + 64));
            else
                return 'F';
        }
    }
}
