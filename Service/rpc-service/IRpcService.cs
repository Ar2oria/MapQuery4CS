using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.rpc_service
{
    public interface IRpcService
    {
        void InitService();
        void InitService(object obj);
        void ReCreateJMapQuery();
        void StartJMapQuery();
        void StartJMapQuery(object obj);
        long JMapQueryIsRunning();
        bool JMapQueryHealthCheck();
        bool CloseJMapQuery();

        void JMapQuerySupervisor();
        void CloseSupervisor();
        void StartJService(string path);
        void StartJService(string path,object obj);
    }
}
