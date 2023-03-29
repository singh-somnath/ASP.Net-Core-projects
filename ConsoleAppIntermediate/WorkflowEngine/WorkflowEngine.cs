using System.Collections.Generic;
using static ConsoleAppIntermediate.Program;

namespace ConsoleAppIntermediate
{
    public class WorkflowEngine
    {
        private readonly IList<IActivity> _activity;
        public WorkflowEngine()
        {
            _activity = new List<IActivity>();
        }

        public void Run()
        {
            foreach (var activity in _activity)
            {
                activity.Execute();
            }
        }

        public void AddActivity(IActivity activity)
        {
            _activity.Add(activity);
        }
    }

}