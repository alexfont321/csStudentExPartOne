namespace studentExercises 
{

    public class Instructor 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SlackHandle { get; set; }

        public int Cohort { get; set; }

        public void AssignStudentExercise(Exercise exercise, Student student) {
            student.AddExercise(exercise);
        }






    }


}