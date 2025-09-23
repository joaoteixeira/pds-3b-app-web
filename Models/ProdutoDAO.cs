using AppWeb.Configs;

namespace AppWeb.Models
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;

        public ProdutoDAO(Conexao conexao) 
        { 
            _conexao = conexao;
        }

        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            var comando = _conexao.CreateCommand("SELECT * FROM produto;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = DAOHelper.GetString(leitor, "nome_pro");
                produto.Descricao = DAOHelper.GetString(leitor, "descricao_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Valor = leitor.GetDecimal("preco_pro");

                lista.Add(produto);
            }

            return lista;
        }
    }
}
