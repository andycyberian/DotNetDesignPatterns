namespace NullObject.Entities;

public class NullLearner : ILearner
{
    public int Id => -1;

    public string UserName => "Just browsing";

    public int CoursesCompleted => 0;
}
