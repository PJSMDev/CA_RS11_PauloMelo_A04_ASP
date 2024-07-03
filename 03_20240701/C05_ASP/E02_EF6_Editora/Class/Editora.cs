using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Editora.Class
{

    internal class Editora
    {

        #region Properties

        // Scalar Properties
        public int EditoraID { get; set; }
        public string Nome { get; set; }

        // Navigation Properties
        public virtual ICollection<Livro> Livros { get; set; }

        #endregion
    }
}
