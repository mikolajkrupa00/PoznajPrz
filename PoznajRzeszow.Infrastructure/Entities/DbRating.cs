using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbRating
    {
        public Guid RatingId { get; set; }
        public DateTime RatingDate { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }

        public Guid PlaceId { get; set; }
        public virtual DbPlace Place { get; set; }
        public Guid UserId { get; set; }
        public virtual DbUser User { get; set; }

        public static DbRating Create(Rating rating)
            => new DbRating
            {
                Comment = rating.Comment,
                PlaceId = rating.PlaceId,
                UserId = rating.UserId,
                RatingDate = rating.RatingDate,
                Value = rating.Value,
                RatingId = rating.RatingId
            };
    }
}
