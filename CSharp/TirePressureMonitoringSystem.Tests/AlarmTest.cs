using RacingCar.Domain.ConcreteCreator;
using RacingCar.Domain.Creator;
using RacingCar.Domain.Model;
using RacingCar.Domain.Models;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Activate_alarm_when_pressure_not_between_safe_interval()
        {
            SensorFactory sensorFactory = new TirePressureSensorFactory();
            Sensor tirePressureSensor = sensorFactory.CreateSensor();
            
            AlarmFactory alarmFactory = new TirePressureAlarmFactory(tirePressureSensor);
            Alarm alarm = alarmFactory.CreateAlarm();
            
            SafetyRange safetyRange = new SafetyRange(17, 21);
            
            alarm.Check(safetyRange, 22);
            Assert.True(alarm.AlarmOn);
            alarm.Check(safetyRange, 16);
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Not_activate_alarm_when_pressure_is_between_safe_interval()
        {
            SensorFactory sensorFactory = new TirePressureSensorFactory();
            Sensor tirePressureSensor = sensorFactory.CreateSensor();

            AlarmFactory alarmFactory = new TirePressureAlarmFactory(tirePressureSensor);
            Alarm alarm = alarmFactory.CreateAlarm();
           
            SafetyRange safetyRange = new SafetyRange(17, 21);
           
            alarm.Check(safetyRange, 18);
            Assert.False(alarm.AlarmOn);
            alarm.Check(safetyRange, 20);
            Assert.False(alarm.AlarmOn);
        }
    }
}