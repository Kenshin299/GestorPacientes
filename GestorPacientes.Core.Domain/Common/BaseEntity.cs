namespace GestorPacientes.Core.Domain.Common
{
    public class BaseEntity
    { 
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
