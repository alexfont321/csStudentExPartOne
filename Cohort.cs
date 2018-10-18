using System.Collections.Generic;

namespace studentExercises 
{

    public class Cohort 
    {

        public string CohortName { get; set; }

        public List<Student> Students = new List<Student>();

        List<Instructor> Instructors = new List<Instructor>();

        public void AddStudent(Student student) {
            Students.Add(student);
        }

        public void AddInstructor(Instructor instructor) {
            Instructors.Add(instructor);
        }

    }



}