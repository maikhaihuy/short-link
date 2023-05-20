using System;

namespace ShortLink.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}