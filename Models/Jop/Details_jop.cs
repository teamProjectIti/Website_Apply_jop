using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Details_jop:baseClass
    {
        public string TitleJop  { get; set; }
        public DateTime DatePublisher  { get; set; }
        public string ContentJop { get; set; }
        public string ImageFile { get; set; }
        [Display(Name = "Required")]
        public string Required_jop { get; set; }

        [ForeignKey("categorys")]
        [Display(Name = "Name Catigory")]
        public int cat_Id { get; set; }
        public virtual category categorys { get; set; }

    }
}
