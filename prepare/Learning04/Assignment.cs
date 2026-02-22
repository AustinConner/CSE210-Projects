using System.ComponentModel;
using System.Net.NetworkInformation;

public class Assignment
{
    //vars
    private string _studentName;
    private string _topic;

    //constructor
    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    //methods
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    public string GetStudentName()
    {
        return _studentName;
    }
    

}