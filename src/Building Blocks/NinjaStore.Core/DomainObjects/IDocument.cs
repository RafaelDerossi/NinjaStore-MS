using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NinjaStore.Core.DomainObjects
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CriadoEm { get; }
    }
}