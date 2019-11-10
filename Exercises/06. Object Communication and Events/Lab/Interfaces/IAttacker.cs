public interface IAttacker
{
    int Rewards { get; }

    void Attack();

    void SetTarget(IObservableTarget target);
}