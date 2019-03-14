using Common.serviceManager;
using Common.utils;
using Service.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.rpc_service.impl
{
    public class RpcServiceImpl : IRpcService
    {
        private volatile static int supervisorStatus;

        public void SetSupervisorStatus(int status)
        {
            supervisorStatus = status;
        }

        public bool CloseJMapQuery()
        {
            bool status = false;
            var ss = ServiceManager.RegistService(x =>
            {
                int queryCount = 0;
                while (queryCount <= 10)
                {
                    var pid = JMapQueryIsRunning();
                    if (pid > 0)
                    {
                        CloseSupervisor();
                        CmdUtils.RunCmdStandard("taskkill /f /pid " + pid);
                        status = true;
                        break;
                    }
                    else
                    {
                        Thread.Sleep(3000);
                        queryCount++;
                    }
                }
            }, null);
            ServiceManager.ExecuteService(ss.Id);
            
            return status;
        }

        public void CloseSupervisor()
        {
            supervisorStatus = 0;
        }

        public void InitService()
        {
            InitService(null);
        }

        public void InitService(object obj)
        {
            if (!File.Exists(Resources.JMapQuery))
            {
                if (!Directory.Exists(Resources.Lib))
                {
                    Directory.CreateDirectory(Resources.Lib);
                }
                using (FileStream fs = new FileStream(Resources.JMapQuery, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    var fileBuffer = Resources.map_query;
                    fs.Write(fileBuffer, 0, fileBuffer.Length);
                }
            }

            var filePath = Directory.GetFiles(Resources.Lib);
            foreach (var item in filePath)
            {
                if (Path.GetExtension(item).Equals(".jar"))
                {
                    StartJService(item);
                }
            }
        }

        public bool JMapQueryHealthCheck()
        {
            var status = "";
            try
            {
                var path = Resources.JMapQueryBaseUrl + Resources.JMapQueryHealthCheck;
                status = HttpRequestUtil.GetHttpResponse(path, 3000);

            }
            catch (Exception e) { }
            if (status == "OK")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public long JMapQueryIsRunning()
        {
            var pid = "0";
            try
            {
                var path = Resources.JMapQueryBaseUrl + Resources.JMapQueryPid;
                pid = HttpRequestUtil.GetHttpResponse(path, 3000);

            }
            catch (Exception e) { }
            long p = long.Parse(pid);
            return p;
        }

        public void JMapQuerySupervisor()
        {
            supervisorStatus = 1;
            var ss = ServiceManager.RegistService(x =>
            {
                int queryCount = -1;
                bool onStart = false;
                while (supervisorStatus == 1)
                {
                    var status = JMapQueryHealthCheck();
                    if (status)
                    {
                        queryCount = -1;
                        onStart = false;
                    }
                    else 
                    {
                        queryCount++;
                    }

                    if (queryCount > 5)
                    {
                        StartJMapQuery();
                        queryCount = -5;
                        onStart = true;
                    }

                    if (onStart)
                    {
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                    
                }
            }, null);
            ServiceManager.ExecuteService(ss.Id);
        }

        public void ReCreateJMapQuery()
        {
            if (!Directory.Exists(Resources.Lib))
            {
                Directory.CreateDirectory(Resources.Lib);
            }

            if (File.Exists(Resources.JMapQuery))
            {
                File.Delete(Resources.JMapQuery);
            }

            using (FileStream fs = new FileStream(Resources.JMapQuery, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                var fileBuffer = Resources.map_query;
                fs.Write(fileBuffer, 0, fileBuffer.Length);
            }
        }

        public void StartJMapQuery(object obj)
        {
            if (!File.Exists(Resources.JMapQuery))
            {
                throw new FileNotFoundException("无法重启服务");
            }
            StartJService(Resources.JMapQuery, obj);
        }

        public void StartJMapQuery()
        {
            StartJMapQuery(null);
        }

        public void StartJService(string path)
        {
            StartJService(path, null);
        }
        public void StartJService(string path, object obj)
        {
            string param = obj == null ? "" : obj.ToString();
            param = "java -jar " + param + " " + path;
            var ss = ServiceManager.RegistService(CmdUtils.RunCmd, param);
            ServiceManager.ExecuteService(ss.Id);
        }
    }
}
