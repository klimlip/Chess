namespace oop3
{
    /// <summary>
    /// класс для паттерна Observer, Subject = GameField
    /// </summary>
    public interface IGameFieldNotificationPublisher
    {
        void Attach(params IGameFieldNotificationObserver[] observers);//метод добавления наблюдателей
        void Notify();//метод определения действия наблюдателей
    }
}
