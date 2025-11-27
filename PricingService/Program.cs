var builder = WebApplication.CreateBuilder(args);

// 1. AGREGAR SERVICIOS AL CONTENEDOR
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CORRECCIÓN 1: Habilitar CORS (Permisos para que el navegador no bloquee) ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()  // Permitir a cualquiera
              .AllowAnyMethod()  // Permitir GET, POST, etc.
              .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});
// --------------------------------------------------------------------------------

var app = builder.Build();

// 2. CONFIGURAR LA TUBERÍA (PIPELINE)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --- CORRECCIÓN 2: Usar la política de CORS que creamos arriba ---
app.UseCors("PermitirTodo");

// --- CORRECCIÓN 3: Comentar la redirección HTTPS para evitar errores de certificado SSL ---
// app.UseHttpsRedirection(); // <--- Ponle // al inicio para desactivarlo por ahora

app.UseAuthorization();

app.MapControllers();

app.Run();