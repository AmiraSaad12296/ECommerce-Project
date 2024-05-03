﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    public int ProdId { get; set; }

    [Required]
    [StringLength(100)]
    [Unicode(false)]
    public string ProdName { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string ShortDesc { get; set; }

    [Unicode(false)]
    public string LongDesc { get; set; }

    [Unicode(false)]
    public string AdditionalDesc { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Color { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Size { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CompanyName { get; set; }

    public int CatId { get; set; }

    public int SubCatId { get; set; }

    public int? Sold { get; set; }

    public bool IsCustomized { get; set; }

    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey("CatId")]
    [InverseProperty("Products")]
    public virtual Category Cat { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Product")]

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();


    [InverseProperty("Product")]
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    [ForeignKey("SubCatId")]
    [InverseProperty("Products")]
    public virtual SubCategory SubCat { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}