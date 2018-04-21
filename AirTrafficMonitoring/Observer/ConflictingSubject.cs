using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class ConflictingSubject
    {
        private List<IConflictingObserver> conflictlist = new List<IConflictingObserver>();

        public void Attach(IConflictingObserver conflictingObserver)
        {
            conflictlist.Add(conflictingObserver);
        }

        public void Detach(IConflictingObserver conflictingObserver)
        {
            conflictlist.Remove(conflictingObserver);
        }

        public void Notify()
        {
            foreach (var conflict in conflictlist)
            {
                conflict.Update();
            }
        }

    }
}
