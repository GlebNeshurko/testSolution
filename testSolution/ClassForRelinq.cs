using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSolution
{
    public class ClassForRelinq : IEnumerable<StartingDataClass>
    {
        public List<StartingDataClass> TableRelinq = new List<StartingDataClass>();
        public IEnumerator<StartingDataClass> GetEnumerator()
        {
            return TableRelinq.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
