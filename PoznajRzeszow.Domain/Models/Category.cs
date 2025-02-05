﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Category
    {
        public Category(Guid categoryId, string name, Guid categoryTypeId)
        {
            PlaceCategoryId = categoryId;
            Name = name;
            CategoryTypeId = categoryTypeId;
        }

        public Guid PlaceCategoryId { get; set; }
        public Guid CategoryTypeId { get; set; }
        public string Name { get; set; }

        public static Category Create(string name, Guid categoryTypeId)
            => new Category(Guid.NewGuid(), name, categoryTypeId);
    }
}
