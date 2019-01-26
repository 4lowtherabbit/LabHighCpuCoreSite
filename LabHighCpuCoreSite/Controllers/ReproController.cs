using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LabHighCpuCoreSite.Controllers
{
    public class ReproController : Controller
    {
        static volatile bool enabled = true;

        public string Enable()
        {
            enabled = true;
            return "Done";
        }

        public string Disable()
        {
            enabled = false;
            return "Done";
        }

        public string Index()
        {
            int i = DoJob();
            return i.ToString();
        }

        private int DoJob()
        {
            int i = 0;
            while (enabled)
            {
                for (int j = 0; j < 1000; j++) ;

                Thread.Yield();
                i++;
            }
            return i;
        }
    }
}