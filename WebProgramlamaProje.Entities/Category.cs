using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Entities
{
	public class Category
	{
        public int Id { get; set; }

        [Required(ErrorMessage ="Kategori adı boş olamaz.")]
        public String Name { get; set; }
    }
}
