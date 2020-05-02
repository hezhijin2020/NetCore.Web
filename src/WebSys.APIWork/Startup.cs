using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebSys.APIWork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //#region Jwt��֤
            ////��appsettings.json�е�JwtSettings�����ļ���ȡ��JwtSettings�У����Ǹ������ط��õ�
            //services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            // var jwtSettings = new JwtSettings(); //���ڳ�ʼ����ʱ�����Ǿ���Ҫ�ã�����ʹ��Bind�ķ�ʽ��ȡ����
            //Configuration.Bind("JwtSettings", jwtSettings); //�����ð󶨵�JwtSettingsʵ����

            //services.AddAuthentication(options => {
            //    //��֤middleware����
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(o => {
            //    //��Ҫ��jwt  token��������
            //    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        //Token�䷢����
            //        ValidIssuer = jwtSettings.Issuer,
            //        //�䷢��˭
            //        ValidAudience = jwtSettings.Audience,
            //        //�����keyҪ���м��ܣ���Ҫ����Microsoft.IdentityModel.Tokens
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
            //        //ValidateIssuerSigningKey=true,
            //        ////�Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
            //        ValidateLifetime = true,
            //        ////����ķ�����ʱ��ƫ����
            //        ClockSkew = TimeSpan.FromMinutes(5)

            //    };
            //});

            //#endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}