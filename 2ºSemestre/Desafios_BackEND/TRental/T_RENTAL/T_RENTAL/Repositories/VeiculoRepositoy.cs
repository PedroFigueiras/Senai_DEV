using System;
using System.Collections.Generic;
using T_RENTAL.Controllers;
using T_RENTAL.Interfaces;
using System.Data.SqlClient;

namespace T_RENTAL.Repositories
{


    public class VeiculoRepository : IVeiculoRepositoy
    {
        private string stringConexao = "Data LAPTOP-FU757ILI\\SQLEXPRESS; initial catalog=T_Rental; user Id=SA; pwd=R260169p";

        public void AtualizarIdUrl(int IdVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE VEICULO SET placaVeiculo = @placaVeiculo WHERE IdVeiculo= @IdVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@placaVeiculo", VeiculoAtualizado.placaVeiculo);
                    cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            };
        }

        public VeiculoDomain BuscarPorId(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = @"
                    SELECT placaVeiculo,IdVeiculo,empresa, modelo 
                    FROM VEICULO 
                    INNER JOIN EMPRESA ON EMPRESA.IdEmpresa = VEICULO.IdEmpresa INNER JOIN MODELO ON  MODELO.IdModelo = VEICULO.IdModelo WHERE IdVeiculo = @IdVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            IdVeiculo = Convert.ToInt32(reader["IdVeiculo"]),

                            placaVeiculo = reader["placaVeiculo"].ToString(),

                            empresa = new EmpresaDomain
                            {
                                empresa = reader["empresa"].ToString()
                            },

                            modelo = new ModeloDomain
                            {
                                modelo = reader["modelo"].ToString()
                            }


                        };

                        return veiculoBuscado;
                    }

                    return null;
                }

            }

        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO (IdEmpresa,IdModelo,placaVeiculo) VALUES (@IdEmpresa,@IdModelo,@placaVeiculo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEmpresa", novoVeiculo.IdEmpresa);
                    cmd.Parameters.AddWithValue("@IdModelo", novoVeiculo.IdModelo);
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.placaVeiculo);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE IdVeiculo = @IdVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"

                              SELECT IdVeiculo,ISNULL(VEICULO.IdEmpresa,0),ISNULL(VEICULO.IdModelo,0),placaVeiculo,empresa,modelo FROM VEICULO 
                              INNER JOIN EMPRESA ON 
                              EMPRESA.IdEmpresa = VEICULO.IdEmpresa
                              INNER JOIN MODELO  ON  MODELO.IdModelo = VEICULO.IdModelo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        VeiculoDomain veiculos = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(rdr[0]),

                            IdEmpresa = Convert.ToInt32(rdr[1]),

                            IdModelo = Convert.ToInt32(rdr[2]),

                            placaVeiculo = rdr[3].ToString(),

                            empresa = new EmpresaDomain()
                            {
                                IdEmpresa = Convert.ToInt32(rdr[1]),
                                empresa = rdr[4].ToString()
                            },

                            modelo = new ModeloDomain()
                            {
                                IdModelo = Convert.ToInt32(rdr[2]),
                                modelo = rdr[5].ToString()
                            }
                        };

                        listaVeiculos.Add(veiculos);
                    }
                }
            }

            return listaVeiculos;
        }

    }
}

