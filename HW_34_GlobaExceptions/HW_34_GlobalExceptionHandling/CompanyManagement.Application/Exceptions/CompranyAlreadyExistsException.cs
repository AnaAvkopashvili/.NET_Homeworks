using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Exceptions
{
    public class CompranyAlreadyExistsException : Exception
    {
        public string Code = "CompanyAlreadyExists";

        public CompranyAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
