using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ObjetoOT;
using Utilitarios;
using System.Data;
using Comum;

namespace Controle.Auxiliares
{

    public static class PreencherControle
    {
        /// <summary>
        /// Prenche um controle ComboBox.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto.</typeparam>
        /// <param name="pCombo">Combo a ser preenchido.</param>
        /// <param name="pDataSource">Lista para preenchimento.</param>
        /// <param name="pDisplayMember">Texto visivel.</param>
        /// <param name="pValueMember">Código do texto visivel.</param>
        /// <param name="pItemTodos">Indica se serár exibido todos ou selecione como primeiro index.</param>
        public static void PreencherComboBox<T>(ComboBox pCombo, List<T> pDataSource, string pDisplayMember, string pValueMember, bool pItemTodos) where T : BaseOT
        {
            if (pDataSource != null)
            {
                if (pDataSource.Count > 0)
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(pDataSource[0].GetType());

                    BaseOT novoItem = (BaseOT)assembly.CreateInstance(string.Format("{0}.{1}", pDataSource[0].GetType().Namespace, pDataSource[0].GetType().Name));

                    novoItem.Codigo = 0;

                    if (pItemTodos)
                    {
                        novoItem.Nome = " -- TODOS -- ";
                    }
                    else
                    {
                        novoItem.Nome = " -- SELECIONE -- ";
                    }

                    pDataSource.Insert(0, (T)novoItem);
                }

                pCombo.DataSource = pDataSource;
                pCombo.DisplayMember = pDisplayMember;
                pCombo.ValueMember = pValueMember;
            }
        }

        /// <summary>
        /// Prenche um controle ComboBox com os estados 
        /// </summary>
        /// <param name="pComboBox">ComboBox a ser preenchido</param>
        /// <param name="pItemTodos">Indica se serár exibido todos ou selecione como primeiro index.</param>
        public static void PreencherComboBoxEstado(ComboBox pCombo, bool pItemTodos)
        {
            EstadoCTRL EstadoCTRL = new EstadoCTRL();
            List<EstadoOT> estadoList = (List<EstadoOT>)EstadoCTRL.ConsultarTodos().ListaObjetos;

            if (estadoList != null)
            {
                if (estadoList.Count > 0)
                {
                    EstadoOT novoItem = new EstadoOT();

                    novoItem.Codigo = 0;

                    if (pItemTodos)
                    {
                        novoItem.Sigla = " -- TODOS -- ";
                    }
                    else if (!estadoList.Contains(novoItem))
                    {
                        novoItem.Sigla = " -- SELECIONE -- ";
                    }

                    if (!estadoList.Contains(novoItem))
                    {
                        estadoList.Insert(0, novoItem);
                    }
                }

                pCombo.DataSource = estadoList;
                pCombo.DisplayMember = "Sigla";
                pCombo.ValueMember = "Codigo";
            }
        }

        /// <summary>
        /// Prenche um controle ComboBox com os status
        /// </summary>
        /// <param name="pComboBox">ComboBox a ser preenchido</param>
        /// <param name="pItemTodos">Indica se serár exibido todos ou selecione como primeiro index.</param>
        public static void PreencherDropDownStatus(ComboBox pComboBox, bool pItemTodos)
        {
            DataTable dtStatus = new DataTable();
            DataColumn colDescricao = new DataColumn("Descricao");
            DataColumn colValor = new DataColumn("Valor");

            dtStatus.Columns.Add(colDescricao);
            dtStatus.Columns.Add(colValor);

            foreach (Enumeradores.Status status in Enum.GetValues(typeof(Enumeradores.Status)))
            {
                DataRow drLinha = dtStatus.NewRow();

                if (pItemTodos)
                {
                    if (status == Enumeradores.Status.Todos)
                    {
                        drLinha[0] = " -- TODOS -- ";
                        drLinha[1] = 0;
                    }
                    else
                    {
                        drLinha[0] = Enum.GetName(status.GetType(), status);
                        drLinha[1] = Enum.GetName(status.GetType(), status);
                    }

                }
                else
                {
                    if (status == Enumeradores.Status.Todos)
                    {
                        drLinha[0] = " -- SELECIONE -- ";
                        drLinha[1] = 0;
                    }
                    else
                    {
                        drLinha[0] = Enum.GetName(status.GetType(), status);
                        drLinha[1] = Enum.GetName(status.GetType(), status);
                    }
                }


                dtStatus.Rows.Add(drLinha);
            }

            pComboBox.DataSource = dtStatus;

            pComboBox.DisplayMember = dtStatus.Columns[0].ColumnName;
            pComboBox.ValueMember = dtStatus.Columns[1].ColumnName;

        }

        /// <summary>
        /// Prenche um controle ComboBox com os estados civis
        /// </summary>
        /// <param name="pComboBox">ComboBox a ser preenchido</param>
        /// <param name="pItemTodos">Indica se serár exibido todos ou selecione como primeiro index.</param>
        public static void PreencherDropDownEstadoCivil(ComboBox pComboBox, bool pItemTodos)
        {
            DataTable dtEstadoCivil = new DataTable();
            DataColumn colDescricao = new DataColumn("Descricao");
            DataColumn colValor = new DataColumn("Valor");

            dtEstadoCivil.Columns.Add(colDescricao);
            dtEstadoCivil.Columns.Add(colValor);

            foreach (Enumeradores.EstadoCivil estado in Enum.GetValues(typeof(Enumeradores.EstadoCivil)))
            {
                DataRow drLinha = dtEstadoCivil.NewRow();

                if (pItemTodos)
                {
                    if (estado == Enumeradores.EstadoCivil.Todos)
                    {
                        drLinha[0] = " --- TODOS --- ";
                        drLinha[1] = 0;
                    }
                    else
                    {
                        drLinha[0] = Enum.GetName(estado.GetType(), estado);
                        drLinha[1] = Enum.GetName(estado.GetType(), estado);
                    }

                }
                else
                {
                    if (estado == Enumeradores.EstadoCivil.Todos)
                    {
                        drLinha[0] = " --- SELECIONE --- ";
                        drLinha[1] = 0;
                    }
                    else
                    {
                        drLinha[0] = Enum.GetName(estado.GetType(), estado);
                        drLinha[1] = Enum.GetName(estado.GetType(), estado);
                    }
                }

                dtEstadoCivil.Rows.Add(drLinha);
            }

            pComboBox.DataSource = dtEstadoCivil;

            pComboBox.DisplayMember = dtEstadoCivil.Columns[0].ColumnName;
            pComboBox.ValueMember = dtEstadoCivil.Columns[1].ColumnName;

        }


        /// <summary>
        /// Prenche um controle ComboBox com os tipos de pagamentos
        /// </summary>
        /// <param name="pComboBox">ComboBox a ser preenchido</param>
        /// <param name="pItemTodos">Indica se serár exibido todos ou selecione como primeiro index.</param>
        public static void PreencherDropDownFormasPagamentos(ComboBox pComboBox, bool pItemTodos)
        {
            TipoPagamentoCTRL tipoPagamentoCTRL = new TipoPagamentoCTRL();
            List<TipoPagamentoOT> tipoPagamentoList = (List<TipoPagamentoOT>)tipoPagamentoCTRL.ConsultarTodos().ListaObjetos;

            if (tipoPagamentoList != null)
            {
                TipoPagamentoOT novoItem = new TipoPagamentoOT();

                if (pItemTodos)
                {
                    novoItem.Nome = " -- TODOS -- ";
                    novoItem.Codigo = -1;
                }
                else
                {
                    novoItem.Nome = " -- SELECIONE -- ";
                    novoItem.Codigo = -2;
                }

                tipoPagamentoList.Insert(0, novoItem);

                pComboBox.DataSource = tipoPagamentoList;
                pComboBox.DisplayMember = "Nome";
                pComboBox.ValueMember = "CodigoFP";
            }
        }


        /// <summary>
        /// Prenche um controle Listbox
        /// </summary>
        /// <param name="pListBox"></param>
        /// <param name="pDataSource"></param>
        /// <param name="pDisplayMember"></param>
        /// <param name="pValueMember"></param>
        public static void PreencherListBox<T>(ListBox pListBox, List<T> pDataSource, string pDisplayMember, string pValueMember) where T : BaseOT
        {
            pListBox.DataSource = pDataSource;
            pListBox.DisplayMember = pDisplayMember;
            pListBox.ValueMember = pValueMember;

        }

    }
}
