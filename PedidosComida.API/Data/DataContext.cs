using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidosComida.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<PedidosComida.Modelos.Cliente> Clientes { get; set; } = default!;

        public DbSet<PedidosComida.Modelos.PedidoComida>? PedidoComidas { get; set; }
    }
