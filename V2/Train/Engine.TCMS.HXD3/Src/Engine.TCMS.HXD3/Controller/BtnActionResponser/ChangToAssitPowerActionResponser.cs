using System.ComponentModel.Composition;
using Engine.TCMS.HXD3.Resource.Keys;

namespace Engine.TCMS.HXD3.Controller.BtnActionResponser
{
    [Export]
    public class ChangToAssitPowerActionResponser : BtnActionResponserBase
    {
        /// <summary>
        /// ��Ӧ����
        /// </summary>
        public override void ResponseClick()
        {
            NavigateTo(StateKeys.Root_����״̬_������Դ);
        }
    }
}