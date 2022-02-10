using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Core.Services
{
    public class UsuarioServ : IUsuarioServ
    {
        private readonly IUsuarioRepos _usuarioRepos;
        private readonly IEmailServ _emailServ;

        private static Random random = new Random();

        public UsuarioServ(IUsuarioRepos usuarioRepos, IEmailServ emailServ) {
            _usuarioRepos = usuarioRepos;
            _emailServ = emailServ;
        }

        public async Task<IList<Usuario>> GetAll()
        {
            return await _usuarioRepos.GetAll();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _usuarioRepos.GetById(id);
        }
        
        public async Task<Usuario> GetByEmail(string email)
        {
            return await _usuarioRepos.GetByEmail(email);
        }
        
        public async Task<Usuario> Login(string email, string senha)
        {
            var user = await _usuarioRepos.GetByEmail(email);
            return user != null && user.Senha.Equals(EncryptarSenha(senha)) ? user : null;
        }

        public async Task<int> Insert(Usuario obj)
        {
            var senhaTemp = RandomString(6);
            obj.Senha = EncryptarSenha(senhaTemp);
            var result = await _usuarioRepos.Insert(obj);
            await SendWelcomeEmail(senhaTemp, obj.Nome, obj.Email);           
            return result;
        } 
        
        public async Task<bool> Update(Usuario obj)
        {
            return await _usuarioRepos.Update(obj);
        }

        public async Task<bool> UpdatePassword(Usuario obj)
        {
            obj.Senha = EncryptarSenha(obj.Senha);
            return await _usuarioRepos.Update(obj);
        }

        public async Task<bool> ResetPassword(Usuario obj)
        {
            var senhaTemp = RandomString(6);
            obj.Senha = EncryptarSenha(senhaTemp);
            var result = await _usuarioRepos.Update(obj);
            await SendResetPasswordEmail(senhaTemp, obj.Nome, obj.Email);           
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _usuarioRepos.Delete(id);
        }

        private async Task SendWelcomeEmail(string senhaTemp, string nome, string email)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Bem vindo, { nome }.");
            sb.AppendLine($"Esta é sua senha de acesso temporária: { senhaTemp }.");
            sb.AppendLine("Altere essa senha após o primeiro acesso.");

            await _emailServ.SendEmailAsync(email, "Bem vindo ao Sistema de Agendandamento de Vacinação.", sb.ToString());
        }

        private async Task SendResetPasswordEmail(string senhaTemp, string nome, string email)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Olá, { nome }.");
            sb.AppendLine($"Sua senha foi alterada para a senha de acesso temporária: { senhaTemp }.");
            sb.AppendLine("Altere essa senha após o primeiro acesso.");

            await _emailServ.SendEmailAsync(email, "Sua senha de acesso ao Sistema de Agendandamento de Vacinação foi alterada.", sb.ToString());
        }
        
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string EncryptarSenha(string senha)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}