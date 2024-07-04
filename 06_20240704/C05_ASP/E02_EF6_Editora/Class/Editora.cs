using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E02_EF6_Editora.Class
{

    internal class Editora
    {

        #region Properties

        // Scalar Properties
        public int EditoraId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string EditoraName { get; set; }


        // Navigation Properties
        public virtual ICollection<Livro> Livros { get; set; }

        #endregion
    }
}
