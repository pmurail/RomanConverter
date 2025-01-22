var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/convert/roman-to-int", (string romanNumeral) =>
    {
        try
        {
            RomanConverter.Program.RomanValueIsWrong(romanNumeral.ToUpper());
            int result = RomanConverter.Program.RomanToInt(romanNumeral);
            return Results.Ok(new { Value = result });
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(new { Error = ex.Message });
        }
    })
    .WithName("ConvertRomanToInt")
    .WithOpenApi();

app.Run();