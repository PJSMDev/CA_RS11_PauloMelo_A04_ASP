using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_EF6_Editora.Class
{

    internal class Livro
    {

        #region Properties

        // Scalar Properties
        public int LivroID { get; set; }
        public int EditoraID { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }

        // Navigation Properties
        public virtual Editora Editora { get; set; }

        #endregion
    }
}
