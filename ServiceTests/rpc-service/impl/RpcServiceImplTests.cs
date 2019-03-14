using Common.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.rpc_service.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.rpc_service.impl.Tests
{
    [TestClass()]
    public class RpcServiceImplTests
    {
        [TestMethod()]
        public void InitServiceTest()
        {

            new Thread(() => {
                while (true)
                {
                    var pid = "0";
                    try
                    {
                        pid = HttpRequestUtil.GetHttpResponse("http://localhost:8081/pid", 3000);

                    }
                    catch (Exception e) { }

                    var p = Convert.ToInt64(pid);
                    if (p > 0)
                    {
                        CmdUtils.RunCmdStandard("taskkill /f /pid " + p);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            }).Start();

            IRpcService rpc = new RpcServiceImpl();
            rpc.ReCreateJMapQuery(); 
            rpc.InitService();

        }
    }
}