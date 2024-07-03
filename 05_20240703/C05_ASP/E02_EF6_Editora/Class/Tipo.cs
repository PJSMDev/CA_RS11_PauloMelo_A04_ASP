using System.ComponentModel.DataAnnotations;

namespace E02_EF6_Editora.Class
{

    internal class Tipo
    {

        #region Properties

        // Scalar Properties
        public int TipoID { get; set; }
        public int LivroID { get; set; }

        [StringLength(50, ErrorMessage = "Limite de 50 caracteres.")]
        public string TipoLivro { get; set; }

        // Navigation Properties
        public virtual Livro Livro { get; set; }

        #endregion
    }
}
