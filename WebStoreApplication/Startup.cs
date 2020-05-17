using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using WebStoreApplication.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace WebStoreApplication
{
    public static class ProductsContext
    {
        public static ProductsAggregate aggregate;
        public static int nextProductID = 1;

        static ProductsContext()
        {
            string jsonString  = File.ReadAllText("Data\\Products.json");
            aggregate = JsonSerializer.Deserialize<ProductsAggregate>(jsonString);
        }
    }

    public interface IProductAccessor
    {
        public void addProduct(ProductModel product);
        public void removeProduct(int productID);
        public ProductModel getProduct(int productID);
        public void updateProduct(ProductModel product); 
        public List<ProductModel> getAllProducts();
    }
    public class ProductAccessor: IProductAccessor
    {
        public void addProduct(ProductModel product)
        {
            product.productID = ProductsContext.nextProductID++;
            ProductsContext.aggregate.products.Add(product);
        }
        public void removeProduct(int productID)
        {
            ProductsContext.aggregate.products.RemoveAll(pr => pr.productID == productID);
        }
        public ProductModel getProduct(int productID)
        {
            return ProductsContext.aggregate.products.Where(pr => pr.productID == productID).SingleOrDefault();
        }

        public List<ProductModel> getAllProducts()
        {
            return ProductsContext.aggregate.products;
        }  

        public void updateProduct(ProductModel product)
        {
            int index = ProductsContext.aggregate.products.FindIndex(pr => pr.productID == product.productID);
            ProductsContext.aggregate.products[index].productName = product.productName;
            ProductsContext.aggregate.products[index].productDescription = product.productDescription;
            ProductsContext.aggregate.products[index].price = product.price;
            ProductsContext.aggregate.products[index].userID = product.userID;        
        } 
    }

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
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Store API", Version = "v1" , Description = "ASP.NET Core API for an online store.", });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            services.AddSingleton<IProductAccessor, ProductAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }

}
