public interface IAbility 
{
    public GameHandler handler { get; set; }
    public void Remove();
    public void Use(int value);
    public void Activate(SpaceCell cell, int count);
}
