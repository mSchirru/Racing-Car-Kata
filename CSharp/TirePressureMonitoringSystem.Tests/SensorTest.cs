using RacingCar.Domain.Creator;
using RacingCar.Domain.Models;
using RacingCar.Domain.ConcreteCreator;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    public class SensorTest
    {
        [Fact]
        public void Guarantee_sensor_is_not_returning_null()
        {
            SensorFactory sensorFactory = new TirePressureSensorFactory();
            Sensor sensor = sensorFactory.CreateSensor();

            Assert.NotNull(sensor.psiValue);
        }
    }
}
