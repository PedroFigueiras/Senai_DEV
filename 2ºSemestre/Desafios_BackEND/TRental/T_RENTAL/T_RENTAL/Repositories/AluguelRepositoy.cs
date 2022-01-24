using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using T_RENTAL.Controllers;
using T_RENTAL.Interfaces;

namespace T_RENTAL.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data LAPTOP-FU757ILI\\SQLEXPRESS; initial catalog=T_Rental; user Id=SA; pwd=R260169p";

       

        public void AtualizarIdUrl(int IdAluguel, AluguelDomain AluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET Aluguel= @Aluguel , Devolucao= @Devolucao WHERE IdAluguel= @IdAluguel";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Aluguel", AluguelAtualizado.Aluguel);
                    cmd.Parameters.AddWithValue("@Devolucao", AluguelAtualizado.Devolucao);
                    cmd.Parameters.AddWithValue("@Aluguel", IdAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int IdAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"SELECT IdAluguel,Aluguel,Devolucao,nomeCliente,sobrenomeCliente,placaVeiculo 
                FROM ALUGUEL LEFT JOIN VEICULO ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo 
                LEFT JOIN CLIENTE ON CLIENTE.IdCliente = ALUGUEL.IdCliente WHERE IdAluguel = @IdAluguel";

                

                SqlDataReader reader;

                con.Open();
                

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdAluguel", IdAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            IdAluguel = Convert.ToInt32(reader["IdAluguel"]),

                            Aluguel = Convert.ToDateTime(reader["Aluguel"]),

                            Devolucao = Convert.ToDateTime(reader["Devolucao"]),

                            cliente = new ClienteDomain
                            {
                                nomeCliente = reader["nomeCliente"].ToString(),
                                sobrenomeCliente = reader["sobrenomeCliente"].ToString()
                            },

                            veiculo = new VeiculoDomain
                            {
                                placaVeiculo = reader["placaVeiculo"].ToString()
                            }
                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Deletar(int IdAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE IdAluguel = @IdAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", IdAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(AluguelDomain Aluguelnovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ALUGUEL (idVeiculo,idCliente,dataAluguel,dataDevolucao) VALUES (@idVeiculo,@idCliente,@dataAluguel,@dataDevolucao)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", Aluguelnovo.IdVeiculo);
                    cmd.Parameters.AddWithValue("@IdCliente", Aluguelnovo.IdCliente);
                    cmd.Parameters.AddWithValue("@Aluguel", Aluguelnovo.Aluguel);
                    cmd.Parameters.AddWithValue("@Devolucao", Aluguelnovo.Devolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll =
                    @"SELECT IdAluguel, Aluguel.IdVeiculo, Aluguel.idCliente, Aluguel, Devolucao, placaVeiculo, nomeCliente FROM ALUGUEL
                     LEFT JOIN VEICULO ON VEICULO.IdVeiculo = ALUGUEL.IdVeiculo
                     LEFT JOIN CLIENTE ON CLIENTE.IdCliente = ALUGUEL.IdCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            IdAluguel = Convert.ToInt32(rdr[0]),

                            IdVeiculo = Convert.ToInt32(rdr[1]),

                            IdCliente = Convert.ToInt32(rdr[2]),

                            Aluguel = Convert.ToDateTime(rdr[3]),

                            Devolucao = Convert.ToDateTime(rdr[4]),

                            veiculo = new VeiculoDomain()
                            {
                                IdVeiculo = Convert.ToInt32(rdr[1]),
                                placaVeiculo = rdr[5].ToString()
                            },

                            cliente = new ClienteDomain()
                            {
                                IdCliente = Convert.ToInt32(rdr[2]),
                                nomeCliente = rdr[6].ToString()
                            }
                        };

                        listaAlugueis.Add(aluguel);


                    }
                }
            }
            return listaAlugueis;
        }
    }
}
                    

                   