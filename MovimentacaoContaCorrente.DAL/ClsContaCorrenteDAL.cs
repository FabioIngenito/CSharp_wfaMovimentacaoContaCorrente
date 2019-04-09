using MovimentacaoContaCorrente.DOMAIN;
using SecureAppC;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace MovimentacaoContaCorrente.DAL
{
    public class ClsContaCorrenteDAL : ICrud<ClsContaCorrenteDomain, int>
    {
        DTICrypto objCrypto = new DTICrypto();

        #region INCLUIR
        /// <summary>
        /// Incluir Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="CCDomain">Estrutura DOMAIN da Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns>Retorna string com a PK incluída dependendo se o BD suporta fazer isto.</returns>
        public string Incluir(ClsContaCorrenteDomain entidade, ClsBDDomain BDM)
        {
            string incluir = "";

            if (BDM.Banco == "A")
                incluir = IncluirAccess(entidade);
            else if (BDM.Banco == "S")
                incluir = IncluirSQL(entidade);

            return incluir;
        }

        private string IncluirAccess(ClsContaCorrenteDomain ContaCorrenteDomain)
        {
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
                    CommandText = "INSERT INTO tblContaCorrente (IDContaCorrente, ValorAtual) VALUES (" +
                            "'" + ContaCorrenteDomain.IDContaCorrente + "', " +
                            "'" + ContaCorrenteDomain.ValorAtual + "') "
                };

                OleDbCommand cmd2 = new OleDbCommand
                {
                    Connection = cn,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                    //SQL Access
                    CommandText = "INSERT INTO tblMovimentacoes(DataHora, DebitoCredito, ValorMovimentacao, IDContaCorrente) VALUES (" +
                            "'" + DateTime.Now.ToLocalTime() + "', " +
                            "'C', " +
                            "'" + ContaCorrenteDomain.ValorAtual + "', " +
                            "'" + ContaCorrenteDomain.IDContaCorrente + "') "
                };

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                tran.Commit();

                //Precisaria voltar o número do que foi inserido para posicionar a tela de visualização na mesma posição
                //ContaCorrenteDomain.IDContaCorrente = (Int32)cmd.Parameters["@contacorrente"].Value;
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

        private string IncluirSQL(ClsContaCorrenteDomain ContaCorrenteDomain)
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
                    CommandText = "insere_conta_corrente"
                };

                //parâmetros da Stored Procedure
                SqlParameter PIDContaCorrente = new SqlParameter("@idcontacorrente", SqlDbType.Int)
                {
                    Direction = ParameterDirection.InputOutput
                };

                cmd.Parameters.Add(PIDContaCorrente);

                SqlParameter PValorAtual = new SqlParameter("@valoratual", SqlDbType.BigInt)
                {
                    Value = ContaCorrenteDomain.ValorAtual
                };

                cmd.Parameters.Add(PValorAtual);

                cn.Open();
                cmd.ExecuteNonQuery();

                ContaCorrenteDomain.IDContaCorrente = (Int32)cmd.Parameters["@idcontacorrente"].Value;
                return Convert.ToString(cmd.Parameters["@idcontacorrente"].Value);
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
        /// <param name="entidade">Estrutura DOMAIN da Conta Corrente</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        public void Alterar(ClsContaCorrenteDomain entidade, ClsBDDomain BDM)
        {
            if (BDM.Banco == "A")
                AlterarAccess(entidade);
            else if (BDM.Banco == "S")
                AlterarSQL(entidade);
        }

        private void AlterarAccess(ClsContaCorrenteDomain ContaCorrenteDomain)
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
                    CommandText = "UPDATE tblContaCorrente " +
                                  "SET ValorAtual = '" + ContaCorrenteDomain.ValorAtual + "' " +
                                  "WHERE IDContaCorrente = " + ContaCorrenteDomain.IDContaCorrente
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

        private void AlterarSQL(ClsContaCorrenteDomain ContaCorrenteDomain)
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
                    CommandText = "altera_conta_corrente"
                };

                //parametros da stored procedure
                SqlParameter PContaCorrente = new SqlParameter("@idcontacorrente", SqlDbType.Int)
                {
                    Value = ContaCorrenteDomain.IDContaCorrente
                };
                cmd.Parameters.Add(PContaCorrente);

                SqlParameter PValorAtual = new SqlParameter("@valoratual", SqlDbType.BigInt)
                {
                    Value = ContaCorrenteDomain.ValorAtual
                };
                cmd.Parameters.Add(PValorAtual);

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
        /// Excluir Genérico da DAL. Redireciona para o BD Correto.
        /// </summary>
        /// <param name="chave">Chave do Banco de Dados</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        public void Excluir(ClsContaCorrenteDomain entidade, ClsBDDomain BDM)
        {
            if (BDM.Banco == "A")
                ExcluirAccess(entidade.IDContaCorrente);
            else if (BDM.Banco == "S")
                ExcluirSQL(entidade.IDContaCorrente);
        }

        private void ExcluirAccess(int ContaCorrente)
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
                    CommandText = "DELETE FROM tblContaCorrente WHERE IDContaCorrente = " + ContaCorrente
                };

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o contato " + ContaCorrente);
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

        private void ExcluirSQL(int ContaCorrente)
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
                    CommandText = "exclui_conta_corrente"
                };

                //parâmetros da stored procedure
                SqlParameter PContaCorrente = new SqlParameter("@IDContaCorrente", SqlDbType.Int)
                {
                    Value = ContaCorrente
                };

                cmd.Parameters.Add(PContaCorrente);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a conta corrente " + ContaCorrente);
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
        /// <returns>Retorna um DataTable</returns>
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
                    strSQL = "SELECT IDContaCorrente, ValorAtual FROM tblContaCorrente";
                }
                else
                {
                    strSQL = "SELECT c.IDContaCorrente, c.ValorAtual " +
                             "FROM tblContaCorrente c " +
                             "WHERE c.IDContaCorrente like '%" + filtro + "%'";
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
                    CommandText = "seleciona_conta_corrente"
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
        public int ContaRegistros(ClsBDDomain BDM)
        {
            int conta = 0;

            if (BDM.Banco == "A")
                conta = ContaRegistrosAccess();
            else if (BDM.Banco == "S")
                conta = ContaRegistrosSQL();

            return conta;
        }

        private int ContaRegistrosAccess()
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
                    CommandText = "SELECT COUNT(*) FROM tblContaCorrente"
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

        private int ContaRegistrosSQL()
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
                    CommandText = "SELECT COUNT(*) FROM tblContaCorrente"
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

        #region EXISTE CHAVE
        /// <summary>
        /// Verifica se a chave existe.
        /// </summary>
        /// <param name="chave">Chave Primária</param>
        /// <param name="BDM">Sigla do Banco de Dados</param>
        /// <returns></returns>
        public bool ExisteChave(int chave, ClsBDDomain BDM)
        {
            bool existe = false;

            if (BDM.Banco == "A")
                existe = ExisteChaveAccess(chave);
            else if (BDM.Banco == "S")
                existe = ExisteChaveSQL(chave);

            return existe;
        }

        private bool ExisteChaveAccess(int ContaCorrente)
        {
            bool existe = false;
            string queryString = "SELECT COUNT(*) FROM tblContaCorrente WHERE IDContaCorrente = " + ContaCorrente;

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

        private bool ExisteChaveSQL(int ContaCorrente)
        {
            return true;
        }

        #endregion

        #region Atualiza Conta Corrente

        public bool AtualizaValorContaCorrente(ClsBDDomain BDM)
        {
            bool existe = false;

            if (BDM.Banco == "A")
                existe = AtualizaValorContaCorrenteAccess(BDM);
            else if (BDM.Banco == "S")
                existe = AtualizaValorContaCorrenteChaveSQL(BDM);

            return existe;
        }

        private bool AtualizaValorContaCorrenteAccess(ClsBDDomain BDM)
        {
            OleDbConnection cn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            bool atualiza = false;
            int registros = 0;
            string queryString = "";

            registros = ContaRegistrosAccess();

            try
            {
                if (registros > 0)
                {
                    atualiza = true;

                    cn.ConnectionString = objCrypto.Decifrar(ClsDadosDAL.StringDeConexaoAccess, "teste");

                    //adapter
                    da.SelectCommand = new OleDbCommand
                    {
                        Connection = cn,
                        CommandType = CommandType.Text
                    };

                    queryString = "SELECT IDContaCorrente, ValorAtual FROM tblContaCorrente";

                    da.SelectCommand.CommandText = queryString;
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ClsMovimentacaoDAL Movimentacao = new ClsMovimentacaoDAL();
                        ClsContaCorrenteDomain entidade = new ClsContaCorrenteDomain
                        {
                            IDContaCorrente = Convert.ToInt32(dt.Rows[i]["IDContaCorrente"])
                        };

                        entidade.ValorAtual = Movimentacao.SomaValores(entidade.IDContaCorrente, BDM);

                        AlterarAccess(entidade);
                    }
                }

                return atualiza;
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

        private bool AtualizaValorContaCorrenteChaveSQL(ClsBDDomain BDM)
        {
            bool existe = false;

            return existe;
        }
        #endregion
    }
}
