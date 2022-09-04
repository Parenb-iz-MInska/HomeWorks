namespace WebApplication1.Models
{
    public class CarPark
    {
        public List<Car> Cars { get; set; } = new();
        public CarPark()
        {

        }
        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
        public void RemoveCar(int targetCarId)
        {
            Cars.Remove(Cars.Find(car => targetCarId == car.Id));
        }
    }
}
