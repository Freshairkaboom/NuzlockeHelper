using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class ScreenInfo
    {
        private List<string> _screenInfo = new List<string>();

        public void AddInfo(string Info)
        {
            _screenInfo.Add(Info);
        }

        public void AddInfo(string prefix, string Info)
        {
            _screenInfo.Add(prefix + " " + Info);
        }

        public void AddInfo(List<string> Info)
        {
            foreach(string info in Info) _screenInfo.Add(info);
        }

        public void ResetInfo()
        {
            _screenInfo.Clear();
        }

        public void PrintInfo()
        {
            Console.Clear();

            foreach(string info in _screenInfo)
            {
                Console.WriteLine(info);
            }
        }
    }
}
