using System.ComponentModel;
using Bogus;
using Newtonsoft.Json;

namespace DatabaseOperations.Models.Dto;

public class UserDto
{


    [DefaultValue("John")]
    public string Name { get; set; }

    [DefaultValue("johnvitorconstant@gmail.com")]
    public string Email { get; set; }


    [DefaultValue(29)]
    public int Age { get; set; }

    [DefaultValue(1740)]
    public long Height { get; set; }

    [DefaultValue(9.2)]
    public decimal Number { get; set; }

    [DefaultValue(1)]
    public int DepartmentId { get; set; }

   
    //1:n

    public UserDto(string name, string email, int age, long height, decimal number, int departmentId)
    {
        Name = name;
        Email = email;
        Age = age;
        Height = height;
        Number = number;
        DepartmentId = departmentId;

    }

    public UserDto()
    { }



}