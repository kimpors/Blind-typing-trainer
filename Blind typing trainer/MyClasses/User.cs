using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Blind_typing_trainer
{
    [Serializable]
    internal class User : ISerializable
    {
        public Theme currTheme { get; set; }
        public ILanguage currLanguage { get; set; }
        public TimeSpan trainingTime { get; set; }
        public List<float> allRuns = new List<float>();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CurrentTheme", currTheme);
            info.AddValue("CurrentLanguage", currLanguage);
            info.AddValue("AllTimeOfTraining", trainingTime);
            info.AddValue("AllRuns", allRuns);
        }

        public void AddRun(float result)
        {
            allRuns.Add(result);
        }

        public User(Theme theme, ILanguage language, TimeSpan allTimeOfTraining, List<float> allRuns)
        {
            currTheme = theme;
            currLanguage = language;
            this.trainingTime = allTimeOfTraining;
            this.allRuns = allRuns;
        }
        public User(SerializationInfo info, StreamingContext context)
        {
            currTheme = (Theme)info.GetValue("CurrentTheme", typeof(Theme));
            currLanguage = (ILanguage)info.GetValue("CurrentLanguage", typeof(ILanguage));
            trainingTime = (TimeSpan)info.GetValue("AllTimeOfTraining", typeof(TimeSpan));
            //allTimeOfTraining = info.GetInt32("AllTimeOfTraining");
            allRuns = (List<float>)info.GetValue("AllRuns", typeof(List<float>));
        }
    }
}
