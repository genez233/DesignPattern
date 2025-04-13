using ChainOfResponsibilityPattern.Hanlder;
using ChainOfResponsibilityPattern.Request;

namespace ChainOfResponsibilityPattern.ConcreteHandler;

/// <summary>
/// 具体处理者：经理处理者
/// </summary>
public class ManagerLeaveHandler : LeaveHandler
{
    public override void HandleRequest(LeaveRequest request)
    {
        if (request.Days is >= 4 and <= 7)
        {
            Console.WriteLine($"{request.Name} 的请假申请被经理审批通过");
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