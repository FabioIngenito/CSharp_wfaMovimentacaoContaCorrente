using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using MovimentacaoContaCorrente.DOMAIN;
using SecureAppC;

namespace MovimentacaoContaCorrente.DAL
{
    public class ClsMovimentacaoDAL : ICrud<ClsMovimentacaoDomain, int>
    {
        DTICrypto objCrypto = new DTICrypto();

        #region INCLUIR

        /// <summary>
        /// Incluir Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="entidade">Estrutura DOMAIN de Movimentações</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna string com a PK incluída dependendo se o BD suporta fazer isto.</returns>
        public string Incluir(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        {
            string incluir = "";

            if (BDM.Banco == "A")
                incluir = IncluirAccess(entidade);
            else if (BDM.Banco == "S")
                incluir = IncluirSQL(entidade);

            return incluir;
        }

        private string IncluirAccess(ClsMovimentacaoDomain MovimentacaoDomain)
        {
            double DblSoma = 0;

            OleDbConnection cn = new OleDbConnection
            {
                //conexao
                ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste")
            };

            cn.Open();
            OleDbTransaction tran = cn.BeginTransaction();

            try
            {
                OleDbCommand cmd1 = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                    //SQL Access
                    CommandText = "INSERT INTO tblMovimentacoes(DataHora, DebitoCredito, ValorMovimentacao, IDContaCorrente) VALUES (" +
                            "'" + MovimentacaoDomain.DataHora + "', " +
                            "'" + MovimentacaoDomain.DebitoCredito + "', " +
                            "'" + MovimentacaoDomain.ValorMovimentacao + "', " +
                            "'" + MovimentacaoDomain.IDContaCorrente + "') "
                };

                DblSoma = SomaValoresAccess(MovimentacaoDomain.IDContaCorrente);
                DblSoma += MovimentacaoDomain.ValorMovimentacao;

                OleDbCommand cmd2 = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                    //SQL Access
                    CommandText = "UPDATE tblContaCorrente " +
                                  "SET ValorAtual = '" + DblSoma + "' " +
                                  "WHERE IDContaCorrente = " + MovimentacaoDomain.IDContaCorrente

                    //CommandText = "UPDATE tblContaCorrente " +
                    //              "SET ValorAtual = (" +
                    //                "SELECT Sum(tblMovimentacoes.ValorMovimentacao) " +
                    //                "FROM tblMovimentacoes " +
                    //                "WHERE tblMovimentacoes.IDContaCorrente = " + MovimentacaoDomain.IDContaCorrente + ") " +
                    //              "WHERE IDContaCorrente = " + MovimentacaoDomain.IDContaCorrente
                };

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                tran.Commit();

                //Precisaria voltar o número do que foi inserido para posicionar a tela de visualização na mesma posição
                //MovimentacaoDomain.IDMovimentacao = (Int32)cmd.Parameters["@movimentacao"].Value;
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw new Exception("Servidor ACCESS Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            //Bom ... precisamos ver como recuperar esta informação no Access...
            //... com certeza um SELECT, mas ... do quê?
            return "";
        }

        private string IncluirSQL(ClsMovimentacaoDomain MovimentacaoDomain)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                //conexao
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoSQLServer, "teste");

                //command
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.StoredProcedure,
                    //nome da Stored Procedure
                    CommandText = "insere_movimentacao"
                };

                //parâmetros da Stored Procedure
                SqlParameter PIDContaCorrente = new SqlParameter("@IDContaCorrente", SqlDbType.Int)
                {
                    Direction = ParameterDirection.InputOutput
                };
                cmd.Parameters.Add(PIDContaCorrente);

                SqlParameter PDataHora = new SqlParameter("@datahora", SqlDbType.DateTime)
                {
                    Value = MovimentacaoDomain.DataHora
                };
                cmd.Parameters.Add(PDataHora);

                SqlParameter PDebitoCredito = new SqlParameter("@debitocredito", SqlDbType.Char)
                {
                    Value = MovimentacaoDomain.DebitoCredito
                };
                cmd.Parameters.Add(PDebitoCredito);

                SqlParameter PValorMovimentacao = new SqlParameter("@valormovimentacao", SqlDbType.BigInt)
                {
                    Value = MovimentacaoDomain.ValorMovimentacao
                };
                cmd.Parameters.Add(PValorMovimentacao);

                cn.Open();
                cmd.ExecuteNonQuery();

                MovimentacaoDomain.IDContaCorrente = (Int32)cmd.Parameters["@IDContaCorrente"].Value;
                return Convert.ToString(cmd.Parameters["@IDContaCorrente"].Value);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion

        #region ALTERAR

        /// <summary>
        /// Alterar Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="entidade">Estrutura DOMAIN de Movimentações</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        public void Alterar(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        {
            if (BDM.Banco == "A")
                AlterarAccess(entidade);
            else if (BDM.Banco == "S")
                AlterarSQL(entidade);
        }

        private void AlterarAccess(ClsMovimentacaoDomain MovimentacaoDomain)
        {
            //conexao
            OleDbConnection cn = new OleDbConnection();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                //command
                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    //SQL Access
                    CommandText = "UPDATE tblMovimentacoes " +
                                  "SET DataHora = '" + MovimentacaoDomain.DataHora + "'," +
                                     " DebitoCredito = '" + MovimentacaoDomain.DebitoCredito + "', " +
                                     " ValorMovimentacao = '" + MovimentacaoDomain.ValorMovimentacao + "' " +
                                     " IDContaCorrente = '" + MovimentacaoDomain.IDContaCorrente + "' " +
                                  "WHERE IDMovimentacao = " + MovimentacaoDomain.IDMovimentacao
                };

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor ACCESS Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void AlterarSQL(ClsMovimentacaoDomain MovimentacaoDomain)
        {
            //conexao
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoSQLServer, "teste");

                //command
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.StoredProcedure,
                    //Nome da Stored Procedure
                    CommandText = "altera_movimentacoes"
                };

                //parâmetros da Stored Procedure
                SqlParameter PIDContaCorrente = new SqlParameter("@idcontacorrente", SqlDbType.Int)
                {
                    Direction = ParameterDirection.InputOutput
                };
                cmd.Parameters.Add(PIDContaCorrente);

                SqlParameter PDataHora = new SqlParameter("@datahora", SqlDbType.DateTime)
                {
                    Value = MovimentacaoDomain.DataHora
                };
                cmd.Parameters.Add(PDataHora);

                SqlParameter PDebitoCredito = new SqlParameter("@debitocredito", SqlDbType.Char)
                {
                    Value = MovimentacaoDomain.DebitoCredito
                };
                cmd.Parameters.Add(PDebitoCredito);

                SqlParameter PValorMovimentacao = new SqlParameter("@valormovimentacao", SqlDbType.BigInt)
                {
                    Value = MovimentacaoDomain.ValorMovimentacao
                };
                cmd.Parameters.Add(PValorMovimentacao);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        #endregion

        #region EXCLUIR

        /// <summary>
        ///  Excluir Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="chave">Chave da entidade</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        public void Excluir(ClsMovimentacaoDomain entidade, ClsBDDomain BDM)
        {
            if (BDM.Banco == "A")
                ExcluirAccess(entidade.IDMovimentacao);
            else if (BDM.Banco == "S")
                ExcluirSQL(entidade.IDMovimentacao);
        }

        private void ExcluirAccess(int chave)
        {
            //conexao
            OleDbConnection cn = new OleDbConnection();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                //command
                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    //SQL Access
                    CommandText = "DELETE FROM tblMovimentacoes WHERE IDMovimentacao = " + chave
                };

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a movimentação " + chave);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor ACCESS erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void ExcluirSQL(int chave)
        {
            //conexao
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoSQLServer, "teste");

                //command
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.StoredProcedure,
                    //nome da stored procedure
                    CommandText = "exclui_movimentacao"
                };

                //parâmetros da stored procedure
                SqlParameter PIDContaCorrente = new SqlParameter("@idcontacorrente", SqlDbType.Int)
                {
                    Value = chave
                };

                cmd.Parameters.Add(PIDContaCorrente);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a movimentação " + chave);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion

        #region LISTAGEM

        /// <summary>
        /// Listagem Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="filtro">Filtro do Banco de Dados</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns></returns>
        public DataTable Listagem(string filtro, ClsBDDomain BDM)
        {
            DataTable listagem = new DataTable();

            if (BDM.Banco == "A")
                listagem = ListagemAccess(filtro);
            else if (BDM.Banco == "S")
                listagem = ListagemSQL(filtro);

            return listagem;
        }

        private DataTable ListagemAccess(string filtro)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            string strSQL = "";

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                //adapter
                da.SelectCommand = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text
                };

                //SQL Access
                if (filtro == "")
                {
                    strSQL = "SELECT * FROM tblMovimentacoes";
                }
                else
                {
                    strSQL = "SELECT m.IDMovimentacao, m.DataHora, m.DebitoCredito, m.ValorMovimentacao, m.IDContaCorrente " +
                             "FROM tblMovimentacoes m " +
                             "WHERE m.IDMovimentacao like '%" + filtro + "%'";
                }

                da.SelectCommand.CommandText = strSQL;
                da.Fill(dt);

                return dt;
            }
            catch (OleDbException ex)
            {
                throw new Exception("Erro no ACCESS: " + ex.ErrorCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private DataTable ListagemSQL(string filtro)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoSQLServer, "teste");

                //adapter
                da.SelectCommand = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.StoredProcedure,
                    //nome da stored procedure
                    CommandText = "seleciona_movimentacao"
                };

                //parâmetros da stored procedure
                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@filtro", SqlDbType.Text);
                pfiltro.Value = filtro;

                da.Fill(dt);
                return dt;

            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion

        #region CONTA REGISTROS

        /// <summary>
        /// Conta Registros Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna um Inteiro</returns>
        public int ContaRegistros(int chave, ClsBDDomain BDM)
        {
            int conta = 0;

            if (BDM.Banco == "A")
                conta = ContaRegistrosAccess(chave);
            else if (BDM.Banco == "S")
                conta = ContaRegistrosSQL(chave);

            return conta;
        }

        private int ContaRegistrosAccess(int chave)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                //adapter
                da.SelectCommand = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    //SQL Access
                    CommandText = "SELECT COUNT(*) FROM tblMovimentacoes WHERE IDContaCorrente = " + chave
                };

                da.Fill(dt);

                return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            }
            catch (OleDbException ex)
            {
                throw new Exception("Erro ACCESS: " + ex.ErrorCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private int ContaRegistrosSQL(int chave)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoSQLServer, "teste");

                //adapter
                da.SelectCommand = new SqlCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    //SQL Server
                    CommandText = "SELECT COUNT(*) FROM tblMovimentacoes WHERE IDContaCorrente = " + chave
                };

                da.Fill(dt);

                return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion

        #region SOMA VALORES

        public double SomaValores(int chave, ClsBDDomain BDM)
        {
            double conta = 0;

            if (BDM.Banco == "A")
                conta = SomaValoresAccess(chave);
            else if (BDM.Banco == "S")
                conta = SomaValoresSQL(chave);

            return conta;
        }

        private double SomaValoresAccess(int chave)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                if (ContaRegistrosAccess(chave) > 0)
                {
                    //adapter
                    da.SelectCommand = new OleDbCommand
                    {
                        Connection = cn,
                        CommandType = CommandType.Text,
                        //SQL Access
                        CommandText = "SELECT SUM(ValorMovimentacao) FROM tblMovimentacoes WHERE IDContaCorrente  = " + chave
                    };

                    da.Fill(dt);

                    return Convert.ToDouble(dt.Rows[0].ItemArray[0]);

                }
                else
                {
                    return 0;
                }
            }
            catch (OleDbException ex)
            {
                throw new Exception("Erro ACCESS: " + ex.ErrorCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private double SomaValoresSQL(int chave)
        {
            return 0;
        }

        #endregion

        #region Conta Corrente

        /// <summary>
        /// Verifica se existe Movimentação para a Conta Corrente.
        /// </summary>
        /// <param name="chave">ID da Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna se existe ou não</returns>
        public bool ExisteChaveEstrangeira(int chave, ClsBDDomain BDM)
        {
            bool existe = false;

            if (BDM.Banco == "A")
                existe = ExisteChaveEstrangeiraAccess(chave);
            else if (BDM.Banco == "S")
                existe = ExisteChaveEstrangeiraSQL(chave);

            return existe;
        }

        private bool ExisteChaveEstrangeiraAccess(int ContaCorrente)
        {
            bool existe = false;
            string queryString = "SELECT COUNT(*) FROM tblMovimentacoes WHERE IDContaCorrente = " + ContaCorrente;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste")))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();

                    var result = command.ExecuteScalar();

                    if (result.ToString() != "0")
                    {
                        existe = true;
                    }
                }

                return existe;
            }
            catch (OleDbException ex)
            {
                throw new Exception("Erro ACCESS: " + ex.ErrorCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ExisteChaveEstrangeiraSQL(int ContaCorrente)
        {
            return false;
        }


        /// <summary>
        /// Retorna a Chave Primária da Tabela Conta Corrente a partir da Chave da tabela Movimentações
        /// </summary>
        /// <param name="chave">Chave Primária da tabela Movimentações </param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna a Chave Primária da Tabela Conta Corrente</returns>
        public int BuscaNumeroContaCorrente(int chave, ClsBDDomain BDM)
        {
            if (BDM.Banco == "A")
                chave = BuscaNumeroContaCorrenteAccess(chave);
            else if (BDM.Banco == "S")
                chave = BuscaNumeroContaCorrenteSQL(chave);

            return chave;
        }

        private int BuscaNumeroContaCorrenteAccess(int chave)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                //adapter
                da.SelectCommand = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    //SQL Access
                    CommandText = "SELECT IDContaCorrente FROM tblMovimentacoes WHERE IDMovimentacao = " + chave
                };

                da.Fill(dt);

                return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            }
            catch (OleDbException ex)
            {
                throw new Exception("Erro ACCESS: " + ex.ErrorCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private int BuscaNumeroContaCorrenteSQL(int chave)
        {
            return 0;
        }

        #endregion
    }
}
