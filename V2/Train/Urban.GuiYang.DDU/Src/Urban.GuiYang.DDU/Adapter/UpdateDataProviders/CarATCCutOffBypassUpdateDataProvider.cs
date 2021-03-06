﻿using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using MMI.Facility.Interface.Data;
using Urban.GuiYang.DDU.Config;
using Urban.GuiYang.DDU.Extension;
using Urban.GuiYang.DDU.Model.Constant;
using Urban.GuiYang.DDU.Model.Train.CarPart;
using Urban.GuiYang.DDU.ViewModel;

namespace Urban.GuiYang.DDU.Adapter.UpdateDataProviders
{
    [Export(typeof (IUpdateDataProvider))]
    public class CarATCCutOffBypassUpdateDataProvider : UpdateDataProviderBase
    {
        [ImportingConstructor]
        public CarATCCutOffBypassUpdateDataProvider(IEventAggregator eventAggregator, DomainViewModel viewModel)
            : base(eventAggregator, viewModel)
        {
        }

        public override void UpdateDatas(object sender, CommunicationDataChangedArgs args)
        {
            var d = ViewModel.TrainViewModel.Model.CarCollection.Select(s => s.MainPageByPass2.Value.ATCCutOffBypass).Where(w => !string.IsNullOrWhiteSpace(w.ItemConfig.UnkownIndex));
            ;

            foreach (var it in d)
            {
                it.State = GetATCCutOffBypass(args, it);
            }
        }

        private SwitchState GetATCCutOffBypass(CommunicationDataChangedArgs args, CarItem<SwitchState, CarATCCutOffBypassConfig> it)
        {
            if (DataService.ReadService.GetInBoolOf(it.ItemConfig.OnIndex))
            {
                return SwitchState.On;
            }

            if (DataService.ReadService.GetInBoolOf(it.ItemConfig.OffIndex))
            {
                return SwitchState.Off;
            }

            return SwitchState.Unkown;
        }
    }
}