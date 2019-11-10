using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

public class StatusCommand : ICommand
{
    private const string ObserversFieldNotFound = "Observers field not found.";

    [Inject]
    private ISubject jobs;

    public void Execute()
    {
        FieldInfo observersField = this.jobs.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.FieldType == typeof(List<IObserver>));

        if (observersField == null)
        {
            throw new InvalidOperationException(ObserversFieldNotFound);
        }

        List<IObserver> observers = (List<IObserver>) observersField.GetValue(this.jobs);

        foreach (IObserver observer in observers)
        {
            IObservableJob observableJob = (IObservableJob) observer;

            observableJob.PrintInfo();
        }
    }
}