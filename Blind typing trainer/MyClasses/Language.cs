using System;

namespace Blind_typing_trainer
{
    public interface ILanguage
    {
        string Standart { get; }
        string Start { get; }
        string Stop { get; }
        string Speed { get; }
        string Time { get; }
        string InfoHotKeys { get; }
        string ShortTextInfo { get; }
        string AllTimeOfTraining { get; }
        string AverageSpeed { get; }
        string Info { get; }
    }

    [Serializable]
    class English : ILanguage
    {
        public string Standart => "Text here";
        public string Start => "Start";
        public string Stop => "Stop";
        public string Speed => "Speed:";
        public string Time => "Time:";
        public string InfoHotKeys => "F5 - start\nQ - Open panel";
        public string ShortTextInfo => "Super short text (al least 1000 letters)";
        public string AllTimeOfTraining => "All time of training:";
        public string AverageSpeed => "Average speed:";
        public string Info => "Info";
    }
    [Serializable]
    class Ukranian : ILanguage
    {
        public string Standart => "Text here";
        public string Start => "Старт";
        public string Stop => "Стоп";
        public string Speed => "Швидкість:";
        public string Time => "Час:";
        public string InfoHotKeys => "F5 - Старт\nQ - Відкрити панель";
        public string ShortTextInfo => "Дуже короткий текст(хоча би 1000 літер)";
        public string AllTimeOfTraining => "Весь час тренувань:";
        public string AverageSpeed => "Середня швидкість:";
        public string Info => "Інформація";
    }
    [Serializable]
    class Russian : ILanguage
    {
        public string Standart => "Text here";
        public string Start => "Старт";
        public string Stop => "Стоп";
        public string Speed => "Скорость:";
        public string Time => "Время:";
        public string InfoHotKeys => "F5 - Старт\nQ - Открыть панель";
        public string ShortTextInfo => "Очень короткий текст(хотя бы 1000 букв)";
        public string AllTimeOfTraining => "Всё время тренировак:";
        public string AverageSpeed => "Средняя скорость:";
        public string Info => "Информация";
    }

    public interface ISwitchLanguage
    {
        ILanguage SwitchEng();
        ILanguage SwitchUkr();
        ILanguage SwitchRus();
    }

    class SwitchLanguage : ISwitchLanguage
    {
        public ILanguage SwitchEng()
        {
            return new English();
        }

        public ILanguage SwitchRus()
        {
            return new Russian();
        }

        public ILanguage SwitchUkr()
        {
            return new Ukranian();
        }
    }
}
