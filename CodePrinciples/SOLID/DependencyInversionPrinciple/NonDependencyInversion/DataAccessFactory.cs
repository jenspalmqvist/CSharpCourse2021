using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePrinciples.SOLID.DependencyInversionPrinciple
{
    public class DataAccessFactoryNonInversion
    {
        public static EmployeeDataAccessNonInversion GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccessNonInversion();
        }
    }
}