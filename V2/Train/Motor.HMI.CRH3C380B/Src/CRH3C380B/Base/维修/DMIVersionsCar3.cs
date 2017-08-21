using System.Drawing;
using MMI.Facility.Interface.Attribute;
using Motor.HMI.CRH3C380B.Resource.Images;

namespace Motor.HMI.CRH3C380B.Base.维修
{
    [GksDataType(DataType.isMMIObjectClass)]
    public class DMIVersionsCar3 : DMIVersionsCarBase
    {

        private readonly string[] m_BtnStr =
        {
            "1号车\n版本",
            "2号车\n版本",
            "",
            "4号车\n版本",
            "5号车\n版本",
            "6号车\n版本",
            "7号车\n版本",
            "8号车\n版本",
            "半车2",
            "主页面"
        };

        //2
        public override string GetInfo()
        {
            return "DMI车辆3的版本";
        }

        //6
        // ReSharper disable once ConvertToAutoProperty
        protected override string[] BtnContents
        {
            get { return m_BtnStr; }
        }

        protected override Image BackgoundImage
        {
            get { return MaintainImages.car3; }
        }

        protected override string TitleName
        {
            get { return "维护; 3号车版本"; }
        }

    }
}