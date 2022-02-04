namespace Tennis
{
    public class Player
    {
    
        internal int Points { get; private set; }
        internal string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public void IncrementPoints()
        {
            Points += 1;
        }

    }
}