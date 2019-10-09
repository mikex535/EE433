using System;
using System.Collections.Generic;

public class Registration
{   // This class represents a registration time in a semester (CRN number)
    // It can hold CRN as an id, the course offered in this registration, and a collection of students registered.
    // it also specifies the capacity of students it can hold
    public string id { get; } = String.Empty;
    public Course course { get; } = new Course();
    public int capacity { get; } = 0;
    public List<Student> students = new List<Student>();


    public Registration()
    { // this is only for testing purposes. 

    }
    public Registration(string id, Course course, int capacity) 
    { // this is the constructor for this class. it creates an object with required info
        this.id = id;
        this.course = course;
        this.capacity = capacity;
    }
    public void add_student(Student student)
    { // add a student of registration is available
        if (is_available())
        {
            students.Add(student);
            student.add_registration(this); // add this registration to the student's list of registrations.
        }
        
    }
    public void remove_student(Student student)
    {   // remove the student from the list of students if exists
        students.Remove(student);
        student.remove_registration(this);
    }

    public Boolean is_available()
    {   // this method returns a boolean if a student can be added
        return (students.Count < capacity);
    }

    public int student_count()
    {
        return students.Count 
    }

}
public class Student
{   // this class includes a students id (b00 number), and full name
    // also stores a list of registrations that the student is registered to
    public string fname { get; } = String.Empty;
    public string lname { get; } = String.Empty;
    public string id { get; } = String.Empty;
    public List<Registration> registrations { get; } = new List<Registration>();
    private Student() // this is for testing
    {

    }
    public Student(string student_id,string student_fname,string student_lname)
    { //this constructor creates an object with required info
        this.id = student_id;
        this.fname = student_fname;
        this.lname = student_lname;
    }
    public string full_name
    { //this method returns first and last name combined
        get { return fname + " " + lname; }
    }

    public void add_registration(Registration reg)
    {   //this method adds a registration for the student
        registrations.Add(reg);
        reg.add_student(this); // this adds the student to the registered class's list
    }
    public void remove_registration(Registration reg)
    { // this method removes the registration from the student's list if exists
        registrations.Remove(reg);
        reg.remove_student(this); // removes the student for that registration's list
    }
    public int get_hours()
    {   // returns total hours registered
        int hours = 0;
        foreach(Registration reg in registrations)
        {
            hours = hours + reg.course.credit_hours;
        }
        return hours;
    }

}
public class Course
{ // this class identifies a course with ID (ex EE433), title and how many credit hours it's woth
    public string id { get; } = String.Empty;
    public string title { get; } = String.Empty;
    public int credit_hours { get; } = 0;
    public Course()
    {

    }
    public Course(string id, string title, int credit_hours)
    {
        this.id = id;
        this.title = title;
        this.credit_hours = credit_hours;
    }
    

}

