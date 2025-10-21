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

        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "INSERT INTO produto (nome_pro, descricao_pro, quantidade_pro, preco_pro) " +
                "VALUES (@nome, @descricao, @quantidade, @preco);");

                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@preco", produto.Valor);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }

        }

        public Produto? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM produto WHERE id_pro = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = DAOHelper.GetString(leitor, "nome_pro");
                produto.Descricao = DAOHelper.GetString(leitor, "descricao_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Valor = leitor.GetDecimal("preco_pro");

                return produto;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE produto SET nome_pro = @_nome, descricao_pro = @_descricao, " +
                "quantidade_pro = @_quantidade, preco_pro = @_preco WHERE id_pro = @_id;");

                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@_quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@_preco", produto.Valor);
                comando.Parameters.AddWithValue("@_id", produto.Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "DELETE FROM produto WHERE id_pro = @id;");

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
