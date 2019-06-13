using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentvalidationDemoConsoles
{
    public class BookCover
    {
        public string url { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public bool NeedCover { get; set; }

        public class BookCoverValidator : AbstractValidator<BookCover>
        {
            public BookCoverValidator()
            {
                RuleFor(x => x.url).NotNull().WithMessage("图片地址不为空");
                RuleFor(x => x.Width).GreaterThan(0).WithMessage("宽度必须大于0");
            }
        }
    }
}
