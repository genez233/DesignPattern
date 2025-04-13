using ChainOfResponsibilityPattern.Request;

namespace ChainOfResponsibilityPattern.Hanlder;

/// <summary>
/// 抽象处理者：请假处理者
/// </summary>
public abstract class LeaveHandler
{
    protected LeaveHandler? NextHandler;

    public void SetNext(LeaveHandler handler)
    {
        NextHandler = handler;
    }
    
    public abstract void HandleRequest(LeaveRequest request);
}