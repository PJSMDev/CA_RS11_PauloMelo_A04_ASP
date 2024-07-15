using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E02_EF6_Editora.Class
{

    internal class Tipo
    {

        #region Properties

        // Scalar Properties
        public int TipoId { get; set; }     // PK

        [Required]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres.")]
        public string Nome { get; set; }


        // Navigation Properties
        public virtual ICollection<Livro> Livros { get; set; }

        #endregion
    }
}
