create table Cohort (
	Id integer not null primary key autoincrement,
	CohortName text not null

);

create table Student (
	Id integer not null primary key autoincrement,
	FirstName text not null,
	LastName text not null,
	CohortId int not null,
	foreign key(CohortId) REFERENCES Cohort(Id)
);

create table Exercise (
	Id integer not null primary key autoincrement,
	ExerciseName text not null,
	ExerciseLanguage text not null	
);

create table Instructor (
	Id integer not null primary key autoincrement,
	FirstName text not null,
	LastName text not null,
	CohortId int not null,
	foreign key(CohortId) REFERENCES Cohort(Id)
);

create table StudentCohort (
	Id integer not null primary key autoincrement,
	StudentId int not null,
	CohortId int not null,
	foreign key (CohortId) REFERENCES Cohort(Id),
	foreign key (StudentId) REFERENCES Student(Id)
);

create table StudentExercises (
	Id integer not null primary key autoincrement,
	StudentId int not null,
	ExerciseId int not null,
	foreign key (StudentId) REFERENCES Student(Id),
	foreign key (ExerciseId) REFERENCES Exercise(Id)
);


insert into Cohort (CohortName) values ("Cohort One");
insert into Cohort (CohortName) values ("Cohort Two");
insert into Cohort (CohortName) values ("Cohort Three");

insert into Exercise (ExerciseName, ExerciseLanguage) values ("Make JavaScript Objects", "JavaScript");
insert into Exercise (ExerciseName, ExerciseLanguage) values ("Style the Page with CSS", "CSS");
insert into Exercise (ExerciseName, ExerciseLanguage) values ("Learn React States", "JavaScript");
insert into Exercise (ExerciseName, ExerciseLanguage) values ("Grunt It Up!", "JavaScript");

insert into Student (FirstName, LastName, CohortId) values ("Alejandro", "Font", 2);
insert into Student (FirstName, LastName, CohortId) values ("David", "Taylor", 1);
insert into Student (FirstName, LastName, CohortId) values ("Helen", "Chalmers", 1);
insert into Student (FirstName, LastName, CohortId) values ("Jonathan", "Edwards", 3);

insert into Instructor (FirstName, LastName, CohortId) values ("Andy", "Collins", 3);
insert into Instructor (FirstName, LastName, CohortId) values ("Meg", "Ducharme", 3);
insert into Instructor (FirstName, LastName, CohortId) values ("Kimmy", "Bird", 1);
