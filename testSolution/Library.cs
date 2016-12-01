using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSolution
{
    public class LibraryE : IEnumerable<ForEnumTable>
    {
        public List<ForEnumTable> Table = new List<ForEnumTable>();
        public IEnumerator<ForEnumTable> GetEnumerator()
        {
            return Table.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
