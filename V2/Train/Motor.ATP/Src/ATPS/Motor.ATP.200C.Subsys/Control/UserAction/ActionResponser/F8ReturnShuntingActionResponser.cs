using Motor.ATP.Infrasturcture.Interface;
using Motor.ATP.Infrasturcture.Interface.UserAction;

namespace Motor.ATP._200C.Subsys.Control.UserAction.ActionResponser
{
    public class F8ReturnShuntingActionResponser : F8ReturnActionResponser
    {
        public F8ReturnShuntingActionResponser(IDriverSelectableItem item)
            : base(item)
        {
        }

        public override void ResponseMouseUp()
        {
            base.ResponseMouseUp();
            ATP.SendInterface.SelectControlMode(new SendModel<ControlType>(ControlType.Shunting, SendModelType.Cancel));
        }
    }
}