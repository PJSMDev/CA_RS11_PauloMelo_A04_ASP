using D00_Utility;
using System;
using System.Linq;

namespace D01_EF6_DatabaseFirst
{

    internal class Program
    {

        static void Main(string[] args)
        {

            using (var db = new NorthwindEntities())
            {

                Utility.SetUnicodeConsole();

                #region New region
                // INSTANCIAÇÃO DE UMA NOVA Region da base de dados
                Region region = new Region();

                // ESTE ERA O VALOR DA RegionID NA VERSAO ANTES DE SER MODIFICADA PARA OS TPCS
                // PARA VER QUAL ERA O VALOR, CLICAS NO BOTÃO -> DO RATO EM dbo.Region e clicas em View Data
                //region.RegionID = 5;

                // ESTE FOI O TPC -> usar LINQ para ir buscar o maior RegionId para incrementar automaticamente e podermos dar o novo RegionId à Region que acabamos de instanciar
                // TODO MRS: usar linq para encontrar o maior RegionID e incrementar 1
                var currentMaxRegionID = db.Region.Max(r => r.RegionID);
                region.RegionID = currentMaxRegionID + 1;
                region.RegionDescription = "Norte";

                // ADICIONA A NOVA Region (apenas no teu código, não afeta ainda o servidor)
                db.Region.Add(region);

                // ISTO JÁ GUARDA AS ALTERAÇÕES DO LADO DO SERVIDOR MAS SE QUISERES IMPRIMIR UMA MENSAGEM DE CONFIRMAÇÃO TENS DE USAR UMA VARIÁVEL PARA A PODERES COLOCAR NA STRING INTERPOLATION
                //db.SaveChanges();

                // POR ISSO CRIAMOS A VARIÁVEL E GUARDADOS AS ALTERAÇÕES AQUI
                var count01 = db.SaveChanges();
                // permite guardar numa variável para poder enviar um aviso para o utilizador de gravação bem sucedida
                
                Utility.WriteMessage($"{count01} nova região gravada", "", "\n\n\n");

                // VARIÁVEL QUE GUARDA O RESULTADO DA QUERY
                // É UM LINQ DUMA SIMPLES QUERY COM SELECT E ORDERBY
                // ASSIM PODES USAR O VALOR DESSA QUERY NO foreach E IMPRIMIR OS SEUS DADOS
                var query01 = db.Region.Select(r => r).OrderBy(r => r.RegionID);

                // foreach QUE VAI PERCORRER TODA A TABELA ATUALIDADA DA REGION E IMPRIMIR OS SEUS DADOS
                foreach (var item in query01)
                {
                    Utility.WriteMessage($"{item.RegionID}, {item.RegionDescription}");
                }
                #endregion

                #region New territory
                // o território é o n (1 -> n) e é criado dentro de uma região
                // por isso aproveito a Region que criei acima
                Territories territories = new Territories();

                // FIZEMOS O MESMO PARA O TERRITORY
                territories.TerritoryID = "00001";
                territories.TerritoryDescription = "Espinho";

                //ESTE ERA O VALOR DO RegionId DO territories ANTES DE TER SIDO ALTERADO NO TPC
                //territories.RegionID = 5;

                // TODO MRS: este tem de ser igual ao de cima
                // COMO O RegionID da Region PASSOU A SER DINAMICO E O RegionID do Territory É IGUAL AO DA Region MAIS VALE MUDÁ-LO NESSE SENTIDO
                territories.RegionID = region.RegionID;
                // relação 1 -> n

                db.Territories.Add(territories);

                var count02 = db.SaveChanges();

                Utility.WriteMessage($"{count02} novo território gravado", "\n\n\n", "\n\n\n");

                var query02 = db.Territories.Select(t => t).OrderBy(t => t.TerritoryID);

                foreach (var item in query02)
                {
                    Utility.WriteMessage($"{item.TerritoryID}, {item.TerritoryDescription}, {item.RegionID}");
                }
                #endregion

                Console.ReadKey();
                // SE TENTARES CORRER O CODIGO MAIS DO QUE UMA VEZ VAIS CONTINUAR A DAR ERRO PORQUE O territories.TerritoryID = "00001"; NÃO É DINAMICO, TEM DE SER UNICO, E JA DEU ENTRADA NA BASE DA DADOS
            }
        }
    }
}
