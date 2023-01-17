namespace ShortLink.EntityFramework.Base
{
    public interface ISoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
}