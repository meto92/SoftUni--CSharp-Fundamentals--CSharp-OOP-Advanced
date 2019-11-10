using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == difficultyLevel &&
                typeof(IMission).IsAssignableFrom(t));

        if (missionType == null)
        {
            throw new ArgumentException(
                string.Format(OutputMessages.UnknownMissionDifficulty, difficultyLevel));
        }

        IMission mission = (IMission) Activator.CreateInstance(
            missionType, 
            new object[] { neededPoints });

        return mission;
    }
}