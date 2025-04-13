using ChainOfResponsibilityPattern.Hanlder;
using ChainOfResponsibilityPattern.Request;

namespace ChainOfResponsibilityPattern.ConcreteHandler;

/// <summary>
/// 具体处理者：CEO请假处理者
/// </summary>
public class CEOLeaveHandler : LeaveHandler
{
    public override void HandleRequest(LeaveRequest request)
    {
        if (request.Days >= 8)
        {
            Console.WriteLine($"{request.Name} 的请假申请被CEO审批通过");
        } else if (NextHandler != null)
        {
            NextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine($"无人处理该请求");
        }
    }
}