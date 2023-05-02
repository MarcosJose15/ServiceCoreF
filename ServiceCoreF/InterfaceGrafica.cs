using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCoreF
{
    internal class InterfaceGrafica
    {
        //Enum
        public enum Resultado_e
        {
            Sucesso = 0,
            Sair = 1,
            Excecao = 2
        }

        //Métodos antigos
        public void MostraMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        public Resultado_e PegaString(ref string minhaString, string mensagem)
        {
            Resultado_e retorno;
            Console.WriteLine(mensagem);
            string temp = Console.ReadLine();
            if (temp == "s" || temp == "S")
                retorno = Resultado_e.Sair;
            else
            {
                minhaString = temp;
                retorno = Resultado_e.Sucesso;
            }
            Console.Clear();
            return retorno;
        }
        public Resultado_e PegaData(ref DateTime data, string mensagem)
        {
            Resultado_e retorno;
            do
            {

                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                        retorno = Resultado_e.Sair;
                    else
                    {
                        data = Convert.ToDateTime(temp);
                        retorno = Resultado_e.Sucesso;
                    }
                }
                catch (Exception e)
                {
                    MostraMensagem("EXCECAO: " + e.Message);
                    retorno = Resultado_e.Excecao;
                }

            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        public Resultado_e PegaUInt32(ref UInt32 numeroUInt32, string mensagem)
        {
            Resultado_e retorno;
            do
            {

                try
                {
                    Console.WriteLine(mensagem);
                    string temp = Console.ReadLine();
                    if (temp == "s" || temp == "S")
                        retorno = Resultado_e.Sair;
                    else
                    {
                        numeroUInt32 = Convert.ToUInt32(temp);
                        retorno = Resultado_e.Sucesso;
                    }
                }
                catch (Exception e)
                {

                    MostraMensagem("EXCECAO: " + e.Message);
                    retorno = Resultado_e.Excecao;
                }

            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        //Atributo
        BaseDeDados baseDeDados;

        //Construtor
        public InterfaceGrafica(BaseDeDados pBaseDeDados)
        {
            baseDeDados = pBaseDeDados;
        }

        //Métodos novos
        public void ImprimeDadosNaTela(CadastroChamado pChamado)
        {
            Console.WriteLine("Matricula: " + pChamado.Matricula);
            Console.WriteLine("Titulo: " + pChamado.Titulo);
            Console.WriteLine("Data do ocorrido: " + pChamado.DataRelato);
            Console.WriteLine("Descrição: " + pChamado.Descricao);
            Console.WriteLine("Prioridade: " + pChamado.Prioridade);
            Console.WriteLine("Tipo: " + pChamado.Tipo);
            Console.WriteLine("Status: " + pChamado.Status);
            Console.WriteLine("Tempo Descorrido: " + pChamado.TempoDescorrido);
            Console.WriteLine("");
        }

        public void ImprimeDadosNaTela(List<CadastroChamado> pListaDeChamados)
        {
            foreach (CadastroChamado Chamado in pListaDeChamados)
            {
                ImprimeDadosNaTela(Chamado);
            }
        }

        public Resultado_e CadastraChamado()
        {
            Console.Clear();
            string Matricula = "";
            string Titulo = "";
            DateTime DataRelato = new DateTime();
            string Descricao = "";
            string Prioridade = "";
            public string Tipo = "";
            public string Status = "";
            public string TempoDescorrido = "";
            
            if (PegaString(ref Matricula, "Digite o número da matricula ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref Titulo, "Digite o titulo do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaData(ref DataRelato, "Digite a data do ocorrido no formato DD/MM/AAAA ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref Descricao, "Digite uma descrição para o chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref Prioridade, "Digite a prioridade do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref Tipo, "Digite o tipo de chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref Status, "Digite o status do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            if (PegaString(ref TempoDescorrido, "Digite o tempo decorrido ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;

            CadastroChamado cadastroChamado = new CadastroChamado(Matricula, Titulo, DataRelato, Descricao, Prioridade, Tipo, Status, TempoDecorrido);
            baseDeDados.AdicionarChamado(cadastroChamado);
            Console.Clear();
            Console.WriteLine("Abrindo um chamado: ");
            ImprimeDadosNaTela(cadastroChamado);
            MostraMensagem("");
            return Resultado_e.Sucesso;
        }


        public void BuscaChamado()
        {
            Console.Clear();
            Console.WriteLine("Digite a matricula para buscar o chamado ou digite S para sair");
            string temp = Console.ReadLine();
            if (temp.ToLower() == "s")
                return;

            List<CadastroChamado> listaDeChamadoTemp = baseDeDados.BuscaChamadoPorMatricula(temp);
            Console.Clear();
            if (listaDeChamadoTemp != null)
            {
                Console.WriteLine("Usuário(s) com matricula " + temp + " encontrado(s)");
                ImprimeDadosNaTela(listaDeChamadoTemp);
            }
            else
                Console.WriteLine("Nenhum chamado com a matricula " + temp + " foi encontrado.");
            MostraMensagem("");
        }

        [HttpDelete("{id}")]
        public void ExcluiChamado()
        {
            Console.Clear();
            Console.WriteLine("Digite a matricula para remover o chamado ou digite S para sair");
            string temp = Console.ReadLine();
            if (temp.ToLower() == "s")
                return;

            List<CadastroChamado> listaDeChamadoTemp = baseDeDados.ExcluiChamadoPorMatricula(temp);
            Console.Clear();
            if (listaDeChamadoTemp != null)
            {
                Console.WriteLine("Chamado(s) com matricula " + temp + " removido(s)");
                ImprimeDadosNaTela(listaDeChamadoTemp);
            }
            else
                Console.WriteLine("Nenhum chamado com a matricula " + temp + " foi encontrado.");
            MostraMensagem("");
        }
        public void Sair()
        {
            Console.Clear();
            MostraMensagem("Encerrando o programa");
        }
        public void OpcaoDesconhecida()
        {
            Console.Clear();
            MostraMensagem("Opção desconhecida");
        }
        public void IniciaInterface()
        {
            string temp;
            do
            {
                Console.WriteLine("Digite A para abrir um novo chamado");
                Console.WriteLine("Digite B para buscar chamados abertos");
                Console.WriteLine("Digite E para excluir um chamado");
                Console.WriteLine("Digite S para sair");
                temp = Console.ReadKey(true).KeyChar.ToString().ToLower();
                switch (temp)
                {
                    case "a":
                        //Abrir um chamado
                        CadastraChamado();
                        break;
                    case "b":
                        //Busca um chamado
                        BuscaChamado();
                        break;
                    case "e":
                        //Exclui um chamado
                        ExcluiChamado();
                        break;
                    case "s":
                        //Sair do programa
                        Sair();
                        break;
                    default:
                        //Opção desconhecida
                        OpcaoDesconhecida();
                        break;
                }

            } while (temp != "s");
        }
    }
}
