namespace ChainOfResponsibilityPattern.Request;

/// <summary>
/// 请求类：请假请求
/// </summary>
public class LeaveRequest(string name, int days)
{
    /// <summary>
    /// 请假天数
    /// </summary>
    public int Days { get; set; } = days;

    /// <summary>
    /// 请假人
    /// </summary>
    public string Name { get; set; } = name;
}