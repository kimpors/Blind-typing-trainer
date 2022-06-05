using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Blind_typing_trainer
{
    [Serializable]
    internal class User : ISerializable
    {
        public Theme currTheme { get; set; }
        public List<CustomTheme> allThemes { get; set; }
        public List<float> allRuns { get; set; }
        public ILanguage currLanguage { get; set; }
        public TimeSpan trainingTime { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CurrentTheme", currTheme);
            info.AddValue("CurrentLanguage", currLanguage);
            info.AddValue("AllTimeOfTraining", trainingTime);
            info.AddValue("AllRuns", allRuns);
            info.AddValue("AllThemes", allThemes);
        }
        public User(Theme currTheme, ILanguage currLanguage, TimeSpan trainingTime, List<float> allRuns, List<CustomTheme> allThemes)
        {
            this.currTheme = currTheme;
            this.currLanguage = currLanguage;
            this.trainingTime = trainingTime;
            this.allRuns = allRuns;
            this.allThemes = allThemes;
        }
        public User(SerializationInfo info, StreamingContext context)
        {
            currTheme = (Theme)info.GetValue("CurrentTheme", typeof(Theme));
            currLanguage = (ILanguage)info.GetValue("CurrentLanguage", typeof(ILanguage));
            trainingTime = (TimeSpan)info.GetValue("AllTimeOfTraining", typeof(TimeSpan));
            allRuns = (List<float>)info.GetValue("AllRuns", typeof(List<float>));
            allThemes = (List<CustomTheme>)info.GetValue("AllThemes", typeof(List<CustomTheme>));
        }
    }
}
