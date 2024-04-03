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

        if (peopleExitingBus > 0)
        {
            Console.WriteLine($"{peopleExitingBus} человек вышли на {_stopNumber} остановке");
            _places -= peopleExitingBus;
        }

        int peopleBoardingBus = _random.Next(0, _maxCapacity - _places + 1);
        _places += peopleBoardingBus;

        if (_places > _maxCapacity)
        {
            Console.WriteLine($"На {_stopNumber} остановке {_places - _maxCapacity} человек не могут войти в автобус, так как он заполнен");
            _places = _maxCapacity;
        }

        if (_places < 0)
        {
            Console.WriteLine($"На {_stopNumber} остановке {_places} человек вышли из автобуса, хотя там не было ни одного пассажира"); _places = 0;
        }

        Console.WriteLine($"{peopleBoardingBus} человек зашли на остановке {_stopNumber} и мест стало {_places}");
        Console.WriteLine(new string('-', 50));
    }
}