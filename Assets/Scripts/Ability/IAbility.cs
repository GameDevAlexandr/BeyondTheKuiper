public interface IAbility 
{
    public SpaceManager maneger { get; set; }
    public void Remove();
    public void Use(int line, int value);
    public void Activate(SpaceCell cell, int count);
    public void Move(bool isUp);

    public void UseCard(CardItem card);
}
