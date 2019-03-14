using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.serviceManager
{
    public class ServiceManager
    {
        private static LinkedList<WorkInfo> works = new LinkedList<WorkInfo>();
        
        public static WorkInfo RegistService(WaitCallback action, object param)
        {
            WorkInfo work = new WorkInfo();
            work.Action = action;
            work.Param = param;
            work.Status = 0;
            work.Id = works.Count;
            works.AddLast(work);
            return work;
        }

        public static void ExecuteService(int id)
        {
            var work = works.Where(x => x.Id == id);
            if (work.Count() == 0)
            {
                return;
            }

            for (int i = 0; i < work.Count(); i++)
            {
                var w = work.ElementAt(i);
                if (w.Status != 0)
                {
                    continue;
                }
                bool status = ThreadPool.QueueUserWorkItem(w.Action, w.Param);
                if (status)
                {
                    w.Status = 1;
                }
            }
        }

    }

    public class WorkInfo
    {
        public int Id
        {
            get;
            set;
        }

        public WaitCallback Action
        {
            get;
            set;
        }

        public object Param
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
    }
}
