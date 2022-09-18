using System.ComponentModel;
using Bogus;
using Newtonsoft.Json;

namespace DatabaseOperations.Models.Dto
{
    public class DepartmentDto
    {
        [DefaultValue("Departamento de compras")]
        public string Name { get; set; }

        [DefaultValue("compras@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("5.6982")]
        public decimal Number { get; set; }


        public DepartmentDto()
        {
        }
    }
}
