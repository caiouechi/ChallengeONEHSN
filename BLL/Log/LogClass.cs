using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Log
{
    /// <summary>
    /// I just created this class to show I would've logged all the errors on a separate file
    /// I know azure has error reports, but I like to control it on application level as well
    /// </summary>
    public static class LogClass
    {
        public static void InsertLog(string log)
        {
            //Log inserted, we could've used Nlog or Elmah
        }
    }
}
