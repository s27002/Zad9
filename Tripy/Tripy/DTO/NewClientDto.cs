using System.ComponentModel.DataAnnotations;

namespace Tripy.DTO;

public class NewClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress] public string Email { get; set; }
    [Phone] public string Telephone { get; set; }
    public string Pesel { get; set; }
    
    public DateTime? PaymentDate { get; set; }  
}