﻿
using System.Windows;
using MMI.Facility.Interface.Service;

namespace Subway.ShiJiaZhuangLine1.Interface.Model
{
    public interface IMMI
    {
        IAirCondition AirCondition { get; }
        IAirPunp AirPunp { get; }
        IAssistModel AssistModel { get; }
        //IBrake BrakeModel { get; }
        IButton ButtonModel { get; }
        //IDoor DoorModel { get; }
        //IFrsmHighSpeed FrsmHighSpeedModel { get; }
        //IHighSpeedGBC HighSpeedGCBModel { get; }
        //IMain MainModel { get; }
        ISmoke SmokeModel { get; }
        //ITitle TitleModel { get; }
        ITraction TractionModel { get; }
        //IEmergencyTalkModel EmergencyTalk { get; }
        Visibility MMIBack { get; }
        IStationsMgr StationsMgr { get; set; }
        IMaintence Maintence { get; set; }
        IBoradercastMgr BoradercastMgr { get; set; }
        IEventMgr EventMgr { get; set; }
        IEnmergencyBorader EnmergencyBorader { get; }
        IStationSettingModel StationSettingModel { get; }
        IResetModel ResetModel { get; }
        //IBypassModel Bypass { get; }
        IEventPageModel EventPageModel { get; }
        ILightSettingViewModel LightSetting { get; set; }
        //ITractionLockModel TractionLockModel { get; }
        ICommunicationDataService Dataserver { get; set; }
        void Init();
    }
}