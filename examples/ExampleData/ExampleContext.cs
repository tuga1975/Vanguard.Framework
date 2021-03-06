﻿namespace ExampleData
{
    using System;
    using ExampleData.Entities;
    using Microsoft.EntityFrameworkCore;
    using Vanguard.Framework.Core.DomainEvents;
    using Vanguard.Framework.Data;
    using Vanguard.Framework.Data.Entities;
    using Vanguard.Framework.Data.Managers;

    /// <summary>
    /// The example context.
    /// </summary>
    /// <seealso cref="Vanguard.Framework.Data.DbContextBase" />
    public class ExampleContext : DbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleContext"/> class.
        /// </summary>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        public ExampleContext(IEventDispatcher eventDispatcher)
            : base(eventDispatcher)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleContext"/> class.
        /// </summary>
        /// <param name="eventDispatcher">The event dispatcher.</param>
        /// <param name="options">The options.</param>
        public ExampleContext(IEventDispatcher eventDispatcher, DbContextOptions<ExampleContext> options)
            : base(eventDispatcher, options)
        {
        }

        /// <summary>
        /// Gets or sets the audit entries.
        /// </summary>
        /// <value>
        /// The audit entries.
        /// </value>
        public DbSet<AuditEntry> AuditEntries { get; set; }

        /// <summary>
        /// Gets or sets the cars.
        /// </summary>
        /// <value>
        /// The cars.
        /// </value>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Gets or sets the garages.
        /// </summary>
        /// <value>
        /// The garages.
        /// </value>
        public DbSet<Garage> Garages { get; set; }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            var auditManager = new AuditManager(this);
            auditManager.CreateAuditRecords("Test", DateTime.UtcNow);
            return base.SaveChanges();
        }
    }
}
