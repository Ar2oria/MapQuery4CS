using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.serviceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Common.utils;
using Service.rpc_service;
using Service.rpc_service.impl;

namespace Common.serviceManager.Tests
{
    [TestClass()]
    public class ServiceManagerTests
    {
        [TestMethod()]
        public void RegistServiceTest()
        {
            IRpcService rpcService = new RpcServiceImpl();
            WaitCallback callback = rpcService.InitService;
            var ss = ServiceManager.RegistService(callback, null);
            ServiceManager.ExecuteService(ss.Id);
        }
    }
}