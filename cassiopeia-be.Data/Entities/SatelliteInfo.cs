namespace cassiopeia_be.Data.Entities
{
    public class SatelliteInfo : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime LaunchDate { get; set; }
        public bool StatusIsEnabled { get; set; }
        public string Owner { get; set; }
        public string OriginCountry { get; set; }
        public bool ReceivedByIsEnabled { get; set; }
        public bool SignalCountIsEnabled { get; set; }
        public bool APRSIsEnabled { get; set; }
        public bool BatteryVoltageIsEnabled { get; set; }
        public bool BatteryCapacityIsEnabled { get; set; }
        public bool BatteryTemperatureIsEnabled { get; set; }
        public bool SolarTemperatureIsEnabled { get; set; }
        public bool UHFTemperatureIsEnabled { get; set; }
        public bool VHFTemperatureIsEnabled { get; set; }
        public bool OBC9DOTemperatureIsEnabled { get; set; }
        public bool OBCNumberIsEnabled { get; set; }
        public bool OBCPacketRecordIsEnabled { get; set; }
        public bool OBCTimestampIsEnabled { get; set; }
        public bool OBCMCUTemperatureIsEnabled { get; set; }
        public bool OBCUptimeTotalIsEnabled { get; set; }
        public bool OBCRestartIsEnabled { get; set; }
        public bool OBCFreeMemoryIsEnabled { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
    }
}

