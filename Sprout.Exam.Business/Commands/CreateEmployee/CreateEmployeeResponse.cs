using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.CreateEmployee
{
    public class CreateEmployeeResponse
    {
        public int ID { get; set; }

        public CreateEmployeeResponse(int id)
        {
            ID = id;
        }
    }
}
