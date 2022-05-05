using System;
using System.Text;
using Api.Models;
using AutoMapper;
using BackEnd.AgendamentoVacina.Core.Services;
using Core.Entities;
using Core.Enumerators;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<Context>(
                x => x.UseSqlServer(_configuration.GetConnectionString("DefaultConn"))
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadVacina", Version = "v1" });
            });

            services.Configure<EmailSettings>(_configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailServ, EmailServ>();

            var secret = _configuration.GetValue<string>("Secret");
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IAgendaRepos, AgendaRepos>();
            services.AddScoped<IEnderecoRepos, EnderecoRepos>();
            services.AddScoped<IGrupoRepos, GrupoRepos>();
            services.AddScoped<ILoteRepos, LoteRepos>();
            services.AddScoped<IAgendamentoRepos, AgendamentoRepos>();
            services.AddScoped<IPerfilRepos, PerfilRepos>();
            services.AddScoped<IPostoRepos, PostoRepos>();
            services.AddScoped<IUsuarioRepos, UsuarioRepos>();

            services.AddScoped<IAgendaServ, AgendaServ>();
            services.AddScoped<IGrupoServ, GrupoServ>();
            services.AddScoped<ILoteServ, LoteServ>();
            services.AddScoped<IAgendamentoServ, AgendamentoServ>();
            services.AddScoped<IPerfilServ, PerfilServ>();
            services.AddScoped<IPostoServ, PostoServ>();
            services.AddScoped<IUsuarioServ, UsuarioServ>();
            services.AddScoped<ITokenServ, TokenServ>();
            services.AddScoped<IEstatisticaServ, EstatisticaServ>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Endereco, EnderecoModel>().ReverseMap();
                config.CreateMap<Grupo, GrupoModel>().ReverseMap();
                config.CreateMap<Perfil, PerfilModel>().ReverseMap();
                config.CreateMap<Estatistica, EstatisticaModel>().ReverseMap();

                config.CreateMap<Agenda, AgendaModel>()
                 .ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.Data.ToString("yyyy-MM-dd")))
                 .ReverseMap();
                
                config.CreateMap<Lote, LoteModel>()
                 .ForMember(dest => dest.DataRecebimento, opts => opts.MapFrom(src => src.DataRecebimento.ToString("yyyy-MM-dd")))
                 .ReverseMap();
                
                config.CreateMap<Posto, PostoModel>()
                 .ForMember(dest => dest.Rua, opts => opts.MapFrom(src => src.Endereco.Rua))
                 .ForMember(dest => dest.Cidade, opts => opts.MapFrom(src => src.Endereco.Cidade))
                 .ForMember(dest => dest.Bairro, opts => opts.MapFrom(src => src.Endereco.Bairro))
                 .ForMember(dest => dest.Numero, opts => opts.MapFrom(src => src.Endereco.Numero))
                 .ForMember(dest => dest.Cep, opts => opts.MapFrom(src => src.Endereco.Cep))
                 .ReverseMap();

                config.CreateMap<Usuario, UsuarioModel>()
                .ForMember(dest => dest.NomePerfil, opts => opts.MapFrom(src => src.Perfil != null ? src.Perfil.Nome : string.Empty))
                .ReverseMap();
                                
                config.CreateMap<Agendamento, AgendamentoModel>()
                .ForPath(dest => dest.DadosPessoais.Nome, opts => opts.MapFrom(src => src.Nome))
                .ForPath(dest => dest.DadosPessoais.Cpf, opts => opts.MapFrom(src => Convert.ToUInt64(src.Cpf).ToString(@"000\.000\.000\-00")))
                .ForPath(dest => dest.DadosPessoais.Mae, opts => opts.MapFrom(src => src.Mae))
                .ForPath(dest => dest.DadosPessoais.Telefone, opts => opts.MapFrom(src => src.Telefone))
                .ForPath(dest => dest.DadosPessoais.DataNascimento, opts => opts.MapFrom(src => src.DataNascimento.ToString("dd/MM/yyyy")))
                .ForPath(dest => dest.Endereco.Rua, opts => opts.MapFrom(src => src.Endereco.Rua))
                .ForPath(dest => dest.Endereco.Cidade, opts => opts.MapFrom(src => src.Endereco.Cidade))
                .ForPath(dest => dest.Endereco.Bairro, opts => opts.MapFrom(src => src.Endereco.Bairro))
                .ForPath(dest => dest.Endereco.Numero, opts => opts.MapFrom(src => src.Endereco.Numero))
                .ForPath(dest => dest.Endereco.Cep, opts => opts.MapFrom(src => src.Endereco.Cep))
                .ForPath(dest => dest.NomePosto, opts => opts.MapFrom(src => $"{src.Posto.Nome},{src.Endereco.Rua},{src.Endereco.Numero},{src.Endereco.Bairro},{src.Endereco.Cidade}"))
                .ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.Data.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Turno, opts => opts.MapFrom(src => src.Turno.Equals(TurnoEnum.T.ToString()) ? "Tarde" : "Manhã"))
                .ReverseMap()
                .ForMember(dest => dest.Turno, opts => opts.MapFrom(src => src.Turno.Equals("Tarde") ? TurnoEnum.T.ToString() : TurnoEnum.M.ToString()))
                .ForPath(dest => dest.DataNascimento, opts => opts.MapFrom(src => Convert.ToDateTime(src.DadosPessoais.DataNascimento)))
                .ForPath(dest => dest.Cpf, opts => opts.MapFrom(src => src.DadosPessoais.Cpf.Replace(".","").Replace("-","")))
                .ForMember(dest => dest.Data, opts => opts.MapFrom(src => Convert.ToDateTime(src.Data)));
                                
            }).CreateMapper());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }
            else {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
