using Motor.ATP.Infrasturcture.Control.UserAction.ActionResponser;
using Motor.ATP.Infrasturcture.Interface.UserAction;

namespace Motor.ATP._300T.Subsys.Control.UserAction.ActionResponser
{
    public class F2ReduceLightActionResponser : F2OrdinaryActionResponser
    {
        public F2ReduceLightActionResponser(IDriverSelectableItem item)
            : base(item)
        {
        }
        public override void ResponseMouseDown()
        {
            this.ATP.Other.Light-=5;
        }
    }
}