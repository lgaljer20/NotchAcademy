using System.ComponentModel.DataAnnotations.Schema;
using cassiopeia_be.Data.Entities;

public class Battery : BaseEntity
{
    [ForeignKey("SatelliteId")]
    public int SatelliteId { get; set; }
    public virtual SatelliteInfo SatelliteInfo { get; set; }

    public virtual ICollection<BatteryStatus> BatteryStatuses { get; set; }
    public virtual ICollection<TemperatureData> TemperatureDataRecords { get; set; }
    public virtual ICollection<BatteryCurrent> BatteryCurrents { get; set; }
}

public class BatteryStatus
{
    public double Voltage { get; set; }
    public double Current { get; set; }
    public int ChargeLevel { get; set; }

    public int BatteryId { get; set; }
    public virtual Battery Battery { get; set; }
}

public class TemperatureData
{
    public DateTime Timestamp { get; set; }
    public double BatteryTemperature { get; set; }
    public double SystemTemperature { get; set; }

    public int BatteryId { get; set; }
    public virtual Battery Battery { get; set; }
}

public class BatteryCurrent
{
    public DateTime Timestamp { get; set; }
    public double CurrentIn { get; set; }
    public double CurrentOut { get; set; }

    public int BatteryId { get; set; }
    public virtual Battery Battery { get; set; }
}
