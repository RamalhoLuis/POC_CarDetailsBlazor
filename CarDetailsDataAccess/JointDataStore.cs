using CarDetailsModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetailsDataAccess
{
    public class JointDataStore
    {
        public List<JointInfo> jointCarInfo;

        public JointDataStore(string? path = null)
        {
            jointCarInfo = GetJointInfo();
        }
        private static List<JointInfo> GetJointInfo(string? path = null)
        {
            var query = new List<JointInfo>();
            return query.ToList();
        }
    }
}



