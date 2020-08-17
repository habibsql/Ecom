using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ecom.Framework
{
    /// <summary>
    /// Base class for all Business Entities.
    /// Concreat entity classes must inherit from this class.
    /// </summary>
    [BsonIgnoreExtraElements]
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique id for each entity object
        /// </summary>
        [BsonId]
        public String Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// When entity is created
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// when entity is last updated
        /// </summary>
        public DateTime LastUpdatedOn { get; set; }

        /// <summary>
        /// User Id who  creates this object
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        ///  user who is updates this object
        /// </summary>
        public Guid LastUpdatedBy { get; set; }
    }
}
