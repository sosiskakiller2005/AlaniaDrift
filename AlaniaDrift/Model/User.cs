//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlaniaDrift.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Booking = new HashSet<Booking>();
            this.Documents = new HashSet<Documents>();
        }
    
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname
        {
            get
            {
                return $"{Name} {Lastname}";
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsVerified { get; set; }
    
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
