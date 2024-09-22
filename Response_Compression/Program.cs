using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container. 
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; 
    //options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});
 
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseResponseCompression();
app.UseHttpsRedirection();

app.MapGet("/",()=>{ 

    List<int> list = new List<int>();

	for (int i = 0; i < 10000; i++)
	{
		list.Add(i);
	}
	return list;

});
 
app.Run();

 
