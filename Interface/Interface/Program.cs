namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var house = new House();
            
            var team = new Team(new List<IWorker>
            {
                new Worker("Worker1"),
                new Worker("Worker2"),
                new Worker("Worker3"),
                new TeamLeader("The foreman")
            });


            team.BuildHouse(house);
        }
    }
}
