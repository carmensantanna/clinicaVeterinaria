/*
 *  TI - Gestão de Contas
 *  Integrantes: Carmen Maria Silva Sant'Anna
 *               Henderson Paradela dos Santos 
 *               Mateus Henrique de Aguiar Diniz
 *               
 *  Classe: Data.cs
 *  
 *  Função: Modelo e Auxiliar. Esta classe representa tanto a Data presente em uma Conta quanto atua como auxiliar para as operações
 *          necessárias envolvendo Datas, como exibição, acréscimo de mês, diferencia entre datas, igualdade entre datas e comparação.
 *          Pode ser instanciada sem parâmetros, através de dia, mes e ano ou através de uma data no formato string. Sendo que esta ultima 
 *          opção dá suporte tanto para datas completas ou apenas com mês e ano.
 *     
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_ClinicaVeterinaria
{
    public class Data
    {
        //Atributos
        private int dia;
        private int mes;
        private int ano;
        private int hora;
        private int minuto;
        private int segundo;

        //Constantes
        //private int[] mes31 = { 1, 3, 5, 7, 8, 10, 12 };
        //private int[] mes30 = { 4, 6, 9, 11 };

        //Consturtor default
        public Data()
        {
            this.dia = 1;
            this.mes = 1;
            this.ano = 2000;
        }

        //Consturtor default
        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        //Recebe uma string no formato DD/MM/AAAA e converte para data
        public Data(string dataString, string tipo)
        {
            switch (tipo)
            {
                case "br":
                    toData(dataString);
                    break;
                case "us":
                    toBR(dataString);
                    break;

                case "usTime":
                    toBRTime(dataString);
                    break;
            }
        }

        //Verifica se uma data é válida
        /*public bool verificaData()
        {
            if (this.mes >= 1 && this.mes <= 12)
            {
                if (dia <= diaMaxMes(this.mes))
                    return true;
                else
                    return false;
            }

            return false;
        }

        //Adiciona dias a uma certa data
        public void adicionaDias(int quantDias)
        {
            for (int i = 0; i < quantDias; i++)
            {
                this.dia++;
                if (this.dia > diaMaxMes(this.mes))
                {
                    this.dia = 1;
                    this.mes++;

                    if (this.mes > 12)
                    {
                        this.mes = 1;
                        this.ano++;
                    }
                }
            }
        }

        public int dataNoAno()
        {
            int quantosDias = 0, maxDia = 0;

            //Conta os meses
            for (int i = 1; i <= this.mes; i++)
            {
                //Se for o mês que o usuário digitou, conta somente at? o dia informado.
                if (this.mes == i)
                    maxDia = this.dia;
                else
                    maxDia = diaMaxMes(this.mes);

                for (int j = 1; j <= maxDia; j++)
                    quantosDias++;
            }


            return quantosDias;
        }

        //Calcula e retorna qual o último dia de um determinado mês
        private int diaMaxMes(int mesComp)
        {
            int maxDia = 30;

            if (mesComp == 2)
            {
                if (verificaBissexto())
                    maxDia = 29;
                else
                    maxDia = 28;
            }
            else if (mes31.Contains(mesComp))
                maxDia = 31;
            else if (mes30.Contains(mesComp))
                maxDia = 30;

            return maxDia;
        }

        //Verifica e retorna se o ano é bissexto
        private bool verificaBissexto()
        {
            if (this.ano % 4 == 0)
            {
                if (this.ano % 100 == 0)
                {
                    if (this.ano % 400 == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }

            return false;
        }*/

        //Converte uma string no formato DD/MM/AAA para data
        public void toData(string data)
        {
            string[] aux = data.Split('/');

            if (aux.Length == 3)
            {
                this.dia = int.Parse(aux[0]);
                this.mes = int.Parse(aux[1]);
                this.ano = int.Parse(aux[2]);
            }
            else
            {
                this.dia = this.mes = 1;
                this.ano = 2000;
            }
        }

        //Retorna a data no tipo string e formato DD/MM/AAAA
        public override string ToString()
        {
            return dia.ToString("00") + "/" + mes.ToString("00") + "/" + ano;
        }

        //Retorna a data no tipo string e formato MM/AAAA
        public string mesAno()
        {
            return mes.ToString("00") + "/" + ano;
        }

        //Verifica se duas datas são iguais. Retorna verdadeiro somente se a data for idêntica
        public bool Equals(Data data)
        {
            if (this.ano == data.ano)
            {
                if (this.mes == data.mes)
                {
                    if (this.dia == data.dia)
                        return true;
                }
            }

            return false;
        }

        public bool ehMenor(Data data)
        {
            //Se o ano é menor, a data já é considerada menor
            if (data.Ano < this.ano)
                return true;
            else if (data.Ano == this.ano)
            {
                if (data.Mes < this.mes)
                    return true;
                else if (data.Mes == this.Mes)
                {
                    if (data.Dia <= this.dia)
                        return true;
                }
            }

            return false;
        }

        public void incrementaMes()
        {
            int pxMes = this.mes + 1;

            /*if (diaMaxMes(this.mes) > diaMaxMes(pxMes))
            {
                this.dia = 01;
                pxMes += 1;
            }*/

            if (pxMes > 12)
            {
                this.ano += 1;
                this.mes = 1;
            }
            else
                this.mes = pxMes;

        }

        public void decrementaAno()
        {
            this.ano -= 1;
        }

        public int difMes(Data data2)
        {
            int diferenca = data2.mes - this.mes;

            if (diferenca < 0)
            {
                diferenca = 12 - this.mes;
                diferenca += data2.mes;
            }

            return diferenca;
        }

        //Retorna a data no formato para banco de dados: AAAA-00-00
        public string toUS()
        {
            return this.ano + "-" + this.mes + "-" + this.dia;
        }

        //Recebe uma data no formato de banco de dados e converte para objeto data
        public Data toBR(string data)
        {
            string[] aux = data.Split('-');

            if (aux.Length == 3)
            {
                this.dia = int.Parse(aux[2]);
                this.mes = int.Parse(aux[1]);
                this.ano = int.Parse(aux[0]);
            }
            else
            {
                this.dia = this.mes = 1;
                this.ano = 2000;
            }

            return this;
        }

        //Recebe uma data no formato de banco de dados e converte para objeto data
        public Data toBRTime(string data)
        {
            string[] aux = data.Split(' ');

            toData(aux[0]);

            string[] time = aux[1].Split(':');

            if (time.Length == 3)
            {
                this.segundo = int.Parse(time[2]);
                this.minuto = int.Parse(time[1]);
                this.hora = int.Parse(time[0]);
            }
            else
            {
                this.hora = this.minuto = this.segundo = 1;
            }

            return this;
        }

        //Getters e Setters
        public int Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public int Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; }
        }
        public int Segundo
        {
            get { return segundo; }
            set { segundo = value; }
        }

        public string DataTxt
        {
            get
            {
                return dia.ToString("00") + "/" + mes.ToString("00") + "/" + ano.ToString("00");
            }
        }

        public string HoraMin
        {
            get
            {
                return hora.ToString("00") + ":" + minuto.ToString("00");
            }
        }
    }
}