﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Models;

[Table("User")]
[Index("UserName", Name = "IX_User", IsUnique = true)]
public partial class User 
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FullName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UserName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Mobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    [Unicode(false)]
    public string Address { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Image { get; set; }

    public int RoleId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}