using FluentValidation;
using System;
using System.Collections.Generic;
using static FluentvalidationDemoConsoles.BookCover;
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

        public List<BookCover> BookCovers { get; set; }

        public string Code { get; set; }

        public DateTime PublishTime { get; set; }

        public int CustomerNum { get; set; }

        public class BooksValidator : AbstractValidator<Books>
        {
            public BooksValidator()
            {
                //RuleFor的使用
                RuleFor(x => x.Name).NotNull().WithMessage("书名不能为空")
                    .MinimumLength(1).WithMessage("请输入书名")
                    .MaximumLength(20).WithMessage("书名最多是20");

                RuleFor(x => x.Price).GreaterThan(0).WithMessage("价格必须大于0");
                RuleFor(x => x.Images).Must(x => x != null && x.Count > 0).WithMessage("必须要有图片");
                RuleFor(x => x.Code).Length(4).WithMessage("code长度是4");

                //RuleForEach的使用
                RuleForEach(x => x.Images).NotNull().WithMessage("图片地址不能为空");

                //时间校验
                RuleFor(x => x.PublishTime).NotEqual(new DateTime()).WithMessage("时间错误");

                //子校验
                RuleFor(x => x.BookDetails).SetValidator(new BookDetailsValidator());


                RuleForEach(x => x.BookCovers).Where(x => x.NeedCover is true).SetValidator(new BookCoverValidator());

                //自定义校验
                RuleFor(x => x.CustomerNum).Must(NumValidate).WithMessage("数字不正确");
            }

            /// <summary>
            /// 自定义校验
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            private bool NumValidate(int num)
            {
                var result = num != 1 && num != 4 && num != 49 && num != 0;
                return result;
            }
        }
    }
}
