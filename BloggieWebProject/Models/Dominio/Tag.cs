using System.ComponentModel.DataAnnotations;

namespace BloggieWebProject.Models.Dominio
{
    public class Tag
    {
        public Guid Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? DisplayNombre { get; set; }

        [Required]

        public ICollection<BlogPost> BlogPosts { get; set; }  //Un tag tendrá multiples post
    }
}
