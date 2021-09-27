using System;
using System.Collections.Generic;
using System.Text;

namespace CodePrinciples.SOLID.DependencyInversionPrinciple
{
    public class EmployeeBusinessLogicNonInversion
    {
        EmployeeDataAccessNonInversion _EmployeeDataAccess;

        public EmployeeBusinessLogicNonInversion()
        {
            _EmployeeDataAccess = DataAccessFactoryNonInversion.GetEmployeeDataAccessObj();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return _EmployeeDataAccess.GetEmployeeDetails(id);
        }
    }
}