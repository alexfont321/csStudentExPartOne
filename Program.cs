using System;
using System.Collections.Generic;

namespace studentExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            Exercise MakeJavaScriptObjects = new Exercise();
                MakeJavaScriptObjects.Name = "Make JavaScript Objects";
                MakeJavaScriptObjects.ExerciseLanguage = "JavaScript";

            Exercise StyleThePage = new Exercise();
                StyleThePage.Name = "Style the Page with CSS";
                StyleThePage.ExerciseLanguage = "CSS";

            Exercise ReactToState = new Exercise();
                ReactToState.Name = "Learn React States";
                StyleThePage.ExerciseLanguage = "React";

            Exercise GruntItUp = new Exercise();
                GruntItUp.Name = "Grunt It Up!";
                GruntItUp.ExerciseLanguage = "Grunt/Git";

            Cohort CohortOne = new Cohort();
                CohortOne.Name = "Cohort One";

            Cohort CohortTwo = new Cohort();
                CohortTwo.Name = "Cohort Two";

            Cohort CohortThree = new Cohort();
                CohortThree.Name = "Cohort Three";

            Student Alejandro = new Student() {
                FirstName = "Alejandro",
                LastName = "Font",
                Cohort = 2
            };

            Student David = new Student() {
                FirstName = "David",
                LastName = "Taylor",
                Cohort = 1
            };

            Student Helen = new Student() {
                FirstName = "Helen",
                LastName = "Chalmers",
                Cohort = 1
            };

            Student Jonathan = new Student() {
                FirstName = "Jonathan",
                LastName = "Edwards",
                Cohort = 3
            };

            CohortOne.AddStudent(David);
            CohortOne.AddStudent(Helen);
            CohortTwo.AddStudent(Alejandro);
            CohortThree.AddStudent(Jonathan);

            Instructor Andy = new Instructor() {
                FirstName = "Andy",
                LastName = "Collins",
                Cohort = 3
            };
            Instructor Meg = new Instructor() {
                FirstName = "Meg",
                LastName = "Ducharme",
                Cohort = 3
            };
            Instructor Kimmy = new Instructor() {
                FirstName = "Kimmy",
                LastName = "Bird",
                Cohort = 1
            };

            CohortThree.AddInstructor(Andy);
            CohortThree.AddInstructor(Meg);
            CohortOne.AddInstructor(Kimmy);

            Andy.AssignStudentExercise(ReactToState, Jonathan);
            Andy.AssignStudentExercise(MakeJavaScriptObjects, Jonathan);

            Meg.AssignStudentExercise(StyleThePage, Alejandro);
            Meg.AssignStudentExercise(ReactToState, Alejandro);

            Kimmy.AssignStudentExercise(GruntItUp, David);
            Kimmy.AssignStudentExercise(MakeJavaScriptObjects, David);

            List<Student> students = new List<Student>();
                students.Add(Alejandro);
                students.Add(David);
                students.Add(Helen);
                students.Add(Jonathan);



            List<Exercise> exercises = new List<Exercise>();
                exercises.Add(MakeJavaScriptObjects);
                exercises.Add(ReactToState);
                exercises.Add(StyleThePage);
                exercises.Add(GruntItUp);

            // foreach (Student student in students) {
            //     foreach (Exercise exercise in exercises){
            //         if(student.StudentExercises == )
            //     }
            //     Console.WriteLine($"{student.StudentExercises}")
            // }



        }
    }
}
