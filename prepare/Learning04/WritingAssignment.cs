using System.Dynamic;
using System.Net.Http.Headers;

public class WritingAssignment : Assignment
{
    // vars
    string _title;

    // constructor
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    // methods
    public string GetWritingInfromation()
    {
        return $"{_title} by {GetStudentName()}";
    }


}