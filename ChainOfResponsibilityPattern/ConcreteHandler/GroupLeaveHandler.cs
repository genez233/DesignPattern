using ChainOfResponsibilityPattern.Hanlder;
using ChainOfResponsibilityPattern.Request;

namespace ChainOfResponsibilityPattern.ConcreteHandler;

/// <summary>
/// 具体处理者：组长处理者
/// </summary>
public class GroupLeaveHandler : LeaveHandler
{
    public override void HandleRequest(LeaveRequest request)
    {
        if (request.Days is >= 1 and <= 3)
        {
            Console.WriteLine($"{request.Name} 的请假申请被组长审批通过");
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