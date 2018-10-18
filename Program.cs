using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Text;
using Dapper;

namespace studentExercises {

    public class NewStudentEntry {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentExercises { get; set; }

    }

    public class NewCohort {
        public string Name { get; set; }
        public int Students { get; set; }

    }
    class Program {
        static void Main (string[] args) {

            Exercise MakeJavaScriptObjects = new Exercise ();
            MakeJavaScriptObjects.ExerciseName = "Make JavaScript Objects";
            MakeJavaScriptObjects.ExerciseLanguage = "JavaScript";
            Exercise StyleThePage = new Exercise ();
            StyleThePage.ExerciseName = "Style the Page with CSS";
            StyleThePage.ExerciseLanguage = "CSS";

            Exercise ReactToState = new Exercise ();
            ReactToState.ExerciseName = "Learn React States";
            ReactToState.ExerciseLanguage = "JavaScript";

            Exercise GruntItUp = new Exercise ();
            GruntItUp.ExerciseName = "Grunt It Up!";
            GruntItUp.ExerciseLanguage = "JavaScript";

            Cohort CohortOne = new Cohort ();
            CohortOne.CohortName = "Cohort One";

            Cohort CohortTwo = new Cohort ();
            CohortTwo.CohortName = "Cohort Two";

            Cohort CohortThree = new Cohort ();
            CohortThree.CohortName = "Cohort Three";

            Student Alejandro = new Student () {
                FirstName = "Alejandro",
                LastName = "Font",
                Cohort = CohortTwo
            };

            Student David = new Student () {
                FirstName = "David",
                LastName = "Taylor",
                Cohort = CohortOne
            };

            Student Helen = new Student () {
                FirstName = "Helen",
                LastName = "Chalmers",
                Cohort = CohortOne
            };

            Student Jonathan = new Student () {
                FirstName = "Jonathan",
                LastName = "Edwards",
                Cohort = CohortThree
            };

            CohortOne.AddStudent (David);
            CohortOne.AddStudent (Helen);
            CohortTwo.AddStudent (Alejandro);
            CohortThree.AddStudent (Jonathan);

            Instructor Andy = new Instructor () {
                FirstName = "Andy",
                LastName = "Collins",
                Cohort = CohortThree
            };
            Instructor Meg = new Instructor () {
                FirstName = "Meg",
                LastName = "Ducharme",
                Cohort = CohortThree
            };
            Instructor Kimmy = new Instructor () {
                FirstName = "Kimmy",
                LastName = "Bird",
                Cohort = CohortOne
            };

            CohortThree.AddInstructor (Andy);
            CohortThree.AddInstructor (Meg);
            CohortOne.AddInstructor (Kimmy);

            // Andy.AssignStudentExercise (ReactToState, Jonathan);
            // Andy.AssignStudentExercise (MakeJavaScriptObjects, Jonathan);
            Andy.AssignStudentExercise (StyleThePage, Alejandro);
            Andy.AssignStudentExercise (GruntItUp, Alejandro);

            Meg.AssignStudentExercise (StyleThePage, Alejandro);
            Meg.AssignStudentExercise (ReactToState, Alejandro);
            Meg.AssignStudentExercise (GruntItUp, David);
            Meg.AssignStudentExercise (MakeJavaScriptObjects, David);

            Kimmy.AssignStudentExercise (GruntItUp, David);
            Kimmy.AssignStudentExercise (MakeJavaScriptObjects, David);
            // Kimmy.AssignStudentExercise(GruntItUp, Helen);
            // Kimmy.AssignStudentExercise(StyleThePage, Helen);

            List<Student> students = new List<Student> ();
            students.Add (Alejandro);
            students.Add (David);
            students.Add (Helen);
            students.Add (Jonathan);

            List<Exercise> exercises = new List<Exercise> ();
            exercises.Add (MakeJavaScriptObjects);
            exercises.Add (StyleThePage);
            exercises.Add (ReactToState);
            exercises.Add (GruntItUp);

            // foreach (Student student in students) {

            //     // List<Exercise> InsideLoopEx = new List<Exercise>();

            //     foreach (Exercise exercise in student.StudentExercises) {
            //         // InsideLoopEx.Add(exercise);
            //         Console.WriteLine($"{student.FirstName}: plus {exercise.Name}");
            //     }

            // };

            List<Cohort> cohorts = new List<Cohort> () {
                CohortOne,
                CohortTwo,
                CohortThree
            };

            List<Instructor> instructors = new List<Instructor> () {
                Andy,
                Kimmy,
                Meg
            };

            IEnumerable<Exercise> JavaScriptExercises = from ex in exercises
            where ex.ExerciseLanguage == "JavaScript"
            select ex
            ;

            // foreach (Exercise ex in JavaScriptExercises) {
            //     Console.WriteLine(ex.Name);
            //     Console.WriteLine(ex.ExerciseLanguage);
            // }

            IEnumerable<Student> studentsByCohort = from stu in students
            where stu.Cohort == CohortOne
            select stu
            ;

            // foreach (Student stu in studentsByCohort) {
            //     Console.WriteLine(stu.FirstName);
            // }

            IEnumerable<Instructor> instructorsByCohort = from inst in instructors
            where inst.Cohort == CohortThree
            select inst
            ;

            // foreach (Instructor inst in instructorsByCohort) {
            //     Console.WriteLine(inst.FirstName);
            // }

            IEnumerable<Student> studentsByLastName = from s in students
            orderby s.LastName descending
            select s
            ;

            // foreach (Student stu in studentsByLastName) {
            //     Console.WriteLine (stu.LastName);
            // }

            List<NewStudentEntry> studentsWithNoEx = students.Select (s =>
                new NewStudentEntry {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentExercises = s.StudentExercises.Count
                }
            ).Where(s => s.StudentExercises == 0).ToList ();

            // foreach (NewStudentEntry stu in studentsWithNoEx) {
            //     Console.WriteLine(stu.FirstName);
            // }

            List<NewStudentEntry> studentWithMostEx = students.Select(s => 
                new NewStudentEntry {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentExercises = s.StudentExercises.Count
                }).OrderByDescending(s => s.StudentExercises).ToList();

                // IEnumerable<NewStudentEntry> newListOfStudent = (from s in studentWithMostEx
                //     select s).First();

                Console.WriteLine($"{studentWithMostEx.First().FirstName}");
            
            // foreach (NewStudentEntry stu in studentWithMostEx) {
            //     Console.WriteLine(stu.FirstName);
            // }


            List<NewCohort> newCohortList = cohorts.Select(c => 
                new NewCohort {
                    Name = c.CohortName,
                    Students = c.Students.Count
                }).ToList();

                // foreach (NewCohort nc in newCohortList) {
                //     Console.WriteLine($"{nc.Name}: {nc.Students}");
                // }

//////////////////////////////////////////////////////
////////Student Exercise Part 4


            SqliteConnection db = DatabaseInterface.Connection;


            List<Exercise> exercisesFromDap = db.Query<Exercise>(@"SELECT * FROM Exercise").ToList();
            
        //////PART 3

            // foreach (Exercise ex in exercisesFromDap) {
            //     Console.WriteLine($"{ex.ExerciseName}");
            // }

        //////PART 4


            // foreach (Exercise ex in exercisesFromDap) {
            //     if (ex.ExerciseLanguage == "JavaScript") {
            //         Console.WriteLine(ex.ExerciseName);
            //     }
            // }

        // DatabaseInterface.AddExercise("Hanging with the Coders", "HTML");


        ////Part 5


        // db.Execute($@"insert into Exercise 
        //             (ExerciseName, ExerciseLanguage) 
        //             values
        //             ('Hanging with Coders', 'HTML')");

        /////Part 6

            List<Instructor> InstructorsFromDap = db.Query<Instructor>(@"SELECT * FROM Instructor").ToList();
            List<Cohort> CohortFromDap = db.Query<Cohort>(@"SELECT * FROM Cohort").ToList();

            foreach (Instructor i in InstructorsFromDap) {
                Console.WriteLine($"{i.FirstName} {i.LastName}: {CohortFromDap.Find(c => c.Id == i.CohortId).CohortName}");
            }

        /////Part 7

        // db.Execute($@" insert into Instructor
        //                 (FirstName, LastName, CohortId)
        //                 values
        //                 ('Steve', 'Brownlee', 2)");



        /////Part 8 

        // db.Execute($@" insert into StudentExercises
        //             (ExerciseId, StudentId)
        //             values
        //             (1, 4)");



        }
    }
}