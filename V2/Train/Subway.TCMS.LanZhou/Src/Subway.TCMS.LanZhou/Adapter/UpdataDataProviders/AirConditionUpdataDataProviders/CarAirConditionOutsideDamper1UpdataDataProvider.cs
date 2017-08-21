﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using MMI.Facility.Interface.Data;
using Subway.TCMS.LanZhou.Config;
using Subway.TCMS.LanZhou.Extension;
using Subway.TCMS.LanZhou.Model.Domain.Car.CarParts;
using Subway.TCMS.LanZhou.Model.Domain.Constant;
using Subway.TCMS.LanZhou.ViewModel;

namespace Subway.TCMS.LanZhou.Adapter.UpdataDataProviders.AirConditionUpdataDataProviders
{
    [Export(typeof(IUpdateDataProvider))]
    class CarAirConditionOutsideDamper1UpdataDataProvider : UpdateDataProviderBase
    {
        [ImportingConstructor]
        public CarAirConditionOutsideDamper1UpdataDataProvider(IEventAggregator eventAggregator, DomainViewModel viewModel)
            : base(eventAggregator, viewModel)
        {
        }

        public override void UpdateDatas(object sender, CommunicationDataChangedArgs args)
        {
            var d = ViewModel.TrainViewModel.Model.CarModels.Select(s => s.AirConditionControl.AirConditionStatusLazy.Value.AirConditionOutsideDamper1Status).Where(w => !string.IsNullOrWhiteSpace(w.ItemConfig.OutsideDamper1Unknow));
            
            foreach (var it in d)
            {
                it.State = GetGroundConnectState(args, it);
            }
        }

        private AirConditionOutsideDamper GetGroundConnectState(CommunicationDataChangedArgs args, CarItem<AirConditionOutsideDamper, CarAirConditionOutsideDamperStatusConfig> it)
        {
            if (DataService.ReadService.GetInBoolOf(it.ItemConfig.OutsideDamper1Closed))
            {
                return AirConditionOutsideDamper.FullyClosed;
            }
            if (DataService.ReadService.GetInBoolOf(it.ItemConfig.OutsideDamper1Half))
            {
                return AirConditionOutsideDamper.Half;
            }
            if (DataService.ReadService.GetInBoolOf(it.ItemConfig.OutsideDamper1SeventyFive))
            {
                return AirConditionOutsideDamper.SeventyFive;
            }
            if (DataService.ReadService.GetInBoolOf(it.ItemConfig.OutsideDamper1Totally))
            {
                return AirConditionOutsideDamper.Totally;
            }
            return AirConditionOutsideDamper.Unkonw;
        }
    }
}
