using System.Collections.Generic;

namespace studentExercises 
{

    public class Student 
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SlackHandle { get; set; }

        public Cohort Cohort { get; set; }

        public List<Exercise> StudentExercises = new List<Exercise>();

        // public void AddExercise(Exercise exercise) {
        //     StudentExercises.Add(exercise);
        // }


    }

}