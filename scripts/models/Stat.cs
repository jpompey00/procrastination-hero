public class Stat
{
    public int value { get; set; }
    public int currentValue { get; set; }

    public void setValueAtStart(int value)
    {
        this.value = value;
        this.currentValue = value;
    }

}