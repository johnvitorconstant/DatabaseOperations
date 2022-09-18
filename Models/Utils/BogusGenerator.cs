using AutoMapper.Execution;
using Bogus.DataSets;
using Bogus;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseOperations.Models.Utils
{
    public static class BogusGenerator
    {

        public static User GenerateRandomUser(this User user, int departmentQuantity)
        {
            var faker = new Faker("pt_PT");
            user.Name = faker.Name.FullName();
            user.Email = faker.Internet.Email(user.Name).ToLower();
            user.Age = faker.Random.Int(18, 50);
            user.Height = faker.Random.Int(1500, 2100);
            var number = faker.Random.Decimal(0M, 100M);
           user.NumberDecimal = number;
           user.NumberDouble = Decimal.ToDouble(number);
           user.NumberFloat = (float)Decimal.ToDouble(number);
           user.DepartmentId = faker.Random.Int(1, departmentQuantity);
           return user;
        }

        public static Department GenerateRandomDepartment(this Department department)
        {
            var faker = new Faker("pt_PT");
            department.Name = faker.Commerce.Department();
            department.Email = faker.Internet.Email(department.Name).ToLower();
            var number = faker.Random.Decimal(0M, 100M);
            department.NumberDecimal = number;
            department.NumberDouble = Decimal.ToDouble(number);
            department.NumberFloat = (float)Decimal.ToDouble(number);
            department.NumberInt = Decimal.ToInt32(number);
            department.NumberLong = Decimal.ToInt64(number);
            return department;
        }

    }
}
