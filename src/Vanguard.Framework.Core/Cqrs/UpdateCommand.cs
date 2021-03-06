﻿namespace Vanguard.Framework.Core.Cqrs
{
    /// <summary>
    /// The update command class.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="Vanguard.Framework.Core.Cqrs.ICommand" />
    public class UpdateCommand<TModel> : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommand{TModel}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the model.</param>
        /// <param name="model">The model.</param>
        public UpdateCommand(object id, TModel model)
        {
            Guard.ArgumentNotNull(id, nameof(id));
            Guard.ArgumentNotNull(model, nameof(model));
            Id = id;
            Model = model;
        }

        /// <summary>
        /// Gets the identifier of the model.
        /// </summary>
        /// <value>
        /// The identifier of the model.
        /// </value>
        public object Id { get; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public TModel Model { get; }
    }
}
