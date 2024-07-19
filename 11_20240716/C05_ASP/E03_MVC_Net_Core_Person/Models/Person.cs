using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Person
{
    // TODO: usar anotações para controlar os campos da tabela
    // TODO: FirstName: obrigatório, tem de ter mensagem de erro, nvarchar, tamanho 30
    // TODO: LastName: não obrigatório, nvarchar, 30
    // TODO: Age: compreendida entre 0 e 150
    // TODO: para todos os fields: criar um nome de apresentação
    #region Properties

    [Key]
    [Display(Name = "Person ID")]
    public int PersonId { get; set; }

    [Required(ErrorMessage = "First name is mandatory.")]
    [StringLength(30, ErrorMessage = "First name max 30 characters")]
    [Column(TypeName = "nvarchar")]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [StringLength(30, ErrorMessage = "Last name max 30 characters")]
    [Column(TypeName = "nvarchar")]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [Range(0, 150, ErrorMessage = "Age between 0 and 150")]
    public int Age { get; set; }
    #endregion
    #region Constructor
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    #endregion
}