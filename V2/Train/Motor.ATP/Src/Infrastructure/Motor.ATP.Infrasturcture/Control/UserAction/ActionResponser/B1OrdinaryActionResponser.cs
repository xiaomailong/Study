using Motor.ATP.Infrasturcture.Interface.UserAction;
using Motor.ATP.Infrasturcture.Model.UserAction;

namespace Motor.ATP.Infrasturcture.Control.UserAction.ActionResponser
{
    public class B1OrdinaryActionResponser : DriverActionResponserBase
    {
        public B1OrdinaryActionResponser(IDriverSelectableItem item)
            : base(item, UserActionType.B1)
        {
        }
    }
}