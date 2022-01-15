using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.API.Models
{
    public class EmployeeRepository
    {
        private string conStr;

        public EmployeeRepository()
        {
            conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dapper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conStr);
            }
        }

        internal IEnumerable<Employee> GetById()
        {
            throw new NotImplementedException();
        }

        // INSERT 
        public void Add(Employee employee)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO EMPLOYEEINFO (EmpName, Designation, Department) VALUES(@EmpName, @Designation, @Department)";
                dbConnection.Open();
                dbConnection.Execute(sql, employee);
            }
        }

        //GET ALL

        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM EMPLOYEEINFO";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sql);
            }
        }

        public Employee GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM EMPLOYEEINFO WHERE EmpId=@id";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sql, new { Id = id }).FirstOrDefault();
            }
        }
        // Update
        public void Update(Employee employee)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"UPDATE EMPLOYEEINFO SET EmpName=@EmpName, Designation=@Designation, Department=@Department WHERE EmpId=@EmpId";
                dbConnection.Open();
                dbConnection.Query(sql, employee);
            }
        }
        // DELETE
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"DELETE FROM EMPLOYEEINFO WHERE EmpId=@id";
                dbConnection.Open();
                dbConnection.Query(sql, new { Id = id });
            }
        }

    }
}
