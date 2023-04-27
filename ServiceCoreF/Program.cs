using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServiceCoreF
{
    public class Program
    {
        static string delimitadorInicio = "";
        static string delimitadorFim = "";
        static string tagMatricula; 
        static string tagTitulo;
        static string tagDataRelato;
        static string tagDescricao;
        static string tagPrioridade;
        static string tagTipo;
        static string tagStatus;
        static string caminhoArquivo;

        //DadosCadastraisStruct
        public struct ChamadoStruct
        {
            public UInt32 Matricula;
            public string Titulo;
            public DateTime DataRelato;
            public string Descricao;
            //public blob img;
            public string Prioridade;
            //public Time HorarioAbertura;
            //public Time HorarioUltimaAtualizacao;
            public string Tipo;
            public string Status;
            //public string TempoDescorrido;
        }
        public enum Resultado_e
        {
            Sucesso = 0,
            Sair = 1,
            Excecao = 2
        }
        public static void MostraMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        public static Resultado_e PegaString(ref string minhaString, string mensagem)
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
        public static Resultado_e PegaData(ref DateTime data, string mensagem)
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
                    Console.WriteLine("EXCECAO: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }

            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        public static Resultado_e PegaUInt32(ref UInt32 numeroUInt32, string mensagem)
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
                    Console.WriteLine("EXCECAO: " + e.Message);
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    retorno = Resultado_e.Excecao;
                }

            } while (retorno == Resultado_e.Excecao);
            Console.Clear();
            return retorno;
        }

        //NOVO CHAMADO (CADASTRA CHAMADO)
        public static Resultado_e abrirChamado(ref List<ChamadoStruct> ListaDeChamados)
        {
            ChamadoStruct abrirChamado;
            abrirChamado.Matricula = 0;
            abrirChamado.Titulo = "";
            abrirChamado.DataRelato = new DateTime();
            abrirChamado.Descricao = "";
            abrirChamado.Prioridade = "";
            //cadastraChamado.HorarioAbertura = new Time();
            //cadastraChamado.HorarioUltimaAtualizacao = new Time();
            abrirChamado.Tipo = "";
            abrirChamado.Status = "";
            

            if (PegaUInt32(ref abrirChamado.Matricula, "Digite o número da matricula ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;

            if (PegaString(ref abrirChamado.Titulo, "Digite o titulo do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;

            if (PegaData(ref abrirChamado.DataRelato, "Digite a data do ocorrido no formato DD/MM/AAAA ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;

            if (PegaString(ref abrirChamado.Prioridade, "Digite a prioridade do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            
            if (PegaString(ref abrirChamado.Tipo , "Digite o tipo do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;

            if (PegaString(ref abrirChamado.Status, "Digite o status do chamado ou digite S para sair") == Resultado_e.Sair)
                return Resultado_e.Sair;
            
            ListaDeChamados.Add(abrirChamado);
            GravaDados(caminhoArquivo, ListaDeChamados);
            return Resultado_e.Sucesso;
        }

        public static void GravaDados(string caminho, List<ChamadoStruct> ListaDeChamados)
        {
            try
            {
                string conteudoArquivo = "";
                foreach (ChamadoStruct chamado in ListaDeChamados)
                {
                    conteudoArquivo += delimitadorInicio + "\r\n";
                    conteudoArquivo += tagMatricula + chamado.Matricula + "\r\n";
                    conteudoArquivo += tagTitulo + chamado.Titulo + "\r\n";
                    conteudoArquivo += tagDataRelato + chamado.DataRelato.ToString("dd/MM/yyyy") + "\r\n";
                    conteudoArquivo += tagDescricao + chamado.Descricao + "\r\n";
                    //conteudoArquivo += tagNumeroDeDocumento + cadastro.NumeroDoDocumento + "\r\n";
                    conteudoArquivo += tagPrioridade + chamado.Prioridade + "\r\n";
                    conteudoArquivo += tagTipo + chamado.Tipo+ "\r\n";
                    conteudoArquivo += tagStatus + chamado.Status + "\r\n";
                    
                    conteudoArquivo += delimitadorFim + "\r\n";
                }
                File.WriteAllText(caminho, conteudoArquivo);

            }
            catch (Exception e)
            {
                Console.WriteLine("EXCECAO: " + e.Message);
            }
        }

        public static void CarregaDados(string caminho, ref List<ChamadoStruct> ListaDeChamados)
        {
            try
            {
                if (File.Exists(caminho))
                {
                    string[] conteudoArquivo = File.ReadAllLines(caminho);
                    ChamadoStruct dadosCadastrais;
                    dadosCadastrais.Matricula = 0;
                    dadosCadastrais.Titulo = "";
                    dadosCadastrais.DataRelato = new DateTime();
                    dadosCadastrais.Descricao = "";
                    dadosCadastrais.Prioridade = "";
                    dadosCadastrais.Tipo = "";
                    dadosCadastrais.Status= "";

                    foreach (string linha in conteudoArquivo)
                    {
                        if (linha.Contains(delimitadorInicio))
                            continue;

                        if (linha.Contains(delimitadorFim))
                            ListaDeChamados.Add(dadosCadastrais);
                        
                        if (linha.Contains(tagMatricula))
                            dadosCadastrais.Matricula = Convert.ToUInt32(linha.Replace(tagMatricula, ""));

                        if (linha.Contains(tagTitulo))
                            dadosCadastrais.Titulo = linha.Replace(tagTitulo, "");

                        if (linha.Contains(tagDataRelato))
                            dadosCadastrais.DataRelato = Convert.ToDateTime(linha.Replace(tagDataRelato, ""));

                        if (linha.Contains(tagDescricao))
                            dadosCadastrais.Descricao = linha.Replace(tagDescricao, "");
                        
                        if (linha.Contains(tagPrioridade))
                            dadosCadastrais.Prioridade = linha.Replace(tagPrioridade, "");
                        
                        if (linha.Contains(tagTipo))
                            dadosCadastrais.Tipo = linha.Replace(tagTipo, "");

                        if (linha.Contains(tagStatus))
                            dadosCadastrais.Status = linha.Replace(tagStatus, "");

                        //if (linha.Contains(tagNumeroDeDocumento))
                            //dadosCadastrais.NumeroDoDocumento = linha.Replace(tagNumeroDeDocumento, "");

                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCECAO: " + e.Message);
            }
        }

        public static void BuscaChamadoPorMatricula(List<ChamadoStruct> ListaDeChamados)
        {
            Console.WriteLine("Digite a matricula ou digite S para sair");
            string temp = Console.ReadLine();
            if (temp.ToLower() == "s")
                return;
            else
            {
                List<ChamadoStruct> ListaDeChamadosTemp = ListaDeChamados.Where(x => x.Matricula == temp).ToList();
                if(ListaDeChamadosTemp.Count>0)
                {
                    foreach(ChamadoStruct usuario in ListaDeChamadosTemp)
                    {
                        Console.WriteLine(tagMatricula + usuario.Matricula);
                        Console.WriteLine(tagTitulo + usuario.Titulo);
                        Console.WriteLine(tagDataRelato + usuario.DataRelato.ToString("dd/MM/yyyy"));
                        Console.WriteLine(tagDescricao + usuario.Descricao);
                        Console.WriteLine(tagPrioridade + usuario.Prioridade);
                        Console.WriteLine(tagTipo + usuario.Tipo);
                        Console.WriteLine(tagStatus + usuario.Status);
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum usuário possui o documento: " + temp);
                }
                //
                MostraMensagem("");
            }
        }

        public static void ExcluiChamadoPorMatricula(ref List<ChamadoStruct> ListaDeUsuarios)
        {
            Console.WriteLine("Digite o número do documento para excluir o usuário ou digite S para sair");
            string temp = Console.ReadLine();
            bool alguemFoiExcluido = false;
            if (temp.ToLower() == "s")
                return;
            else
            {
                List<ChamadoStruct> ListaDeChamadosTemp = ListaDeChamados.Where(x => x.Matricula == temp).ToList();
                if(ListaDeChamadosTemp.Count>0)
                {
                    foreach(ChamadoStruct chamado in ListaDeChamadosTemp)
                    {
                        ListaDeUsuarios.Remove(chamado);
                        alguemFoiExcluido = true;
                    }
                    if (alguemFoiExcluido)
                        GravaDados(caminhoArquivo, ListaDeUsuarios);
                    Console.WriteLine(ListaDeChamadosTemp.Count + " usuário(s) com documento " + temp + " excluído(s)");
                }
                else
                {
                    Console.WriteLine("Nenhum usuário possui o documento: " + temp);
                }
            }
            MostraMensagem("");
        }

        static void Main(string[] args)
        {
            List<ChamadoStruct> ListaDeChamados= new List<ChamadoStruct>();
            string opcao = "";
            delimitadorInicio = "##### INICIO #####";
            delimitadorFim = "##### FIM #####";
            tagMatricula = "MATRICULA: ";
            tagTitulo = "TITULO: ";
            tagDataRelato = "DATA_DO_OCORRIDO: ";
            tagDescricao = "DESCRIÇÃO: ";
            tagPrioridade = "PRIORIDADE: ";
            tagTipo = "TIPO: ";
            tagStatus = "STATUS: ";

            caminhoArquivo = @"baseDeDados.txt";

            CarregaDados(caminhoArquivo, ref ListaDeChamados);

            do
            {
                Console.WriteLine("Pressione C para abrir um novo chamado");
                Console.WriteLine("Pressione B para buscar chamados abertos");
                Console.WriteLine("Pressione E para excluir um chamado");
                Console.WriteLine("Pressione S para sair");
                opcao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if (opcao == "c")
                {
                    //Abrir chamado
                    abrirChamado(ref ListaDeChamados);   
                }
                else if (opcao == "b")
                {
                    //Buscar chamado por matricula
                    BuscaChamadoPorMatricula(ListaDeChamados);
                }
                else if (opcao == "e")
                {
                    //Excluir chamado
                    ExcluiChamadoPorMatricula(ref ListaDeChamados);
                }
                else if (opcao == "s")
                {
                    //Sair da aplicação
                    MostraMensagem("Encerrando o programa");
                }
                else
                {
                    //Opção desconhecida
                    MostraMensagem("Opção desconhecida");
                }
            } while (opcao != "s");
        }
    }

    public class Time
    {
    }
}
