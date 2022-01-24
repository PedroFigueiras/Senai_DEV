using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_RENTAL.Controllers;
using T_RENTAL.Interfaces;
using System.Data.SqlClient;

namespace T_RENTAL.Repositories
{

    public class ClienteRepository : IClienteRepositoy
    {
        private string stringConexao = "Data LAPTOP-FU757ILI\\SQLEXPRESS; initial catalog=T_Rental; user Id=SA; pwd=R260169p";

        //private string stringConexao = "Data Source=; initial catalog=catalogo_tarde; integrated security=true";

        public void AtualizarIdUrl(int IdCliente, ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @nomeCliente WHERE IdCliente= @IdCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", ClienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int IdCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeCliente, sobrenomeCliente,cnpjCliente,IdCliente FROM CLIENTE WHERE IdCliente = @IdCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobrenomeCliente = reader["sobrenomeCliente"].ToString(),

                            cnpjCliente = reader["cnpjCliente"].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente,sobrenomeCliente,cnpjCliente) VALUES (@nomeCliente,@sobrenomeCliente,@cnpjCliente)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cnpjCliente", novoCliente.cnpjCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE IdCliente = @IdCliente";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }
        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdCliente,nomeCliente, sobrenomeCliente,cnpjCliente FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        ClienteDomain cliente = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[1].ToString(),

                            sobrenomeCliente = rdr[2].ToString(),

                            cnpjCliente = rdr[3].ToString(),
                        };

                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }
    }
}
