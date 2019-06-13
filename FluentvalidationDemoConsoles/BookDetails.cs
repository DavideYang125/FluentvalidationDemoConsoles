using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentvalidationDemoConsoles
{
    public class BookDetails
    {
        public int PageCount { get; set; }

        public string Source { get; set; }

        public class BookDetailsValidator : AbstractValidator<BookDetails>
        {
            public BookDetailsValidator()
            {
                RuleFor(x => x.PageCount).GreaterThan(10).WithMessage("书籍页数必须大于10");
            }
        }
    } 
}
