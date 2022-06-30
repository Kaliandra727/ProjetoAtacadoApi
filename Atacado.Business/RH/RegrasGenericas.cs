using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Business.RH
{
    public static class RegrasGenericas
    {
        /// <summary>
        /// Validar se o campo NOME está vazio.
        /// </summary>
        /// <param name="nome">Campo que será validado.</param>
        /// <param name="mensagem">Mensagem que será exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido, Do contrário, retorna false.</returns>
        public static bool NomeRegra(string nome, ref string mensagem)
        {
            if (string.IsNullOrEmpty(nome) == true)
            {
                mensagem = ("Nome não pode ser vazio.");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Validar se o campo SOBRENOME está vazio.
        /// </summary>
        /// <param name="sobrenome">Campo que será validado.</param>
        /// <param name="mensagem">Mensagem que será exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido, Do contrário, retorna false.</returns>
        public static bool SobrenomeRegra(string sobrenome, ref string mensagem)
        {
            if (string.IsNullOrEmpty(sobrenome) == true)
            {
                mensagem = ("Sobrenome não pode ser vazio.");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Validar se o campo SEXO está vazio.
        /// </summary>
        /// <param name="sexo">Campo que será validado.</param>
        /// <param name="mensagem">Mensagem que será exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido, Do contrário, retorna false.</returns>
        public static bool SexoRegra(string sexo, ref string mensagem)
        {
            if (string.IsNullOrEmpty(sexo) == true)
            {
                mensagem = ("Sexo não pode ser vazio.");
                return false;
            }
            else if ((sexo.Contains("F") == false) && (sexo.Contains("M") == false))
            {
                mensagem = ("Sexo deve conter (F) ou (M).");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Validar se o campo EMAIL está vazio.
        /// - Regra para campo e-mail vazio.
        /// - Regra de formato de e-mail.
        /// </summary>
        /// <param name="email">Campo que será validado.</param>
        /// <param name="mensagem">Mensagem que será exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido, Do contrário, retorna false.</returns>
        public static bool EmailRegra(string email, ref string mensagem)
        {
            if(EmailVazioRegra(email, ref mensagem) == false)
            {
                return false;
            }
            else if(EmailFormatoRegra(email, ref mensagem) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">Campo que será validado.</param>
        /// <param name="mensagem">Mensagem que será exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido, Do contrário, retorna false.</returns>
        private static bool EmailVazioRegra(string email, ref string mensagem)
        {
            if (string.IsNullOrEmpty(email) == true)
            {
                mensagem = ("Email não pode ser vazio.");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">Campo que será validado.</param>
        /// <param name="mensagem">Mensagem que será exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido, Do contrário, retorna false.</returns>
        private static bool EmailFormatoRegra(string email, ref string mensagem)
        {
            bool ValidEmail = false;
            int indexArr = email.IndexOf("@");

            if (indexArr > 0)
            {
                int indexDot = email.IndexOf(".", indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            ValidEmail = true;
                        }
                    }
                }
               
            }
            if(ValidEmail == false)
            {
                mensagem = ("Formato inválido");
            }
            return ValidEmail;
        }
    }
}
