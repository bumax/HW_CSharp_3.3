namespace GB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Labyrinth lab = new Labyrinth();
            lab.StartFind();
            lab.ShowExits();
        }
    }
}