﻿using FluentValidation;
using System.Collections.Generic;
using static FluentvalidationDemoConsoles.BookDetails;

namespace FluentvalidationDemoConsoles
{
    public class Books
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Author { get; set; }

        public List<string> Images { get; set; }

        public BookDetails BookDetails { get; set; }

        public class BooksValidator : AbstractValidator<Books>
        {
            public BooksValidator()
            {
                RuleFor(x => x.Name).NotNull().WithMessage("书名不能为空");
                RuleFor(x => x.Price).GreaterThan(0).WithMessage("价格必须大于0");

                RuleFor(x => x.Images).Must(x => x != null && x.Count > 0).WithMessage("必须要有图片");
                RuleForEach(x => x.Images).NotNull().WithMessage("图片地址不能为空");
                RuleFor(x => x.BookDetails).SetValidator(new BookDetailsValidator());
            }
        }
    }
}