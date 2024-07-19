using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using D00_Utility;

namespace AdventureWorksEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility.SetUnicodeConsole();

            using (var db = new AdventureWorksEntities())
            {
                Utility.WriteMessage("Categorias e Subcategorias Antes da Inserção:");

                foreach (var categoria in db.ProductCategory.OrderBy(pc => pc.ProductCategoryID))
                {
                    Utility.WriteMessage($"Categoria: {categoria.ProductCategoryID}, {categoria.Name}");
                    foreach (var subcategoria in db.ProductSubCategory.Where(sc => sc.ProductCategoryID == categoria.ProductCategoryID).OrderBy(sc => sc.ProductSubCategoryID))
                    {
                        Utility.WriteMessage($"\tSubcategoria: {subcategoria.ProductSubCategoryID}, {subcategoria.Name}");
                    }
                }

                #region Nova Categoria
                ProductCategory novaCategoria = new ProductCategory();

                var currentMaxCategoryID = db.ProductCategory.Max(pc => pc.ProductCategoryID);
                novaCategoria.ProductCategoryID = currentMaxCategoryID + 1;
                novaCategoria.Name = "Nova Categoria";
                novaCategoria.rowguid = Guid.NewGuid();
                novaCategoria.ModifiedDate = DateTime.Now;

                db.ProductCategory.Add(novaCategoria);
                var count01 = db.SaveChanges();

                Utility.WriteMessage($"\n{count01} nova categoria gravada\n\n");
                #endregion

                #region Nova Subcategoria
                ProductSubCategory novaSubcategoria = new ProductSubCategory();

                var currentMaxSubcategoryID = db.ProductSubCategory.Max(psc => psc.ProductSubCategoryID);
                novaSubcategoria.ProductSubCategoryID = currentMaxSubcategoryID++;
                novaSubcategoria.ProductCategoryID = novaCategoria.ProductCategoryID;
                novaSubcategoria.Name = "Nova Subcategoria";
                novaSubcategoria.rowguid = Guid.NewGuid();
                novaSubcategoria.ModifiedDate = DateTime.Now;

                db.ProductSubCategory.Add(novaSubcategoria);
                var count02 = db.SaveChanges();

                Utility.WriteMessage($"\n{count02} nova subcategoria gravada\n\n");
                #endregion

                Utility.WriteMessage("Categorias e Subcategorias Depois da Inserção:");

                foreach (var categoria in db.ProductCategory.OrderBy(pc => pc.ProductCategoryID))
                {
                    Utility.WriteMessage($"Categoria: {categoria.ProductCategoryID}, {categoria.Name}");
                    foreach (var subcategoria in db.ProductSubCategory.Where(sc => sc.ProductCategoryID == categoria.ProductCategoryID).OrderBy(sc => sc.ProductSubCategoryID))
                    {
                        Console.WriteLine($"\tSubcategoria: {subcategoria.ProductSubCategoryID}, {subcategoria.Name}");
                    }
                }

                Utility.TerminateConsole();
            }
        }
    }

    public partial class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<ProductSubCategory> ProductSubCategory { get; set; }
    }

    public partial class ProductSubCategory
    {
        public int ProductSubCategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }

    public partial class AdventureWorksEntities : DbContext
    {
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductSubCategory> ProductSubCategory { get; set; }
    }
}
