Console.WriteLine("Would you you like to input your own population or use the 2021 Bedfordshire Population?");
Console.WriteLine("1) Existing");
Console.WriteLine("2) Custom");
string choice = Console.ReadLine();
if (choice == "1") 
{
    Console.WriteLine("How many days would you like to run?");
    Location Bedfordshire = new Location(669338, 1, 50);
    Bedfordshire.RunSimulation();
}
else
{
    Console.WriteLine("Enter the population.");
    int population = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("How many days would you like to run?");
    Location Bedfordshire = new Location(population, 1, 50);
    Bedfordshire.RunSimulation();
}

class Location
{
    private int day;
    private int humanPopulation;
    private int zombiePopulation;
    private int infectionRate;
    private int duration;

    public Location(int pHumanPopulation, int pZombiePopulation, int pduration)
    {
        day = 1;
        duration = pduration;
        humanPopulation = pHumanPopulation;
        zombiePopulation = pZombiePopulation;
        infectionRate = 50;
    }

    public void PrintData()
    {
        Console.WriteLine("Day: {0}", day);
        Console.WriteLine("Human Population: {0}", humanPopulation);
        Console.WriteLine("Zombie Population: {0}", zombiePopulation);
    }

    public void RunSimulation()
    {
        for (int i = 1; i <= duration; i++)
        {
            PrintData();
            SimulateZombieEncounters();
            day += 1;
        }
    }

    private void SimulateZombieEncounters()
    {
        Random r = new Random();
        int newlyInfected = 0;
        for (int i = 1; i <= humanPopulation; i++)
        {
            if (r.Next(0, 2) == 1)
            {
                if (r.Next(0, infectionRate) > 25)
                {
                    newlyInfected += 1;
                }
            }
        }
        UpdatePopulations(newlyInfected);
    }

    private void UpdatePopulations(int infected)
    {
        humanPopulation -= infected;
        zombiePopulation += infected;
    }
}
