using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E02_EF6_Editora.Class
{

    internal class Livro
    {

        #region Properties

        // Scalar Properties
        public int LivroID { get; set; }
        public int EditoraID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(13)]
        public string ISBN { get; set; }

        /*
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres.")]
        public string Tipo { get; set; }
        */

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Titulo { get; set; }

        // Navigation Properties
        public virtual Editora Editora { get; set; }

        #endregion
    }
}
