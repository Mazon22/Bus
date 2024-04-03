using System;

class BusInfo
{
    private int _places;
    private int _stopNumber;
    private int _maxCapacity = 40;
    private Random _random = new Random();

    public BusInfo()
    {
        _places = _random.Next(1, _maxCapacity);
        Console.WriteLine($"В автобусе {_places} мест\n");
    }

    public void Stop()
    {
        _stopNumber++;

        int peopleExitingBus = _random.Next(0, _places + 1);

        ManagePassengersExitingBus(peopleExitingBus);

        int peopleBoardingBus = _random.Next(0, _maxCapacity - _places + 1);
        _places += peopleBoardingBus;

        CheckAndAdjustCapacity(_places);

        UpdatePassengerCount(_places);

        Console.WriteLine($"{peopleBoardingBus} человек зашли на остановке {_stopNumber} и мест стало {_places}");
        Console.WriteLine(new string('-', 50));
    }

    private void ManagePassengersExitingBus(int passengers)
    {
        if (passengers > 0)
        {
            Console.WriteLine($"{passengers} человек вышли на {_stopNumber} остановке");
            _places -= passengers;
        }
    }

    private void CheckAndAdjustCapacity(int places)
    {
        if (places > _maxCapacity)
        {
            Console.WriteLine($"На {_stopNumber} остановке {places - _maxCapacity} человек не могут войти в автобус, так как он заполнен");
            _places = _maxCapacity;
        }
    }

    private void UpdatePassengerCount(int places)
    {
        if (places < 0)
        {
            Console.WriteLine($"На {_stopNumber} остановке {places} человек вышли из автобуса, хотя там не было ни одного пассажира"); _places = 0;
        }
    }
}