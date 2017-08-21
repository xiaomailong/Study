using Motor.ATP.Infrasturcture.Control.UserAction.ActionResponser;
using Motor.ATP.Infrasturcture.Interface.UserAction;

namespace Motor.ATP._200H.Subsys.Control.UserAction.ActionResponser
{
    public class F2ReduceVolumeActionResponser : F2OrdinaryActionResponser
    {
        public F2ReduceVolumeActionResponser(IDriverSelectableItem item)
            : base(item)
        {
        }
        public override void ResponseMouseDown()
        {
            this.ATP.Other.Volumne--;
        }
    }
}