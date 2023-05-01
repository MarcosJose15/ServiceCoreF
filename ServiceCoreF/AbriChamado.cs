/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCoreF
{
    internal class Chamado
    {
        public string idChamado { get; set; }
        public string Nome { get; set; }
        public DateTime DataRelato { get; set; }
        public string Descricao { get; set; }
        public string Img { get; set; }
        public string Prioridade { get; set; }
        public string HorarioAbertura { get; set; }
        public string HorarioUltimaAtualizacao { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string TempoDescorrido { get; set; }
    }
}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCoreF
{
    internal class AbriChamado
    {
        //Atributos
        public string matricula;
        private string titulo;
        private DateTime dataRelato;
        private string descricao;
        private string prioridade;
        private string tipo;
        private string status;

        //propriedades
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public DateTime DataRelato
        {
            get { return dataRelato; }
            set { dataRelato = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public string Prioridade
        {
            get { return prioridade; }
            set { prioridade = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        //Construtor
        public AbriChamado(string matricula, string titulo, DateTime dataRelato, string descricao, string prioridade, string tipo, string status)
        {
            this.matricula = matricula;
            this.titulo = titulo;
            this.dataRelato = dataRelato;
            this.descricao = descricao;
            this.prioridade = prioridade;
            this.tipo = tipo;
            this.status = status;
        }



    }
}
