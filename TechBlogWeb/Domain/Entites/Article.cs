using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogWeb.Domain.Entites
{
    public class Article : EntityBase
    {
        [Required(ErrorMessage ="Введите название статьи")]
        [Display(Name = "Название заголовка статьи")]
        public override string Title { get => base.Title; set => base.Title = value; }

        //[Required(ErrorMessage ="Заполните описание статьи")]
        [Display(Name ="Краткое описание статьи")]
        public override string SubTitle { get => base.SubTitle ; set => base.SubTitle = value; }

        [Display(Name ="Текст статьи")]
        public override string Text { get => base.Text; set => base.Text = value; }

    }
}
