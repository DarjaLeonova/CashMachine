namespace CashMachine
{
    public interface ICashMachine
    {
        int WithDraw(int amount);
        void Insert(int[] cash);
    }
}