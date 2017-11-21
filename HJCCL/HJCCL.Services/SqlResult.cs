using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJCCL.Services
{
    public class SqlResult
    {
        public bool status;
        public string context;

        public SqlResult()
        {
            this.status = false;
            this.context = "";
        }

        public SqlResult(bool _status)
        {
            this.status = _status;
        }

        public SqlResult(bool _status, string _context)
        {
            this.status = _status;
            this.context = _context;
        }
    }
}
