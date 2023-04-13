namespace MVCBasics.Services
{
    public class DiceRoller : IDiceRoller
    {
        Random rand;

        public DiceRoller()
        {
            rand = new Random();
        }

        public int RollDice()
        {
            return rand.Next(1, 7);
        }
    }
}
