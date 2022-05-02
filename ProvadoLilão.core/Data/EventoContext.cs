using Microsoft.EntityFrameworkCore;
using ProvadoLilão.core.Models;

namespace ProvadoLilão.core.Data;

public class EventoContext : DbContext
{
    public DbSet<Evento> Eventos { get; set; } = default!;

    public EventoContext(DbContextOptions<EventoContext> options) : base(options) 
    { 
    
    }
} 