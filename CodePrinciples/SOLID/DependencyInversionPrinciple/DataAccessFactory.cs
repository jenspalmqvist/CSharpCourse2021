using System;
using System.Collections.Generic;
using System.Text;

namespace CodePrinciples.SOLID.DependencyInversionPrinciple
{
    public class DataAccessFactory
    {
        public static IEmployeeDataAccess GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccess();
        }
    }
}